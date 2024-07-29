namespace ETC.Gas {
    public class Calculation {
        private readonly static ExpositionData[] O2ExpositionLimits = [ new ExpositionData(0.50,   0.00, int.MaxValue),
                                                                        new ExpositionData(0.60,   0.14, 714),
                                                                        new ExpositionData(0.64,   0.15, 667),
                                                                        new ExpositionData(0.66,   0.16, 625),
                                                                        new ExpositionData(0.68,   0.17, 588),
                                                                        new ExpositionData(0.70,   0.18, 556),
                                                                        new ExpositionData(0.74,   0.19, 526),
                                                                        new ExpositionData(0.76,   0.20, 500),
                                                                        new ExpositionData(0.78,   0.21, 476),
                                                                        new ExpositionData(0.80,   0.22, 455),
                                                                        new ExpositionData(0.82,   0.23, 435),
                                                                        new ExpositionData(0.84,   0.24, 417),
                                                                        new ExpositionData(0.86,   0.25, 400),
                                                                        new ExpositionData(0.88,   0.26, 385),
                                                                        new ExpositionData(0.90,   0.28, 357),
                                                                        new ExpositionData(0.92,   0.29, 345),
                                                                        new ExpositionData(0.94,   0.30, 333),
                                                                        new ExpositionData(0.96,   0.31, 323),
                                                                        new ExpositionData(0.98,   0.32, 313),
                                                                        new ExpositionData(1.00,   0.33, 303),
                                                                        new ExpositionData(1.02,   0.35, 286),
                                                                        new ExpositionData(1.04,   0.36, 278),
                                                                        new ExpositionData(1.06,   0.38, 263),
                                                                        new ExpositionData(1.08,   0.40, 250),
                                                                        new ExpositionData(1.10,   0.42, 238),
                                                                        new ExpositionData(1.12,   0.43, 233),
                                                                        new ExpositionData(1.14,   0.43, 233),
                                                                        new ExpositionData(1.16,   0.44, 227),
                                                                        new ExpositionData(1.18,   0.46, 217),
                                                                        new ExpositionData(1.20,   0.47, 213),
                                                                        new ExpositionData(1.22,   0.48, 208),
                                                                        new ExpositionData(1.24,   0.51, 196),
                                                                        new ExpositionData(1.26,   0.52, 192),
                                                                        new ExpositionData(1.28,   0.54, 185),
                                                                        new ExpositionData(1.30,   0.56, 179),
                                                                        new ExpositionData(1.32,   0.57, 175),
                                                                        new ExpositionData(1.34,   0.60, 167),
                                                                        new ExpositionData(1.36,   0.62, 161),
                                                                        new ExpositionData(1.38,   0.63, 159),
                                                                        new ExpositionData(1.40,   0.65, 154),
                                                                        new ExpositionData(1.42,   0.68, 147),
                                                                        new ExpositionData(1.44,   0.71, 141),
                                                                        new ExpositionData(1.46,   0.74, 135),
                                                                        new ExpositionData(1.48,   0.78, 128),
                                                                        new ExpositionData(1.50,   0.83, 120),
                                                                        new ExpositionData(1.52,   0.93, 108),
                                                                        new ExpositionData(1.54,   1.04,  96),
                                                                        new ExpositionData(1.56,   1.19,  84),
                                                                        new ExpositionData(1.58,   1.47,  68),
                                                                        new ExpositionData(1.60,   2.22,  45),
                                                                        new ExpositionData(1.62,   5.00,  20),
                                                                        new ExpositionData(1.65,   6.25,  16),
                                                                        new ExpositionData(1.67,   7.69,  13),
                                                                        new ExpositionData(1.70,  10.00,  10),
                                                                        new ExpositionData(1.72,  12.50,   8),
                                                                        new ExpositionData(1.74,  20.00,   5),
                                                                        new ExpositionData(1.77,  25.00,   4),
                                                                        new ExpositionData(1.79,  31.25,   3),
                                                                        new ExpositionData(1.80,  50.00,   2),
                                                                        new ExpositionData(1.82, 100.00,   1) ];
        
        /// <summary></summary>
        /// <param name="pPressureAmbient">Umgebungsdruck in Bar.</param>
        /// <param name="pTimeExposition">Expositionszeit in Sekunden.</param>
        public void UpdateCnsSaturation(double pPressureAmbient, int pTimeExposition) {
            if (pPressureAmbient < 0.3) {
                //Entsättigung
                //CNS %(t) = CNS % * (½)t/90 = CNS % * e–t/130
                if (ContinousData.CurrentCnsExposition > 0) {
                    ContinousData.CurrentCnsExposition *= Math.Exp(-pTimeExposition / 130.0);
                    
                    if (ContinuousData.CurrentCnsExposition < 0) {
                        ContinuousData.CurrentCnsExposition = 0;
                    }
                }
            } else {
                //Aufsättigung
                if (pPressureAmbient <= O2ExpositionLimits[0].PressurePartial) {
                    return;
                } else if (pPressureAmbient > O2ExpositionLimits[O2ExpositionLimits.Length - 1].PressurePartial) {
                    ContinuousData.CurrentCnsExposition += O2ExpositionLimits[O2ExpositionLimits.Length - 1].CalculateStress(pTimeExposition);
                    return;
                }

                 foreach (ExpositionData exp in O2ExpositionLimits) {
                    if (exp.PressurePartial >= pPressureAmbient) {
                        ContinuousData.CurrentCnsExposition += exp.CalculateStress(pTimeExposition);
                        return;
                    }
                }
            }
        }

        public IEnumerable<MixtureData> GetMixturesWithinPpO2(double pPressureAmbient, MixtureTypeEnum pMixtureType) {
            return Settings.Mixtures.Skip(1)
                .Where(x => x.Type == pMixtureType
                         && x.IsWithinPpO2(pPressureAmbient));
        }
    }
}
