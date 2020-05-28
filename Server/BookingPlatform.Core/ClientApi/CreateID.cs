using BookingPlatform.Common;
using System;

namespace BookingPlatform.Core
{
    /// <summary>
    /// 获取GUID
    /// </summary>
    public static class CreateID
    {
        /// <summary>
        /// 
        /// </summary>
        public static string GetID()
        {
            return DateTime.Now.ToString("yyMMddHHmmssfff") + "_" + GenerateStringID().ToUpper();
        }

        /// <summary>
        /// 
        /// </summary>
        private static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string re = string.Format("{0:x}", i - DateTime.Now.Ticks);
            if (re.Length < 16) return re.PadRight(16, 'F');
            else return re.Substring(0, 16);
        }
        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <returns></returns>
        public static string CreateBookingInfoNo()
        {
            var RandomCode = DateTime.Now.ToDate1();
            for (int i = 0; i < 3; i++)
            {
                //获取随机数的方法
                Random rand = new Random();
                int RandKey = rand.Next(0, 10);
                RandomCode += RandKey.ToString();
            }
            return RandomCode;
        }
    }
}