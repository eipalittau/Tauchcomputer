namespace ETC.Buehlmann {
  public class N2Data : GasData {
    <summary>Nur N2=0.78084; N2+Ar+Ne=0.79020</summary>
    public static float Fraction { get; } = 0.79020;

    public static TissueData[] Tissues { get; }

    static N2Data() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }
    
    <summary>Nur N2=0.78084; N2+Ar+Ne=0.79020</summary>
    public N2Data()
      : base(0.79020) {}

    public new float PI(float pAmbientPressure) {
      return PI(pAmbientPressure);
    }
  }
}
