namespace ETC.Buehlmann {
  public abstract class InertGasBase {
    private protected Calculation _Parent;

    private protected float Fraction { get; set; }

    private protected InertGasBase(Calculation pParent) {
      _Parent = pParent;
    }
      
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected float CalculateInspiredPartialPressure(float pStandardGasFraction) {
      return (_Parent.AmbientPressure - Constant.PH2O) * pStandardGasFraction;
    }
  }
}
