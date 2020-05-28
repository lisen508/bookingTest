/*----------------------------------------------------------------
* desc：yeheping.t_mt_bookinglistoplog  的基本增删改查操作
* date：2019-08-30 14:50:50 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_bookinglistoplog
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///操作者ID
        ///</summary>
        public string OperateUserID { get; set; }

        ///<summary>
        ///操作者名字
        ///</summary>
        public string OperateUserName { get; set; }

        ///<summary>
        ///操作者账号
        ///</summary>
        public string OperateUserAccount { get; set; }

        ///<summary>
        ///预约单信息表ID
        ///</summary>
        public string TBookingList { get; set; }

        ///<summary>
        ///患者信息表ID
        ///</summary>
        public string TPatientID { get; set; }

        ///<summary>
        ///操作类型
        ///</summary>
        public string OperaType { get; set; }

        ///<summary>
        ///预约检查日期
        ///</summary>
        public string BookingDate { get; set; }

        ///<summary>
        ///预约时间段
        ///</summary>
        public string BookingPeriod { get; set; }

        ///<summary>
        ///预约时段
        ///</summary>
        public int? PeriodTime { get; set; }

        ///<summary>
        ///号子
        ///</summary>
        public string QueueNo { get; set; }

        ///<summary>
        ///操作时间
        ///</summary>
        public DateTime? OperateDT { get; set; }
    }
}