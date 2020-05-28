/*----------------------------------------------------------------
* desc：yeheping.t_outpatsourcebookingplatform  的基本增删改查操作
* date：2019-08-30 14:51:02 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatsourcebookingplatform
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///预约平台License
        ///</summary>
        public string BookingPlatformLicense { get; set; }

        ///<summary>
        ///预约平台Key
        ///</summary>
        public string BookingPlatformKey { get; set; }

        ///<summary>
        ///排序
        ///</summary>
        public int? Sort { get; set; }

        ///<summary>
        ///预约平台名称
        ///</summary>
        public string BookingPlatformName { get; set; }

        ///<summary>
        ///号源分配百分比
        ///</summary>
        public int? RuleOne_Per { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///释放号源规则信息表ID
        ///</summary>
        public string TReleaseSourceRuleID { get; set; }
    }
}