using System.Reflection;

namespace ETCalc.Calculator.Bühlmann {
    internal class GasEnum {
        #region Properties / Felder
        public static readonly GasEnum N2 = new(0, nameof(N2), 0.781, [
            new CompartmentData(0, 4.0, 1.2599, 0.5050),
            new CompartmentData(1, 8.0, 1.0000, 0.6514),
            new CompartmentData(2, 12.5, 0.8618, 0.7222),
            new CompartmentData(3, 18.5, 0.7562, 0.7825),
            new CompartmentData(4, 27.0, 0.6667, 0.8125),
            new CompartmentData(5, 38.3, 0.5933, 0.8434),
            new CompartmentData(6, 54.3, 0.5282, 0.8693),
            new CompartmentData(7, 77.0, 0.4701, 0.8910),
            new CompartmentData(8, 109.0, 0.4187, 0.9092),
            new CompartmentData(9, 146.0, 0.3798, 0.9222),
            new CompartmentData(10, 187.0, 0.3497, 0.9319),
            new CompartmentData(11, 239.0, 0.3223, 0.9403),
            new CompartmentData(12, 305.0, 0.2971, 0.9477),
            new CompartmentData(13, 390.0, 0.2737, 0.9544),
            new CompartmentData(14, 498.0, 0.2523, 0.9602),
            new CompartmentData(15, 635.0, 0.2327, 0.9653) ]);

        public static readonly GasEnum He = new(1, nameof(He), 0.000005, [
            new CompartmentData(0, 1.51, 1.7424, 0.4245),
            new CompartmentData(1, 3.02, 1.383, 0.5747),
            new CompartmentData(2, 4.72, 1.1911, 0.6527),
            new CompartmentData(3, 6.99, 1.0458, 0.7223),
            new CompartmentData(4, 10.21, 0.922, 0.7582),
            new CompartmentData(5, 14.48, 0.8205, 0.7957),
            new CompartmentData(6, 20.53, 0.7305, 0.8279),
            new CompartmentData(7, 29.11, 0.6502, 0.8553),
            new CompartmentData(8, 41.20, 0.595, 0.8757),
            new CompartmentData(9, 55.19, 0.5545, 0.8903),
            new CompartmentData(10, 70.69, 0.5333, 0.8997),
            new CompartmentData(11, 90.34, 0.5189, 0.9073),
            new CompartmentData(12, 115.29, 0.5181, 0.9122),
            new CompartmentData(13, 147.42, 0.5176, 0.9171),
            new CompartmentData(14, 188.24, 0.5172, 0.9217),
            new CompartmentData(15, 240.03, 0.5119, 0.9267) ]);

