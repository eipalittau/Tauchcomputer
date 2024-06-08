namespace ETCalc.Calculation.Bühlmann {
    public class DiveProfileData {
        #region Properties / Felder
        public long Number { get; init; }

        public DateTime Timestamp { get; init; }

        public double AmbientPressure { get; init; }

        public double ExposureTime { get; init; }

        public MixtureDTO Gas { get; init; }
        #endregion

        #region Konstruktor
        public DiveProfileData(long pNumber, DateTime pTimestamp, double pAmbientPressure, double pExposureTime, MixtureDTO pGas)
            => (Number, Timestamp, AmbientPressure, ExposureTime, Gas) = (pNumber, pTimestamp, pAmbientPressure, pExposureTime, pGas);
        #endregion
    }
}