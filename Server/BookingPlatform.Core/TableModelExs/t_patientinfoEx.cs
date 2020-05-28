namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// t_patientinfo扩展类
    /// </summary>
    public partial class t_patientinfoEx
    {
        /// <summary>
        /// 申请单日期
        /// </summary>
        public string ApplyDate { get; set; }

        /// <summary>
        /// 患者信息
        /// </summary>
        public t_patientinfo PatientInfo { get; set; }
    }
}
