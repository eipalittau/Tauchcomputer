namespace ETC.Gas {
    public class ExpositionData {
        #region Properties / Felder
        public double PressurePartial { get; set; }

        public double Load { get; set; }

        public int MaximalExpositionTime { get; set; }
        #endregion

        #region Konstruktor
        public ExpositionData(double pPressurePartial, double pLoad, int pMaximalExpositionTime)
            => (PressurePartial, Load, MaximalExpositionTime) = (pPressurePartial, pLoad, pMaximalExpositionTime);
        #endregion

        #region Methoden
        /// <summary>Berechnet die neu entstandene ZNS-Belastung in Abhängigkeit zur Expositions-Zeit.</summary>
        /// <param name="pDeltaTime">Expositionszeit in Sekunden.</param>
        /// <returns>Die zu addierende ZNS-Belastung.</returns>
        public double CalculateStress(int pDeltaTime) {
            return Load * pDeltaTime / 60;
        }
        #endregion
    }
}