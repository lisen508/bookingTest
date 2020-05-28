/*----------------------------------------------------------------
* desc：yeheping.t_useropsroomlink  的基本增删改查操作
* date：2019-08-30 14:51:16 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_useropsroomlink
    {
        ///<summary>
        ///主键
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string ClinicId { get; set; }

        ///<summary>
        ///用户ID
        ///</summary>
        public string UserId { get; set; }

        ///<summary>
        ///手术间id
        ///</summary>
        public string TOpsRoomID { get; set; }
    }
}