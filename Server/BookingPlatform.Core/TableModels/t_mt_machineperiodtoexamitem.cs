namespace BookingPlatform.Core.TableModels
{
    public class t_mt_machineperiodtoexamitem
    {
        public string ID { get; set; }
        public int? Week { get; set; }
        public string ExamItemID { get; set; }
        public string QueueID { get; set; }
        public string MachinePeriodID { get; set; }
        public string MachinePeriodSummaryID { get; set; }
        public int IsDelete { get; set; }
    }
}
