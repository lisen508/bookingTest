namespace BookingPlatform.Core.TableModelExs
{
    /// <summary>
    /// 医生信息
    /// </summary>
    public class DoctorInfoDTO
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        public string doctorId { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string doctorJobNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string doctorNmae { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string doctorGrade { get; set; }
        /// <summary>
        /// 科室号
        /// </summary>
        public string deptId { get; set; }
    }
}
