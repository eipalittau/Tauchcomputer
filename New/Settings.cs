namespace ETC {
  public static class Settings {
    public static List<MixturData> Mixtures { get; set; }

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

    static Settings() {
      LoadDefaults();
    }

    public static LoadDefaults() {
      Mixtures = new List<MixtureData>();
      MinPpO2 = 0.16;
      MaxPpO2Deco = 1.6;
      MaxPpO2Dive = 1.4;
      MaxPpN2 = 3.2;
      RQ = 0.8;
      WaterVaporPressure = 0.06266;
      PpCO2 = 0.05333
    }
  }
}
