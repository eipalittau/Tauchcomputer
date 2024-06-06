namespace ETCalc.Calculator.Bühlmann {
    internal class GasData {
        #region Properties / Felder
        public GasEnum InertGas { get; init; }

        public double[] Saturations { get; set; }

        public double GasFraction { get; set; }

        public double PartialGasPressure { get; private set; }

        public bool IsActive { get { return GasFraction > 0; }  }
        #endregion

        public GasData(GasEnum pInertGas) {
            InertGas = pInertGas;
            Saturations = new double[pInertGas.Compartments.Length];
            GasFraction = pInertGas.StandardGasFraction;
            PartialGasPressure = double.MinValue;
        }

        public void SetPartialGasPressure(double pAmbientPressure) {
            PartialGasPressure = pAmbientPressure * GasFraction;
        }

        public CompartmentData GetCompartiment(int pIndex) {
            return InertGas.Compartments[pIndex];
        }
    }
}