using BookingPlatform.Common;
using BookingPlatform.Models.LogManage;
using System;
using System.Collections.Generic;

namespace BookingPlatform.Commom
{
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
    /// 公共处理类
    /// </summary>
    public class CommonHandleMethod
    {
        /// <summary>
        /// 转换List 为字符串
        /// </summary>
        /// <param name="listStr"></param>
        /// <returns></returns>
        public static string TransferListToStr(List<string> listStr)
        {
            var returnList = new List<string>();
            listStr.ForEach(item =>
            {
                item = "'" + item + "'";
                returnList.Add(item);
            });

            return string.Join(",", returnList);
        }

        /// <summary>
        /// 转换List 为字符串
        /// </summary>
        /// <param name="listInt"></param>
        /// <returns></returns>
        public static string TransferIntListToStr(List<int> listInt)
        {
            var returnList = new List<string>();
            listInt.ForEach(item =>
            {
                var s = "'" + item.ToString() + "'";
                returnList.Add(s);
            });

            return string.Join(",", returnList);
        }

        /// <summary>
        /// 根据系统配置获取起始/结束日期
        /// </summary>
        /// <param name="sourceValidTime">号源有效期</param>
        /// <param name="todayBookingState">今日预约开启状态</param>
        /// <returns></returns>
        public static ValidDatePeriod GetValidDate(int sourceValidTime, int todayBookingState)
        {
            try
            {
                var validSourceDays = TransferToEnumData(sourceValidTime);
                var startDate = DateTime.Now;
                var endDate = DateTime.Now.AddDays(validSourceDays);
                if (todayBookingState == 0)
                {
                    startDate = startDate.AddDays(1);
                }
                return new ValidDatePeriod()
                {
                    StartDate = startDate.ToDate1(),
                    EndDate = endDate.ToDate1()
                };
            }
            catch (Exception ex)
            {
                return new ValidDatePeriod();
                throw (ex);
            }
        }

        /// <summary>
        /// 根据传入的时间，返回所在时段
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ReturnPeriodByDateTime(string time)
        {
            var returnValue = 1;
            var sourceValue = Convert.ToInt32(time);
            if (sourceValue >= 8 && sourceValue < 12)
            {
                returnValue = 1;
            }
            else if (sourceValue >= 12 && sourceValue < 14)
            {
                returnValue = 2;
            }
            else if (sourceValue >= 14 && sourceValue < 18)
            {
                returnValue = 3;
            }
            else
            {
                returnValue = 4;
            }
            return returnValue;
        }

        /// <summary>
        /// 针对【号源预约有效期】和【申请单预约有效期】配置，进行数据转换 
        /// </summary>
        /// <param name="flagData">具体配置标识值</param>
        /// <param name="flag">传参标识，0：表示号源预约有效期，1：表示申请单预约有效期,2:表示队列号源有效期</param>
        public static int TransferToEnumData(int flagData, int flag = 0)
        {
            var returnData = 0;

            #region 号源有效期
            if (flag == 0)
            {
                switch (flagData)
                {
                    case 0:
                        returnData = 7;//7天
                        break;
                    case 1:
                        returnData = 14;//14天
                        break;
                    case 2:
                        returnData = 30;//一个月
                        break;
                    case 3:
                        returnData = 60;//两个月
                        break;
                }
            }
            #endregion

            #region 申请单有效期
            else if (flag == 1)
            {
                switch (flagData)
                {
                    case 0:
                        returnData = -1;//无限制
                        break;
                    case 1:
                        returnData = 7;//7天
                        break;
                    case 2:
                        returnData = 14;//14天
                        break;
                    case 3:
                        returnData = 30;//30天
                        break;
                }
            }
            #endregion

            #region 队列号源有效期
            else if (flag == 2)
            {
                switch (flagData)
                {
                    case 1:
                        returnData = 7;//7天
                        break;
                    case 2:
                        returnData = 14;//14天
                        break;
                    case 3:
                        returnData = 30;//30天
                        break;
                    case 4:
                        returnData = 60;//60天
                        break;
                }
            }
            #endregion

            return returnData;
        }
        /// <summary>
        /// 转化配置时间
        /// </summary>
        /// <param name="configValue"></param>
        /// <returns></returns>
        public static int TransferDayConfig(object configValue)
        {
            if (configValue == null) return 0;
            int config = 0;
            if (configValue is string)
            {
                config = Int32.Parse((string)configValue);
            }
            if (configValue is int)
            {
                config = (int)configValue;
            }
            switch (config)
            {
                case 0:
                    return 0;
                case 1:
                    return 7;
                case 2:
                    return 14;
                case 3:
                    return 30;
                case 4:
                    return 60;
                default:
                    return 0;
            }

        }

