namespace ETC.Buehlmann {
  public sealed class Calculation {
    public List<MixturData> Mixtures;
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    }

    public MixtureData GetBestMix(double pAmbientPressure) {
      List<MixtureData> result = [];
            
      foreach (MixtureData mixture in Settings.Mixtures) {
        if (mixture.IsWithinPPO2(pAmbientPressure)) {
          result.Add(mixture);
        }
      }

      if (result.Count == 0) {
        return null;
      } else if (result.Count == 1) {
        return result[0];
      } else {
        return result.Max(x => x.CalculatePartialPressure(pAmbientPressure));
      }
    }
  }
}
