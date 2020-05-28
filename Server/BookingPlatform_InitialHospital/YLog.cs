using BookingPlatform.Models.LogManage;
using System;

namespace BookingPlatform_InitialHospital
{
    public class YLog
    {
        public static void LogError(Exception ex, string moduleType = "")
        {
            LogManage.LogError(moduleType + "---" + string.Format("{0}{1}", ex.Message, ex.StackTrace));
        }

        public static void LogError(string msg, string moduleType = "")
        {
            LogManage.LogError(moduleType + "---" + msg);
        }

        public static void LogInfo(string msg, string moduleType = "")
        {
            LogManage.LogInfo(moduleType + "---" + msg);
        }

        public static void LogSystemError(string msg, string moduleType = "")
        {
            LogManage.LogError(moduleType + "---" + msg);
        }

        public static void LogDebug(string msg, string moduleType = "")
        {
            LogManage.LogInfo(moduleType + "---" + msg);
        }
    }
}
