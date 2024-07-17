namespace ETC.Buehlmann {
  public abstract GasBase {
    <summary>Gas-Partialdruck bei 1 bar</summary>
    public float BaseFraction { get; private set; };

    private protected GasBase(float pBaseFraction) {
      BaseFraction = pBaseFraction;
    }
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    }
  }
}
