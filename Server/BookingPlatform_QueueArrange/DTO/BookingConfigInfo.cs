namespace BookingPlatform_QueueArrange.DTO
{
    public class BookingConfigInfo
    {
        /// <summary>
        /// 手机端申请单有效期设置
        /// </summary>
        public int Phone_BkValidTime { get; set; } = 0;

        /// <summary>
        /// 自助机申请单有效期设置
        /// </summary>
        public int Auto_BkValidTime { get; set; } = 0;

        /// <summary>
        /// PC端申请单有效期设置
        /// </summary>
        public int PC_BkValidTime { get; set; } = 0;

        /// <summary>
        /// 自助机预约时段显示配置
        /// </summary>
        public int Auto_ShowPeriodConfig { get; set; } = 0;

        /// <summary>
        /// 自助机预约时段余号显示配置
        /// </summary>
        public int Auto_ShowPeriodSurplusConfig { get; set; } = 0;

        /// <summary>
        /// 自助机未预约列表显示配置
        /// </summary>
        public int Auto_ShowUnBookingConfig { get; set; } = 0;

        /// <summary>
        /// 检查预约排队号显示配置
        /// </summary>
        public int Auto_ShowQueueConfig { get; set; } = 0;

        /// <summary>
        /// 检查预约页面号源显示配置
        /// </summary>
        public int Auto_ShowSourceNoConfig { get; set; } = 0;

        /// <summary>
        /// 手机端号源预约有效期配置,单位/天
        /// </summary>
        public int Phone_SourceValidTime { get; set; } = 0;

        /// <summary>
        /// 自助机号源预约有效期设置,单位/天
        /// </summary>
        public int Auto_SourceValidTime { get; set; } = 0;

        /// <summary>
        /// PC端号源预约有效期设置,单位/天
        /// </summary>
        public int PC_SourceValidTime { get; set; } = 0;

        /// <summary>
        /// 检查互斥状态,0/1
        /// </summary>
        public int ExamMutexState { get; set; } = 0;

        /// <summary>
        /// 检查项目空腹推荐上午标志
        /// </summary>
        public int ExamItemEmptyMarkMorningState { get; set; } = 0;

        /// <summary>
        /// 今日预约启用标志  0/1---禁用/启用
        /// </summary>
        public int BookingTodayState { get; set; } = 0;

        /// <summary>     
        /// 检查时段可预约号数状态启用 0/1---禁用/启用
        /// </summary>    
        public int PeriodCanBookingState { get; set; } = 0;

        /// <summary>
        /// 号源顺序显示风格
        /// </summary>
        public int SourceDisplayOrderStyle { get; set; } = 0;

        /// <summary>
        /// PC端独享号源方式 0/1/2---不设置/按比例独享号源/按具体号数独享号源
        /// </summary>
        public int PCSourcePossessStyle { get; set; } = 0;

        /// <summary>
        /// 预约须知
        /// </summary>
        public int BookingNotice { get; set; } = 0;

        /// <summary>
        /// 医技预约手机端注意事项展示
        /// </summary>
        public int Phone_AttentionDisplay { get; set; } = 0;

        /// <summary>
        /// 就诊规则
        /// </summary>
        public int GoDoctorRule { get; set; } = 0;

        /// <summary>
        /// 预约单过期后支持取消或改约 0:不支持过期取消/改约  1:支持过期取消/改约
        /// </summary>
        public int ExpiredBooking_CancelChangeBooking { get; set; } = 0;

        /// <summary>
        /// 检查项目时间启用
        /// </summary>
        public int ExamItem_SpendTime { get; set; } = 0;

        /// <summary>
        /// 病人类型预约比例
        /// </summary>
        public int PatientType_BookingRate { get; set; } = 0;
        public string XYHospitalUrl { get; set; } = "";
    }
}
