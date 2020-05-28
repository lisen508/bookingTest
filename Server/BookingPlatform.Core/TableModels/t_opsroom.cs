/*----------------------------------------------------------------
* desc：yeheping.t_opsroom  的基本增删改查操作
* date：2019-08-30 14:51:00 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_opsroom
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///手术室表ID
        ///</summary>
        public string TOpsClinicID { get; set; }

        ///<summary>
        ///手术间名称
        ///</summary>
        public string OpsName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int IsDelete { get; set; }
    }
}