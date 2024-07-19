namespace ETC.Buehlmann {
  public sealed class Calculation {
    public List<MixturData> Mixtures;
    
    <summary>Partialdruck im Atemgas bei der Einatmung</summary>
    private PI(float pAmbientPressure) {
      return (pAmbientPressure - Constant.PH2O) * BaseFraction;
    }

    private IEnumerable<MixtureData> GetMixturesWithinPPO2(double pAmbientPressure, MixtureTypeEnum pMixtureType) {
            List<MixtureData> result = [];
            double maxPPO2 = pMixtureType == MixtureModeEnum.Dekogas ? Settings.MaximumPPO2Deko : Settings.MaximumPPO2Tg;

            foreach (MixtureData mixture in Mixtures) {
                if (mixture.Mode == pMode) {
                    double ppO2 = pAmbientPressure * mixture.MetabolicGas.Fraction;

                    if (ppO2 >= Settings.MinimumPPO2 && ppO2 <= maxPPO2) {
                        result.Add(mixture);
                    }
                }
            }

            return result;
        }
  }
}
