namespace ETC.Buehlmann {
  public class Calculation {
    public class N2 : IInertGas {
      public float Fraction { get; internal set; }

      private Calculation _Parent;

      private N2(Calculation pParent) {
        _Parent = pParent;
      }
      
      <summary>Partialdruck im Atemgas bei der Einatmung</summary>
      public float PIN2() {
        return (_Parent - Constant.PH2O) * Constant.N2.BaseFraction;
      }
    }
  }
}
