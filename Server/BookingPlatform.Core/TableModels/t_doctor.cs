/*----------------------------------------------------------------
* desc：yeheping.t_doctor  的基本增删改查操作
* date：2019-08-30 14:50:42 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_doctor
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///科室表ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///第三方医生ID，如用户中心医生ID
        ///</summary>
        public string ThirdDoctorID { get; set; }

        ///<summary>
        ///第三方医生用户ID
        ///</summary>
        public string ThirdDoctorUserID { get; set; }

        ///<summary>
        ///HIS医生ID
        ///</summary>
        public string HIS_DoctorID { get; set; }

        ///<summary>
        ///医生名字
        ///</summary>
        public string DoctorName { get; set; }

        ///<summary>
        ///医生性别
        ///</summary>
        public string DoctorSex { get; set; }

        ///<summary>
        ///工号
        ///</summary>
        public string DoctorJobNo { get; set; }

        ///<summary>
        ///手机号码
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        ///医生职称
        ///</summary>
        public string DoctorGrade { get; set; }

        ///<summary>
        ///医生专业技能
        ///</summary>
        public string DoctorSpecialTech { get; set; }

        ///<summary>
        ///医生简介
        ///</summary>
        public string DoctorSummary { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}