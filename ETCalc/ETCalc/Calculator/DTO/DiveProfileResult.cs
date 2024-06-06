namespace ETCalc.Calculator.DTO {
    public class DiveProfileResult {
        public double TTS { get; set; }

        public double NDL { get; set; } = double.MaxValue;

        public DecoStopDTO NextDecoStop { get; } = new ();

        public List<DecoStopDTO> DecoStops { get; } = [];
    }
}