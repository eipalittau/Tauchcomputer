namespace ETC.Buehlmann {
  public class Calculation {
    public class N2 : InertGasBase, IInertGas {
      public float Fraction { get; internal set; }

      private N2(Calculation pParent) : base(pParent) { }
      
      <summary>Partialdruck im Atemgas bei der Einatmung</summary>
      public float CalculateInspiredPartialPressure() {
        return CalculateInspiredPartialPressure(Constant.N2.BaseFraction);
      }
    }
  }
}
