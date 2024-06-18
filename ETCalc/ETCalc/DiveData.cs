using ETCalc.Calculation;
using ETCalc.Calculation.Bühlmann;
using ETCalc.Calculation.DTO;
using ETCalc.Enumeration;

namespace ETCalc {
    public class DiveData {
        #region Properties / Felder
        /// <summary>Das zur Zeit geatmete Gas.</summary>
        public MixtureDTO ActiveMixture { get; set; }

        public double CNSLoad { get; private set; }

        /// <summary>Das zuletzt berechnete Tauch-Profil.</summary>
        public DiveProfileResult CurrentProfile { get; private set; }

        public double GFHigh { get; init; }

        public double GFLow { get; init; }

        /// <summary>Liste der mitgeführten Gase und zusätzlich das Oberflächengas.</summary>
        public List<MixtureDTO> Mixtures { get; init; }

        /// <summary>Aufzeichnung des gesammten Tauchgangs.</summary>
        public List<DiveProfileData> Profile { get; private set; }

        /// <summary>Oberflächendruck in bar.</summary>
        public double SurfacePressure { get; init; }

        private readonly ICalculator _Calculator;
        #endregion

        #region Konstruktor
        public DiveData(double pSurfacePressure, double pGFLow, double pGFHigh) {
            _Calculator = new Calculator(this, GasEnum.Enumerate(true).Select(x => new GasData(x)).ToArray());

            CNSLoad = 0;
            CurrentProfile = new DiveProfileResult();
            GFHigh = pGFHigh;
            GFLow = pGFLow;
            Mixtures = [];
            Profile = [];
            SurfacePressure = pSurfacePressure;

            AddMixture(MixtureModeEnum.Surfacegas,
                       GasEnum.O2.ToMixtureGas(),
                       GasEnum.N2.ToMixtureGas(100 - GasEnum.O2.StandardGasFraction - GasEnum.He.StandardGasFraction),
                       GasEnum.He.ToMixtureGas());
            SwitchMixture(0);
        }
        #endregion

        #region Methoden
        #region Mixture-Management
        /// <summary>Fügt ein weiteres Atemgas der Auflistung hinzu.</summary>
        /// <param name="pGas"></param>
        public void AddMixture(MixtureDTO pGas) {
            if (!Mixtures.Contains(pGas)) {
                Mixtures.Add(pGas);
            }
        }

        /// <summary>Fügt ein weiteres Atemgas der Auflistung hinzu.</summary>
        /// <param name="pMode"></param>
        /// <param name="pMetabolicGas"></param>
        /// <param name="pInertGases"></param>
        public void AddMixture(MixtureModeEnum pMode, MixtureGasDTO pMetabolicGas, params MixtureGasDTO[] pInertGases) {
            AddMixture(new MixtureDTO(pMode, pMetabolicGas, pInertGases));
        }

        /// <summary>Führt einen Gaswechsel aus.</summary>
        /// <param name="pIndex">Der Index des Gases in der Liste. <paramref name="pIndex"/>grösser/gleich 1</param>
        public void SwitchMixture(int pIndex) {
            ActiveMixture = Mixtures[pIndex];

            foreach (MixtureGasDTO inertGas in ActiveMixture.InertGases) {
                _Calculator.SwitchGas(inertGas.Gas.Id, inertGas.Fraction);
            }
        }
        #endregion

        public void ProcessMeasurement(double pAmbientPressure, double pExposureTime) {
            Profile.Add(new DiveProfileData(Profile.Count, DateTime.Now, pAmbientPressure, pExposureTime, ActiveMixture));
            CurrentProfile = _Calculator.Calculate(pAmbientPressure, pExposureTime);
            CNSLoad += CalculateCnsLoad(pAmbientPressure, pExposureTime);
        }

