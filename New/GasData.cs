namespace ETC.Gas {
  public class GasData {
    public IGas Gas { get; set; }

    public double Fraction { get; set; }

    public double CalculatePartialPressure(double pAmbientPressure) {
      return Fraction * pAmbientPressure;
    }
  }
}
