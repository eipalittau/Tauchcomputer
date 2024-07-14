namespace ETC.Buehlmann {
  public abstract GasBase {
    public float Fraction { get; private set; };

    private protected GasBase(float pFraction) {
      Fraction = pFraction;
    }
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * Fraction;
    }
  }
}
