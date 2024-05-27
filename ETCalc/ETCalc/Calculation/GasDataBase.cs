namespace ETCalc {
    internal abstract class GasDataBase {
        public double GasFraction { get; set; }

        private protected readonly double SurfacePressure;

        private protected readonly double Log2 = Math.Log(2);

        private protected GasDataBase(double pGasFraction, double pSurfacePressure) {
            SurfacePressure = pSurfacePressure;
            GasFraction = pGasFraction;
        }

        private protected double CalculateNDL(double pAmbientPressure, double[] pTissuePressures, ValueData[] pCompartiments, double pMinNDL = double.MaxValue) {
            double gasPressure = (pAmbientPressure - SurfacePressure) * GasFraction;

            for (int i = 0; i < pCompartiments.Length; i++) {
                double maxInertGasPressure = pCompartiments[i].A + (pAmbientPressure - pCompartiments[i].A) * pCompartiments[i].B;
                double remainingTime = -Math.Log((maxInertGasPressure - gasPressure) / (pTissuePressures[i] - gasPressure)) / (Log2 / pCompartiments[i].HalfTime);

                if (remainingTime > 0 && remainingTime < pMinNDL) {
                    pMinNDL = remainingTime;
                }
            }

            return pMinNDL;
        }
    }
}