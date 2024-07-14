namespace ETC.Buehlmann {
  public static class HeData {
    public float Fraction { get; } = 0.000005;

    public TissueData[] Tissues { get; }

    static HeData() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }
  }
}
