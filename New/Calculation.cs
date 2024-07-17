namespace ETC.Buehlmann {
  public partial class Calculation {
    public void SetAmbientPressure
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    } 
  }
}
