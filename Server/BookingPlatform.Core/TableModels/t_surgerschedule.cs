/*----------------------------------------------------------------
* desc：yeheping.t_surgerschedule  的基本增删改查操作
* date：2019-08-30 14:51:14 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_surgerschedule
    {
        ///<summary>
        ///
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///手术时间
        ///</summary>
        public DateTime? SurgerDate { get; set; }

        ///<summary>
        ///手术间id
        ///</summary>
        public string TOpsRoomID { get; set; }

        ///<summary>
        ///手术室id
        ///</summary>
        public string TOpsClinicID { get; set; }

        ///<summary>
        ///手术台id
        ///</summary>
        public string TOpsStageID { get; set; }

        ///<summary>
        ///可预约总数
        ///</summary>
        public int? CanArrangeNo { get; set; }

        ///<summary>
        ///已预约数量
        ///</summary>
        public int? ArragnedNo { get; set; }

        ///<summary>
        ///已审核台数
        ///</summary>
        public int? AuditedNo { get; set; }
    }
}