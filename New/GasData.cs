namespace ETC.Gas {
  public class GasData {
    public IGas Gas { get; set; }

    public float Fraction { get; set; }

    public bool IsWithinPpO2(float pAmbientPressure) {
      float fraction = Fraction * pAmbientPressure;
      
    }
  }
}
