using System;

namespace BookingPlatform_InitialHospital.EntityModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_hospital
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医联体ID
        ///</summary>
        public string UnionID { get; set; }

        ///<summary>
        ///省ID
        ///</summary>
        public string ProvinceID { get; set; }

        ///<summary>
        ///省名称
        ///</summary>
        public string ProvinceName { get; set; }

        ///<summary>
        ///医院Code
        ///</summary>
        public string HospitalCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatHospitalID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatHospitalName { get; set; }

        ///<summary>
        ///院区
        ///</summary>
        public string HospitalArea { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalDesc { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsShowSurplusBed { get; set; }

        ///<summary>
        ///开始平仓时间
        ///</summary>
        public DateTime? StartSynchronizedDataTime { get; set; }

        ///<summary>
        ///同步状态 0-未启动  1-同步中  2-同步错误
        ///</summary>
        public string SynchronizedDataStatus { get; set; }

        ///<summary>
        ///同步进度
        ///</summary>
        public int? SynchronizedDataProgress { get; set; }
    }
}
