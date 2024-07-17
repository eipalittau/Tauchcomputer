namespace ETC.Buehlmann {
  public sealed class Calculation {
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    } 
  }
}
