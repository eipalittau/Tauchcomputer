namespace ETC {
  public static class Settings {
    public List<MixturData> Mixtures { get; set; }

    public float MinPpO2 { get; set; }

    public float MaxPpO2Deco { get; set; }

    public float MaxPpO2Dive { get; set; }

    public double MaxPpN2 { get; set; }

    static Settings() {
      Mixtures = new List<MixtureData>();
      MinPpO2 = 0.16;
      MaxPpO2Deco = 1.6;
      MaxPpO2Dive = 1.4;
      MaxPpN2 = 3;
  }
}
