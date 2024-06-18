namespace ETCalc {
    internal static class Settings {
        /// <summary>Maximaler partieller Sauerstoff-Druck während der Dekompression</summary>
        public static double MaximumPPO2Deko { get; set; }

        /// <summary>Maximaler partieller Sauerstoff-Druck während des Tauchgangs.</summary>
        public static double MaximumPPO2Tg { get; set; }

        /// <summary>Minimaler partieller Sauerstoff-Druck.</summary>
        public static double MinimumPPO2 { get; set; }

        public static double MaximumPPN2 {  get; set; }

        /// <summary>Maximale Aufstiegsgeschwindigkeit in bar pro Minute.</summary>
        public static double MaximumAscent { get; set; }

        /// <summary>Intervall zur Berechnung des Tauchprofils in Minuten.</summary>
        public static double CalculationInterval { get; set; }

        /// <summary>Abstand der Dekompressionsstopps in bar.</summary>
        public static double DecompressionStopInterval { get; set; }

        public static void LoadDefault() {
            MaximumPPO2Deko = 1.6;
            MaximumPPO2Tg = 1.4;
            MinimumPPO2 = 0.16;
            MaximumPPN2 = 3.16;
            MaximumAscent = 1; // 1 bar pro Minute = 10m pro Minute
            CalculationInterval = 0.1; // 6 Sekunden
            DecompressionStopInterval = 0.3;
        }
    }
}