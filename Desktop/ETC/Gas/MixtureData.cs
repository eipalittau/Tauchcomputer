namespace ETC.Gas {
    public partial class MixtureData {
        #region Properties / Felder
        ///<summary>Partialdruck Helium<summary>
        public GasData He { get; init; }

        ///<summary>Partialdruck Sauerstoff<summary>
        public GasData O2 { get; init; }

        ///<summary>Partialdruck Stickstoff<summary>
        public GasData N2 { get; init; }

        /// <summary>Verwendungszweck des Gases</summary>
        public MixtureTypeEnum Type { get; set; }
        #endregion

        #region Konstruktor
        public MixtureData(MixtureTypeEnum pType, double pO2Percent, double pHePercent)
            : this() {
            Type = pType;
            He.Percent = pHePercent;
            O2.Percent = pO2Percent;
        }
        
        public MixtureData() {
            He = new GasData(0, 99);
            He.Changed += OnChanged;

            O2 = new GasData(1, 100);
            O2.Changed += OnChanged;

            N2 = new GasData(0, 99);
        }
        #endregion

        #region Methoden
        public bool IsWithinPpO2(double pPressureAmbient) {
            double pPO2 = O2.CalculatePressurePartial(pPressureAmbient);

            if (pPO2 < Settings.MinPpO2) {
                return false;
            }

            return Type == MixtureTypeEnum.Travelgas
                ? pPO2 <= Settings.MaxPpO2Dive
                : pPO2 <= Settings.MaxPpO2Deco;
        }

        private void OnChanged(object? sender, GasDataChangedEventArgs e) {
            N2.Percent = 100 - O2.Percent - He.Percent;
        }
        #endregion
    }
}