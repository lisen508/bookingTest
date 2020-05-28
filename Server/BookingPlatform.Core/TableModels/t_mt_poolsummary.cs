/*----------------------------------------------------------------
* desc：yeheping.t_mt_poolsummary  的基本增删改查操作
* date：2019-08-30 14:50:57 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_poolsummary
    {
        ///<summary>
        ///统计ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///队列ID
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///年月日
        ///</summary>
        public string YMD { get; set; }

        ///<summary>
        ///预约数
        ///</summary>
        public int? ApplyNum { get; set; }

        ///<summary>
        ///取消预约数
        ///</summary>
        public int? CancleApplyNum { get; set; }
    }
}