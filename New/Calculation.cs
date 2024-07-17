namespace ETC.Buehlmann {
  public partial class Calculation {
    private float _AmbientPressure;

    private Calculation.N2 InertGas

    public Calculation(float pAmbientPressure) {
      SetAmbientPressure(pAmbientPressure);
    }
    
    public void SetAmbientPressure(float pAmbientPressure) {
      _AmbientPressure = pAmbientPressure;
    }
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    } 
  }
}
