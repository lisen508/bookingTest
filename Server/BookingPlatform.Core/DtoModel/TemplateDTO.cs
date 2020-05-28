namespace BookingPlatform.Core.DtoModel
{
    /// <summary>
    /// 模板导入对象
    /// </summary>
    public class TemplateDTO
    {
        /// <summary>
        /// 院区id
        /// </summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// excel文件
        /// </summary>
        public string ExamStr { get; set; }
    }
}
