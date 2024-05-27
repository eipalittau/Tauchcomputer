namespace ETCalc {
    internal class Calculate {
        private readonly List<IGasData> GasData = [];

        private readonly double SurfacePressure;
        public Calculate(double pSurfacePressure, double? pGasFractionN2, double? pGasFractionHe) {
            SurfacePressure = pSurfacePressure;

            GasSwitching(pGasFractionN2, pGasFractionHe);
        }

        public double CalculateNDL(double pAmbientPressure, double[] pTissuePressuresN2, double[] pTissuePressuresHe) {
            double minNDL = double.MaxValue;

            foreach (IGasData item in GasData) {
                minNDL = item.CalculateNDL(pAmbientPressure, minNDL, pTissuePressuresHe);
            }

            return minNDL;
        }

        public void GasSwitching(double? pGasFractionN2, double? pGasFractionHe) {
            HandleGasList(Enumeration.GasTypeEnum.N2, pGasFractionN2);
            HandleGasList(Enumeration.GasTypeEnum.He, pGasFractionHe);
        }

        private void HandleGasList(Enumeration.GasTypeEnum pGasType, double? pGasFraction) {
            IGasData? item = GasData.FirstOrDefault(x => x.GasType == pGasType);

            if (pGasFraction > 0) {
                if (item == null) {
                    GasData.Add(new N2Data(pGasFraction.Value, SurfacePressure));
                } else {
                    item.GasFraction = pGasFraction.Value;
                }
            } else {
                if (item != null) {
                    GasData.Remove(item);
                }
            }
        }
    }
}