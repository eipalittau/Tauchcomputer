using ETC.Gas;

namespace ETC {
    public static class Settings {
        #region Properties / Felder
        public static Mixture?[] Mixtures { get; } = new Mixture[6];

        public static int ActiveMixtureIndex { get; set; }
        
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
        #endregion

        #region Konstruktor
        static Settings() {
            LoadDefault();
        }
        #endregion

        #region Methoden
        public static void LoadDefault() {
            Mixtures[0] = new Mixture() {
                He = 0,
                O2 = 20.946,
                Type = MixtureTypeEnum.Surfacegas
            };

            for (int i = 1; i < Mixtures.Length; i++) {
                Mixtures[i] = null;
            }
            ActiveMixtureIndex = 0;
            MinPpO2 = 0.16;
            MaxPpO2Deco = 1.6;
            MaxPpO2Dive = 1.4;
            MaxPpN2 = 3.2;
            RQ = 0.8;
            WaterVaporPressure = 0.06266;
            PpCO2 = 0.05333;
        }
        #endregion
    }
}
