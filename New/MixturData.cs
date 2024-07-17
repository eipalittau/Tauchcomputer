namespace ETC.Buehlmann {
  public class MixturData {
    public List<GasData> Gas { get; } = new List<GasData>();

    public MixturData(params GasData[] pGases) {
      if (pGases?.Lenght > 0) {
        Gas.AddList(pGases);
      }
    }
  }
}
