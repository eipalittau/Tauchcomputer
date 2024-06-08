namespace ETCalc.Calculation {
    internal interface ICalculator {
        Bühlmann.GasData[] GasComposition { get; init; }

        void SwitchGas(int pId, double pFraction);

        DTO.DiveProfileResult Calculate(double pAmbientPressure, double pExposureTime);

        Bühlmann.Calculator Clone();
    }
}