/*----------------------------------------------------------------
* desc：yeheping.t_remainingbeds  的基本增删改查操作
* date：2019-08-30 14:51:09 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_remainingbeds
    {
        ///<summary>
        ///主键
        ///</summary>
        public string id { get; set; }

        ///<summary>
        ///院区ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///房间类型id
        ///</summary>
        public string TInfectedpatchroomId { get; set; }

        ///<summary>
        ///剩余床位
        ///</summary>
        public int? CanBookingNum { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///作废标准
        ///</summary>
        public string IsDelete { get; set; }
    }
}