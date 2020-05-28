using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingPlatform.Core.DataInPut
{

    public partial class SurgerAppointInput
    {
        public sealed class SurgerAppointInputData
        {
            /// <summary>
            /// 拟手术名称
            /// </summary>
            [Required(ErrorMessage = "拟手术名称不能为空")]
            public string SurgeryName { get; set; }


            /// <summary>
            /// 申请手术台id
            /// </summary>
            [Required(ErrorMessage = "申请手术台id不能为空")]
            public string StageId { get; set; }

            /// <summary>
            /// 手术时长（小时）
            /// </summary>
            [Required(ErrorMessage = "手术时长不能为空")]
            public double? SurgerTime { get; set; }
            /// <summary>
            /// 手术冰冻
            /// </summary>
            [Required(ErrorMessage = "手术冰冻不能为空")]
            public string SurgerFrozen { get; set; }
            /// <summary>
            /// 术前诊断
            /// </summary>
            [Required(ErrorMessage = "术前诊断不能为空")]
            public string PreDiagnosis { get; set; }


        }
    }
    /// <summary>
    /// 预约手术入参
    /// </summary>
    public partial class SurgerAppointInput
    {

        public SurgerAppointInput()
        {
            this.Source = "0";
        }
        /// <summary>
        /// 患者信息
        /// </summary>
        public PatientInfo PatientInfo { get; set; }
        /// <summary>
        /// 拟手术名称
        /// </summary> 
        public string SurgeryName { get; set; }
        /// <summary>
        /// 申请手术时间
        /// </summary>
        public string ApplyTime { get; set; }

        /// <summary>
        /// 申请手术台id
        /// </summary> 
        public string StageId { get; set; }
        /// <summary>
        /// 手术类别
        /// </summary>
        public string SurgerType { get; set; }
        /// <summary>
        /// 是否首次手术 0 否 1是
        /// </summary>
        public int? IsfirstSurger { get; set; }
        /// <summary>
        /// 手术时长（小时）
        /// </summary> 
        public double? SurgerTime { get; set; }
        /// <summary>
        /// 手术冰冻
        /// </summary> 
        public string SurgerFrozen { get; set; }
        /// <summary>
        /// 术前诊断
        /// </summary> 
        public string PreDiagnosis { get; set; }
        /// <summary>
        /// 切口位置
        /// </summary>
        public string NotchLocation { get; set; }
        /// <summary>
        /// 申请科室名称
        /// </summary>
        //[Required(ErrorMessage = "申请科室名称不能为空")]
        public string ApplySectionName { get; set; }
        /// <summary>
        /// 申请科室id
        /// </summary> 
        public string ApplySectionId { get; set; }
        /// <summary>
        /// 申请医生姓名
        /// </summary>
        //[Required]
        public string ApplyDocName
        {
            get;
            set;
        }
        /// <summary>
        /// 申请医生id
        /// </summary> 
        public string ApplyDocId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public IList<DateTime?> OtherAppointTimeArray
        {
            get;
            set;
        }
        /// <summary>
        /// 可预约的其他时间（多个时间段用逗号隔开）
        /// </summary>
        public IList<string> OtherAppointTime
        {
            get;
            set;
        }
        /// <summary>
        /// 麻醉方法
        /// </summary> 
        public string AnesthetMethod { get; set; }
        /// <summary>
        /// 申请医院id
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 操作用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 申请来源（来源  0-PC段 1-手机段 2-其他）
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 主刀医生
        /// </summary> 
        public DocSimpleModel MainSugeryon { get; set; }

        /// <summary>
        /// 一助
        /// </summary>
        public DocSimpleModel FirstSugeryonHelper { get; set; }
        /// <summary>
        /// 二助
        /// </summary>
        public DocSimpleModel SecondSugeryonHelper { get; set; }
        /// <summary>
        /// 三助
        /// </summary>
        public DocSimpleModel ThirdSugeryon { get; set; }
        /// <summary>
        /// 麻醉师
        /// </summary> 
        public DocSimpleModel Anesthetist { get; set; }

        /// <summary>
        /// 麻醉师一
        /// </summary>
        public DocSimpleModel FirstAnesthetist { get; set; }
        /// <summary>
        /// 麻醉师二
        /// </summary>
        public DocSimpleModel SecondAnesthetist { get; set; }

    }
    /// <summary>
    /// 医生简要信息
    /// </summary>
    public class DocSimpleModel
    {
        /// <summary>
        /// 医生id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 患者信息
    /// </summary>
    public class PatientInfo
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }


        /// <summary>
        /// 患者性别 0 男 1女
        /// </summary>
        public string PatientSex { get; set; }

        /// <summary>
        /// 患者性别 0 男 1女
        /// </summary>
        public string PatientSexText { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string AdNo { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string MrNo { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 当前床位
        /// </summary>
        public string CurrentBedNo { get; set; }

        /// <summary>
        /// 预计手术开始-开始时间
        /// </summary>
        public string EstimatedStartTime { get; set; }


        /// <summary>
        ///  预计手术开始-截止时间
        /// </summary>
        public string EstimatedEndTime { get; set; }


        /// <summary>
        /// 预计手术开始-开始时间
        /// </summary>
        public string EstimatedTime { get; set; }

    }



    /// <summary>
    /// 手术台排班入参信息
    /// </summary>
    public class StageArrangeInput
    {
        /// <summary>
        /// 手术室id
        /// </summary>
        public string ClinicId { get; set; }
        /// <summary>
        /// 手术间id
        /// </summary>
        public string RoomID { get; set; }

        /// <summary>
        /// 周几(数字) 0-周日，1-周一，2-周二，3周三，4-周四，5-周五，6-周六
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// 周几（文字）
        /// </summary>
        public string DayOfWeekStr { get; set; }

        /// <summary>
        /// 手术台排班数量
        /// </summary>
        //public IList<SimpleOpsStageInfo> StageArrangeNo { get; set; }
    }
}