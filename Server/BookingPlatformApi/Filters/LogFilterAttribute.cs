using BookingPlatform.Models.LogManage;
using Microsoft.AspNetCore.Mvc.Filters;

using System;


namespace BookingPlatformApi.Controllers.Filter
{
    //1.IAuthorizationFilter(权限)>2.IResourceFilter（资源）>3.ActionFilterAttribute（方法）>4.ExceptionFilterAttribute（异常）>5.ResultFilterAttribute（结果）

    /// <summary>
    /// 日志记录过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)] //可以多次运行
    public class LogFilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        ///  在Action执行之前由 MVC 框架调用。
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            //接口调用uri
            var absoluteUri = ctx.HttpContext.Request.Host + ctx.HttpContext.Request.Path + ctx.HttpContext.Request.QueryString.ToString();// r.RequestUri.AbsoluteUri;
            //接口调用绝对路径
            var absolutePath = ctx.HttpContext.Request.Path;// ctx.Request.RequestUri.AbsolutePath;
            LogManage.LogInfo("接口调用绝对Uri：" + absoluteUri);
            LogManage.LogInfo("接口路径：" + absolutePath);
        }
    }
}