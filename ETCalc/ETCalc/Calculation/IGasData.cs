using ETCalc.Enumeration;

namespace ETCalc {
    internal interface IGasData {
        GasTypeEnum GasType { get; }

        double GasFraction { get; set; }

        double CalculateNDL(double pAmbientPressure, double pMinNDL, double[] pTissuePressures);
    }
}