namespace BookingPlatform.Core.TableModelExs
{
    /// <summary>
    /// 预约列表 属性类扩展
    /// </summary>
    public class t_mt_bookinglistEx
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 患者表主键
        /// </summary>
        public string TPatientID { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者类型
        /// </summary>
        public int PatientType { get; set; }
    }
}
