namespace ETC.Gas {
  public sealed class Mixture {
    public MixtureTypeEnum Type { get; set; } = MixtureTypeEnum.Surfacegas;
    
    ///<summary>Partialdruck Sauerstoff<summary>
    public double O2 { get; set; } = 20.946

    ///<summary>Partialdruck Helium<summary>
    public double He { get; set; } = 0;

    ///<summary>Partialdruck Stickstoff<summary>
    public double N2 {
      get {
        return 100 - O2 - He;
      }
    }
  }
}
