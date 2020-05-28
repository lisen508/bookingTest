using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    #region 预约规则配置TAB

    public enum Enum_BookingRuleConfigTab
    {
        [Description("PC功能配置")]
        PCConfig = 1,
        [Description("手机/自助机功能配置")]
        PhoneAndAutoConfig = 2,
        [Description("有效期配置")]
        ValidConfig = 3
    }

    #endregion

    #region 号源预约有效期设置

    /// <summary>
    /// 自助机号源预约有效期设置
    /// </summary>
    public enum EnumAuto_SourceValidTime
    {
        [Description("7天内")]
        SevenDays = 0,
        [Description("14天内")]
        FourteenDays = 1,
        [Description("1个月内")]
        OneMonth = 2,
        [Description("2个月内")]
        TwoMonths = 3,
    }
    /// <summary>
    /// PC端独享号源方式
    /// </summary>
    public enum Enum_PCSourcePossessStyle
    {
        [Description("不设置")]
        NoSetting = 0,
        [Description("按比例独享")]
        RatePossession = 1,
        [Description("按具体号数独享")]
        ConcreteSourcePossession = 2
    }
    /// <summary>
    /// 号源顺序显示方式
    /// </summary>
    public enum Enum_SourceDisplayOrderStyle
    {
        [Description("全天顺序显示")]
        DisplayWholeDay = 0,
        [Description("具体时段顺序显示")]
        DisplayConcretePeriod = 1
    }
    /// <summary>
    /// 自助机号源预约有效期 枚举处理类
    /// </summary>
    public static class ClassAuto_SourceValidTime
    {
        public static string GetAuto_SourceValidTime(EnumAuto_SourceValidTime d)
        {
            switch (d)
            {
                case EnumAuto_SourceValidTime.SevenDays: return "7天内";
                case EnumAuto_SourceValidTime.FourteenDays: return "14天内";
                default: return "未知";
            }
        }

        public static int Auto_SourceValidTimeValue(string code)
        {
            switch (code)
            {
                case "7天内": return (int)(EnumAuto_SourceValidTime.SevenDays);
                case "14天内": return (int)(EnumAuto_SourceValidTime.FourteenDays);
                default: return 0;
            }
        }
    }

    /// <summary>
    /// 手机端号源预约有效期设置
    /// </summary>
    public enum EnumPhone_SourceValidTime
    {
        [Description("七天内")]
        SevenDays = 0,
        [Description("十四天内")]
        FourteenDays = 1
    }
    /// <summary>
    /// 手机号源预约有效期 枚举处理类
    /// </summary>
    public static class ClassPhone_SourceValidTime
    {
        public static string GetPhone_SourceValidTimes(EnumPhone_SourceValidTime d)
        {
            switch (d)
            {
                case EnumPhone_SourceValidTime.SevenDays: return "7天内";
                case EnumPhone_SourceValidTime.FourteenDays: return "14天内";
                default: return "未知";
            }
        }

        public static int Phone_SourceValidTimeValue(string code)
        {
            switch (code)
            {
                case "7天内": return (int)(EnumPhone_SourceValidTime.SevenDays);
                case "14天内": return (int)(EnumPhone_SourceValidTime.FourteenDays);
                default: return 0;
            }
        }
    }

    /// <summary>
    /// PC端号源预约有效期设置
    /// </summary>
    public enum EnumPC_SourceValidTime
    {
        [Description("七天内")]
        SevenDays = 0,
        [Description("十四天内")]
        FourteenDays = 1
    }
    /// <summary>
    /// PC端号源预约有效期 枚举处理类
    /// </summary>
    public static class ClassPC_SourceValidTime
    {
        public static string GetPC_SourceValidTimes(EnumPC_SourceValidTime d)
        {
            switch (d)
            {
                case EnumPC_SourceValidTime.SevenDays: return "7天内";
                case EnumPC_SourceValidTime.FourteenDays: return "14天内";
                default: return "未知";
            }
        }

        public static int PC_SourceValidTimeValue(string code)
        {
            switch (code)
            {
                case "7天内": return (int)(EnumPC_SourceValidTime.SevenDays);
                case "14天内": return (int)(EnumPC_SourceValidTime.FourteenDays);
                default: return 0;
            }
        }
    }
    #endregion

    #region 申请单预约有效期设置 【迭代6B新增】
    /// <summary>
    /// 自助机申请单预约有效期设置
    /// </summary>
    public enum EnumAuto_BKValidTime
    {
        [Description("无限制")]
        UnLimit = 0,
        [Description("七天内")]
        SevenDays = 1,
        [Description("十四天内")]
        FourteenDays = 2,
        [Description("一个月内")]
        OneMonth = 3
    }
    /// <summary>
    /// 自助机端申请单预约有效期 枚举处理类
    /// </summary>
    public static class ClassAuto_BKValidTime
    {
        public static string GetAuto_BKValidTimes(EnumAuto_BKValidTime d)
        {
            switch (d)
            {
                case EnumAuto_BKValidTime.UnLimit: return "无限制";
                case EnumAuto_BKValidTime.SevenDays: return "7天内";
                case EnumAuto_BKValidTime.FourteenDays: return "14天内";
                case EnumAuto_BKValidTime.OneMonth: return "一个月内";
                default: return "未知";
            }
        }

        public static int Auto_BKValidTimeValue(string code)
        {
            switch (code)
            {
                case "无限制": return (int)(EnumAuto_BKValidTime.UnLimit);
                case "7天内": return (int)(EnumAuto_BKValidTime.SevenDays);
                case "14天内": return (int)(EnumAuto_BKValidTime.FourteenDays);
                case "一个月内": return (int)(EnumAuto_BKValidTime.OneMonth);
                default: return 0;
            }
        }
    }

    /// <summary>
    /// 手机端申请单预约有效期设置
    /// </summary>
    public enum EnumPhone_BKValidTime
    {
        [Description("无限制")]
        UnLimit = 0,
        [Description("七天内")]
        SevenDays = 1,
        [Description("十四天内")]
        FourteenDays = 2,
        [Description("一个月内")]
        OneMonth = 3
    }
    /// <summary>
    /// 手机端申请单预约有效期 枚举处理类
    /// </summary>
    public static class ClassPhone_BKValidTime
    {
        public static string GetPhone_BKValidTimes(EnumPhone_BKValidTime d)
        {
            switch (d)
            {
                case EnumPhone_BKValidTime.UnLimit: return "无限制";
                case EnumPhone_BKValidTime.SevenDays: return "7天内";
                case EnumPhone_BKValidTime.FourteenDays: return "14天内";
                case EnumPhone_BKValidTime.OneMonth: return "一个月内";
                default: return "未知";
            }
        }

        public static int Phone_BKValidTimeValue(string code)
        {
            switch (code)
            {
                case "无限制": return (int)(EnumPhone_BKValidTime.UnLimit);
                case "7天内": return (int)(EnumPhone_BKValidTime.SevenDays);
                case "14天内": return (int)(EnumPhone_BKValidTime.FourteenDays);
                case "一个月内": return (int)(EnumPhone_BKValidTime.OneMonth);
                default: return 0;
            }
        }
    }

    /// <summary>
    /// PC端申请单预约有效期设置
    /// </summary>
    public enum EnumPC_BKValidTime
    {
        [Description("无限制")]
        UnLimit = 0,
        [Description("七天内")]
        SevenDays = 1,
        [Description("十四天内")]
        FourteenDays = 2,
        [Description("一个月内")]
        OneMonth = 3
    }
    /// <summary>
    /// PC端申请单预约有效期 枚举处理类
    /// </summary>
    public static class ClassPC_BKValidTime
    {
        public static string GetPC_BKValidTimes(EnumPC_BKValidTime d)
        {
            switch (d)
            {
                case EnumPC_BKValidTime.UnLimit: return "无限制";
                case EnumPC_BKValidTime.SevenDays: return "7天内";
                case EnumPC_BKValidTime.FourteenDays: return "14天内";
                case EnumPC_BKValidTime.OneMonth: return "一个月内";
                default: return "未知";
            }
        }

        public static int PC_BKValidTimeValue(string code)
        {
            switch (code)
            {
                case "无限制": return (int)(EnumPC_BKValidTime.UnLimit);
                case "7天内": return (int)(EnumPC_BKValidTime.SevenDays);
                case "14天内": return (int)(EnumPC_BKValidTime.FourteenDays);
                case "一个月内": return (int)(EnumPC_BKValidTime.OneMonth);
                default: return 0;
            }
        }
    }

    #endregion

    /// <summary>
    /// 自助机预约时段显示配置
    /// </summary>
    public enum EnumAuto_ShowPeriodConfig
    {
        ShowCanBookingPeriod = 0,
        ShowAllBookingPeriod = 1
    }

    #region 预约配置配置类型
    public enum Enum_SystemConfigType
    {
        //配置类型 1:bool型 2:单选框型 3:复选框型 4:下拉框型 5:输入框型
        [Description("滑块bool型")]
        Slide = 1,
        [Description("单选框型")]
        Radio = 2,
        [Description("复选框型")]
        CheckBox = 3,
        [Description("下拉框型")]
        DropDownBox = 4,
        [Description("输入框型")]
        Input = 5
    }
    public static class Enum_ClassSystemConfig
    {
        /// <summary>
        /// 根据预约配置类型代码获取配置枚举
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public static Enum_SystemConfigType GetConfigTypeEnumByInt(int typeId)
        {
            switch (typeId)
            {
                case 1: return Enum_SystemConfigType.Slide;
                case 2: return Enum_SystemConfigType.Radio;
                case 3: return Enum_SystemConfigType.CheckBox;
                case 4: return Enum_SystemConfigType.DropDownBox;
                case 5: return Enum_SystemConfigType.Input;
                default: return Enum_SystemConfigType.Slide;
            }
        }
    }
    #endregion

    public static class ClassAuto_ShowPeriodConfig
    {
        public static string GetAuto_ShowPeriodConfig(EnumAuto_ShowPeriodConfig d)
        {
            switch (d)
            {
                case EnumAuto_ShowPeriodConfig.ShowCanBookingPeriod: return "只显示可约时段";
                case EnumAuto_ShowPeriodConfig.ShowAllBookingPeriod: return "显示全部预约时段";
                default: return "未知";
            }
        }

        public static int Auto_ShowPeriodConfigValue(string code)
        {
            switch (code)
            {
                case "只显示可约时段": return (int)(EnumAuto_ShowPeriodConfig.ShowCanBookingPeriod);
                case "显示全部预约时段": return (int)(EnumAuto_ShowPeriodConfig.ShowAllBookingPeriod);
                default: return 0;
            }
        }
    }

    /// <summary>
    /// 检查预约页面号源显示配置
    /// </summary>
    public enum EnumAuto_ShowSourceNoConfig
    {
        ShowDetailSource = 0,
        ShowDetailPeriod = 1
    }
    /// <summary>
    /// 平仓规则类型/by yeheping 2019-06-17
    /// </summary>
    public static class Enum_ClassPositionClosingRule
    {
        public static string GetPositionClosingRuleTypeNameByCode(string code)
        {
            switch (code)
            {
                default: return "平均分配";
                    //default: return "未知";
            }
        }
    }
    public enum Enum_PositionClosingRuleType
    {
        /// <summary>
        /// 平均分配
        /// </summary>
        [Description("平均分配")]
        EqualDivision = 1

        //[Description("未知")]
        //Other = 0
    }
    public static class ClassAuto_ShowSourceNoConfig
    {
        public static string GetAuto_ShowQueueConfig(EnumAuto_ShowSourceNoConfig d)
        {
            switch (d)
            {
                case EnumAuto_ShowSourceNoConfig.ShowDetailSource: return "具体号源显示";
                case EnumAuto_ShowSourceNoConfig.ShowDetailPeriod: return "只展示预约时段";
                default: return "未知";
            }
        }

        public static int Auto_ShowQueueConfigValue(string code)
        {
            switch (code)
            {
                case "具体号源显示": return (int)(EnumAuto_ShowSourceNoConfig.ShowDetailSource);
                case "只展示预约时段": return (int)(EnumAuto_ShowSourceNoConfig.ShowDetailPeriod);
                default: return 0;
            }
        }
    }


    //预约日期状态
    public enum BookDateStatus
    {
        //无
        Nothing = 2,
        //余
        MoreThan = 0,
        //满
        Full = 1
    }


    public static class ClassBookDateStatus
    {
        /// <summary>
        /// 枚举转文字
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string Enum2String(BookDateStatus d)
        {
            switch (d)
            {
                case BookDateStatus.Full: return "满";
                case BookDateStatus.Nothing: return "无";
                case BookDateStatus.MoreThan: return "余";
                default: return "未知";
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
        public static BookDateStatus String2Enum(string code)
        {
            switch (code)
            {
                case "满": return (BookDateStatus.Full);
                case "无": return (BookDateStatus.Nothing);
                case "余": return (BookDateStatus.MoreThan);
                default: return BookDateStatus.Nothing;
            }
        }
    }

    #region 医技预约日期状态


    //预约日期状态
    public enum SchedulingStatus
    {
        //无
        Nothing = 2,
        //余
        MoreThan = 0,
        //满
        Full = 1,
        //无号源
        NoNum = 3,
    }


    public static class ClassSchedulingStatus
    {
        /// <summary>
        /// 枚举转文字
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string Enum2String(SchedulingStatus d)
        {
            switch (d)
            {
                case SchedulingStatus.Full: return "满";
                case SchedulingStatus.Nothing: return "无";
                case SchedulingStatus.MoreThan: return "余";
                case SchedulingStatus.NoNum: return "无号";
                default: return "未知";
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
        public static SchedulingStatus String2Enum(string code)
        {
            switch (code)
            {
                case "满": return (SchedulingStatus.Full);
                case "无": return (SchedulingStatus.Nothing);
                case "余": return (SchedulingStatus.MoreThan);
                case "无号": return (SchedulingStatus.NoNum);
                default: return SchedulingStatus.Nothing;
            }
        }
    }
    #endregion

    /// <summary>
    /// 日间手术申请单审批状态
    /// </summary>
    public enum EnumDaySurgicalStatus
    {
        [Description("已申请")]
        WaitAuth = 1,
        [Description("已审核")]
        Approval = 2,
        [Description("已拒绝")]
        Rejection = 3,
        [Description("已取消")]
        Cancel = 4,
        [Description("已签到")]
        CheckIn = 5
    }
    /// <summary>
    /// 日间手术入院状态
    /// </summary>
    public enum EnumDaySurgicalAdmissionStatus
    {
        [Description("已签到")]
        CheckIn = 1,
        [Description("已入院")]
        Admitted = 2,
        [Description("已出院")]
        Discharged = 3
    }
    #region 排班状态
    /// <summary>
    /// 门诊预约排班状态
    /// </summary>
    public enum SchedulingState
    {
        Stop = 0,//停诊 
        Visit = 1, //出诊
        OneApplicationForSuspension = 3, //停诊申请
        MiniApplicationForSuspension = 4, //停诊申请
    }

    public class ClassSchedulingState
    {
        /// <summary>
        /// 枚举转文字
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string Enum2String(SchedulingState d)
        {
            switch (d)
            {
                case SchedulingState.Stop: return "停诊";
                case SchedulingState.Visit: return "出诊";
                case SchedulingState.OneApplicationForSuspension: return "停诊申请(单)";
                case SchedulingState.MiniApplicationForSuspension: return "停诊申请(长）";
                default: return "未知";
            }
        }

        /// <summary>
        /// 枚举转文字
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string Enum2StringS(SchedulingState d)
        {
            switch (d)
            {
                case SchedulingState.Stop: return "已停诊";
                case SchedulingState.Visit: return "出诊";
                case SchedulingState.OneApplicationForSuspension: return "申请中";
                case SchedulingState.MiniApplicationForSuspension: return "申请中";
                default: return "未知";
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
        public static SchedulingState String2Enum(string code)
        {
            switch (code)
            {
                case "停诊": return (SchedulingState.Stop);
                case "出诊": return (SchedulingState.Visit);
                case "停诊申请(单)": return (SchedulingState.OneApplicationForSuspension);
                case "停诊申请(长)": return (SchedulingState.MiniApplicationForSuspension);
                default: return SchedulingState.Visit;
            }
        }
    }
    #endregion


}
