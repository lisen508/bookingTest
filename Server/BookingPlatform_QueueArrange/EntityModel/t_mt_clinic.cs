using System;

namespace BookingPlatform_QueueArrange.EntityModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_clinic
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室编码
        ///</summary>
        public string ClinicCode { get; set; }

        ///<summary>
        ///科室名称
        ///</summary>
        public string ClinicName { get; set; }

        ///<summary>
        ///科室位置
        ///</summary>
        public string ClinicPalce { get; set; }

        ///<summary>
        ///HIS科室编码
        ///</summary>
        public string Clinic_HisCode { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///科室描述
        ///</summary>
        public string ClinicDesc { get; set; }

        ///<summary>
        ///科室中文名称
        ///</summary>
        public string ClinicChineseName { get; set; }

        ///<summary>
        ///科室图片地址
        ///</summary>
        public string ClinicImageUrl { get; set; }
    }
}
