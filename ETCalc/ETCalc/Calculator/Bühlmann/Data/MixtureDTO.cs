using ETCalc.Enumeration;

namespace ETCalc.Calculator.Bühlmann {
    internal class MixtureDTO {
        public MixtureGasDTO[] Gases { get; init; }

        public ModeEnum Mode { get; init; }

        public MixtureDTO(ModeEnum pMode, params MixtureGasDTO[] pGases) {
            Mode = pMode;
            Gases = pGases;
        }
    }
}