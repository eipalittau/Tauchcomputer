using ETCalc.Enumeration;

namespace ETCalc {
    internal class HeData : GasDataBase, IGasData {
        public GasTypeEnum GasType { get; } = GasTypeEnum.He;

        private static readonly ValueData[] CompartimentDatas = [
            new (0, 1.51, 1.7424, 0.4245),
            new (1, 3.02, 1.383, 0.5747),
            new (2, 4.72, 1.1911, 0.6527),
            new (3, 6.99, 1.0458, 0.7223),
            new (4, 10.21, 0.922, 0.7582),
            new (5, 14.48, 0.8205, 0.7957),
            new (6, 20.53, 0.7305, 0.8279),
            new (7, 29.11, 0.6502, 0.8553),
            new (8, 41.20, 0.595, 0.8757),
            new (9, 55.19, 0.5545, 0.8903),
            new (10, 70.69, 0.5333, 0.8997),
            new (11, 90.34, 0.5189, 0.9073),
            new (12, 115.29, 0.5181, 0.9122),
            new (13, 147.42, 0.5176, 0.9171),
            new (14, 188.24, 0.5172, 0.9217),
            new (15, 240.03, 0.5119, 0.9267)
        ];

        public HeData()
            : this(0, 1) { }

        public HeData(double pGasFraction, double pSurfacePressure)
            : base(pGasFraction, pSurfacePressure) { }

        public double CalculateNDL(double pAmbientPressure, double pMinNDL, double[] pTissuePressures) {
            return CalculateNDL(pAmbientPressure, pTissuePressures, CompartimentDatas, pMinNDL);
        }
    }
}