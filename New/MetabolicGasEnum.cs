namespace ETC.Bühlmann {
    public class MetabolicGasEnum {
        #region Properties / Felder
        public static readonly MetabolicGasEnum O2 = new(pName: nameof(O2),
                                          pStandardGasFraction: 0.20948,
                                                pExposerLimits: [ new ExposerLimitData(0.50,   0.00, int.MaxValue),
                                                                  new ExposerLimitData(0.60,   0.14, 714),
                                                                  new ExposerLimitData(0.64,   0.15, 667),
                                                                  new ExposerLimitData(0.66,   0.16, 625),
                                                                  new ExposerLimitData(0.68,   0.17, 588),
                                                                  new ExposerLimitData(0.70,   0.18, 556),
                                                                  new ExposerLimitData(0.74,   0.19, 526),
                                                                  new ExposerLimitData(0.76,   0.20, 500),
                                                                  new ExposerLimitData(0.78,   0.21, 476),
                                                                  new ExposerLimitData(0.80,   0.22, 455),
                                                                  new ExposerLimitData(0.82,   0.23, 435),
                                                                  new ExposerLimitData(0.84,   0.24, 417),
                                                                  new ExposerLimitData(0.86,   0.25, 400),
                                                                  new ExposerLimitData(0.88,   0.26, 385),
                                                                  new ExposerLimitData(0.90,   0.28, 357),
                                                                  new ExposerLimitData(0.92,   0.29, 345),
                                                                  new ExposerLimitData(0.94,   0.30, 333),
                                                                  new ExposerLimitData(0.96,   0.31, 323),
                                                                  new ExposerLimitData(0.98,   0.32, 313),
                                                                  new ExposerLimitData(1.00,   0.33, 303),
                                                                  new ExposerLimitData(1.02,   0.35, 286),
                                                                  new ExposerLimitData(1.04,   0.36, 278),
                                                                  new ExposerLimitData(1.06,   0.38, 263),
                                                                  new ExposerLimitData(1.08,   0.40, 250),
                                                                  new ExposerLimitData(1.10,   0.42, 238),
                                                                  new ExposerLimitData(1.12,   0.43, 233),
                                                                  new ExposerLimitData(1.14,   0.43, 233),
                                                                  new ExposerLimitData(1.16,   0.44, 227),
                                                                  new ExposerLimitData(1.18,   0.46, 217),
                                                                  new ExposerLimitData(1.20,   0.47, 213),
                                                                  new ExposerLimitData(1.22,   0.48, 208),
                                                                  new ExposerLimitData(1.24,   0.51, 196),
                                                                  new ExposerLimitData(1.26,   0.52, 192),
                                                                  new ExposerLimitData(1.28,   0.54, 185),
                                                                  new ExposerLimitData(1.30,   0.56, 179),
                                                                  new ExposerLimitData(1.32,   0.57, 175),
                                                                  new ExposerLimitData(1.34,   0.60, 167),
                                                                  new ExposerLimitData(1.36,   0.62, 161),
                                                                  new ExposerLimitData(1.38,   0.63, 159),
                                                                  new ExposerLimitData(1.40,   0.65, 154),
                                                                  new ExposerLimitData(1.42,   0.68, 147),
                                                                  new ExposerLimitData(1.44,   0.71, 141),
                                                                  new ExposerLimitData(1.46,   0.74, 135),
                                                                  new ExposerLimitData(1.48,   0.78, 128),
                                                                  new ExposerLimitData(1.50,   0.83, 120),
                                                                  new ExposerLimitData(1.52,   0.93, 108),
                                                                  new ExposerLimitData(1.54,   1.04,  96),
                                                                  new ExposerLimitData(1.56,   1.19,  84),
                                                                  new ExposerLimitData(1.58,   1.47,  68),
                                                                  new ExposerLimitData(1.60,   2.22,  45),
                                                                  new ExposerLimitData(1.62,   5.00,  20),
                                                                  new ExposerLimitData(1.65,   6.25,  16),
                                                                  new ExposerLimitData(1.67,   7.69,  13),
                                                                  new ExposerLimitData(1.70,  10.00,  10),
                                                                  new ExposerLimitData(1.72,  12.50,   8),
                                                                  new ExposerLimitData(1.74,  20.00,   5),
                                                                  new ExposerLimitData(1.77,  25.00,   4),
                                                                  new ExposerLimitData(1.79,  31.25,   3),
                                                                  new ExposerLimitData(1.80,  50.00,   2),
                                                                 
        public string Name { get; init; }

        public double StandardGasFraction { get; init; }

        public ExposerLimitData[] ExposerLimits { get; init; }
        #endregion

        #region Konstruktor
        private GasEnum(string pName, double pStandardGasFraction, ExposerLimitData[] pExposerLimits) {
            Name = pName;
            StandardGasFraction = pStandardGasFraction;
            ExposerLimits = pExposerLimits;
        }
        #endregion

        #region Methoden
        public static IEnumerable<MetabolicGasEnum> Enumerate() {
            return typeof(MetabolicGasEnum)
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.GetValue(null))
                .Cast<MetabolicGasEnum>();
        }

        public bool EqualsAny(params MetabolicGasEnum[] pOthers) {
            return pOthers.Any(x => x.Name.Equals(Name));
        }

        #region Convertion
        public MixtureGasDTO ToMixtureGas() {
            return ToMixtureGas(StandardGasFraction);
        }

        public MixtureGasDTO ToMixtureGas(double pGasFraction) {
            return new MixtureGasDTO(this, pGasFraction);
        }
        #endregion
        #endregion
    }
}
