namespace BookingPlatform.Core.DataInPut
{
    public class ArrangeSpecialStop
    {
        public string Theme { get; set; } = string.Empty;
        public string StopStartDate { get; set; } = string.Empty;
        public string StopStartPeriod { get; set; } = string.Empty;
        public string StopEndDate { get; set; } = string.Empty;
        public string StopEndPeriod { get; set; } = string.Empty;
        public string OutClinicIDList { get; set; } = string.Empty;
        public string TArrangeSpecialStopID { get; set; }
    }
}