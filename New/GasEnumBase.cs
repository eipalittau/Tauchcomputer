namespace ETC.Gas {
  public abstract class GasEnumBase {
    #region Properties / Felder
    public string Name { get; init; }

    public double StandardGasFraction { get; init; }

    public GasTypeEnum GasType { get; init; }
    #endregion

    #region Konstruktor
    private protected GasEnumBase(string pName, double pStandardGasFraction, GasTypeEnum pGasType) {
        Name = pName;
        StandardGasFraction = pStandardGasFraction;
        GasType = pGasType;
    }
    #endregion

    #region Methoden
    private protected static IEnumerable<T> Enumerate<T() where T : GasEnumBase {
      return typeof(T)
        .GetProperties(BindingFlags.Static | BindingFlags.Public)
        .Select(x => x.GetValue(null))
        .Cast<T>();
    }

    private protected bool EqualsAny<T>(params T[] pOthers) where T : GasEnumBase {
      return pOthers.Any(x => x.Name.Equals(Name));
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
