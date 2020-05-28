/*----------------------------------------------------------------
* desc：yeheping.t_mt_mattneedatttoexamitem  的基本增删改查操作
* date：2019-08-30 14:50:56 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_mattneedatttoexamitem
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查项目表ID
        ///</summary>
        public string ExamItemID { get; set; }

        ///<summary>
        ///注意事项表ID
        ///</summary>
        public string MattNeedAttID { get; set; }
    }
}