namespace ETC.Gas {
  public sealed class MixtureTypeEnum : EnumBase {
    public static readonly Surfacegas = new MixtureTypeEnum(nameof(Surfacegas), false);
    
    public static readonly Travelgas = new MixtureTypeEnum(nameof(Travelgas), true);
    
    public static readonly Decogas = new MixtureTypeEnum(nameof(Decogas), true);

    public bool IsSelectable { get; init; }
    
    private MixtureTypeEnum(string pName, bool pIsSelectable)
      : base(pName) {
      IsSelectable = pIsSelectable;
  }
}
