namespace ETC.Buehlmann {
  public class HeData : GasData {
    public static float Fraction { get; } = 0.000005;

    public static TissueData[] Tissues { get; }

    static HeData() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }

    public HeData() {}

    public float PIHe(float pAmbientPressure) {
      return base.PI(pAmbientPressure, Fraction);
    }
  }
}
