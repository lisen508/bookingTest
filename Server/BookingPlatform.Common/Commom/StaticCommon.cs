using BookingPlatform.Common;
using System;

namespace BookingPlatform.Commom
{
    /// <summary>
    /// 静态文件
    /// </summary>
    public static class StaticCommon
    {
        public static string ConnStr
        {
            get
            {
                try
                {
                    return ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"];
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

    }
}
