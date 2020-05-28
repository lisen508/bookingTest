namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 新增病人主键
    /// </summary>
    public class BookingPatientInput
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者性别 0 男 1女
        /// </summary>
        public string PatientSex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string MrNo { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// 申请科室ID
        /// </summary>
        public string ApplyClinicID { get; set; }
        /// <summary>
        /// 申请科室名称
        /// </summary>
        public string ApplyClinicName { get; set; }
        /// <summary>
        /// 申请医生ID
        /// </summary>
        public string ApplyDoctorId { get; set; }
        /// <summary>
        /// 申请医生名称
        /// </summary>
        public string ApplyDoctorName { get; set; }
        /// <summary>
        /// 申请病房类型id
        /// </summary>
        public string ApplyBedTypeID { get; set; }
        /// <summary>
        /// 申请病房类型文字
        /// </summary>
        public string ApplyBedName { get; set; }
        /// <summary>
        /// 入院日期（0-三天 1-一周内 2-一月内）
        /// </summary>
        public int DateOfAdmission { get; set; }
        /// <summary>
        /// 是否接受调剂 （0-不接受 1-接受）
        /// </summary>
        public int IsDispensing { get; set; }


    }


    /// <summary>
    /// 通知是调剂房型
    /// </summary>
    public class bookingBedTypeInput
    {
        /// <summary>
        /// 房型ID
        /// </summary>
        public string InfectedPatchRoom { get; set; }


        /// <summary>
        /// 房型名称
        /// </summary>
        public string InfectedPatchRoomText { get; set; }
    }
}