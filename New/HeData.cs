namespace ETC.Buehlmann {
  public class HeData : GasData {
    public static TissueData[] Tissues { get; }

    static HeData() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }

    public HeData()
      : base(0.000005) {}

    public new float PI(float pAmbientPressure) {
      return PI(pAmbientPressure);
    }
  }
}
