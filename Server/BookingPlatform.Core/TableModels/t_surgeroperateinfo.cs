/*----------------------------------------------------------------
* desc：yeheping.t_surgeroperateinfo  的基本增删改查操作
* date：2019-08-30 14:51:14 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_surgeroperateinfo
    {
        ///<summary>
        ///
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///手术预约id
        ///</summary>
        public string SurgerId { get; set; }

        ///<summary>
        ///操作人id
        ///</summary>
        public string OpUserId { get; set; }

        ///<summary>
        ///操作人姓名
        ///</summary>
        public string OpUserName { get; set; }

        ///<summary>
        ///操作时间
        ///</summary>
        public DateTime? OpTime { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///预约状态
        ///</summary>
        public int? Status { get; set; }
    }
}