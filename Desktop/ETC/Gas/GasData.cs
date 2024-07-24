namespace ETC.Gas {
    public partial class MixtureData {
        public class GasData {
            internal event EventHandler<GasDataChangedEventArgs>? Changed;

            #region Properties / Felder
            private double _Percent = double.MinValue;

            ///<summary>Partialdruck in Prozent<summary>
            public double Percent {
                get {
                    return _Percent;
                }
                set {
                    if (_Percent != value && value >= _Min && value <= _Max) {
                        ExecuteChanged(value, _Percent);
                        _Percent = value;
                        Bar = _Percent / 100;
                    }
                }
            }

            ///<summary>Partialdruck in Bar<summary>
            public double Bar { get; private set; }

            private readonly double _Max;

            private readonly double _Min;
            #endregion

            #region Konstruktor
            internal GasData(double pMin, double pMax) {
                _Max = pMax;
                _Min = pMin;
            }
            #endregion

            #region Methoden
            public double CalculatePressurePartial(double pPressureAmbient) {
                return Bar * pPressureAmbient;
            }

            private void ExecuteChanged(double pOldValue, double pNewValue) {
                Changed?.Invoke(this, new GasDataChangedEventArgs(pOldValue, pNewValue));
            }
            #endregion
        }
    }
}