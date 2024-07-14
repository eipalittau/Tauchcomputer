namespace ETC.Buehlmann {
  public static class N2Data {
    <summary>Nur N2=0.78084; N2+Ar+Ne=0.79020</summary>
    public float Fraction { get; } = 0.79020;

    public TissueData[] Tissues { get; }

    static N2Data() {
      Tissues = {
        new TissueData() { Halftime: 1, A: 1, B: 1 }
      }
    }
  }
}
