using BookingPlatform.Models.LogManage;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace BookingPlatform.Commom
{
    /// <summary>
    /// 
    /// </summary>
    public class MyWebApi_Get
    {
        /// <summary>  
        /// 指定Post地址使用Get 方式获取全部字符串  
        /// </summary>  
        /// <param name="url">请求后台地址</param>  
        /// <returns></returns>  
        public static string Get(string url)
        {
            var sbUrl = new StringBuilder(url);
            var lastUrl = sbUrl.ToString();
            string result = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tmpResult = client.GetAsync(lastUrl).Result;
                tmpResult.EnsureSuccessStatusCode();
                result = tmpResult.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>  
        /// 指定Post地址使用Get 方式获取全部字符串  
        /// </summary>  
        /// <param name="url">请求后台地址</param>  
        /// <returns></returns>  
        public static string Get(string url, Dictionary<string, string> dic, string appID)
        {
            return Get(url, dic, appID, string.Empty);
        }


        /// <summary>  
        /// 指定Post地址使用Get 方式获取全部字符串  
        /// </summary>  
        /// <param name="url">请求后台地址</param>  
        /// <returns></returns>  
        public static string Get(string url, Dictionary<string, string> dic, string appID, string token)
        {
            var sbUrl = new StringBuilder(url);
            if (dic != null && dic.Count > 0)
            {
                sbUrl.Append("?");
                int index = 0;
                foreach (var item in dic)
                {
                    sbUrl.Append(string.Format("{0}={1}", item.Key,
                        HttpUtility.UrlEncode(item.Value, Encoding.UTF8)));
                    if (index < dic.Count - 1)
                    {
                        sbUrl.Append("&");
                    }
                    index++;
                }
            }
            var lastUrl = sbUrl.ToString();
            string result = "";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("appid", appID);
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("token", token);
                }
                LogManage.LogInfo("调用地址:" + lastUrl);
                var tmpResult = client.GetAsync(lastUrl).Result;
                tmpResult.EnsureSuccessStatusCode();
                result = tmpResult.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}