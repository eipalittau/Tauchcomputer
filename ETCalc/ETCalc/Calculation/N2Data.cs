using ETCalc.Enumeration;

namespace ETCalc {
    internal class N2Data : GasDataBase, IGasData {
        public GasTypeEnum GasType { get; } = GasTypeEnum.N2;

        private static readonly ValueData[] CompartimentDatas = {
            new (0, 4.0, 1.2599, 0.5050),
            new (1, 8.0, 1.0000, 0.6514),
            new (2, 12.5, 0.8618, 0.7222),
            new (3, 18.5, 0.7562, 0.7825),
            new (4, 27.0, 0.6667, 0.8125),
            new (5, 38.3, 0.5933, 0.8434),
            new (6, 54.3, 0.5282, 0.8693),
            new (7, 77.0, 0.4701, 0.8910),
            new (8, 109.0, 0.4187, 0.9092),
            new (9, 146.0, 0.3798, 0.9222),
            new (10, 187.0, 0.3497, 0.9319),
            new (11, 239.0, 0.3223, 0.9403),
            new (12, 305.0, 0.2971, 0.9477),
            new (13, 390.0, 0.2737, 0.9544),
            new (14, 498.0, 0.2523, 0.9602),
            new (15, 635.0, 0.2327, 0.9653)
        };

        public N2Data()
            : this(0, 1) { }

        public N2Data(double pGasFraction, double pSurfacePressure)
            : base(pGasFraction, pSurfacePressure) { }

        public double CalculateNDL(double pAmbientPressure, double pMinNDL, double[] pTissuePressures) {
            return CalculateNDL(pAmbientPressure, pTissuePressures, CompartimentDatas, pMinNDL);
        }
    }
}
