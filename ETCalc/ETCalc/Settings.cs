namespace ETCalc {
    internal static class Settings {
        /// <summary>Maximaler partieller Sauerstoff-Druck während der Dekompression</summary>
        public static double MaximumPPO2Deko { get; set; }

        /// <summary>Maximaler partieller Sauerstoff-Druck während des Tauchgangs.</summary>
        public static double MaximumPPO2Tg { get; set; }

        /// <summary>Minimaler partieller Sauerstoff-Druck.</summary>
        public static double MinimumPPO2 { get; set; }

        /// <summary>Maximale Aufstiegsgeschwindigkeit in bar pro Sekunde.</summary>
        public static double MaximumAscent { get; set; }

        /// <summary>Intervall zur Berechnung des Tauchprofils in Sekunden.</summary>
        public static int CalculationInterval { get; set; }

        public static void LoadDefault() {
            MaximumPPO2Deko = 1.6;
            MaximumPPO2Tg = 1.4;
            MinimumPPO2 = 0.16;
            MaximumAscent = 1 / 60; // 1 bar pro Minute = 10m pro Minute
            CalculationInterval = 5;
        }
    }
}