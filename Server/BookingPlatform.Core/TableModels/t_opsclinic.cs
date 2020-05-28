/*----------------------------------------------------------------
* desc：yeheping.t_opsclinic  的基本增删改查操作
* date：2019-08-30 14:50:59 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_opsclinic
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///手术科室ID，用户输入
        ///</summary>
        public string OpsClinicID { get; set; }

        ///<summary>
        ///手术室名称
        ///</summary>
        public string OpsClinicName { get; set; }

        ///<summary>
        ///手术室位置
        ///</summary>
        public string OpsClinicSite { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}