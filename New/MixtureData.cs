namespace ETC.Buehlmann {
  public class MixtureData {
    public List<GasData> Gas { get; } = new List<GasData>();

    public MixtureTypeEnum MixtureType { get; set; }
    
    public MixtureData(MixtureTypeEnum pMixtureType, params GasData[] pGases) {
      MixtureType = pMixtureType;
      if (pGases?.Lenght > 0) {
        Gas.AddList(pGases);
      }
    }
  }
}
