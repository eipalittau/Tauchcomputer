namespace ETC.Buehlmann {
  public static class O2Data {
    public float Fraction { get; } = 0.20948;

    public TissueData[] Tissues { get; }

    static O2Data() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }
  }
}
