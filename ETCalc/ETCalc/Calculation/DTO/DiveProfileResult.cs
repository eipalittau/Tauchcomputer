namespace ETCalc.Calculation.DTO {
    public class DiveProfileResult {
        public double TTS { get; set; }

        public double NDL { get; set; }

        public List<DecoStopDTO>? DecoStops { get; set; }
    }
}