using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using Microsoft.AspNetCore.Mvc;


namespace BookingPlatformApi.Controllers
{
    /// <summary> 
    /// ApiController重写
    /// </summary>
    public class MyApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected MyApiController()
        {
        }

        /// <summary>
        /// 统一返回数据包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg">信息</param>
        /// <param name="code">错误码</param>
        /// <param name="errorType">错误类型</param>
        /// <returns></returns>
        protected T returnMsg<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "SystemManage") where T : stHead, new()
        {
            if (code == 0)
            {
                //Models.LogManage.LogManage.LogError(msg, errorType);
            }
            T t = new T();
            t.Head.ErrCode = code;
            t.Head.Msg = msg;

            return t;
        }



    }


}