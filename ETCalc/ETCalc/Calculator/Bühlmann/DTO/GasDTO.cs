namespace ETCalc.Calculator.Bühlmann {
    internal class GasDTO {
        #region Properties / Felder
        public GasEnum InertGas { get; init; }

        public double[] Saturations { get; set; }

        public double GasFraction { get; set; }

        public double PartialGasPressure { get; private set; }

        public bool IsActive { get { return GasFraction > 0; }  }
        #endregion

        public GasDTO(GasEnum pInertGas) {
            InertGas = pInertGas;
            Saturations = new double[pInertGas.Compartments.Length];
            GasFraction = double.MinValue;
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