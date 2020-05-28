/*----------------------------------------------------------------
* desc：yeheping.t_arrangedoctorstop  的基本增删改查操作
* date：2019-08-30 14:50:36 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_arrangedoctorstop
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///院区id
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室表ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///医生表ID
        ///</summary>
        public string TDoctorID { get; set; }

        ///<summary>
        ///停诊起始日期
        ///</summary>
        public DateTime? StopStartDate { get; set; }

        ///<summary>
        ///停诊起始时间段
        ///</summary>
        public int? PeriodStart { get; set; }

        ///<summary>
        ///停诊结束日期
        ///</summary>
        public DateTime? StopEndDate { get; set; }

        ///<summary>
        ///停诊结束时间段
        ///</summary>
        public int? PeriodEnd { get; set; }

        ///<summary>
        ///1-发起停诊 0-取消停诊 2-停诊申请中 
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///停诊时间
        ///</summary>
        public DateTime? CancleDater { get; set; }

        ///<summary>
        ///停诊原因
        ///</summary>
        public string Reason { get; set; }
    }
}