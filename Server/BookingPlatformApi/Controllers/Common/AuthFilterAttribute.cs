using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingPlatformApi.Controllers
{

    //优先级1：权限过滤器IAuthorizationFilter 
    /// <summary>
    /// 
    /// </summary>
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        //private static bool _bAutoContinue = false;
        //private static bool _bFirstLoadHospital = false;

        /// <summary>
        /// 
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //foreach (var v in ctx.ActionArguments)
            //{
            //    dic.Add(v.Key, v.Value);
            //}

            //foreach (var d in dic)
            //{
            //    if (d.Value == null) continue;
            //    if (d.Value.GetType().Name.ToLower() == "string")
            //    {
            //        if (d.Value.ToString().Trim().Length > 0 && d.Value.ToString().Trim().First() == '[') continue;
            //        //patient
            //        if (d.Key.ToLower().IndexOf("list") < 0 && d.Key.ToLower().IndexOf("patient") < 0) ctx.ActionArguments[d.Key] = d.Value.ToString().Replace("'", "").Replace("\"", "");
            //    }
            //}

            ////LogManage.LogInfo("接口调用：" + ctx.RequestUri.PathAndQuery);

            //if (ctx.ActionArguments.ContainsKey("UserID") == false)
            //{
            //    ctx.ActionArguments["UserID"] = "111";
            //}
            ////服务层
            //Dal_FilterAttribute ac = new Dal_FilterAttribute();
            ////自动延续排班和号源
            //if (ctx.ActionArguments.ContainsKey("HospitalID") == true && _bAutoContinue == false)
            //{
            //    _bAutoContinue = true;
            //    //AutoContinue ac = new AutoContinue();
            //    var vac = ac.StartAutoContinue(ctx.ActionArguments["HospitalID"].ToString());
            //    if (vac.Item1 == false)
            //        LogManage.LogInfo("排班和号源自动延续失败：" + vac.Item2);
            //    _bAutoContinue = false;
            //}

            ////首次加载医院
            //if (ctx.ActionArguments.ContainsKey("HospitalID") == true && _bFirstLoadHospital == false)
            //{
            //    ac.StartCheckFirstLoadHospital(ctx.ActionArguments["HospitalID"].ToString());
            //    _bFirstLoadHospital = true;
            //}

        }
    }
}