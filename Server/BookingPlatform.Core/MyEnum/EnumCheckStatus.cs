using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    public enum EnumCheckStatus
    {
        UnFinishBooking = 1000,
        FinishBooking = 1001,
        FinishBookingPrint = 1002,

        ExpiredBooking = 1003,
        CompletedBooking = 1004,

        UnFinishCheck = 1100,
        FinishCheck = 1101,
        Deleted = 9000
    }

    public static class ClassCheckStatus
    {
        public static string GetCheckStatus(EnumCheckStatus d)
        {
            switch (d)
            {
                case EnumCheckStatus.UnFinishBooking: return "未预约";
                case EnumCheckStatus.FinishBooking: return "已预约";
                case EnumCheckStatus.FinishBookingPrint: return "已预约(打印)";
                case EnumCheckStatus.ExpiredBooking: return "已过期";
                case EnumCheckStatus.CompletedBooking: return "预约完成";
                case EnumCheckStatus.UnFinishCheck: return "未检查";
                case EnumCheckStatus.FinishCheck: return "已检查";
                case EnumCheckStatus.Deleted: return "已删除";
                default: return "未知";
            }
        }

        public static int WeekCheckStatus(string code)
        {
            switch (code)
            {
                case "未预约": return (int)(EnumCheckStatus.UnFinishBooking);
                case "已预约": return (int)(EnumCheckStatus.FinishBooking);
                case "已预约(打印)": return (int)(EnumCheckStatus.FinishBookingPrint);
                case "未检查": return (int)(EnumCheckStatus.UnFinishCheck);
                case "已检查": return (int)(EnumCheckStatus.FinishCheck);
                case "已删除": return (int)(EnumCheckStatus.Deleted);
                default: return 0;
            }
        }
    }


    /// <summary>
    /// 检查状态
    /// </summary>
    public enum ExamStatus
    {
        All = 0, //全部
        UnFinishCheck = 1100, //未检查
        FinishCheck = 1101, //已检查
    }

    /// <summary>
    /// 号源状态描述
    /// </summary>
    public enum SourceStatus
    {
        [Description("未使用")]
        UnUse = 0,
        [Description("已使用")]
        Used = 1,
        [Description("已冻结")]
        Frozen = 2
    }
    public static class EnumSourceStatus_Class
    {
        public static string GetSourceStatusNameByCode(int code)
        {
            var sourceStatusName = string.Empty;
            switch (code)
            {
                case 0:
                    sourceStatusName = "未使用";
                    break;
                case 1:
                    sourceStatusName = "已使用";
                    break;
                case 2:
                    sourceStatusName = "已冻结";
                    break;
            }
            return sourceStatusName;
        }
    }

    /// <summary>
    /// 检查状态类型转换
    /// </summary>
    public static class ExamStatus_Class
    {
        public static string Enum2String(ExamStatus d)
        {
            switch (d)
            {
                case ExamStatus.All:
                    return "全部";
                case ExamStatus.UnFinishCheck:
                    return "未检查";
                case ExamStatus.FinishCheck:
                    return "已检查";
                default:
                    return "全部";
            }

        }

        /// <summary>
        /// 枚举字符串转数组
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int EnumString2Int(string code)
        {
            return (int)String2Enum(code);
        }

        /// <summary>
        /// 枚举字符串转枚举
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ExamStatus String2Enum(string code)
        {
            switch (code)
            {
                case "全部": return (ExamStatus.All);
                case "未检查": return (ExamStatus.UnFinishCheck);
                case "已检查": return (ExamStatus.FinishCheck);
                default: return ExamStatus.All;
            }
        }
    }


}
