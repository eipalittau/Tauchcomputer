using ETC.Gas;

namespace ETC {
    public static class Settings {
        #region Properties / Felder
        public static MixtureData[] Mixtures { get; } = new MixtureData[6];

        public static MixtureData CurrentMixture { get; set; }

        public static double MinPpO2 { get; set; }

        public static double MaxPpO2Deco { get; set; }

        public static double MaxPpO2Dive { get; set; }

        public static double MaxPpN2 { get; set; }

        ///<summary>Respiratorischer Quotient</summary>
        public static double RQ { get; set; }

        ///<summary>Wasserdampfdruck. 47mmHg * 0.00133322 bar/mmHg</summary>
        public static double WaterVaporPressure { get; set; }

        ///<summary>Partialdruck Kohlendioxid. 40mmHg * 0.00133322 bar/mmHg<summary>
        public static double PpCO2 { get; set; }

        public static double CorrectedCO2Pressure { get; } = PpCO2 / RQ;

        /// <summary>Halbwertszeit der ZNS-Entsätigung in Minuten.</summary>
        public static double CnsDesaturationHalfLife { get; set; }
        #endregion

        #region Konstruktor
        static Settings() {
            LoadDefault();
        }
        #endregion

        #region Methoden
        public static void LoadDefault() {
            Mixtures[0] = new MixtureData(MixtureTypeEnum.Surfacegas, 20.946, 0);
            for (int i = 1; i < Mixtures.Length; i++) {
                Mixtures[i] = new MixtureData();
            }
            CurrentMixture = Mixtures[0];

            MinPpO2 = 0.16;
            MaxPpO2Deco = 1.6;
            MaxPpO2Dive = 1.4;
            MaxPpN2 = 3.2;
            RQ = 0.8;
            WaterVaporPressure = 0.06266;
            PpCO2 = 0.05333;
            CnsDesaturationHalfLife = 90;
        }
        #endregion
    }
}
