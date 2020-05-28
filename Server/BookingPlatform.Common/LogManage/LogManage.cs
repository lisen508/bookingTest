using BookingPlatform.Common;
using System;

namespace BookingPlatform.Models.LogManage
{

    public class LogManage
    {

        public static string StrLogPath { get; set; }

        public static void LogError(string msg, string moduleType = "")
        {

            try
            {
                Logger.Default.Error(moduleType + "---" + msg.Replace("\n", "").Replace(" ", ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void LogError(Exception ex, string moduleType = "")
        {

            try
            {
                Logger.Default.Error(moduleType + "---" + string.Format("{0} {1}", ex.Message, ex.StackTrace));
            }
            catch { }
        }

        public static void LogInfo(string msg, string moduleType = "")
        {
            try
            {
                Logger.Default.Info(moduleType + "---" + msg.Replace("\n", "").Replace(" ", ""));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void LogSystemError(string msg, string moduleType = "")
        {
            try
            {
                Logger.Default.Error(moduleType + "---" + msg.Replace("\n", "").Replace(" ", ""));
            }
            catch { }
        }

        public static void LogDebug(string msg, string moduleType = "")
        {
            try
            {
                Logger.Default.Info(moduleType + "---" + msg.Replace("\n", "").Replace(" ", ""));
            }
            catch { }
        }
    }


}