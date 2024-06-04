using ETCalc.Calculator.Bühlmann;
using ETCalc.Enumeration;

namespace ETCalc.Calculator.DTO {
    internal class MixtureDTO {
        public GasEnum Gas { get; init; }

        public double PartialPressure { get; init; }

        public MixtureDTO(ModeEnum pMode, Dictionary<GasEnum, double> pInertGases) {
            Mode = pMode;
            FractionO2 = pFractionO2;
            FractionHe = pFractionHe;
            FractionN2 = 100 - pFractionO2 - pFractionHe;
        }
    }
}