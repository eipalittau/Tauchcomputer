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
    public static IEnumerable<GasEnum> Enumerate() {
            return typeof(InertGasEnum)
                .GetProperties(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.GetValue(null))
                .Cast<InertGasEnum>();
        }

        public bool EqualsAny(params InertGasEnum[] pOthers) {
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
