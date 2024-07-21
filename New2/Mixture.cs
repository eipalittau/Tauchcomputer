namespace ETC.Gas {
  public sealed class Mixture {
    ///<summary>Partialdruck Sauerstoff<summary>
    public double O2 { get; set; }

    ///<summary>Partialdruck Helium<summary>
    public double He { get; set; }

    ///<summary>Partialdruck Stickstoff<summary>
    public double N2 {
      get {
        return 100 - O2 - He;
      }
    }
  }
}
