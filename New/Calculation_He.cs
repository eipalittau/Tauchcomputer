namespace ETC.Buehlmann {
  public class Calculation {
    public class He : InertGasBase, IInertGas {
      private He(Calculation pParent)
        : base(pParent) { }
      
      <summary>Partialdruck im Atemgas bei der Einatmung</summary>
      public float CalculateInspiredPartialPressure() {
        return CalculateInspiredPartialPressure(Constant.He.BaseFraction);
      }
    }
  }
}
