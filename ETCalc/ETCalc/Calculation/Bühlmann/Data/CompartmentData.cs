namespace ETCalc.Calculation.Bühlmann {
    public class CompartmentData {
        #region Properties / Felder
        /// <summary>halbzeit des Kompartiments</summary>
        public double HalfTime { get; init; }

        /// <summary>Koeffizent A</summary>
        public double A { get; init; }

        /// <summary>Koeffizent B</summary>
        public double B { get; init; }

        /// <summary>Konstante K = ln(2) / Halbwertszeit</summary>
        public double K { get; init; }
        #endregion

        #region Konstruktor
        public CompartmentData(double pHalfTime, double pA, double pB)
            => (HalfTime, A, B, K) = (pHalfTime, pA, pB, Constants.LN2 / pHalfTime);
        #endregion
    }
}