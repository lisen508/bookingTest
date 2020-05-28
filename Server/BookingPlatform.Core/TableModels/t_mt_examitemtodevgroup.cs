/*----------------------------------------------------------------
* desc：yeheping.t_mt_examitemtodevgroup  的基本增删改查操作
* date：2019-08-30 14:50:54 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_examitemtodevgroup
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查项目信息表ID
        ///</summary>
        public string TExamItemID { get; set; }

        ///<summary>
        ///群组信息表ID
        ///</summary>
        public string TDeviceGroupID { get; set; }
    }
}