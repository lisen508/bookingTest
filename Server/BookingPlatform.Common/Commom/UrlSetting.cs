//using Microsoft.Web.Administration;
//using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace BookingPlatform.Commom
{
    /// <summary>
    /// 地址
    /// </summary>
    public class UrlSetting
    {
        /// <summary>
        /// 地址
        /// </summary>
        private static IList<SettingModel> _links = new List<SettingModel>();

        public static IList<SettingModel> Links
        {
            get
            {
                return _links;
            }
        }
        // 自动生成序列号
        public static string AutoGenerateSeqNo()
        {
            var No1 = DateTime.Now.ToString("yyyyMMddHHmmss");
            var No2 = new Random().Next(1000, 9999);
            return No1 + No2;
        }

        /// <summary>
        /// 获取ip加端口号
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetUrlPort(HttpRequest request)
        {
            string url = request.Host.ToString();
            //int port = 8080;// request.Url.Port;
            return string.Format("http://{0}/api", url);
        }

        /// <summary>
        /// 注册地址信息
        /// </summary>
        public static void Register()
        {
            //if (Links.Any())
            //    return;
            //var path = GetIpPort();
            //_links.Add(new SettingModel
            //{
            //    HostpialID = "",
            //    HostpialName = "",
            //    Urls = new Models.Links
            //    {
            //        IntranetAddress_Url = "http://127.0.0.1:8350"
            //    }
            //});
            //var path = HttpContext.Current.Server.MapPath("~/") + "Setting.json";
            //if (File.Exists(path))
            //{
            //    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            //    {
            //        using (var sr = new StreamReader(fs))
            //        {
            //            var str = sr.ReadToEnd();
            //            _links= JsonConvert.DeserializeObject<IList<SettingModel>>(str);
            //        }
            //    }
            //}
        }


    }


}