using Newtonsoft.Json;
using System;

namespace BookingPlatform_InitialHospital
{
    /// <summary>
    /// DateTime类型转换String扩展类
    /// </summary>
    public static class Date2StringEx
    {
        /// <summary>
        /// 转换yyyy-MM-dd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转换yyyy-MM-dd 00:00:00
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1_First(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 00:00:00");
        }

        /// <summary>
        /// 转换yyyy-MM-dd 23:59:59
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate1_Last(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd 23:59:59");
        }
        /// <summary>
        /// 转换yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate3(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm");
        }
        /// <summary>
        /// 转换yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate4(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 转换yyyyMMdd
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate5(this DateTime dt)
        {
            return dt.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 转换HH:mm
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDate6(this DateTime dt)
        {
            return dt.ToString("HH:mm");
        }
    }

    /// <summary>
    /// String类型转换int扩展类
    /// </summary>
    public static class StringIntEx
    {
        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T JSONDeserialize<T>(this string @this) where T : class
        {
            if (@this.IsNullOrEmpty())
                return null;
            return JsonConvert.DeserializeObject<T>(@this);
        }


        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 是否是Int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            int odt = 0;
            return int.TryParse(str, out odt);
        }


        /// <summary>
        /// 转换日期格式，如果不能转换返回当前日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            if (str.IsInt())
                return int.Parse(str);
            return 0;
        }
    }

    /// <summary>
    ///String类型转换DateTime扩展类
    /// </summary>
    public static class StringDateEx
    {
        /// <summary>
        /// 是否日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str)
        {
            DateTime odt = DateTime.Now;
            return DateTime.TryParse(str, out odt);
        }

        /// <summary>
        /// 是否日期格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTimeOrNull(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return true;
            DateTime odt = DateTime.Now;
            return DateTime.TryParse(str, out odt);
        }

        /// <summary>
        /// 转换日期格式，如果不能转换返回当前日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            if (str.IsDateTime())
                return DateTime.Parse(str);
            return DateTime.Now;
        }


        /// <summary>
        /// 转换日期格式，如果不能转换返回Null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeOrNull(this string str)
        {
            if (str.IsDateTime())
                return DateTime.Parse(str);
            return null;
        }
    }
}
