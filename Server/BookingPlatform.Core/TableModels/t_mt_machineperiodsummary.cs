/*----------------------------------------------------------------
* desc：yeheping.t_mt_machineperiodsummary  的基本增删改查操作
* date：2019-08-30 14:50:55 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_machineperiodsummary
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///队列ID
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///起始时间
        ///</summary>
        public string StartDT { get; set; }

        ///<summary>
        ///结束时间
        ///</summary>
        public string EndDT { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string ReMark { get; set; }

        ///<summary>
        ///状态
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int IsDelete { get; set; }

        ///<summary>
        ///创建者账号
        ///</summary>
        public string CreateUserAccount { get; set; }

        ///<summary>
        ///创建者名字
        ///</summary>
        public string CreateUserName { get; set; }
    }
}