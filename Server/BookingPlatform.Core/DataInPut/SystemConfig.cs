namespace BookingPlatform.Core.DataInPut
{
    public class SystemConfig
    {
        /// <summary>
        /// 配置key
        /// </summary>
        public string ConfigKey { get; set; }
        /// <summary>
        /// 配置value
        /// </summary>
        public string ConfigValue { get; set; }
        /// <summary>
        /// 配置类型 1:bool型 2:单选框型 3:复选框型 4:下拉框型 5:输入框型
        /// </summary>
        public int ConfigType { get; set; }
    }
}
