/*----------------------------------------------------------------
* desc：yeheping.t_re_examitemmutex  的基本增删改查操作
* date：2019-08-30 14:51:10 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_re_examitemmutex
    {
        ///<summary>
        ///检查项目互斥表主键GUID
        ///</summary>
        public string ReExamItemMutexGUID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///源检查项目GUID
        ///</summary>
        public string SourceExamItemGUID { get; set; }

        ///<summary>
        ///被互斥检查项目GUID
        ///</summary>
        public string DestExamItemGUID { get; set; }

        ///<summary>
        ///互斥失效，单位：小时
        ///</summary>
        public string MutexEffectiveTime { get; set; }

        ///<summary>
        ///当前互斥规则状态，0：未启用，1：启用
        ///</summary>
        public string State { get; set; }

        ///<summary>
        ///互斥规则创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///互斥规则修改时间
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志0：存在，1：删除
        ///</summary>
        public string IsDelete { get; set; }
    }
}