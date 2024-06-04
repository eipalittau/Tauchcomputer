namespace ETCalc {
    internal static class Settings {
        public static double MaximumPPO2Deko { get; set; }

        public static double MaximumPPO2Tg { get; set; }

        public static double MinimumPPO2 { get; set; }

        public static void LoadDefault() {
            MaximumPPO2Deko = 1.6;
            MaximumPPO2Tg = 1.4;
            MinimumPPO2 = 0.16;
        }
    }
}