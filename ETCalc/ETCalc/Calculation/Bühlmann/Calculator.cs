using ETCalc.Calculation.DTO;

namespace ETCalc.Calculation.Bühlmann {
    public class Calculator : ICalculator{
        #region Properties / Felder
        /// <summary>Liste der Inertgase mit der jeweiligen Gewebesättigung und Gas-Informationen.</summary>
        public GasData[] GasComposition { get; init; }

        private readonly DiveData Parent;
        #endregion

        #region Konstruktor
        /// <summary>Initialisiert Pressluft als Atemgas, damit eine initiale Sättigung berechnet werden kann.</summary>
        /// <param name="pSurfacePressure">Der aktuelle Oberflächendruck in bar.</param>
        /// <param name="pExposureTime">Expositionszeit in Minuten</param>
        public Calculator(DiveData pParent, GasData[] pGasComposition) {
            Parent = pParent;
            GasComposition = pGasComposition;

            foreach (GasData gas in Enumerate()) {
                double pressure = AlveolarInertGasPressure(gas, Parent.SurfacePressure);

                gas.SetPartialGasPressure(Parent.SurfacePressure);

                for (int i = 0; i < gas.Saturations.Length; i++) {
                    gas.Saturations[i] = pressure;
                }
            }
        }
        #endregion

        #region Methoden
        public void SwitchGas(int pId, double pFraction) {
            GasComposition[pId].GasFraction = pFraction;
        }

        #region Berechnung
        /// <summary>Berechnet die neue Iteration.</summary>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <param name="pExposureTime">Die Expositionszeit in Minuten.</param>
        /// <returns></returns>
        public DiveProfileResult Calculate(double pAmbientPressure, double pExposureTime) {
            // Partialdrücke aller Gase setzen.
            foreach (GasData gas in GasComposition) {
                gas.SetPartialGasPressure(pAmbientPressure);
            }

            // Gewebesättigung aktualisieren.
            foreach (GasData gas in Enumerate()) {
                for (int i = 0; i < gas.Gas.Compartments.Length; i++) {
                    gas.Saturations[i] = CalculateTissuePressure(gas.GetCompartment(i), gas.Saturations[i], pAmbientPressure, pExposureTime);
                }
            }

            DiveProfileResult result = new() {
                NDL = CalculateNDL(pAmbientPressure),
                DecoStops = CalculateDecoStops(pAmbientPressure)
            };

            result.TTS = result.DecoStops.Sum(x => x.Time) + (pAmbientPressure - Parent.SurfacePressure) / Settings.MaximumAscent;

            return result;
        }

        /// <summary>Berechnet die NDL (Non-Decompression Limit), auch Null-Zeit genannt, basierend auf dem aktuellen Umgebungsdruck.
        /// Das NDL repräsentiert die maximale verbleibende Tauchzeit ohne erforderliche Dekompression.</summary>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns>Das NDL, auch Null-Zeit genannt.</returns>
        private double CalculateNDL(double pAmbientPressure) {
            double minNDL = double.MaxValue;

            foreach (GasData gas in Enumerate()) {
                for (int i = 0; i < gas.Saturations.Length; i++) {
                    double halftime = gas.GetCompartment(i).HalfTime;
                    double maxTissuePressure = MaxTissuePressure(gas.GetCompartment(i), pAmbientPressure);
                    double tempNDL;

                    if (gas.PartialGasPressure > gas.Saturations[i]) {
                        tempNDL = -halftime / Constants.LN2 * Math.Log(1 - (maxTissuePressure - gas.Saturations[i]) / (gas.PartialGasPressure - gas.Saturations[i]));
                    } else {
                        tempNDL = 0;
                    }

                    if (tempNDL < minNDL) {
                        minNDL = tempNDL;
                    }
                }
            }

            return minNDL;
        }

        /// <summary>Berechnet alle Dekostops.</summary>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns></returns>
        private List<DecoStopDTO> CalculateDecoStops(double pAmbientPressure) {
            List<DecoStopDTO> result = [];
            double currentPressure = pAmbientPressure;
            GasData[] gasData = Enumerate();
            double[][] tissuePressures = new double[gasData.Length][];

            for (int i = 0; i < gasData.Length; i++) {
                tissuePressures[i] = (double[])gasData[i].Saturations.Clone();
            }

            while (currentPressure > Parent.SurfacePressure) {
                double nextStopPressure = GetNextStopPressure(currentPressure);
                bool stopRequired = false;
                double maxDecoTime = 0.0;
                double ascentTime = (currentPressure - nextStopPressure) / Settings.MaximumAscent;

                for (int i = 0; i < gasData.Length; i++) {
                    for (int j = 0; j < tissuePressures.Length; j++) {
                        CompartmentData compartment = gasData[i].GetCompartment(j);
                        double maxTissuePressure = MaxTissuePressure(compartment, nextStopPressure);

                        tissuePressures[i][j] = CalculateTissuePressure(compartment, tissuePressures[i][j], pAmbientPressure, ascentTime);

                        if (tissuePressures[i][j] > maxTissuePressure) {
                            double requiredTime = -compartment.HalfTime / Constants.LN2 * Math.Log(1 - (tissuePressures[i][j] - maxTissuePressure) / (currentPressure - maxTissuePressure));

                            stopRequired = true;
                            if (requiredTime > maxDecoTime) {
                                maxDecoTime = requiredTime;
                            }
                        }
                    }
                }

                if (stopRequired && !result.Any(x => x.AmbientPressure == nextStopPressure)) {
                    result.Add(new() { AmbientPressure = nextStopPressure, Time = maxDecoTime });
                }

                currentPressure = nextStopPressure;
            }

            return result;
        }

        /// <summary>P(0) + (P(Ambient) - P(0)) * (1 - e^(-t * k))</summary>
        /// <param name="pCompartment"></param>
        /// <param name="pAmbientPressure"></param>
        /// <param name="pExposureTime"></param>
        /// <returns></returns>
        private double CalculateTissuePressure(CompartmentData pCompartment, double pInitialPressure, double pAmbientPressure, double pExposureTime) {
            double timefactor = 1 - Math.Exp(-pExposureTime * pCompartment.K);

            return pInitialPressure + (pAmbientPressure - pInitialPressure) * timefactor;
        }

        /// <summary>Maximal zulässiger Gewebedruck.</summary>
        /// <param name="pCompartment"></param>
        /// <param name="pAmbientPressure"></param>
        /// <returns></returns>
        private double MaxTissuePressure(CompartmentData pCompartment, double pAmbientPressure) {
            return pCompartment.A + pCompartment.B * pAmbientPressure;
        }

        private double GetNextStopPressure(double pAmbientPressure) {
            if (pAmbientPressure > Parent.SurfacePressure) {
                double remainder = pAmbientPressure % Settings.DecompressionStopInterval;

                if (remainder == 0.0) {
                    return pAmbientPressure - Settings.DecompressionStopInterval;
                } else {
                    return pAmbientPressure - remainder;
                }
            } else {
                return Parent.SurfacePressure;
            }
        }

        private double AlveolarInertGasPressure(GasData pGas, double pAmbientPressure) {
            return (pAmbientPressure - 0.0627) * pGas.GasFraction;
        }
        #endregion

        /// <summary>Aufzählung der verwendeten Inert-Gase.</summary>
        /// <returns></returns>
        private GasData[] Enumerate() {
            return GasComposition.Where(x => x.IsActive).ToArray();
        }
        #endregion
    }
}