using System.ComponentModel;


namespace BookingPlatform.Common.MyEnum
{
    /// <summary>
    /// 申请入院日期
    /// </summary>
    public enum EnumInHospitalState
    {
        /// <summary>
        /// 三天内
        /// </summary>
        [Description("三天内")]
        ThreeDays = 0,

        /// <summary>
        /// 一周内
        /// </summary>
        [Description("一周内")]
        Week = 1,

        /// <summary>
        /// 一月内
        /// </summary>
        [Description("一月内")]
        Month = 2,
    }

    public static class EnumInHospitalState_Class
    {
        public static string EnumInHospitalState_GetExplainByEnum(EnumInHospitalState ep)
        {
            switch (ep)
            {
                case EnumInHospitalState.ThreeDays: return "三天内";
                case EnumInHospitalState.Week: return "一周内";
                case EnumInHospitalState.Month: return "一月内";
                default: return "其他";
            }
        }

        public static string EnumInHospitalState_GetExplainByInt(int ep)
        {
            switch (ep)
            {
                case 0: return "三天内";
                case 1: return "一周内";
                case 2: return "一月内";
                default: return "其他";
            }
        }
    }

    /// <summary>
    /// 入院状态
    /// </summary>
    public enum EnumAdmissionState
    {
        /// <summary>
        /// 未入院
        /// </summary>
        [Description("未入院")]
        NoAdmission = 0,


        /// <summary>
        /// 已入院
        /// </summary>
        [Description("已入院")]
        AdmittedToHospital = 1
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumBedState
    {
        /// <summary>
        /// 待申请
        /// </summary>
        [Description("待申请")]
        WaitApply = 0,

        /// <summary>
        /// 已申请
        /// </summary>
        [Description("已申请")]
        FinishApply = 1,

        /// <summary>
        /// 已审核
        /// </summary>
        [Description("已审核")]
        FinishVerify = 2,

        /// <summary>
        /// 已入院
        /// </summary>
        [Description("已入院")]
        InHospital = 3,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        FinishCancel = 4,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        FinishRefuse = 5,

        /// <summary>
        /// 已出院
        /// </summary>
        [Description("已出院")]
        OutHospital = 6,
    }

    public static class EnumBedState_Class
    {
        public static string EnumBedState_GetExplainByEnum(EnumBedState ep)
        {
            switch (ep)
            {
                case EnumBedState.WaitApply: return "待申请";
                case EnumBedState.FinishApply: return "已申请";
                case EnumBedState.FinishVerify: return "已审核";
                case EnumBedState.InHospital: return "已入院";
                case EnumBedState.FinishCancel: return "已取消";
                case EnumBedState.FinishRefuse: return "已拒绝";
                case EnumBedState.OutHospital: return "已出院";
                default: return "其他";
            }
        }

        public static string EnumBedState_GetExplainByInt(int ep)
        {
            switch (ep)
            {
                case 0: return "待申请";
                case 1: return "已申请";
                case 2: return "已审核";
                case 3: return "已入院";
                case 4: return "已取消";
                case 5: return "已拒绝";
                case 6: return "已出院";
                default: return "其他";
            }
        }
    }

    /// <summary>
    /// 通知状态
    /// </summary>
    public enum EnumNotificationState
    {
        /// <summary>
        /// 未通知
        /// </summary>
        [Description("未通知")]
        NoNotification = 0,


        /// <summary>
        /// 已通知
        /// </summary>
        [Description("已通知")]
        Informed = 1
    }

    public static class EnumNotificationState_Class
    {
        public static string EnumNotificationState_GetExplainByEnum(EnumNotificationState ep)
        {
            switch (ep)
            {
                case EnumNotificationState.NoNotification: return "未通知";
                case EnumNotificationState.Informed: return "已通知";
                default: return "其他";
            }
        }

        public static string EnumNotificationState_GetExplainByInt(int ep)
        {
            switch (ep)
            {
                case 0: return "未通知";
                case 1: return "已通知";
                default: return "其他";
            }
        }
    }

    /// <summary>
    /// 预约来源
    /// </summary>
    public enum EnumPatientSourceType
    {
        /// <summary>
        /// PC
        /// </summary>
        [Description("PC")]
        PC = 1,


