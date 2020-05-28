/*----------------------------------------------------------------
* desc：yeheping.t_bookingid  的基本增删改查操作
* date：2019-08-30 14:50:41 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_bookingid
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string UseSourceID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TOutpatSourcePoolConfigID { get; set; }

        ///<summary>
        ///院区ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }
    }
}