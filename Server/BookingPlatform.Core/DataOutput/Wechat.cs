namespace BookingPlatform.Core.DataOutput
{
    #region 微信推送相关实体
    public class SendWeChatModel
    {
        /// <summary>
        /// 医院ID
        /// </summary>
        public string HospitalID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// PatientGUID
        /// </summary>
        public string PatientGUID { get; set; }
        /// <summary>
        /// openid
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string BookDate { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }

    }
    /// <summary>
    /// 微信本身的接口模型
    /// </summary>
    public class Wechat
    {
        public string touser { get; set; }
        public string template_id { get; set; }
        public string topcolor { get; set; }
        public string url { get; set; }

        public WechatParam data { get; set; }

    }
    /// <summary>
    /// 微信本身的接口模型
    /// </summary>
    public class WechatParam
    {
        public dynamic first { get; set; }
        public dynamic keyword1 { get; set; }
        public dynamic keyword2 { get; set; }
        public dynamic keyword3 { get; set; }
    }
    #endregion
}
