namespace ETC.Buehlmann {
  public static partial class Constant {
    public static class N2 {
      <summary>Gas-Partialdruck bei 1 bar. Nur N2=0.78084; N2+Ar+Ne=0.79020</summary>
      public static float BaseFraction { get; } = 0.79020;
      
      public static CompartmentData[] Compartment { get; } = new CompartmentData[] {
        new CompartmentData(  4.0, 1.2599, 0.5050),
        new CompartmentData(  5.0, 1.1696, 0.5578),
        new CompartmentData(  8.0, 1.0000, 0.6514),
        new CompartmentData( 12.5, 0.8618, 0.7222),
        new CompartmentData( 18.5, 0.7562, 0.7825),
        new CompartmentData( 27.0, 0.6200, 0.8125),
        new CompartmentData( 38.3, 0.5043, 0.8434),
        new CompartmentData( 54.3, 0.4410, 0.8693),
        new CompartmentData( 77.0, 0.4000, 0.8910),
        new CompartmentData(109.0, 0.3750, 0.9092),
        new CompartmentData(146.0, 0.3500, 0.9222),
        new CompartmentData(187.0, 0.3295, 0.9319),
        new CompartmentData(239.0, 0.3065, 0.9403),
        new CompartmentData(305.0, 0.2835, 0.9477),
        new CompartmentData(390.0, 0.2610, 0.9544),
        new CompartmentData(498.0, 0.2480, 0.9602),
        new CompartmentData(635.0, 0.2327, 0.9653)
      };
    }
  }
}
