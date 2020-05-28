using System.Collections.Generic;

namespace BookingPlatform.Core.DataOutput
{
    #region 1.统一号源池 图形支持
    /// <summary>
    /// 号源池统计平台传输模型
    /// </summary>
    public class StaticSourceModelOutput
    {
        /// <summary>
        /// 平台数据列表
        /// </summary>
        public List<StaticSourcePlatModel> dataPlatList { get; set; }
        /// <summary>
        /// 平台数据列表(按月)
        /// </summary>
        public List<StaticSourceMonthModel> dataMonthList { get; set; }

    }
    /// <summary>
    /// 按月统计号源数据模型
    /// </summary>
    public class StaticSourceMonthModel
    {
        /// <summary>
        /// 月份
        /// </summary>
        public string month { get; set; }
        /// <summary>
        /// 值/数量
        /// </summary>
        public string count { get; set; }
    }
    /// <summary>
    /// 按平台统计号源模型
    /// </summary>
    public class StaticSourcePlatModel
    {
        /// <summary>
        /// 平台ID
        /// </summary>
        public string platformId { get; set; }

        /// <summary>
        /// 平台名称
        /// </summary>
        public string platformName { get; set; }

        /// <summary>
        /// 平台的值/数量
        /// </summary>
        public string total { get; set; }

        /// <summary>
        /// 比率
        /// </summary>
        public string ratio { get; set; }
    }

    #endregion

    #region 2.床位预约统计输出对象
    /// <summary>
    /// 床位预约统计输出对象
    /// </summary>
    public class StaticBedBookingModelOutput
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<StaticBedBooking> dataList { get; set; }

    }
    /// <summary>
    /// 床位预约统计模型
    /// </summary>
    public class StaticBedBooking
    {
        /// <summary>
        /// 病房类型名称
        /// </summary>
        public string roomTypeText { get; set; }
        /// <summary>
        /// 病房类型
        /// </summary>
        public string roomType { get; set; }
        /// <summary>
        /// 病房申请数
        /// </summary>
        public string applyCount { get; set; }
    }
    #endregion

    #region 3.手术预约输出对象
    /// <summary>
    /// 手术预约传输对象
    /// </summary>
    public class StaticSurgerModelOutput
    {

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<StaticSurgerModel> dataList { get; set; }
    }

    /// <summary>
    /// 手术预约统计模型
    /// </summary>
    public class StaticSurgerModel
    {
        /// <summary>
        /// 手术台名称
        /// </summary>
        public string stageName { get; set; }
        /// <summary>
        /// 手术台ID
        /// </summary>
        public string stageId { get; set; }
        /// <summary>
        /// 释放个数
        /// </summary>
        public string releaseCount { get; set; }
        /// <summary>
        /// 使用个数
        /// </summary>
        public string useCount { get; set; }
        /// <summary>
        /// 比率
        /// </summary>
        public string ratio { get; set; }

    }
    #endregion

    #region 4.医技预约统计输出对象

    /// <summary>
    /// 1.队列数据图形模型支撑
    /// </summary>
    public class StaticQueueSourceModel
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<QueueSourceModel> dataList { get; set; }
    }
    /// <summary>
    /// 2.医技（整体分析）--医技预约统计类型返回格式
    /// </summary>
    public class StaticMTModelOutput
    {
        /// <summary>
        /// 预约总数
        /// </summary>
        public totalCountModel dataCount { get; set; }
        /// <summary>
        /// 检查类型列表（含总的，今天的和昨天的）
        /// </summary>
        public List<clinicModelOutput> clinicList { get; set; }

        /// <summary>
        /// 病人类型分组占比数据
        /// </summary>
        public List<PatientTypeModelOutput> patientList { get; set; }



    }

    /// <summary>
    /// 预约总数类
    /// </summary>
    public class totalCountModel
    {
        /// <summary>
        /// 总次数
        /// </summary>
        public string totalCount { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public string totalPersons { get; set; }
        /// <summary>
        /// 今天总数
        /// </summary>
        public string todayCount { get; set; }
        /// <summary>
        /// 昨日总数
        /// </summary>
        public string ysCount { get; set; }

    }
    /// <summary>
    ///3.医技（整体分析）--统计时长输出对象
    /// </summary>
    public class StaticDurationModelOutput
    {
        /// <summary>
        /// 类别
        /// </summary>
        public string type { get; set; }

        /// <summary>
        ///混合结构数据
        /// </summary>
        public List<DurationDateModel> dateList { get; set; }

    }
    /// <summary>
    /// 时间段模型
    /// </summary>
    public class DurationModel
    {
        /// <summary>
        /// 组名称
        /// </summary>
        public string groupName { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<xModelOutput> dataList { get; set; }
    }

    /// <summary>
    /// 时间段模型
    /// </summary>
    public class DurationDateModel
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<xModelOutput> dataList { get; set; }
    }

    /// <summary>
    /// X坐标的值
    /// </summary>
    public class xModelOutput
    {
        /// <summary>
        /// 数据昵称
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string total { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string date { get; set; }
    }

    /// <summary>
    /// 检查类型输出类
    /// </summary>
    public class clinicModelOutput
    {
        /// <summary>
        /// 检查类型名称
        /// </summary>
        public string clinicName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 占比%
        /// </summary>
        public string ratio { get; set; }
        /// <summary>
        /// 今天统计的数量
        /// </summary>
        public string tcount { get; set; }
        /// <summary>
        /// 昨天统计的数量
        /// </summary>
        public string ycount { get; set; }

    }
    /// <summary>
    /// 患者类型输出类
    /// </summary>
    public class PatientTypeModelOutput
    {
        /// <summary>
        /// 类型枚举值
        /// </summary>
        public string typeId { get; set; }
        /// <summary>
        /// 患者类型
        /// </summary>
        public string typeName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string count { get; set; }

    }
    /// <summary>
    /// 队列模型
    /// </summary>
    public class QueueSourceModel
    {
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// 释放号源数
        /// </summary>
        public string totalCount { get; set; } = "0";
        /// <summary>
        /// 取消号源数据
        /// </summary>
        public string cancelCount { get; set; } = "0";
        /// <summary>
        /// 预约号源数
        /// </summary>
        public string bookCount { get; set; } = "0";
        /// <summary>
        /// 预约率
        /// </summary>
        public string ratio { get; set; } = "0";
    }

    #endregion
}
