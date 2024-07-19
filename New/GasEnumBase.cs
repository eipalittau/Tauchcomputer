namespace ETC.Gas {
  public abstract class GasEnumBase : EnumBase {
    #region Properties / Felder
    public double StandardGasFraction { get; init; }

    public GasTypeEnum GasType { get; init; }
    #endregion

    #region Konstruktor
    private protected GasEnumBase(string pName, double pStandardGasFraction, GasTypeEnum pGasType)
    : base(pName) {
        StandardGasFraction = pStandardGasFraction;
        GasType = pGasType;
    }
    #endregion

    #region Methoden
    private protected static IEnumerable<T> Enumerate<T>() {
      return Enumerate<T>();
    }

    private protected bool EqualsAny<T>(params T[] pOthers) {
      return EqualsAny<T>(pOthers);
    }

    #region Convertion
    public MixtureGasDTO ToMixtureGas() {
      return ToMixtureGas(StandardGasFraction);
    }

    public MixtureGasDTO ToMixtureGas(double pGasFraction) {
      return new MixtureGasDTO(this, pGasFraction);
    }
    #endregion
    #endregion
  }
}
