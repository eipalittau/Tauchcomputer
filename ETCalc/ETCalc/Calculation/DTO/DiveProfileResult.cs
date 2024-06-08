namespace ETCalc.Calculation.DTO {
    public class DiveProfileResult {
        public double TTS { get; set; }

        public double NDL { get; set; } = double.MaxValue;

        public DecoStopDTO NextDecoStop { get; }

        public List<DecoStopDTO> DecoStops { get; }

        public DiveProfileResult() {
            DecoStops = [];
            NDL = double.MaxValue;
            NextDecoStop = new ();
        }
    }
}