namespace BookingPlatform_InitialHospital.EntityModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_hospitalareaconfig
    {
        ///<summary>
        /// 院区配置表，主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        /// 申请单开放外院预约
        ///</summary>
        public int IsApplyOpenBooking { get; set; }

        ///<summary>
        /// 号源开放外院预约
        ///</summary>
        public int IsSourceOpenBooking { get; set; }

        ///<summary>
        /// 院区ID
        ///</summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}
