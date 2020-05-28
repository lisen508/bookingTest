using BookingPlatform.Common;
using BookingPlatform.Core;
using BookingPlatform.Models.LogManage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookingPlatformApi.Controllers.Filter
{
    //1.IAuthorizationFilter(权限)>2.IResourceFilter（资源）>3.ActionFilterAttribute（方法）>4.ExceptionFilterAttribute（异常）>5.ResultFilterAttribute（结果）

    /// <summary>
    /// 医技系统管理过滤器
    /// </summary>
    public class MedicalSystemErrorFilter : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider _moprovider;
        /// <summary>
        /// 错误记录过滤器
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            if (actionExecutedContext.Exception != null)
            {
                LogManage.LogError(actionExecutedContext.Exception.Message);
                LogManage.LogError(actionExecutedContext.Exception.StackTrace);
            }
            var errmsg = string.Empty;
            if (actionExecutedContext.Exception is ParmsException)
            {
                var e = actionExecutedContext.Exception as ParmsException;
                errmsg = e.Message;
            }

            var err = string.Empty;
            if (errmsg.IsNullOrEmpty())
            {
                err = JsonConvert.SerializeObject(CommonOutputData<List<object>>.Error());
            }
            else
            {
                err = JsonConvert.SerializeObject(CommonOutputData<List<object>>.Error(errmsg, BookingPlatform.Common.MyEnum.ErrCode.ERROR));
            }
            ContentResult result = new ContentResult
            {
                StatusCode = 500,
                ContentType = "text/json;charset=utf-8;"
            };

            //actionExecutedContext.HttpContext = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            //{ 
            // Content = new StringContent(err, System.Text.Encoding.UTF8, "application/json")
            //};
            actionExecutedContext.Result = result;

        }
    }
}