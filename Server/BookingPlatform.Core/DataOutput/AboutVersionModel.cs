
namespace BookingPlatform.Core.DataOutput
{
    /// <summary>
    /// 关于页面的版本模型
    /// </summary>
    public class VersionAboutModel
    {
        /// <summary>
        /// 产品线
        /// </summary>
        public string productLine { get; set; }
        /// <summary>
        /// 业务模块
        /// </summary>
        public string businessModel { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string versionNo { get; set; }
        /// <summary>
        /// Jenkins构建次数
        /// </summary>
        public string buildTimes { get; set; }
        /// <summary>
        /// Jenkins构建的guid
        /// </summary>
        public string buildGUID { get; set; }
        /// <summary>
        /// Jenkins最后构建时间
        /// </summary>
        public string lastUpdateTime { get; set; }
    }

    /// <summary>
    /// 统一版本外链模型
    /// </summary>
    public class ExternalLinkAddressModel
    {
        /// <summary>
        /// 返回码，0表示成功
        /// </summary>
        public int return_code { get; set; } = 0;
        /// <summary>
        /// 返回信息，return_code不为0时返回错误信息
        /// </summary>
        public string return_msg { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string product_name { get; set; }
        /// <summary>
        /// 主版本及次版本信息（如：v3.1）
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 关于页面完整地址
        /// </summary>
        public string about_url { get; set; }
        /// <summary>
        /// 最后更新时间 根式yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string update_time { get; set; }
    }
}
