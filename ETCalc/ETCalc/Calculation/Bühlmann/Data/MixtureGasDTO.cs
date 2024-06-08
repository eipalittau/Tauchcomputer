namespace ETCalc.Calculation.Bühlmann {
    public class MixtureGasDTO {
        public GasEnum Gas { get; init; }

        public double Fraction { get; init; }

        public MixtureGasDTO(GasEnum pGas, double pFraction)
            => (Gas, Fraction) = (pGas, pFraction);
    }
}