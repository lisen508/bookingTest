/*----------------------------------------------------------------
* desc：yeheping.t_positionclosinginfo  的基本增删改查操作
* date：2019-08-30 14:51:08 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_positionclosinginfo
    {
        ///<summary>
        ///平仓配置表主键GUID
        ///</summary>
        public string PositionCloseGUID { get; set; }

        ///<summary>
        ///医院ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///平仓规则名称
        ///</summary>
        public string RuleName { get; set; }

        ///<summary>
        ///平台来源名称
        ///</summary>
        public string PlatformNames { get; set; }

        ///<summary>
        ///来源平台GUID
        ///</summary>
        public string PlatformGUIDs { get; set; }

        ///<summary>
        ///平仓规则选定的时间点如09:00/10：00/12：00
        ///</summary>
        public string Time { get; set; }

        ///<summary>
        ///规则的执行有效期，指当天平仓最近几天的号，如validDay=7，指平仓最近7天的号
        ///</summary>
        public int? ValidDay { get; set; }

        ///<summary>
        ///规则类型Code
        ///</summary>
        public string RuleTypeCode { get; set; }

        ///<summary>
        ///用户ID
        ///</summary>
        public string UserID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}