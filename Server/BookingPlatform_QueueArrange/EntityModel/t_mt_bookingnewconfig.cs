namespace BookingPlatform_QueueArrange.EntityModel
{

    ///<summary>
	///
	///</summary>
	public partial class t_mt_bookingnewconfig
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///配置keyId
        ///</summary>
        public string ConfigKeyId { get; set; }
        ///<summary>
        ///配置key
        ///</summary>
        public string ConfigKey { get; set; }

        /// <summary>
        /// 配置值value
        /// </summary>
        public string ConfigValue { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}
