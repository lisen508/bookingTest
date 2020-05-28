/*----------------------------------------------------------------
* desc：yeheping.t_surgerapplyinfo  的基本增删改查操作
* date：2019-08-30 14:51:12 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_surgerapplyinfo
    {
        ///<summary>
        ///手术预约id
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///预约单号
        ///</summary>
        public string SurgeryNo { get; set; }

        ///<summary>
        ///患者id
        ///</summary>
        public string TPatientInfoId { get; set; }

        ///<summary>
        ///拟手术名称
        ///</summary>
        public string SurgeryName { get; set; }

        ///<summary>
        ///申请手术时间
        ///</summary>
        public DateTime? ApplyTime { get; set; }

        ///<summary>
        ///安排手术时间
        ///</summary>
        public DateTime? ExecApplyTime { get; set; }

        ///<summary>
        ///申请手术地点名称
        ///</summary>
        public string SurgeryPlaceName { get; set; }

        ///<summary>
        ///申请手术地点id
        ///</summary>
        public string SurgeryPlaceId { get; set; }

        ///<summary>
        ///安排手术地点名称
        ///</summary>
        public string ExecSurgeryPlaceName { get; set; }

        ///<summary>
        ///安排手术地点id
        ///</summary>
        public string ExecSurgeryPlaceId { get; set; }

        ///<summary>
        ///手术类别
        ///</summary>
        public string SurgerType { get; set; }

        ///<summary>
        ///是否首次手术 0 否 1是
        ///</summary>
        public sbyte IsfirstSurger { get; set; }

        ///<summary>
        ///手术时长（小时）
        ///</summary>
        public double? SurgerTime { get; set; }

        ///<summary>
        ///手术冰冻
        ///</summary>
        public string SurgerFrozen { get; set; }

        ///<summary>
        ///术前诊断
        ///</summary>
        public string PreDiagnosis { get; set; }

        ///<summary>
        ///预约状态1待审核 2已取消（申请取消）3审核通过4已取消（审核取消）5已拒绝（审核通过）6已拒绝（未审核）
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///切口位置
        ///</summary>
        public string NotchLocation { get; set; }

        ///<summary>
        ///申请科室名称
        ///</summary>
        public string ApplySectionName { get; set; }

        ///<summary>
        ///申请科室id
        ///</summary>
        public string ApplySectionId { get; set; }

        ///<summary>
        ///申请医生姓名
        ///</summary>
        public string ApplyDocName { get; set; }

        ///<summary>
        ///申请医生id
        ///</summary>
        public string ApplyDocId { get; set; }

        ///<summary>
        ///申请医院id
        ///</summary>
        public string ApplHosId { get; set; }

        ///<summary>
        ///可预约的其他时间（多个时间段用逗号隔开）
        ///</summary>
        public string OtherAppointTime { get; set; }

        ///<summary>
        ///来源  0-PC端 1-手机端 2-其他
        ///</summary>
        public string Source { get; set; }

        ///<summary>
        ///预计开始时间起始
        ///</summary>
        public string EstimatedStartTime { get; set; }

        ///<summary>
        ///预计开始时间终点
        ///</summary>
        public string EstimatedEndTime { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        public DateTime? UpdateDT { get; set; }

        ///<summary>
        ///修改人ID
        ///</summary>
        public string UpDateUId { get; set; }
    }
}