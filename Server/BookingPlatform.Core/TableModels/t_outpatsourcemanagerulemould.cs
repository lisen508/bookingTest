/*----------------------------------------------------------------
* desc：yeheping.t_outpatsourcemanagerulemould  的基本增删改查操作
* date：2019-08-30 14:51:03 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatsourcemanagerulemould
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///规则模板编号
        ///</summary>
        public int? RuleNo { get; set; }

        ///<summary>
        ///规则模板名称
        ///</summary>
        public string RuleName { get; set; }

        ///<summary>
        ///规则模板描述
        ///</summary>
        public string RuleDesc { get; set; }

        ///<summary>
        ///规则模板数据包
        ///</summary>
        public string RuleData { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///状态。1启用
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Remark { get; set; }
    }
}