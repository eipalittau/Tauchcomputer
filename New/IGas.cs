namespace ETC.Gas {
  public interface IGas {
    string Name { get; init; }
    double StandardGasFraction { get; init; }
    GasTypeEnum GasType { get; init; }

    static IEnumerable<T> Enumerate<T() where T : GasEnumBase;
    bool EqualsAny<T>(params T[] pOthers) where T : GasEnumBase;
    MixtureGasDTO ToMixtureGas();
    MixtureGasDTO ToMixtureGas(double pGasFraction);
  }
}
