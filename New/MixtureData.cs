namespace ETC.Buehlmann {
  public class MixtureData {
    public List<GasData> Gas { get; } = new List<GasData>();

    public int Usage 
    
    public MixtureData(params GasData[] pGases) {
      if (pGases?.Lenght > 0) {
        Gas.AddList(pGases);
      }
    }
  }
}
