namespace BookingPlatform.Commom
{
    /// <summary>
    /// 配置文件Model
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// 院区ID
        /// </summary>
        public string HostpialID { get; set; }

        /// <summary>
        /// HostpialName
        /// </summary>
        public string HostpialName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Links Urls { get; set; }

    }

    /// <summary>
    /// 地址
    /// </summary>
    public class Links
    {
        /// <summary>
        /// 床位预约地址
        /// </summary>
        public string IntranetAddress_Url { get; set; }



    }
}