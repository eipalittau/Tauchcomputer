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

            /// <summary>Maximaler prozentualer Anteil des Gases in der Mixtur</summary>
            private readonly double _Max;

            /// <summary>Minimaler prozentualer Anteil des Gases in der Mixtur</summary>
            private readonly double _Min;
            #endregion

            #region Konstruktor
            internal GasData(double pMin, double pMax) {
                _Max = pMax;
                _Min = pMin;
            }
            #endregion

            #region Methoden
                //Berechnet den aktuellen Partial-Druck.
            public double CalculatePressurePartial(double pPressureAmbient) {
                return pPressureAmbient * Bar;
            }

            /// <summary>Partialdruck im Atemgas bei der Einatmung.</summary>
            /// <param name="pPressureAmbient">Der aktuelle Umgebungsdruck in bar.</param>
            /// <returns></returns>
            /// <remarks>PIN2 = (PAMB - 0.0627) * 0.7902</remarks>
            public double CalculatePressureInspiratory(double pPressureAmbient) {
                return (pPressureAmbient - Settings.WaterVaporPressure) * Bar;
            }

            private void ExecuteChanged(double pOldValue, double pNewValue) {
                Changed?.Invoke(this, new GasDataChangedEventArgs(pOldValue, pNewValue));
            }
            #endregion
        }
    }
}
