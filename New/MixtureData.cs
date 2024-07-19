namespace ETC.Gas {
  public sealed class MixtureData {
    public List<GasData> Gases { get; } = new List<GasData>();

    public MixtureTypeEnum MixtureType { get; set; }
    
    public MixtureData(MixtureTypeEnum pMixtureType, params GasData[] pGases) {
      MixtureType = pMixtureType;
      if (pGases?.Lenght > 0) {
        Gas.AddList(pGases);
      }
    }

    public bool IsWithinPPO2() {
      return true;
    }
  }
}
