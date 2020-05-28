using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    /// <summary>
    /// 检查项目的预约渠道
    /// </summary>
    public enum EnumExamItemBookingChannel
    {
        [Description("自动预约")]
        AutoBooking = 1,
        [Description("手机预约")]
        PhoneBooking = 2,
        [Description("PC预约")]
        PCBooking = 3,
        [Description("自助机预约")]
        AutoMachineBooking = 4
    }

    /// <summary>
    /// 检查项目预约渠道枚举处理类
    /// </summary>
    public static class EnumExamItemBookingChannel_Class
    {
        /// <summary>
        /// 通过预约渠道代码获取预约渠道名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumBookingChannel_GetBookingChannelNameByCode(int? code)
        {
            var bookingChannel = "";
            switch (code)
            {
                case 1:
                    bookingChannel = "自动预约";
                    break;
                case 2:
                    bookingChannel = "手机预约";
                    break;
                case 3:
                    bookingChannel = "PC预约";
                    break;
                case 4:
                    bookingChannel = "自助机预约";
                    break;
            }
            return bookingChannel;
        }

        /// <summary>
        /// 通过预约渠道名称获取预约渠道枚举
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static EnumExamItemBookingChannel EnumBookingChannel_GetChannelEnumByName(string channelName)
        {
            var channelEnum = new EnumExamItemBookingChannel();
            switch (channelName)
            {
                case "自动预约":
                    channelEnum = EnumExamItemBookingChannel.AutoBooking;
                    break;
                case "手机预约":
                    channelEnum = EnumExamItemBookingChannel.PhoneBooking;
                    break;
                case "PC预约":
                    channelEnum = EnumExamItemBookingChannel.PCBooking;
                    break;
                case "自助机预约":
                    channelEnum = EnumExamItemBookingChannel.AutoMachineBooking;
                    break;
            }
            return channelEnum;
        }

        /// <summary>
        /// 通过预约渠道枚举获取预约渠道名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumBookingChannel_GetChannelNameByEnum(EnumExamItemBookingChannel em)
        {
            var channelName = "";
            switch (em)
            {
                case EnumExamItemBookingChannel.AutoBooking:
                    channelName = "自动预约";
                    break;
                case EnumExamItemBookingChannel.PhoneBooking:
                    channelName = "手机预约";
                    break;
                case EnumExamItemBookingChannel.PCBooking:
                    channelName = "PC预约";
                    break;
                case EnumExamItemBookingChannel.AutoMachineBooking:
                    channelName = "自助机预约";
                    break;
            }
            return channelName;
        }

        /// <summary>
        /// 通过预约渠道枚举获取预约渠道代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumBookingChannel_GetChannelCodeByEnum(EnumExamItemBookingChannel em)
        {
            var channelCode = 0;
            switch (em)
            {
                case EnumExamItemBookingChannel.AutoBooking:
                    channelCode = 1;
                    break;
                case EnumExamItemBookingChannel.PhoneBooking:
                    channelCode = 2;
                    break;
                case EnumExamItemBookingChannel.PCBooking:
                    channelCode = 3;
                    break;
                case EnumExamItemBookingChannel.AutoMachineBooking:
                    channelCode = 4;
                    break;
            }
            return channelCode;
        }
    }

    /// <summary>
    /// 检查队列属性
    /// </summary>
    public enum EnumExamQueueProperty
    {
        [Description("门诊")]
        OutPatient = 1,
        [Description("住院")]
        InHospital = 2,
        [Description("急诊")]
        Emergency = 3,
        [Description("VIP")]
        VIP = 4
    }
    /// <summary>
    /// 检查队列属性枚举处理类
    /// </summary>
    public static class EnumQueueProperty_Class
    {
        /// <summary>
        /// 通过队列属性代码获取队列属性名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumQueueProperty_GetQueuePropertyNameByCode(int code)
        {
            var queueProperty = "";
            switch (code)
            {
                case 1:
                    queueProperty = "门诊";
                    break;
                case 2:
                    queueProperty = "住院";
                    break;
                case 3:
                    queueProperty = "急诊";
                    break;
                case 4:
                    queueProperty = "VIP";
                    break;
            }
            return queueProperty;
        }

        /// <summary>
        /// 通过队列属性名称获取队列属性枚举
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static EnumExamQueueProperty EnumQueueProperty_GetQueuePropertyEnumByName(string channelName)
        {
            var queuePropertyEnum = new EnumExamQueueProperty();
            switch (channelName)
            {
                case "门诊":
                    queuePropertyEnum = EnumExamQueueProperty.OutPatient;
                    break;
                case "住院":
                    queuePropertyEnum = EnumExamQueueProperty.InHospital;
                    break;
                case "急诊":
                    queuePropertyEnum = EnumExamQueueProperty.Emergency;
                    break;
                case "VIP":
                    queuePropertyEnum = EnumExamQueueProperty.VIP;
                    break;
            }
            return queuePropertyEnum;
        }

        /// <summary>
        /// 通过队列属性枚举获取队列属性名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumQueueProperty_GetQueuePropertyNameByEnum(EnumExamQueueProperty em)
        {
            var queuePropertyName = "";
            switch (em)
            {
                case EnumExamQueueProperty.OutPatient:
                    queuePropertyName = "门诊";
                    break;
                case EnumExamQueueProperty.InHospital:
                    queuePropertyName = "住院";
                    break;
                case EnumExamQueueProperty.Emergency:
                    queuePropertyName = "急诊";
                    break;
                case EnumExamQueueProperty.VIP:
                    queuePropertyName = "VIP";
                    break;
            }
            return queuePropertyName;
        }

        /// <summary>
        /// 通过队列属性枚举获取队列属性代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumQueueProperty_GetQueuePropertyCodeByEnum(EnumExamQueueProperty em)
        {
            var queuePropertyCode = 0;
            switch (em)
            {
                case EnumExamQueueProperty.OutPatient:
                    queuePropertyCode = 1;
                    break;
                case EnumExamQueueProperty.InHospital:
                    queuePropertyCode = 2;
                    break;
                case EnumExamQueueProperty.Emergency:
                    queuePropertyCode = 3;
                    break;
                case EnumExamQueueProperty.VIP:
                    queuePropertyCode = 4;
                    break;
            }
            return queuePropertyCode;
        }
    }

    /// <summary>
    /// 检查队列号源有效期属性
    /// </summary>
    public enum EnumQueueSourceValidTime
    {
        [Description("默认系统配置")]
        DefaultSetting = 0,
        [Description("7天")]
        SevenDays = 1,
        [Description("14天")]
        FourteenDays = 2,
        [Description("1个月")]
        OneMonth = 3,
        [Description("2个月")]
        TwoMonths = 4
    }

    /// <summary>
    /// 检查队列号源有效期枚举处理类
    /// </summary>
    public static class EnumQueueSourceValidTime_Class
    {
        /// <summary>
        /// 通过号源有效期代码获取号源有效期名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumQueueSourceValidTime_GetSourceValidTimeNameByCode(int code)
        {
            var sourceValidTime = "";
            switch (code)
            {
                case 0:
                    sourceValidTime = "默认系统配置";
                    break;
                case 1:
                    sourceValidTime = "7天";
                    break;
                case 2:
                    sourceValidTime = "14天";
                    break;
                case 3:
                    sourceValidTime = "1个月";
                    break;
                case 4:
                    sourceValidTime = "2个月";
                    break;
            }
            return sourceValidTime;
        }

        /// <summary>
        /// 通过号源有效期名称获取号源有效期枚举
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EnumQueueSourceValidTime EnumQueueSourceValidTime_GetSourceValidTimeEnumByName(string name)
        {
            var sourceValidTimeEnum = new EnumQueueSourceValidTime();
            switch (name)
            {
                case "默认系统配置":
                    sourceValidTimeEnum = EnumQueueSourceValidTime.DefaultSetting;
                    break;
                case "7天":
                    sourceValidTimeEnum = EnumQueueSourceValidTime.SevenDays;
                    break;
                case "14天":
                    sourceValidTimeEnum = EnumQueueSourceValidTime.FourteenDays;
                    break;
                case "1个月":
                    sourceValidTimeEnum = EnumQueueSourceValidTime.OneMonth;
                    break;
                case "2个月":
                    sourceValidTimeEnum = EnumQueueSourceValidTime.TwoMonths;
                    break;
            }
            return sourceValidTimeEnum;
        }

        /// <summary>
        /// 通过号源有效期枚举获取号源有效期名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumQueueSourceValidTime_GetSourceValidTimeNameByEnum(EnumQueueSourceValidTime em)
        {
            var sourceValidTimeName = "";
            switch (em)
            {
                case EnumQueueSourceValidTime.DefaultSetting:
                    sourceValidTimeName = "默认系统配置";
                    break;
                case EnumQueueSourceValidTime.SevenDays:
                    sourceValidTimeName = "7天";
                    break;
                case EnumQueueSourceValidTime.FourteenDays:
                    sourceValidTimeName = "14天";
                    break;
                case EnumQueueSourceValidTime.OneMonth:
                    sourceValidTimeName = "1个月";
                    break;
                case EnumQueueSourceValidTime.TwoMonths:
                    sourceValidTimeName = "2个月";
                    break;
            }
            return sourceValidTimeName;
        }

        /// <summary>
        /// 通过号源有效期枚举获取号源有效期代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumQueueSourceValidTime_GetSourceValidTimeCodeByEnum(EnumQueueSourceValidTime em)
        {
            var sourceValidTimeCode = 0;
            switch (em)
            {
                case EnumQueueSourceValidTime.DefaultSetting:
                    sourceValidTimeCode = 0;
                    break;
                case EnumQueueSourceValidTime.SevenDays:
                    sourceValidTimeCode = 1;
                    break;
                case EnumQueueSourceValidTime.FourteenDays:
                    sourceValidTimeCode = 2;
                    break;
                case EnumQueueSourceValidTime.OneMonth:
                    sourceValidTimeCode = 3;
                    break;
                case EnumQueueSourceValidTime.TwoMonths:
                    sourceValidTimeCode = 4;
                    break;
            }
            return sourceValidTimeCode;
        }
    }
}
