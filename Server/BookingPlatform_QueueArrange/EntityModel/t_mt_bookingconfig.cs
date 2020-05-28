namespace BookingPlatform_QueueArrange.EntityModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_bookingconfig
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
        ///手机端申请单有效期设置
        ///</summary>
        public int? Phone_BkValidTime { get; set; }

        ///<summary>
        ///自助机申请单有效期设置
        ///</summary>
        public int? Auto_BkValidTime { get; set; }

        ///<summary>
        ///PC端申请单有效期设置
        ///</summary>
        public int? PC_BkValidTime { get; set; }

        ///<summary>
        ///自助机预约时段显示配置
        ///</summary>
        public int? Auto_ShowPeriodConfig { get; set; }

        ///<summary>
        ///自助机预约时段余号显示配置
        ///</summary>
        public int? Auto_ShowPeriodSurplusConfig { get; set; }

        ///<summary>
        ///自助机未预约列表显示配置
        ///</summary>
        public int? Auto_ShowUnBookingConfig { get; set; }

        ///<summary>
        ///检查预约排队号显示配置
        ///</summary>
        public int? Auto_ShowQueueConfig { get; set; }

        ///<summary>
        ///检查预约页面号源显示配置 0：具体号源展示；1：只展示预约字段
        ///</summary>
        public int? Auto_ShowSourceNoConfig { get; set; }

        ///<summary>
        ///手机端号源有效期配置
        ///</summary>
        public int? Phone_SourceValidTime { get; set; }

        ///<summary>
        ///自助机端号源预约有效期设置
        ///</summary>
        public int? Auto_SourceValidTime { get; set; }

        ///<summary>
        ///PC端号源预约有效期设置
        ///</summary>
        public int? PC_SourceValidTime { get; set; }

        ///<summary>
        ///检查互斥状态，0/1分别表示 关闭/启用
        ///</summary>
        public int? ExamMutexState { get; set; }

        ///<summary>
        ///检查项目空腹推荐上午,状态，0/1分别表示关闭/启用
        ///</summary>
        public int? ExamItemEmptyMarkMorningState { get; set; }

        ///<summary>
        ///今日预约启用标志  0/1---禁用/启用
        ///</summary>
        public int? BookingTodayState { get; set; }

        ///<summary>
        ///检查时段可预约号数状态启用 0/1---禁用/启用
        ///</summary>
        public int? PeriodCanBookingState { get; set; }
    }
}
