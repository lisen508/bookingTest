/*----------------------------------------------------------------
* desc：yeheping.t_opsstage  的基本增删改查操作
* date：2019-08-30 14:51:00 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_opsstage
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///手术室表ID
        ///</summary>
        public string TOpsRoomID { get; set; }

        ///<summary>
        ///手术台名称
        ///</summary>
        public string OpsStage { get; set; }

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