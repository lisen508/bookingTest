using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    public enum EnumPeriod
    {
        Morning = 1,
        Nooning = 2,
        Afternoon = 3,
        Night = 4,


        Other = 0,
    }

    public static class EnumPeriod_Class
    {
        public static string EnumPeriod_GetExplainByEnum(EnumPeriod ep)
        {
            switch (ep)
            {
                case EnumPeriod.Morning: return "上午";
                case EnumPeriod.Nooning: return "中午";
                case EnumPeriod.Afternoon: return "下午";
                case EnumPeriod.Night: return "夜间";
                default: return "其他";
            }
        }
        public static int EnumPeriod_GetExplainByTime(string t)
        {
            switch (t)
            {
                case "上午": return 1;
                case "中午": return 2;
                case "下午": return 3;
                case "夜间": return 4;
                default: return 0;
            }
        }
        public static string EnumPeriod_GetExplainByInt(int i)
        {
            switch (i)
            {
                case 1: return "上午";
                case 2: return "中午";
                case 3: return "下午";
                case 4: return "夜间";
                default: return "其他";
            }
        }

        public static EnumPeriod EnumPeriod_GetEnum(string e)
        {
            switch (e)
            {
                case "上午": return EnumPeriod.Morning;
                case "中午": return EnumPeriod.Nooning;
                case "下午": return EnumPeriod.Afternoon;
                case "夜间": return EnumPeriod.Night;
                default: return EnumPeriod.Other;
            }
        }


        /// <summary>
        /// 科室检查时间
        /// </summary>
        public static class EnumTimeInterval_Class
        {
            public static string EnumTimeInterval_GetEnum(string TimeInterval)
            {
                switch (TimeInterval)
                {
                    case "0": return "0分钟";
                    case "1": return "15分钟";
                    case "2": return "30分钟";
                    case "3": return "45分钟";
                    default: return "60分钟";
                }
            }
            public static int EnumTimeInterval_GetIntByDBInt(int timeInterval)
            {
                switch (timeInterval)
                {
                    case 0: return 0;
                    case 1: return 15;
                    case 2: return 30;
                    case 3: return 45;
                    case 4: return 60;
                    default: return 0;
                }
            }
        }

        public static class EnumCheckqueueType_Class
        {
            public static string EnumCheckqueueType_GetEnum(string TimeInterval)
            {
                switch (TimeInterval)
                {
                    case "0": return "0分钟";
                    case "1": return "15分钟";
                    case "2": return "30分钟";
                    case "3": return "45分钟";
                    default: return "60分钟";
                }
            }
        }

        public enum EnumExamInterval
        {
            [Description("不设置")]
            None = 1,
            [Description("启用检查科室间隔")]
            ExamClinicInterval = 2,
            [Description("启用检查队列间隔")]
            ExamQueueInterval = 3
        }

        public static class EnumExamInterval_Class
        {
            public static EnumExamInterval EnumExamInterval_GetEnumByInt(int code)
            {
                switch (code)
                {
                    case 1: return EnumExamInterval.None;
                    case 2: return EnumExamInterval.ExamClinicInterval;
                    case 3: return EnumExamInterval.ExamQueueInterval;
                    default: return EnumExamInterval.None;
                }
            }
            public static string EnumExamInterval_GetStringByEnum(EnumExamInterval eg)
            {
                switch (eg)
                {
                    case EnumExamInterval.None: return "不设置";
                    case EnumExamInterval.ExamClinicInterval: return "启用检查科室间隔";
                    case EnumExamInterval.ExamQueueInterval: return "启用检查队列间隔";
                    default: return "不设置";
                }
            }
            public static int EnumExamInterval_GetIntByEnum(EnumExamInterval eg)
            {
                switch (eg)
                {
                    case EnumExamInterval.None: return 1;
                    case EnumExamInterval.ExamClinicInterval: return 2;
                    case EnumExamInterval.ExamQueueInterval: return 3;
                    default: return 1;
                }
            }
        }
    }
}