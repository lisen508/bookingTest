/*----------------------------------------------------------------
* desc：yeheping.t_test_his_bedbooking  的基本增删改查操作
* date：2019-08-30 14:51:15 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_test_his_bedbooking
    {
        ///<summary>
        ///
        ///</summary>
        public int ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ApplyClinicID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ApplyClinicName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ApplyDoctorID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ApplyDoctorName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ApplyDate { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientSex { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientAge { get; set; }

        ///<summary>
        ///身份证
        ///</summary>
        public string IDCard { get; set; }

        ///<summary>
        ///就诊卡
        ///</summary>
        public string CardNo { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientType { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string InPatientID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string OutPatientID { get; set; }

        ///<summary>
        ///待申请0；已取消4；
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}