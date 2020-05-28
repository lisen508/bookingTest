using BookingPlatform.Models.LogManage;
using System;

namespace BookingPlatform_QueueArrange
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
    //public class YLog
    //{
    //    //private static void SetLogPath()
    //    //{
    //    //    var baseLogPath = Directory.GetCurrentDirectory() + "\\" + ConfigurationManager.AppSettings["LogPath"].ToString().Trim();
    //    //    if (!Directory.Exists(baseLogPath))
    //    //    {
    //    //        Directory.CreateDirectory(baseLogPath);
    //    //    }
    //    //}

    //    /// <summary>
    //    /// 写错误日志
    //    /// </summary>
    //    /// <param name="msg"></param>
    //    public static void LogError(string msg)
    //    {
    //        HLogManager.LogError(msg);
    //    }

    //    /// <summary>
    //    /// 写Info
    //    /// </summary>
    //    /// <param name="msg"></param>
    //    public static void LogInfo(string msg)
    //    {
    //        HLogManager.LogInfo(msg);
    //    }

    //    /// <summary>
    //    /// 写系统错误
    //    /// </summary>
    //    /// <param name="msg"></param>
    //    public static void LogSystemError(Exception ex)
    //    {
    //        HLogManager.LogError($"错误日志:{ex.Message},系统堆栈:{ex.StackTrace}");
    //    }


    //    public static void LogError(Exception ex)
    //    {
    //        var lmsg = string.Format("{0}/r/n{1}", ex.Message, ex.StackTrace);
    //        LogError(lmsg);
    //    }

    //    /// <summary>
    //    /// 写错误日志
    //    /// </summary>
    //    /// <param name="msg"></param>
    //    public static void LogError(string msg, Exception ex)
    //    {
    //        LogError(msg);
    //        LogError(ex);
    //    }
    //}
}
