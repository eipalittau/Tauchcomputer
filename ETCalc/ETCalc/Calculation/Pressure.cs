namespace ETCalc.Calculation {
    internal class Pressure {
        #region Properties / Felder
        /// <summary>Süsswasserdruck pro Meter in Bar-</summary>
        private const double FreshwaterPressure = 0.0981;

        /// <summary>Salzwasserdruck bei 35 PSU pro Meter in Bar. (35 PSU entsprechen ca. 3.5% Sazgehalt)</summary>
        private const double SaltwaterPressure = 0.1013;

        /// <summary>Standard Salzgehalt im Salzwassere in PSU</summary>
        private const double StandardSalinity = 35;

        public int SalinityInPSU { get; private set; }

        public double DensityFactor { get; private set; }

        public double SurfacePressure { get; init; }
        #endregion

        #region Konstruktor
        public Pressure(int pSalinityInPSU, double pSurfacePressure) {
            SurfacePressure = pSurfacePressure;
            SetSalinity(pSalinityInPSU);
        }
        #endregion

        #region Methoden
        /// <summary>Berechnet den Dichtefaktor des Wassers.</summary>
        /// <param name="pSalinityInPSU">Salzgehalt in PSU. (35 PSU entsprechen ca. 3.5% Sazgehalt)</param>
        /// <returns></returns>
        public void SetSalinity(int pSalinityInPSU) {
            SalinityInPSU = pSalinityInPSU;
            DensityFactor = FreshwaterPressure + (SaltwaterPressure - FreshwaterPressure) * pSalinityInPSU / StandardSalinity;
        }

        public double CalculateDepth(double pAmbientPressure) {
            return (pAmbientPressure - SurfacePressure) * DensityFactor;
        }

        #region Convert
        public static double ConvertPSU2Percentage(double pPSU) {
            return pPSU / 10;
        }

        public static double ConvertPercentage2PSU(double pPercentage) {
            return pPercentage * 10;
        }
        #endregion
        #endregion
    }
}