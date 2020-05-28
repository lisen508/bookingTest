/*----------------------------------------------------------------
* desc：yeheping.t_arrange  的基本增删改查操作
* date：2019-08-30 14:50:35 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class v_arrangedoctorstop
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///医生ID
        ///</summary>
        public string TDoctorID { get; set; }
        /// <summary>
        /// StopStartDate
        /// </summary>
        public DateTime? StopStartDate { get; set; }
        /// <summary>
        /// PeriodStart
        /// </summary>
        public int? PeriodStart { get; set; }
        /// <summary>
        /// StopEndDate
        /// </summary>
        public DateTime? StopEndDate { get; set; }

        /// <summary>
        /// PeriodEnd
        /// </summary>
        public int? PeriodEnd { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDT { get; set; }

        /// <summary>
        /// 医生职称
        /// </summary>
        public string DoctorJobNo { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 医生级别
        /// </summary>
        public string DoctorGrade { get; set; }


    }
}