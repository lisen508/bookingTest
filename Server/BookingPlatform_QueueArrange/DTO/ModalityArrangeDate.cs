using BookingPlatform_QueueArrange.EntityModel;
using System.Collections.Generic;

namespace BookingPlatform_QueueArrange.DTO
{
    public class ModalityArrangeDate
    {
        /// <summary>
        /// 检查类型和生成的排班日期列表对象
        /// </summary>
        public ModalityArrangeDate()
        {
            ArrangeDateList = new List<t_mt_queuearrangemain>();
        }
        /// <summary>
        /// 检查类型Id
        /// </summary>
        public string ModalityId { get; set; }
        /// <summary>
        /// 检查类型名称
        /// </summary>
        public string Modality { get; set; }
        public List<t_mt_queuearrangemain> ArrangeDateList { get; set; }
    }

    /// <summary>
    /// 日期格式
    /// </summary>
    public class DateFormat
    {
        /// <summary>
        /// 具体时段Id
        /// </summary>
        public string WeekId { get; set; }
        /// <summary>
        /// 具体时段起始日期
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 具体时段结束日期
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 当前时段所处的序号
        /// </summary>
        public int SequenceNumber { get; set; }
    }
}