        /// <summary>
        /// 移动端
        /// </summary>
        [Description("移动端")]
        Phone = 2
    }
    /// <summary>
    /// 预约类型，强制预约（不受规则限制）和互斥规则下预约
    /// </summary>
    public enum Enum_BookingType
    {
        /// <summary>
        /// 互斥规则下预约
        /// </summary>
        [Description("互斥规则预约")]
        BookingWithRule = 1,
        /// <summary>
        /// 强制预约
        /// </summary>
        [Description("强制预约")]
        CompulsoryBooking = 2
    }

    public static class EnumPatientSourceType_Class
    {
        public static string EnumPatientSourceType_GetExplainByEnum(EnumPatientSourceType ep)
        {
            switch (ep)
            {
                case EnumPatientSourceType.PC: return "PC";
                case EnumPatientSourceType.Phone: return "移动端";
                default: return "其他";
            }
        }

        public static string EnumPatientSourceType_GetExplainByInt(int ep)
        {
            switch (ep)
            {
                case 1: return "PC";
                case 2: return "移动端";
                default: return "其他";
            }
        }
    }


    /// <summary>
    /// 房间类型
    /// </summary>
    public enum EnumBedType
    {
        /// <summary>
        /// 单人间
        /// </summary>
        [Description("单人间")]
        SingleRoom = 0,
        /// <summary>
        /// 双人间
        /// </summary>
        [Description("双人间")]
        DoubleRooms = 1,
        /// <summary>
        /// 三人间
        /// </summary>
        [Description("三人间")]
        TripleRooms = 2,
        /// <summary>
        /// 四人间
        /// </summary>
        [Description("四人间")]
        QuadRooms = 3,
        /// <summary>
        /// 五人间
        /// </summary>
        [Description("五人间")]
        FiveRooms = 4,
        /// <summary>
        /// 六人间
        /// </summary>
        [Description("六人间")]
        SixRooms = 5,
        /// <summary>
        /// 七人间
        /// </summary>
        [Description("七人间")]
        SevenRooms = 6,
        /// <summary>
        /// 八人间
        /// </summary>
        [Description("八人间")]
        EightRooms = 7
    }
    public static class EnumBedType_Class
    {
        /// <summary>
        /// 通过病房类型代码获取病房类型名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetEnumBedTypeNameByInt(int code)
        {
            var bedTypeName = "";
            switch (code)
            {
                case 0:
                    bedTypeName = "单人间";
                    break;
                case 1:
                    bedTypeName = "双人间";
                    break;
                case 2:
                    bedTypeName = "三人间";
                    break;
                case 3:
                    bedTypeName = "四人间";
                    break;
                case 4:
                    bedTypeName = "五人间";
                    break;
                case 5:
                    bedTypeName = "六人间";
                    break;
                case 6:
                    bedTypeName = "七人间";
                    break;
                case 7:
                    bedTypeName = "八人间";
                    break;
            }
            return bedTypeName;
        }

        /// <summary>
        /// 科室间隔时间
        /// </summary>
        public enum EnumTimeInterval
        {   /// <summary>
            /// 15分钟
            /// </summary>
            [Description("0分钟")]
            SingleMinute = 0,
            /// <summary>
            /// 15分钟
            /// </summary>
            [Description("15分钟")]
            DoubleMinute = 1,
            /// <summary>
            /// 30分钟
            /// </summary>
            [Description("30分钟")]
            TripleMinute = 2,
            /// <summary>
            /// 45分钟
            /// </summary>
            [Description("45分钟")]
            QuadMinute = 3,
            /// <summary>
            /// 60分钟
            /// </summary>
            [Description("60分钟")]
            FiveMinute = 4,

        }

        /// <summary>
        /// 列表间隔时间
        /// </summary>
        public enum EnumCheckqueueType
        {
            /// <summary>
            /// 15分钟
            /// </summary>
            [Description("0分钟")]
            SingleMinute = 0,
            /// <summary>
            /// 15分钟
            /// </summary>
            [Description("15分钟")]
            DoubleMinute = 1,
            /// <summary>
            /// 30分钟
            /// </summary>
            [Description("30分钟")]
            TripleMinute = 2,
            /// <summary>
            /// 45分钟
            /// </summary>
            [Description("45分钟")]
            QuadMinute = 3,
            /// <summary>
            /// 60分钟
            /// </summary>
            [Description("60分钟")]
            FiveMinute = 4,

        }
    }

}