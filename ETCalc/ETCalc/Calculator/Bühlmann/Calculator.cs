namespace ETCalc.Calculator.Bühlmann {
    internal class Calculator : ICalculator{
        #region Properties / Felder
        /// <summary>Liste der Inertgase mit der jeweiligen Gewebesättigung und Gas-Informationen.</summary>
        public GasData[] GasComposition { get; init; }

        private readonly double Log2 = Math.Log(2);

        private readonly DiveData Parent;
        #endregion

        #region Konstruktor
        /// <summary>Initialisiert Pressluft als Atemgas, damit eine initiale Sättigung berechnet werden kann.</summary>
        /// <param name="pSurfacePressure">Der aktuelle Oberflächendruck in bar.</param>
        /// <param name="pExposureTime">Expositionszeit in Minuten</param>
        public Calculator(DiveData pParent, GasData[] pGasComposition) {
            Parent = pParent;
            GasComposition = pGasComposition;
            SwitchGas(0);

            foreach (GasData gas in Enumerate()) {
                gas.SetPartialGasPressure(Parent.SurfacePressure);

                for (int i = 0; i < gas.Saturations.Length; i++) {
                    gas.Saturations[i] = gas.PartialGasPressure;
                }
            }
        }
        #endregion

        #region Methoden
        /// <summary>Führt einen Gaswechsel aus.</summary>
        /// <param name="pIndex">Der Index des Gases in der Liste. <paramref name="pIndex"/>grösser/gleich 1</param>
        public void SwitchGas(int pIndex) {
            foreach (GasEnum gas in GasEnum.Enumerate(true)) {
                GasComposition[gas.Id].GasFraction = Parent.Mixtures[pIndex].Gases.First(x => x.Gas.EqualsAny(gas)).Fraction;
            }
        }

        /// <summary>Berechnet die neue Iteration.</summary>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <param name="pExposureTime">Die Expositionszeit in Minuten.</param>
        /// <returns></returns>
        public DTO.DiveProfileResult Calculate(double pAmbientPressure, double pExposureTime) {
            DTO.DiveProfileResult result = new();

            foreach (GasData gas in Enumerate()) {
                gas.SetPartialGasPressure(pAmbientPressure);

                for (int i = 0; i < gas.InertGas.Compartments.Length; i++) {
                    UpdateSaturation(gas, i, pAmbientPressure, pExposureTime);
                    result.TTS = Math.Max(result.TTS, CalculateTTS(gas, i, pAmbientPressure));

                    double tmpNDL = CalculateNDL(gas, i, pAmbientPressure);
                    if (tmpNDL > 0 && tmpNDL < result.NDL) {
                        result.NDL = tmpNDL;
                    }

                    double tmpMaxAmbientPressure = CalculateMinimumAmbientPressure(gas, i);
                    if (tmpMaxAmbientPressure > result.NextDecoStop.AmbientPressure) {
                        result.NextDecoStop.AmbientPressure = tmpMaxAmbientPressure;
                    }

                    result.NextDecoStop.Time = Math.Max(result.NextDecoStop.Time, CalculateTimeAtMinimumAmbientPressure(gas, i, pAmbientPressure));
                }
            }

            return result;
        }

        public Calculator Clone() {
            return (Calculator)MemberwiseClone();
        }

        /// <summary>Aktualisiert die Gewebedrücke basierend auf dem aktuellen Umgebungsdruck und der Expositionszeit.
        /// Die Methode berechnet die Veränderung der Gewebesättigung für jedes Gewebekompartment über die Zeit und aktualisiert die Gewebedrücke entsprechend.</summary>
        /// <param name="pGas">Instanz des verwendeten Gases.</param>
        /// <param name="pIndex">Array-Index für Saturations und Compartments.</param>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <param name="pExposureTime">Die Expositionszeit in Minuten.</param>
        private void UpdateSaturation(GasData pGas, int pIndex, double pAmbientPressure, double pExposureTime) {
            double pressureDelta = pAmbientPressure - pGas.Saturations[pIndex];
            //double saturationChange = pGas.GetCompartiment(pIndex).A * pressureDelta - pGas.GetCompartiment(pIndex).B * Math.Pow(pressureDelta, 2);
            double timeFactor = 1 - Math.Exp(-pExposureTime / TAU(pGas.GetCompartiment(pIndex)));

            //pGas.Saturations[pIndex] = saturationChange * timeFactor + pGas.Saturations[pIndex];
            pGas.Saturations[pIndex] = pGas.Saturations[pIndex] + pressureDelta * timeFactor;
        }

        /// <summary>Berechnet die Time To Surface (TTS) basierend auf dem aktuellen Umgebungsdruck.
        /// Die Time To Surface (TTS) repräsentiert die geschätzte verbleibende Zeit bis zum Erreichen der Oberfläche unter Berücksichtigung aller Gewebekompartimente.</summary>
        /// <param name="pGas">Instanz des verwendeten Gases.</param>
        /// <param name="pIndex">Array-Index für Saturations und Compartments.</param>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns>Die Time To Surface (TTS).</returns>
        private double CalculateTTS(GasData pGas, int pIndex, double pAmbientPressure) {
            double allowablePressure = pGas.GetCompartiment(pIndex).A * pAmbientPressure + pGas.GetCompartiment(pIndex).B;
            double pressureGas = pGas.Saturations[pIndex] - allowablePressure;

            return pressureGas > 0 ? -TAU(pGas.GetCompartiment(pIndex)) * Math.Log((allowablePressure - pressureGas) / allowablePressure) : 0;

            /*
            double pressureGas = pGas.Saturations[pIndex] - pGas.PartialGasPressure;
            double pressureDelta = pAmbientPressure - pGas.Saturations[pIndex];

            if (pressureGas > 0) {
                return (pGas.GetCompartiment(pIndex).A * ((1 - Math.Exp(-pressureGas / pGas.GetCompartiment(pIndex).A)) - pGas.GetCompartiment(pIndex).B) * TAU(pGas.GetCompartiment(pIndex))) + pressureDelta;
            } else {
                return 0;
            }
            */
        }

        /// <summary>Berechnet die NDL (Non-Decompression Limit), auch Null-Zeit genannt, basierend auf dem aktuellen Umgebungsdruck.
        /// Das NDL repräsentiert die maximale verbleibende Tauchzeit ohne erforderliche Dekompression.</summary>
        /// <param name="pGas">Instanz des verwendeten Gases.</param>
        /// <param name="pIndex">Array-Index für Saturations und Compartments.</param>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns>Das NDL, auch Null-Zeit genannt.</returns>
        private double CalculateNDL(GasData pGas, int pIndex, double pAmbientPressure) {
            double pressureGas = (pAmbientPressure - Parent.SurfacePressure) * pGas.GasFraction;
            double maxInertGasPressure = pGas.GetCompartiment(pIndex).A + (pAmbientPressure - pGas.GetCompartiment(pIndex).A) * pGas.GetCompartiment(pIndex).B;

            return -Math.Log((maxInertGasPressure - pressureGas) / (pGas.Saturations[pIndex] - pressureGas)) / TAU(pGas.GetCompartiment(pIndex));
        }

        /// <summary>Berechnet die maximale Tauchtiefe ohne Dekompression basierend auf den aktuellen Gewebesättigungen und Gewebekoeffizienten.
        /// Die maximale Tauchtiefe ohne Dekompression repräsentiert die maximale Tiefe, die erreicht werden kann, ohne die Grenzwerte für die Gewebesättigung zu überschreiten.</summary>
        /// <returns>Die maximal zu erreichende auftauchtiefe ohne Dekompression.</returns>
        private double CalculateMinimumAmbientPressure(GasData pGas, int pIndex) {
            return (pGas.Saturations[pIndex] - pGas.GetCompartiment(pIndex).A) / pGas.GetCompartiment(pIndex).B;
        }

        /// <summary>Berechnet die maximale Zeit, die benötigt wird, um ein sicheres Druckniveau 
        /// für alle Gewebekompartimente bei einem gegebenen Umgebungsdruck zu erreichen.</summary>
        /// <param name="pGas">Instanz des verwendeten Gases.</param>
        /// <param name="pIndex">Array-Index für Saturations und Compartments.</param>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns>Die Zeit in Minuten, die benötigt wird, um ein sicheres Druckniveau für alle Gewebekompartimente zu erreichen.</returns>
        private double CalculateTimeAtMinimumAmbientPressure(GasData pGas, int pIndex, double pAmbientPressure) {
            double allowablePressure = pGas.GetCompartiment(pIndex).A * pAmbientPressure + pGas.GetCompartiment(pIndex).B;

            return TAU(pGas.GetCompartiment(pIndex)) * Math.Log((allowablePressure - pGas.GetCompartiment(pIndex).A) / (pGas.Saturations[pIndex] - pGas.GetCompartiment(pIndex).A));
        }

        /// <summary>Aufzählung der verwendeten Inert-Gase.</summary>
        /// <returns></returns>
        private IEnumerable<GasData> Enumerate() {
            return GasComposition.Where(x => x.IsActive);
        }

        /// <summary>Berechnet den tau für das jeweilige Compartiment.</summary>
        /// <param name="pCompartment"></param>
        /// <returns></returns>
        private double TAU(CompartmentData pCompartment) {
            return pCompartment.HalfTime / Log2;
        }
        #endregion
    }
}
