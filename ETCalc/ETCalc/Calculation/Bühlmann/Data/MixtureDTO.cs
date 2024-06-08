using ETCalc.Enumeration;

namespace ETCalc.Calculation.Bühlmann {
    public class MixtureDTO {
        public MixtureGasDTO[] InertGases { get; init; }

        public MixtureGasDTO MetabolicGas { get; init; }

        public ModeEnum Mode { get; init; }

        public MixtureDTO(ModeEnum pMode, MixtureGasDTO pMetabolicGas, params MixtureGasDTO[] pInertGases) {
            Mode = pMode;
            MetabolicGas = pMetabolicGas;
            InertGases = pInertGases;
        }
    }
}