        /// <summary>Sucht das optimale Gas für den angegebenen Umgebungsdruck.
        /// Logik:
        /// Liste der Gase mit ppO2 innerhalb der Toleranz.
        /// Einschränken auf Gase welche N2 kleiner als Toleranz. Falls kein Gas gefunden wurde, Gas mit dem kleinsten N2 wählen. Wenn mehrere Gase gefunden wurden, dasjenige mit dem höchsten N2-Anteil wählen.</summary>
        /// <param name="pAmbientPressure">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns></returns>
        public MixtureDTO? FindOptimalDiveMixture(double pAmbientPressure) {
            List<MixtureDTO> result = [];
            IEnumerable<MixtureDTO> gasesWithinPPO2 = GetMixturesWithinPPO2(pAmbientPressure, MixtureModeEnum.Travelgas);

            if (!gasesWithinPPO2.Any()) {
                return null;
            }

            IEnumerable<MixtureDTO> gasesWithinPPN2 = gasesWithinPPO2
                .Where(x => (GetGasFraction(x, GasEnum.N2) * pAmbientPressure) < Settings.MaximumPPN2);

            if (gasesWithinPPN2.Any()) {
                return gasesWithinPPO2
                    .MinBy(x => GetGasFraction(x, GasEnum.N2));
            }

            return gasesWithinPPN2
                .MaxBy(x => GetGasFraction(x, GasEnum.N2));
        }

        public MixtureDTO? FindOptimalDecoMixture(double pAmbientPressure) {
            IEnumerable<MixtureDTO> gasesWithinPPO2 = GetMixturesWithinPPO2(pAmbientPressure, MixtureModeEnum.Dekogas);

            if (!gasesWithinPPO2.Any()) {
                return null;
            }

            return gasesWithinPPO2
                .MaxBy(x => GetGasFraction(x, GasEnum.O2));
        }

        private double GetGasFraction(MixtureDTO pMixture, GasEnum pGas) {
            if (pGas.GasType == GasTypeEnum.Inert) {
                return pMixture.InertGases.FirstOrDefault(x => x.Gas.EqualsAny(pGas))?.Fraction ?? 0;
            } else {
                return pMixture.MetabolicGas.Fraction;
            }
        }

        private IEnumerable<MixtureDTO> GetMixturesWithinPPO2(double pAmbientPressure, MixtureModeEnum pMode) {
            List<MixtureDTO> result = [];
            double maxPPO2 = pMode == MixtureModeEnum.Dekogas ? Settings.MaximumPPO2Deko : Settings.MaximumPPO2Tg;

            foreach (MixtureDTO mixture in Mixtures) {
                if (mixture.Mode == pMode) {
                    double ppO2 = pAmbientPressure * mixture.MetabolicGas.Fraction;

                    if (ppO2 >= Settings.MinimumPPO2 && ppO2 <= maxPPO2) {
                        result.Add(mixture);
                    }
                }
            }

            return result;
        }

        private double CalculateCnsLoad(double pAmbientPressure, double pExposureTime) {
            double usePartialGasPressure = pAmbientPressure * ActiveMixture.MetabolicGas.Fraction;

            if (ActiveMixture.MetabolicGas.Gas.ExposerLimits[0].Pressure > usePartialGasPressure) {
                usePartialGasPressure = ActiveMixture.MetabolicGas.Gas.ExposerLimits[0].Pressure;
            } else if (ActiveMixture.MetabolicGas.Gas.ExposerLimits.Last().Pressure < usePartialGasPressure) {
                usePartialGasPressure = ActiveMixture.MetabolicGas.Gas.ExposerLimits.Last().Pressure;
            }

            ExposerLimitData? exposureLimit = ActiveMixture.MetabolicGas.Gas.ExposerLimits.FirstOrDefault(x => x.Pressure == usePartialGasPressure);
            int counter = 0;

            while (exposureLimit is null || counter < 12) {
                counter++;
                usePartialGasPressure += 0.01;
                exposureLimit = ActiveMixture.MetabolicGas.Gas.ExposerLimits.FirstOrDefault(x => x.Pressure == usePartialGasPressure);
            }

            return pExposureTime * 100 / exposureLimit.MaxDiveTime;
        }
        #endregion
    }
}