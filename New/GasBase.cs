namespace ETC.Buehlmann {
  public abstract GasBase {
    private protected GasBase() {}
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure, float pGasFraction) {
      return (pAmbientPressure - Constant.PH2O) * pGasFraction;
    }
  }
}
