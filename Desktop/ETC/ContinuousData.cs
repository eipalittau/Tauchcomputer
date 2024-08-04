namespace ETC {
    public static class ContinuousData {
        #region Properties / Felder
        public static double CurrentCnsExposition { get; set; } = 0;

        private static double[,] CurrentSaturation { get; } = new double[1, 16];

        public static double PressureSurface { get; set; }
        #endregion

        #region Konstruktor
        static ContinuousData() { }
        #endregion

        #region Methoden
        public static double GetSaturationN2(int pIndex) {
            return CurrentSaturation[0, pIndex];
        }

        public static double GetSaturationHe(int pIndex) {
            return CurrentSaturation[1, pIndex];
        }
    }
}
