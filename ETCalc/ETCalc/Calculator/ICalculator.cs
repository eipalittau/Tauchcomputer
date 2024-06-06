namespace ETCalc.Calculator {
    internal interface ICalculator {
        Bühlmann.GasData[] GasComposition { get; init; }

        void SwitchGas(int pIndex);

        DTO.DiveProfileResult Calculate(double pAmbientPressure, double pExposureTime);

        Bühlmann.Calculator Clone();
    }
}