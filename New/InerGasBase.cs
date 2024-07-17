namespace ETC.Buehlmann {
  public abstract class InerGasBase {
    private protected Calculation _Parent;

    private protected float Fraction { get; set; }

    private protected InerGasBase(Calculation pParent) {
      _Parent = pParent;
    }
      
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private protected float CalculateInspiredPartialPressure(float pBaseFraction) {
      return (_Parent.AmbientPressure - Constant.PH2O) * pBaseFraction;
    }
  }
}
