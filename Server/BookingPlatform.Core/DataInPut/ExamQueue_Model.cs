
using BookingPlatform.Core.TableModels;
using System.Collections.Generic;

namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 检查队列-日期-时段
    /// </summary>
    public class QueueValidArrangeModel
    {

        /// <summary>
        /// 队列Id
        /// </summary>
        public string QueueId { get; set; }
        /// <summary>
        /// 预约日期
        /// </summary>
        public string QueueArrangeDate { get; set; }
        /// <summary>
        /// 预约时段
        /// </summary>
        public int? QueueArrangePeriod { get; set; }
    }

    /// <summary>
    /// 自助机需要展示的队列和号源列表
    /// </summary>
    public class AutoMachineQueueValidArrangeModel
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public AutoMachineQueueValidArrangeModel()
        {
            SourceDateInfoList = new List<SimpleSourceDateInfo>();
        }

        /// <summary>
        /// 队列Id
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }

        /// <summary>
        /// 号源日期信息列表
        /// </summary>
        public List<SimpleSourceDateInfo> SourceDateInfoList { get; set; }
    }

    /// <summary>
    /// 号源日期信息
    /// </summary>
    public class SimpleSourceDateInfo
    {
        /// <summary>
        /// 号源日期
        /// </summary>
        public string SourceDate { get; set; }

        /// <summary>
        /// 周几
        /// </summary>
        public string WeekDay { get; set; }

        /// <summary>
        /// 号源是否满 0/1--->未满/已满
        /// </summary>
        public int IsFull { get; set; }
        /// <summary>
        /// 是否是已预约 0：否 1：是
        /// </summary>
        public int IsBookedRecord { get; set; } = 0;
        
    }

    /// <summary>
    /// 时段号源情况
    /// </summary>
    public class PeriodSourceInfo
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public PeriodSourceInfo()
        {
            SourecInfoList = new List<SourceInfo>();
        }

        /// <summary>
        /// 时段
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// 时段文本显示
        /// </summary>
        public string PeriodText { get; set; }

        /// <summary>
        /// 时段内展示的号源概况
        /// </summary>
        public List<SourceInfo> SourecInfoList { get; set; }
    }

    /// <summary>
    /// 号源信息
    /// </summary>
    public class SourceInfo
    {
        /// <summary>
        /// 号源时段
        /// </summary>
        public int SourcePeriod { get; set; }
        /// <summary>
        /// 是否约满 0/1:未满/已满
        /// </summary>
        public int IsFull { get; set; } = 0;

        /// <summary>
        /// 自助机预约时段余号显示配置 0/1:关闭/开启
        /// </summary>
        public int ShowType { get; set; } = 0;

        /// <summary>
        /// 剩余号源个数
        /// </summary>
        public int RemainSourceCount { get; set; }

        /// <summary>
        /// 起始时段
        /// </summary>
        public string PeriodStart { get; set; }

        /// <summary>
        /// 结束时段
        /// </summary>
        public string PeriodEnd { get; set; }

        /// <summary>
        /// 号源所在时段
        /// </summary>
        public string PeriodTimeText { get; set; }

        /// <summary>
        /// 是否是已预约的记录1 是已预约的号段记录 0：不是
        /// </summary>
        public int IsBookedRecord { get; set; } = 0;

    }

    /// <summary>
    /// 起始/结束 日期
    /// </summary>
    public class ValidDatePeriod
    {
        /// <summary>
        /// 起始日期
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }
    }

    /// <summary>
    /// 队列起始/结束 日期
    /// </summary>
    public class QueueValidDatePeriod
    {
        public QueueValidDatePeriod()
        {
            ValidPeriod = new ValidDatePeriod();
        }
        /// <summary>
        /// 队列ID
        /// </summary>
        public string QueueID { get; set; }
        /// <summary>
        /// 起始/结束 日期 model
        /// </summary>
        public ValidDatePeriod ValidPeriod { get; set; }
    }

    /// <summary>
    /// 队列在时段的号源列表
    /// </summary>
    public class QueuePeriodSourceList
    {
        /// <summary>
        /// 队列ID
        /// </summary>
        public string QueueId { get; set; }
        /// <summary>
        /// 队列所在日期 yyyyMMdd
        /// </summary>
        public string YMD { get; set; }
        /// <summary>
        /// 队列所在时段
        /// </summary>
        public int Period { get; set; }
        /// <summary>
        /// 队列在时段的号源列表
        /// </summary>
        public List<t_mt_sourcepool> SourcePoolList { get; set; }
    }
}
