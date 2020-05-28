/*----------------------------------------------------------------
* desc：yeheping.t_bedbookingnotify  的基本增删改查操作
* date：2019-08-30 14:50:41 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_bedbookingnotify
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///床位信息表ID
        ///</summary>
        public string TBedBookingInfoID { get; set; }

        ///<summary>
        ///病房表ID
        ///</summary>
        public string TinfectedPatchRoomID { get; set; }

        ///<summary>
        ///剩余病床表ID
        ///</summary>
        public string TRemainingBedsID { get; set; }

        ///<summary>
        ///病房和类型信息
        ///</summary>
        public string RoomAndTypeInfo { get; set; }

        ///<summary>
        ///可预约数量
        ///</summary>
        public string CanBookingNum { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }
    }
}