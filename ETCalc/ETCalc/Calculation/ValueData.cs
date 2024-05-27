namespace ETCalc {
    internal class ValueData {
        #region Properties / Felder
        public int Compartiment {  get; set; }

        public double HalfTime { get; set; }

        public double A { get; set; }

        public double B { get; set; }
        #endregion

        #region Konstruktor
        public ValueData(int pCompartiment, double pHalfTime, double pA, double pB)
            => (Compartiment, HalfTime, A, B) = (pCompartiment, pHalfTime, pA, pB);
        #endregion
    }
}
