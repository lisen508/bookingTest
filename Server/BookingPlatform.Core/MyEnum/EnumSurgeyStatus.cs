using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    /// <summary>
    /// 预约状态枚举
    /// </summary>
    public enum EnumSurgeyStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        WaitCheck = 1,
        /// <summary>
        /// 已取消（申请取消）
        /// </summary>
        ApplyCanceled = 2,
        /// <summary>
        /// 审核通过
        /// </summary>
        Pass = 3,
        /// <summary>
        /// 已取消（审核取消）
        /// </summary>
        CheckCanceled = 4,
        /// <summary>
        /// 已拒绝（审核通过)
        /// </summary>
        PassRefuse = 5,
        /// <summary>
        /// 已拒绝（未审核）
        /// </summary>
        Refuse = 6

    }

    /// <summary>
    /// 操作原因
    /// </summary>
    public enum EnumORType
    {
        /// <summary>
        /// 取消
        /// </summary>
        OCancel = 0,

        /// <summary>
        /// (审核前)拒绝
        /// </summary>
        ORefuse = 1,

        /// <summary>
        /// (审核后)拒绝
        /// </summary>
        OCheckRefuse = 2,
    }
    /// <summary>
    /// 操作方式
    /// </summary>
    public enum Enum_HandleType
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        ADD = 0,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        UPDATE = 1,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        DELETE = 2
    }


    /// <summary>
    /// 手机申请记录过滤条件(日期）
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// 一周
        /// </summary>
        [Description("一周")]
        Week = 0,

        /// <summary>
        /// 一个月
        /// </summary>
        [Description("一个月")]
        Month = 1,

        /// <summary>
        /// 三个月
        /// </summary>
        [Description("三个月")]
        ThreeMonths = 2,

        /// <summary>
        /// 一年
        /// </summary>
        [Description("一年")]
        Year = 3,


        /// <summary>
        /// 一年
        /// </summary>
        [Description("全部")]
        All = 4

    }
}