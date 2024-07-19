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

    public bool IsWithinPPO2(double pAmbientPressure) {
      double ppO2 = Gases
        .Where(x => x.GasType == GasTypeEnum.Metabolic)
        .CalculatePartialPressure(pAmbientPressure);

      if (ppO2 > Settings.MinPpO2) {
        if (MixtureType == MixtureTypeEnum.Decogas) {
          return ppO2 < Settings.MaxPpO2Deco;
        } else {
          return ppO2 < Settings.MaxPpO2Dive;
        }
      } else {
        return false;
      }
    }
  }
}
