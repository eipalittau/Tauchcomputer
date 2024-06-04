namespace ETCalc.Calculator.Bühlmann {
    internal class CompartmentData
    {
        #region Properties / Felder
        public int Compartment { get; init; }

        public double HalfTime { get; init; }

        public double A { get; init; }

        public double B { get; init; }
        #endregion

        #region Konstruktor
        public CompartmentData(int pCompartiment, double pHalfTime, double pA, double pB)
            => (Compartment, HalfTime, A, B) = (pCompartiment, pHalfTime, pA, pB);
        #endregion
    }
}