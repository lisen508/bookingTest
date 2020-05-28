/*----------------------------------------------------------------
* desc：yeheping.t_sugeroperationreason  的基本增删改查操作
* date：2019-08-30 14:51:11 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_sugeroperationreason
    {
        ///<summary>
        ///
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///手术预约id
        ///</summary>
        public string TSurgerApplyInfoId { get; set; }

        ///<summary>
        ///操作类型  1-取消原因  2-拒绝原因
        ///</summary>
        public int? ORType { get; set; }

        ///<summary>
        ///原因内容
        ///</summary>
        public string ORRemark { get; set; }
    }
}