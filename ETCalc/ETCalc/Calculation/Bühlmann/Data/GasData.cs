namespace ETCalc.Calculation.Bühlmann {
    internal class GasData {
        #region Properties / Felder
        public GasEnum Gas { get; init; }

        public double[] Saturations { get; set; }

        public double GasFraction { get; set; }

        public double PartialGasPressure { get; private set; }

        public bool IsActive { get { return GasFraction > 0; }  }
        #endregion

        public GasData(GasEnum pGas) {
            Gas = pGas;
            Saturations = new double[pGas.Compartments.Length];
            GasFraction = pGas.StandardGasFraction;
            PartialGasPressure = double.MinValue;
        }

        public void SetPartialGasPressure(double pAmbientPressure) {
            PartialGasPressure = pAmbientPressure * GasFraction;
        }

        public CompartmentData GetCompartiment(int pIndex) {
            return Gas.Compartments[pIndex];
        }
    }
}