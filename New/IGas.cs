namespace ETC.Buehlmann {
  public interface IGas {
    string Name { get; init; }
    
    double StandardGasFraction { get; init; }

    GasTypeEnum GasType { get; init; }
    
  }
}
