namespace ETC {
  public abstract class EnumBase {
    #region Properties / Felder
    public string Name { get; init; }
    #endregion

    #region Konstruktor
    private protected EnumBase(string pName) {
        Name = pName;
    }
    #endregion

    #region Methoden
    private protected static IEnumerable<T> Enumerate<T() where T : EnumBase {
      return typeof(T)
        .GetProperties(BindingFlags.Static | BindingFlags.Public)
        .Select(x => x.GetValue(null))
        .Cast<T>();
    }

    private protected bool EqualsAny<T>(params T[] pOthers) where T : EnumBase {
      return pOthers.Any(x => x.Name.Equals(Name));
    }
    #endregion
  }
}
