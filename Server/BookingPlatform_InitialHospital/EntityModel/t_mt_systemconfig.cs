namespace BookingPlatform_InitialHospital.EntityModel
{

    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_systemconfig
    {
        ///<summary>
		///
		///</summary>
		public string ID { get; set; }

        ///<summary>
        ///配置key
        ///</summary>
        public string ConfigKey { get; set; }

        ///<summary>
        ///配置key描述
        ///</summary>
        public string ConfigKeyComment { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}
