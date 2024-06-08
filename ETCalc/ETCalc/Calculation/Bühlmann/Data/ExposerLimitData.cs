namespace ETCalc.Calculation.Bühlmann {
    public class ExposerLimitData {
        #region Properties / Felder
        /// <summary>Partieller Gasdruck.</summary>
        public double Pressure { get; init; }

        /// <summary>Belastung in Prozent/Minute.</summary>
        public double Percent { get; init; }

        /// <summary>Maximal verfügbare Tauchzeit.</summary>
        public int MaxDiveTime { get; init; }

        #endregion

        #region Konstruktor
        /// <summary>Konstruktor für Expositions-Limiten.</summary>
        /// <param name="pPressure">Partieller Gasdruck.</param>
        /// <param name="pPercent">Belastung in Prozent/Minute.</param>
        /// <param name="pMaxDiveTime">Maximal verfügbare Tauchzeit.</param>
        public ExposerLimitData(double pPressure, double pPercent, int pMaxDiveTime)
            => (Pressure, Percent, MaxDiveTime) = (pPressure, pPercent, pMaxDiveTime);
        #endregion
    }
}