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
	public partial class t_arrange
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///医生排班日期
        ///</summary>
        public string ArrangeDate { get; set; }

        ///<summary>
        ///时间段，1上午、2中午、3下午、4晚上
        ///</summary>
        public int Period { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDT { get; set; }
    }
}