        public static readonly GasEnum O2 = new(2, nameof(O2), 0.209, [
            new ExposerLimitData(0.50, 0.00, int.MaxValue),
            new ExposerLimitData(0.60, 0.14, 714),
            new ExposerLimitData(0.64, 0.15, 667),
            new ExposerLimitData(0.66, 0.16, 625),
            new ExposerLimitData(0.68, 0.17, 588),
            new ExposerLimitData(0.70, 0.18, 556),
            new ExposerLimitData(0.74, 0.19, 526),
            new ExposerLimitData(0.76, 0.20, 500),
            new ExposerLimitData(0.78, 0.21, 476),
            new ExposerLimitData(0.80, 0.22, 455),
            new ExposerLimitData(0.82, 0.23, 435),
            new ExposerLimitData(0.84, 0.24, 417),
            new ExposerLimitData(0.86, 0.25, 400),
            new ExposerLimitData(0.88, 0.26, 385),
            new ExposerLimitData(0.90, 0.28, 357),
            new ExposerLimitData(0.92, 0.29, 345),
            new ExposerLimitData(0.94, 0.30, 333),
            new ExposerLimitData(0.96, 0.31, 323),
            new ExposerLimitData(0.98, 0.32, 313),
            new ExposerLimitData(1.00, 0.33, 303),
            new ExposerLimitData(1.02, 0.35, 286),
            new ExposerLimitData(1.04, 0.36, 278),
            new ExposerLimitData(1.06, 0.38, 263),
            new ExposerLimitData(1.08, 0.40, 250),
            new ExposerLimitData(1.10, 0.42, 238),
            new ExposerLimitData(1.12, 0.43, 233),
            new ExposerLimitData(1.14, 0.43, 233),
            new ExposerLimitData(1.16, 0.44, 227),
            new ExposerLimitData(1.18, 0.46, 217),
            new ExposerLimitData(1.20, 0.47, 213),
            new ExposerLimitData(1.22, 0.48, 208),
            new ExposerLimitData(1.24, 0.51, 196),
            new ExposerLimitData(1.26, 0.52, 192),
            new ExposerLimitData(1.28, 0.54, 185),
            new ExposerLimitData(1.30, 0.56, 179),
            new ExposerLimitData(1.32, 0.57, 175),
            new ExposerLimitData(1.34, 0.60, 167),
            new ExposerLimitData(1.36, 0.62, 161),
            new ExposerLimitData(1.38, 0.63, 159),
            new ExposerLimitData(1.40, 0.65, 154),
            new ExposerLimitData(1.42, 0.68, 147),
            new ExposerLimitData(1.44, 0.71, 141),
            new ExposerLimitData(1.46, 0.74, 135),
            new ExposerLimitData(1.48, 0.78, 128),
            new ExposerLimitData(1.50, 0.83, 120),
            new ExposerLimitData(1.52, 0.93, 108),
            new ExposerLimitData(1.54, 1.04, 96),
            new ExposerLimitData(1.56, 1.19, 84),
            new ExposerLimitData(1.58, 1.47, 68),
            new ExposerLimitData(1.60, 2.22, 45),
            new ExposerLimitData(1.62, 5.00, 20),
            new ExposerLimitData(1.65, 6.25, 16),
            new ExposerLimitData(1.67, 7.69, 13),
            new ExposerLimitData(1.70, 10.00, 10),
            new ExposerLimitData(1.72, 12.50, 8),
            new ExposerLimitData(1.74, 20.00, 5),
            new ExposerLimitData(1.77, 25.00, 4),
            new ExposerLimitData(1.79, 31.25, 3),
            new ExposerLimitData(1.80, 50.00, 2),
            new ExposerLimitData(1.82, 100.00, 1) ]);

        public int Id { get; init; }

        public string Name { get; init; }

        public double StandardGasFraction { get; init; }

        public bool IsInertGas { get; init; }

        public CompartmentData[] Compartments { get; init; }

        public ExposerLimitData[] ExposerLimits { get; init; }
        #endregion

        #region Konstruktor
        private GasEnum(int pId, string pName, double pStandardGasFraction, CompartmentData[] pCompartments) {
            Id = pId;
            IsInertGas = true;
            Name = pName;
            StandardGasFraction = pStandardGasFraction;
            Compartments = pCompartments;
            ExposerLimits = [];
        }

        private GasEnum(int pId, string pName, double pStandardGasFraction, ExposerLimitData[] pExposerLimits) {
            Id = pId;
            IsInertGas = false;
            Name = pName;
            StandardGasFraction = pStandardGasFraction;
            Compartments = [];
            ExposerLimits = pExposerLimits;
        }
        #endregion

        #region Methoden
        public static IEnumerable<GasEnum> Enumerate(bool pOnlyInertGas) {
            IEnumerable<GasEnum> gases = typeof(GasEnum)
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.GetValue(null))
                .Cast<GasEnum>();

            if (pOnlyInertGas) {
                return gases.Where(x => x.IsInertGas);
            } else {
                return gases;
            }
        }

        public bool EqualsAny(params GasEnum[] pOthers) {
            return pOthers.Any(x => x.Name.Equals(Name));
        }
        #endregion
    }
}