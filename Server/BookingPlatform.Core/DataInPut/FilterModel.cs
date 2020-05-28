namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 参数转换对象
    /// </summary>
    public class RequestModel
    {
        public RequestModel() { }

        public RequestModel(string key, object val)
        {
            this.Key = key;
            this.Value = val;
        }
        public string Key { get; set; }

        public object Value { get; set; }
    }

    /// <summary>
    /// 过滤器存储日志model
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// 请求接口的绝对uri
        /// </summary>
        public string AbsoluteUri { get; set; }
        /// <summary>
        /// 请求接口的绝对路径
        /// </summary>
        public string AbsolutePath { get; set; }
        /// <summary>
        /// 请求的用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 医院Id
        /// </summary>
        public string HospitalId { get; set; }
    }
}
