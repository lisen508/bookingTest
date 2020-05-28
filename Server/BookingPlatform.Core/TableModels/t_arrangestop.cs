/*----------------------------------------------------------------
* desc：yeheping.t_arrangestop  的基本增删改查操作
* date：2019-08-30 14:50:39 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_arrangestop
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///0-排班停诊  1-医生长期停诊
        ///</summary>
        public int? StopType { get; set; }

        ///<summary>
        ///审核状态  0-未审核  1-已审核
        ///</summary>
        public int? AuditStatus { get; set; }

        ///<summary>
        ///对外系统id 排班停诊是 t_arrangedetail表id 医生停诊是 t_arrangedoctorstop表的id 
        ///</summary>
        public string Stopid { get; set; }

        ///<summary>
        ///关联表表名
        ///</summary>
        public string LinkTable { get; set; }

        ///<summary>
        ///申请时间
        ///</summary>
        public DateTime? ApplyTime { get; set; }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime? AuditTime { get; set; }
    }
}