        /// <summary>
        /// 转化日期格式
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string TransferDateFormat(string date)
        {
            if (date.Length == 8)
            {
                date = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
            }
            else if (date.Length == 10)
            {
                date = date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2);
            }
            return date;
        }

        /// <summary>
        /// 处理bookinglist里面的预约日期
        /// </summary>
        /// <param name="bookingDate">预约日期</param>
        /// <returns></returns>
        public static string HandleBookingDate(string bookingDate)
        {
            if (bookingDate.Length == 8)
            {
                return TransferDateFormat(bookingDate);
            }
            return bookingDate;
        }

        /// <summary>
        /// 隐私处理患者姓名
        /// </summary>
        /// <param name="patientName"></param>
        /// <param name="flag">处理姓名隐私方式 
        /// 0:不处理,
        /// 1:隐藏除姓的其他内容 【张嘉译--->张**】
        /// 2:隐藏除姓和名字最后一个字的其他内容 【张嘉译--->张*译】
        /// </param>
        /// <returns></returns>
        public static string PatientPrivacyHandle(string patientName, int flag)
        {
            try
            {
                var length = patientName.Length;
                var concatStr = "";
                if (flag == 0)
                {
                    return patientName;
                }
                else if (flag == 1)
                {
                    for (var i = 1; i < length; i++)
                    {
                        concatStr = $"{concatStr}*";
                    }
                    patientName = $"{patientName.Substring(0, 1)}{concatStr.Trim()}";
                }
                else if (flag == 2)
                {
                    for (var i = 1; i < length - 1; i++)
                    {
                        concatStr = $"{concatStr}*";
                    }
                    if (length == 2)
                    {
                        patientName = $"{patientName.Substring(0, 1)}*";
                    }
                    else
                    {
                        patientName = $"{patientName.Substring(0, 1)}{concatStr.Trim()}{patientName.Substring(length - 1)}";
                    }
                }
                return patientName;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 获取本周的第一天(以星期一为第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }
        /// <summary>
        /// 获取本周的最后一天(以星期日为最后一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 计算具体某个日期是星期几
        /// </summary>        
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public static string CaculateWeekDay(DateTime dt)
        {
            var year = dt.Year;
            var month = dt.Month;
            var day = dt.Day;
            if (month == 1 || month == 2)
            {
                month += 12;
                year--;
            }
            int week = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;
            string weekstr = "";
            switch (week)
            {
                case 0: weekstr = "星期一"; break;
                case 1: weekstr = "星期二"; break;
                case 2: weekstr = "星期三"; break;
                case 3: weekstr = "星期四"; break;
                case 4: weekstr = "星期五"; break;
                case 5: weekstr = "星期六"; break;
                case 6: weekstr = "星期日"; break;
            }
            return weekstr;
        }

        /// <summary>
        /// 计算某天是周几 返回int型
        /// </summary>
        /// <param name="dt">具体日期</param>
        /// <returns></returns>
        public static int CalculateWeekNum(DateTime dt)
        {
            var year = dt.Year;
            var month = dt.Month;
            var day = dt.Day;
            if (month == 1 || month == 2)
            {
                month += 12;
                year--;
            }
            int week = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;
            return week + 1;
        }

        /// <summary>
        /// 根据时间差值是否大于0返回bool值
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static bool DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2);
                if (ts.Hours >= 0 && ts.Minutes >= 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogManage.LogError(ex.Message + "--------" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 计算时间差值
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static TimeSpan GetDateDiff(DateTime dt1, DateTime dt2)
        {
            try
            {
                TimeSpan ts1 = new TimeSpan(dt1.Ticks);
                TimeSpan ts2 = new TimeSpan(dt2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2);
                return ts;
            }
            catch (Exception ex)
            {
                LogManage.LogError(ex.Message + "--------" + ex.StackTrace);
                throw (ex);
            }
        }

        /// <summary>
        /// 年龄转换出生日期
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static DateTime HandleUTC(string str)
        {
            string result = System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", "");
            if (result.IsNullOrEmpty())
                return new DateTime(DateTime.Now.Year, 01, 01);
            var age = DateTime.Now.AddYears(-result.ToInt());
            return new DateTime(age.Year, 01, 01);
            //var time = Time.Substring(0, 10);
            //var year = Time.Substring(0, 4);
            //var month = Time.Substring(5, 2);
            //var day = Time.Substring(8, 2);
            //var zone = Time.Substring(11, 2);
            //if (Convert.ToInt32(zone) > 0)
            //{
            //    switch (month)
            //    {
            //        case "01":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "02";
            //                day = "01";
            //            }
            //            break;
            //        case "02":
            //            if (Convert.ToInt32(day) < 28)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "03";
            //                day = "01";
            //            }
            //            break;
            //        case "03":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "04";
            //                day = "01";
            //            }
            //            break;
            //        case "04":
            //            if (Convert.ToInt32(day) < 30)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "05";
            //                day = "01";
            //            }
            //            break;
            //        case "05":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "06";
            //                day = "01";
            //            }
            //            break;
            //        case "06":
            //            if (Convert.ToInt32(day) < 30)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "02";
            //                day = "01";
            //            }
            //            break;
            //        case "07":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "08";
            //                day = "01";
            //            }
            //            break;
            //        case "08":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "09";
            //                day = "01";
            //            }
            //            break;
            //        case "09":
            //            if (Convert.ToInt32(day) < 30)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "10";
            //                day = "01";
            //            }
            //            break;
            //        case "10":
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "11";
            //                day = "01";
            //            }
            //            break;
            //        case "11":
            //            if (Convert.ToInt32(day) < 30)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                month = "12";
            //                day = "01";
            //            }
            //            break;
            //        default:
            //            if (Convert.ToInt32(day) < 31)
            //            {
            //                if (Convert.ToInt32(day) < 9)
            //                {
            //                    day = "0" + (Convert.ToInt32(day) + 1).ToString();
            //                }
            //                else
            //                {
            //                    day = (Convert.ToInt32(day) + 1).ToString();
            //                }
            //            }
            //            else
            //            {
            //                year = (Convert.ToInt32(year) + 1).ToString();
            //                month = "01";
            //                day = "01";
            //            }
            //            break;
            //    }
            //}
            //return new DateTime(year.ToInt(), month.ToInt(), day.ToInt());
        }

        /// <summary>
        /// 计算两个时间之间差值/Added by yeheping 2019/06/26
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public static double ComputeInterval(string dateTime1, string dateTime2, int returnType = 0)
        {
            if (dateTime1.IsNullOrEmpty())
            {
                return 0;
            }
            if (dateTime2.IsNullOrEmpty())
            {
                return 0;
            }
            DateTime dTime1;
            DateTime dTime2;
            TimeSpan t;
            if (dateTime1.Length == 8)
            {
                dateTime1 = dateTime1.Substring(0, 4) + "-" + dateTime1.Substring(4, 2) + "-" + dateTime1.Substring(6, 2) + " 00:00:00";
            }
            if (dateTime2.Length == 8)
            {
                dateTime2 = dateTime2.Substring(0, 4) + "-" + dateTime2.Substring(4, 2) + "-" + dateTime2.Substring(6, 2) + " 00:00:00";
            }
            if (dateTime1.Length == 13)
            {
                dateTime1 = dateTime1.Substring(0, 4) + "-" + dateTime1.Substring(4, 2) + "-" + dateTime1.Substring(6, 2) + " " + dateTime1.Substring(8, 2) + dateTime1.Substring(10, 3);
            }
            if (dateTime2.Length == 13)
            {
                dateTime2 = dateTime2.Substring(0, 4) + "-" + dateTime2.Substring(4, 2) + "-" + dateTime2.Substring(6, 2) + " " + dateTime2.Substring(8, 2) + dateTime2.Substring(10, 3);
            }
            dTime1 = DateTime.Parse(dateTime1);
            dTime2 = DateTime.Parse(dateTime2);
            t = dTime1 - dTime2;
            return t.TotalHours;
        }

        /// <summary>
        /// 根据短信状态代码返回短信状态Text
        /// </summary>
        /// <param name="code">短信发送状态码</param>
        /// <returns></returns>
        public static string GetSendStatusByCode(int code)
        {
            var statusText = string.Empty;
            try
            {
                switch (code)
                {
                    case -1:
                        statusText = "发送失败";
                        break;
                    case 0:
                        statusText = "发送成功";
                        break;
                    case 1:
                        statusText = "未发送";
                        break;
                }
                return statusText;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 根据短信发送状态Text返回短信发送状态码
        /// </summary>
        /// <param name="sendStatusText">短信发送状态Text</param>
        /// <returns></returns>
        public static int GetSendStatusCode(string sendStatusText)
        {
            var statusCode = 0;
            try
            {
                switch (sendStatusText)
                {
                    case "发送失败":
                        statusCode = -1;
                        break;
                    case "发送成功":
                        statusCode = 0;
                        break;
                    case "未发送":
                        statusCode = 1;
                        break;
                }
                return statusCode;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
