namespace BookingPlatform_QueueArrange.DTO
{
    public class ModalityMaxDate
    {
        /// <summary>
        /// 检查类型Id
        /// </summary>
        public string ModalityId { get; set; }
        /// <summary>
        /// 最大日期
        /// </summary>
        public string MaxDate { get; set; }
        /// <summary>
        /// 即将生成排班的周数
        /// </summary>
        public int WeekCount { get; set; }
    }
}
