namespace ETC {
  public static class Settings {
    public Mixture[] Mixtures { get; private set; }

    static Settings() {
      Mixtures = new Mixture[6];
      Mixture[0] = new Mixture();
    }
  }
}
