using System;

namespace BookingPlatform.Common
{
    /// <summary>
    /// 自定义的异常类
    /// </summary>
    public class ParmsException : Exception
    {
        public ParmsException(String message) : base(message)
        {
        }
        public ParmsException()
        {

        }
    }
}