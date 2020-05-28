
using BookingPlatform.Common;
using BookingPlatform.Core;
using BookingPlatform.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BookingPlatformApi.Controllers.Filter
{
    public class ApiAuthorize : ActionFilterAttribute
    {
        #region 字段和属性
        /// <summary>
        /// 模块别名，可配置更改
        /// </summary>
        public string Modules { get; set; }

        /// <summary>
        /// 权限动作
        /// </summary>
        public string Methods { get; set; }

        /// <summary>
        /// 权限访问控制器参数
        /// </summary>
        private string Sign { get; set; }

        /// <summary>
        /// 是否保存日志
        /// </summary>
        public bool IsLog { get; set; } = true;

        /// <summary>
        /// 操作类型CRUD
        /// </summary>
        public LogEnum LogType { get; set; }

        private string ActionArguments { get; set; }
        private Stopwatch Stopwatch { get; set; }


        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (IsLog)
            {
                ActionArguments = JsonConvert.SerializeObject(context.ActionArguments);
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
            var userGuid = "";
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.HttpContext.Request.Headers["Authorization"];
                tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();

                var tm = JwtHelper.SerializeJWT(tokenHeader);
                userGuid = tm.Uid;
            }
            //如果是超管，不做权限控制处理
            if (Modules == "admin")
            {
                base.OnActionExecuting(context);
            }

            if (string.IsNullOrEmpty(Modules))
            {
                ContextReturn(context, "您没有操作权限，请联系系统管理员！");
                return;
            }

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 返回API的信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mes"></param>
        private static void ContextReturn(ActionExecutingContext context, string mes, int enumValue = (int)ApiEnum.Unauthorized)
        {
            var res = new ApiResult<string>() { statusCode = enumValue, message = "您没有操作权限，请联系系统管理员！" };
            context.HttpContext.Response.ContentType = "application/json;charset=utf-8";
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(res));
            context.Result = new EmptyResult();
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            if (!IsLog) return;
            Stopwatch.Stop();

            var url = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            var method = context.HttpContext.Request.Method;

            var qs = ActionArguments;

            var user = "";
            //检测是否包含'Authorization'请求头，如果不包含则直接放行
            if (context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var tokenHeader = context.HttpContext.Request.Headers["Authorization"];
                tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                var tm = JwtHelper.SerializeJWT(tokenHeader);
                user = tm.UserName;
            }

            var str = $"\n 方法：{Modules}：{Methods} \n " +
                      $"地址：{url} \n " +
                      $"方式：{method} \n " +
                      $"参数：{qs}\n " +
                      //$"结果：{res}\n " +
                      $"耗时：{Stopwatch.Elapsed.TotalMilliseconds} 毫秒";
            Logger.Default.Process(user, LogType.GetEnumText(), str);

        }

    }
}
