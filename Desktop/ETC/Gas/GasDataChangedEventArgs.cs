namespace ETC.Gas {
    public sealed class GasDataChangedEventArgs {
        public double OldValue { get; init; }

        public double NewValue { get; init; }

        internal GasDataChangedEventArgs(double pOldValue, double pNewValue)
            => (OldValue, NewValue) = (pOldValue, pNewValue);
    }
}