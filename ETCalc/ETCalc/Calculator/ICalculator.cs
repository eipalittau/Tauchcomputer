using ETCalc.Calculator.Bühlmann;

namespace ETCalc.Calculator {
    internal interface ICalculator {
        GasDTO[] GasComposition { get; init; }

        void SwitchGas(int pIndex);

        DTO.DiveProfileResult Calculate(double pAmbientPressure, double pExposureTime);
    }
}