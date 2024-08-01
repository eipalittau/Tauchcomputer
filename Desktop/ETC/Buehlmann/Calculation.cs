using ETC.Gas;

namespace ETC.Buehlmann {
    public sealed class Calculation {
        public static readonly TissueData[] N2 = [ new TissueData(  4.0, 1.2599, 0.5050),
                                                   new TissueData(  5.0, 1.1696, 0.5577),
                                                   new TissueData(  8.0, 1.0000, 0.6514),
                                                   new TissueData( 12.5, 0.8618, 0.7222),
                                                   new TissueData( 18.5, 0.7562, 0.7825),
                                                   new TissueData( 27.0, 0.6667, 0.8125),
                                                   new TissueData( 38.3, 0.5933, 0.8434),
                                                   new TissueData( 54.3, 0.5282, 0.8693),
                                                   new TissueData( 77.0, 0.4701, 0.8910),
                                                   new TissueData(109.0, 0.4187, 0.9092),
                                                   new TissueData(146.0, 0.3798, 0.9222),
                                                   new TissueData(187.0, 0.3497, 0.9319),
                                                   new TissueData(239.0, 0.3223, 0.9403),
                                                   new TissueData(305.0, 0.2971, 0.9477),
                                                   new TissueData(390.0, 0.2737, 0.9544),
                                                   new TissueData(498.0, 0.2523, 0.9602),
                                                   new TissueData(635.0, 0.2327, 0.9653) ];

        public static readonly TissueData[] He = [ new TissueData(  1.51, 1.7424, 0.4245),
                                                   new TissueData(  1.88, 1.6204, 0.2756),
                                                   new TissueData(  3.02, 1.3830, 0.5747),
                                                   new TissueData(  4.72, 1.1911, 0.6527),
                                                   new TissueData(  6.99, 1.0458, 0.7223),
                                                   new TissueData( 10.21, 0.9220, 0.7582),
                                                   new TissueData( 14.48, 0.8205, 0.7957),
                                                   new TissueData( 20.53, 0.7305, 0.8279),
                                                   new TissueData( 29.11, 0.6502, 0.8553),
                                                   new TissueData( 41.20, 0.5950, 0.8757),
                                                   new TissueData( 55.19, 0.5545, 0.8903),
                                                   new TissueData( 70.69, 0.5333, 0.8997),
                                                   new TissueData( 90.34, 0.5189, 0.9073),
                                                   new TissueData(115.29, 0.5181, 0.9122),
                                                   new TissueData(147.42, 0.5176, 0.9171),
                                                   new TissueData(188.24, 0.5172, 0.9217),
                                                   new TissueData(240.03, 0.5119, 0.9267) ];

        public BuehlmannData Calculate(double pPressureAmbient) {
            BuehlmannData result = new BuehlmannData();

            result.NDL = CalculateNDL(Settings.CurrentMixture, pPressureAmbient);
            result.TTS = CalculateTTS(result.NDL, pPressureAmbient);

            return result;
        }
        
        /// <summary>Berechnet die NDL (Non-Decompression Limit), auch Null-Zeit genannt, basierend auf dem aktuellen Umgebungsdruck.
        /// Das NDL repräsentiert die maximale verbleibende Tauchzeit ohne erforderliche Dekompression.</summary>
        /// <param name="pPressureAmbient">Der aktuelle Umgebungsdruck in bar.</param>
        /// <returns>Das NDL, auch Null-Zeit genannt.</returns>
        /// <remarks>Nullzeit = -t12*log2((PIN2-PTTOLN2)/(PIN2-PTN2))</remarks>
        private int CalculateNDL(double pPressureAmbient) {
            double minNDL = double.MaxValue;

            if (pCurrentMixture.N2.Bar > 0) {
                double pressureInspiratory = Settings.CurrentMixture.N2.CalculatePressureInspiratory(pPressureAmbient);

                for (int i = 0; i < N2.Length; i++) {
                    double numerator = pressureInspiratory - N2[i].CalculatePressureTolerated(pPressureAmbient);
                    double denominator = pressureInspiratory - ContinuousData.CurrentSaturation[0, i];
                    double tempNDL = -N2[i].HalfLife * Math.Log2(numerator / denominator);

                    if (tempNDL < minNDL) {
                        minNDL = tempNDL;
                    }
                }
            }

            if (pCurrentMixture.He.Bar > 0) {
                double pressureInspiratory = Settings.CurrentMixture.He.CalculatePressureInspiratory(pPressureAmbient);

                for (int i = 0; i < He.Length; i++) {
                    double numerator = pressureInspiratory - He[i].CalculatePressureTolerated(pPressureAmbient);
                    double denominator = pressureInspiratory - ContinuousData.CurrentSaturation[1, i];
                    double tempNDL = -He[i].HalfLife * Math.Log2(numerator / denominator);

                    if (tempNDL < minNDL) {
                        minNDL = tempNDL;
                    }
                }
            }

            if (minNDL < 0) {
                return 0;
            } else {
                return (int)Math.Round(minNDL);
            }
        }

        private int CalculateTTS(int pNDL, double pPressureAmbient) {
            int result = (int)Math.Round(pPressureAmbient - ContinuousData.PressureSurface);
            
            if (pNDL < 0) {
                // Dekompression vorausberechnen
                
            }
        }

        private double[,] CalculateDeco(double pPressureAmbient) {

        }

        private void UpdatePressureTissue() {
            //PTIGTE=PTIGT0+(PIIG-PTIGT0)*(1-2^(-TE/T12))
        }
    }
}
