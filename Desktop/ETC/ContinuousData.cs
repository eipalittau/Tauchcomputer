namespace ETC {
    public static class ContinuousData {
        #region Properties / Felder
        public static double CurrentCnsExposition { get; set; } = 0;

        public static double[,] CurrentSaturation { get; } = new double[1, 16];

        public static double PressureSurface { get; set; }
        #endregion

        #region Konstruktor
        static ContinuousData() { }
        #endregion
    }
}
