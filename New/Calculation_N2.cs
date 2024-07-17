namespace ETC.Buehlmann {
  public class Calculation {
    public class N2 {
      public float AmbientPressure { get; private set; }
      
      public float Fraction { get; private set; }
      
      public SetAmbientPressure(float pAmbientPressure) {
        AmbientPressure = pAmbientPressure;
        Fraction = Constant.N2.BaseFraction * pAmbientPressure;
      }
      
      <summary>Partialdruck im Atemgas bei der Einatmung</summary>
      public float PIN2(float pAmbientPressure) {
        return (pAmbientPressure - Constant.PH2O) * Constant.N2.BaseFraction;
      }
    }
  }
}
