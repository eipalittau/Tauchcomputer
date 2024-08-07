namespace ETC.Gas {
    public class InertGasEnum : GasEnumBase, IGas {
        #region Properties / Felder
        /// <summary>
        /// Berechnung Koeffizenz A: 2 * (HalfTime ^ (-1/3))
        /// Berechnung Koeffizenz B: 1.005 - 1 * (HalfTime ^ (-1/2))
        /// </summary>
        public static readonly InertGasEnum N2 = new(pName: nameof(N2),
                                      pStandardGasFraction: 0.79020, // Nur N2=0.78084; N2+Ar+Ne=0.79020
                                             pCompartments: [ new CompartmentData(  4.0, 1.2599, 0.5050),
                                                              new CompartmentData(  5.0, 1.1696, 0.5577),
                                                              new CompartmentData(  8.0, 1.0000, 0.6514),
                                                              new CompartmentData( 12.5, 0.8618, 0.7222),
                                                              new CompartmentData( 18.5, 0.7562, 0.7825),
                                                              new CompartmentData( 27.0, 0.6667, 0.8125),
                                                              new CompartmentData( 38.3, 0.5933, 0.8434),
                                                              new CompartmentData( 54.3, 0.5282, 0.8693),
                                                              new CompartmentData( 77.0, 0.4701, 0.8910),
                                                              new CompartmentData(109.0, 0.4187, 0.9092),
                                                              new CompartmentData(146.0, 0.3798, 0.9222),
                                                              new CompartmentData(187.0, 0.3497, 0.9319),
                                                              new CompartmentData(239.0, 0.3223, 0.9403),
                                                              new CompartmentData(305.0, 0.2971, 0.9477),
                                                              new CompartmentData(390.0, 0.2737, 0.9544),
                                                              new CompartmentData(498.0, 0.2523, 0.9602),
                                                              new CompartmentData(635.0, 0.2327, 0.9653) ]);

        public static readonly InertGasEnum He = new(pName: nameof(He),
                                      pStandardGasFraction: 0.000005,
                                             pCompartments: [ new CompartmentData(  1.51, 1.7424, 0.4245),
                                                              new CompartmentData(  1.88, 1.6204, 0.2756),
                                                              new CompartmentData(  3.02, 1.3830, 0.5747),
                                                              new CompartmentData(  4.72, 1.1911, 0.6527),
                                                              new CompartmentData(  6.99, 1.0458, 0.7223),
                                                              new CompartmentData( 10.21, 0.9220, 0.7582),
                                                              new CompartmentData( 14.48, 0.8205, 0.7957),
                                                              new CompartmentData( 20.53, 0.7305, 0.8279),
                                                              new CompartmentData( 29.11, 0.6502, 0.8553),
                                                              new CompartmentData( 41.20, 0.5950, 0.8757),
                                                              new CompartmentData( 55.19, 0.5545, 0.8903),
                                                              new CompartmentData( 70.69, 0.5333, 0.8997),
                                                              new CompartmentData( 90.34, 0.5189, 0.9073),
                                                              new CompartmentData(115.29, 0.5181, 0.9122),
                                                              new CompartmentData(147.42, 0.5176, 0.9171),
                                                              new CompartmentData(188.24, 0.5172, 0.9217),
                                                              new CompartmentData(240.03, 0.5119, 0.9267) ]);
        
        public CompartmentData[] Compartments { get; init; }
        #endregion

        #region Konstruktor
        private InertGasEnum(string pName, double pStandardGasFraction, CompartmentData[] pCompartments)
          : base(pName, pStandardGasFraction, GasTypeEnum.Inert) {
          Compartments = pCompartments;
        }
        #endregion

        #region Methoden
        public CalculateAlveolarPressure(double pSurfacePressure, double pPPO2) {
          double alveolarPressure = pSurfacePressure - Settings.WaterVaporPressure;
          
          return (StandardGasFraction * alveolarPressure) - (MetabilicGasEnum.O2.CalculateAlveolarPressure(pSurfacePressure) + Settings.PpCO2);
        }
            
        public static IEnumerable<InertGasEnum> Enumerate() {
            return Enumerate<InertGasEnum>();
        }

        public bool EqualsAny<T>(params InertGasEnum[] pOthers) {
            return EqualsAny<T>(pOthers);
        }
        #endregion
    }
}
