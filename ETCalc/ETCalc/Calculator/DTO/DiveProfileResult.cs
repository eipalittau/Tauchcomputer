namespace ETCalc.Calculator.DTO {
    public class DiveProfileResult {
        public double TTS { get; set; }

        public double NDL { get; set; }

        public double MaxAscentHeight { get; set; }

        public double TimeAtMaxAscentHeight { get; set; }

        public List<DecoStopDTO> DecoStops { get; set; } = [];
    }
}