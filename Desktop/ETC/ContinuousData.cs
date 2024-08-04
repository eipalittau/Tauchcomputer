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
        public static double SaturationN2(int pIndex) {
            return CurrentSaturation[0, pIndex];
        }

        public static void SaturationN2(int pIndex, double pValue) {
            CurrentSaturation[0, pIndex] = pValue;
        }

        public static double SaturationHe(int pIndex) {
            return CurrentSaturation[1, pIndex];
        }

        public static void SaturationHe(int pIndex, double pValue) {
            CurrentSaturation[1, pIndex] = pValue;
        }
    }
}
