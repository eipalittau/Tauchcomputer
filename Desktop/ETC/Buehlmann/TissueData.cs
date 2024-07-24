namespace ETC.Buehlmann {
    public sealed class TissueData {
        #region Properties / Felder
        ///<summary>Halbwertzeit des Kompartiments</summary>
        public double HalfLife { get; set; }

        ///<summary>Koeffizient a</summary>
        public double A { get; set; }

        ///<summary>Koeffizient b</summary>
        public double B { get; set; }
        #endregion

        #region Konstruktor
        public TissueData(double pHalfLife, double pA, double pB)
            => (HalfLife, A, B) = (pHalfLife, pA, pB);
        #endregion
    }
}