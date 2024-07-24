using ETC.Gas;

namespace ETC.Buehlmann {
    public sealed class Calculation {
        public bool IsWithinPPO2(double pAmbientPressure) {
            for (int i = 1; i < Settings.Mixtures.Length; i++) {
                if (Settings.Mixtures[i].O2 * pAmbientPressure)
            }

            Settings.Mixtures.Where(x => x.Type == )
            foreach (MixtureData mix in Settings.Mixtures) {

            }

            double ppO2 = Settings.Mixtures Gases
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