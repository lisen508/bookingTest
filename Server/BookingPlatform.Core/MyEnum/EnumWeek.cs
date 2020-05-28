using System;

namespace BookingPlatform.Common.MyEnum
{
    public static class EnumWeek_Class
    {
        public static string EnumWeek_GetWeekName(DayOfWeek date)
        {
            switch (date)
            {
                case DayOfWeek.Monday: return "星期一";
                case DayOfWeek.Tuesday: return "星期二";
                case DayOfWeek.Wednesday: return "星期三";
                case DayOfWeek.Thursday: return "星期四";
                case DayOfWeek.Friday: return "星期五";
                case DayOfWeek.Saturday: return "星期六";
                case DayOfWeek.Sunday: return "星期日";
                default: return "未知";
            }
        }


        public static string EnumWeek_GetZName(DayOfWeek date)
        {
            switch (date)
            {
                case DayOfWeek.Monday: return "周一";
                case DayOfWeek.Tuesday: return "周二";
                case DayOfWeek.Wednesday: return "周三";
                case DayOfWeek.Thursday: return "周四";
                case DayOfWeek.Friday: return "周五";
                case DayOfWeek.Saturday: return "周六";
                case DayOfWeek.Sunday: return "周日";
                default: return "未知";
            }
        }

        public static DateTime EnumWeek_GetMonday(DateTime dt)
        {
            do
            {
                if (dt.DayOfWeek == DayOfWeek.Monday) return dt;

                dt = dt.AddDays(-1);
            }
            while (true);
        }
    }
}