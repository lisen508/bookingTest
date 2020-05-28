using BookingPlatform.Common;
using BookingPlatform.Core;
using BookingPlatform.Core.DataInPut;
using BookingPlatform.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookingPlatformApi.Controllers.Filter
{
    //1.IAuthorizationFilter(权限)>2.IResourceFilter（资源）>3.ActionFilterAttribute（方法）>4.ExceptionFilterAttribute（异常）>5.ResultFilterAttribute（结果）

    /// <summary>
    /// 院区用户验证过滤器
    /// </summary>

    public class HospitalUserFilterAttribute : ActionFilterAttribute
    {
        private static bool _bFirstLoadHospital = false;
        public void OnActionExecuted(ActionExecutedContext ctx)
        {
            //执行完成....
            //写进操作日志

            base.OnActionExecuted(ctx);
        }

        /// <summary>
        /// 接口运行前
        /// </summary>
        /// <param name="ctx">请求</param>
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            IList<RequestModel> parals = new List<RequestModel>();
            foreach (var v in ctx.ActionArguments)
            {
                parals.Add(new RequestModel(v.Key, v.Value));
            }

            Dal_FilterAttribute serviceFilter = new Dal_FilterAttribute();

            var hashosptialid = ctx.ActionArguments.Any(n => n.Key.ToUpper() == "HospitalID".ToUpper());
            if (hashosptialid)
            {
                var hosptialid = ctx.ActionArguments.First(n => n.Key.ToUpper() == "HospitalID".ToUpper()).Value.ToString();
                //验证院区id
                var result = serviceFilter.HasHosptial(hosptialid);
                if (result.Item1 == false)
                {
                    var res = CommonOutputData<object>.Error("院区验证失败:" + result.Item2);
                    ctx.HttpContext.Response.ContentType = "application/json;charset=utf-8";
                    ctx.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(res));
                    ctx.Result = new EmptyResult();
                    return;
                    //throw new ParmsException("院区验证失败:" + result.Item2);
                }

                var info = new FilterModel();
                //记录用户Id
                info.UserId = ctx.ActionArguments.Any(n => n.Key.ToUpper() == "UserID".ToUpper()) ? ctx.ActionArguments.Where(n => n.Key.ToUpper() == "UserID".ToUpper()).FirstOrDefault().Value.ToString() : string.Empty;
                info.HospitalId = hosptialid;
                ////接口调用uri
                info.AbsoluteUri = ctx.HttpContext.Request.Host + ctx.HttpContext.Request.Path + ctx.HttpContext.Request.QueryString.ToString();
                ////接口调用绝对路径
                info.AbsolutePath = ctx.HttpContext.Request.Path;
                serviceFilter.SaveInterfaceInvokeRecord(info);
            }
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

    }
}