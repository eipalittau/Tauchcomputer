namespace ETCalc {
    internal static class Pressure {
        /// <summary>Süsswasserdruck pro Meter in Bar-</summary>
        private const double FreshwaterPressure = 0.0981;

        /// <summary>Salzwasserdruck bei 35 PSU pro Meter in Bar. (35 PSU entsprechen ca. 3.5% Sazgehalt)</summary>
        private const double SaltwaterPressure = 0.1013;

        /// <summary>Standard Salzgehalt im Salzwasser. in Prozent</summary>
        private const double StandardSalinity = 3.5;

        /// <summary>Druckdifferenz zwischen Süsswasser und Salzwasser</summary>
        private const double PressureDifference = SaltwaterPressure - FreshwaterPressure;

        /// <summary>Standard Salzgehalt im Salzwassere in PSU</summary>
        private const double StandardSalinityPSU = StandardSalinity * 10;

        /// <summary>Berechnet den Dichtefaktor des Wassers.</summary>
        /// <param name="pSalinityInPSU">Salzgehalt in PSU. (35 PSU entsprechen ca. 3.5% Sazgehalt)</param>
        /// <returns></returns>
        public static double CalculateDensityFactor(double pSalinityInPSU) {
            return FreshwaterPressure + PressureDifference * pSalinityInPSU / StandardSalinityPSU;
        }

        public static double ConvertPSU2Percentage(double pPSU) {
            return pPSU / 10;
        }

        public static double ConvertPercentage2PSU(double pPercentage) {
            return pPercentage * 10;
        }
    }
}
