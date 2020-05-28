using SqlSugar;
using System;

namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// t_patientinfo扩展类
    /// </summary>
    public partial class t_day_surgical_book_infoEx
    {
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }

        /// <summary>
        /// Desc:医院id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HospitalID { get; set; }

        /// <summary>
        /// Desc:病案号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PatientID { get; set; }

        /// <summary>
        /// Desc:患者姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PatientName { get; set; }

        /// <summary>
        /// Desc:住院号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string InpNo { get; set; }

        /// <summary>
        /// Desc:性别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Sex { get; set; }

        /// <summary>
        /// Desc:性别编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string SexCode { get; set; }

        /// <summary>
        /// Desc:年龄
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Age { get; set; }

        /// <summary>
        /// Desc:身份证号码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string IdNo { get; set; }

        /// <summary>
        /// Desc:手机号码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string Phone { get; set; }

        /// <summary>
        /// Desc:手术名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperationName { get; set; }


        /// <summary>
        /// Desc:手术编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperationCode { get; set; }

        /// <summary>
        /// Desc:手术类别
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperationType { get; set; }

        /// <summary>
        /// Desc:切口位置
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string IncisionLocation { get; set; }

        /// <summary>
        /// Desc:是否首次手术
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? IsFirstOperation { get; set; }

        /// <summary>
        /// Desc:手术冰冻
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperativeFreezing { get; set; }

        /// <summary>
        /// Desc:主刀医师
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperationSurgeonID { get; set; }

        /// <summary>
        /// Desc:主刀医师名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string OperationSurgeonName { get; set; }

        /// <summary>
        /// Desc:助理医生id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AssistantDoctorID { get; set; }

        /// <summary>
        /// Desc:助理医生姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AssistantDoctorName { get; set; }

        /// <summary>
        /// Desc:麻醉方法
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AnesthesiaMethod { get; set; }

        /// <summary>
        /// Desc:麻醉师id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AnesthesiaDoctorID { get; set; }

        /// <summary>
        /// Desc:麻醉师名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AnesthesiaDoctorName { get; set; }

        /// <summary>
        /// Desc:申请科室编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyDeptCode { get; set; }

        /// <summary>
        /// Desc:申请科室名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyDeptName { get; set; }

        /// <summary>
        /// Desc:申请医生id
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyDoctorID { get; set; }

        /// <summary>
        /// Desc:申请医生名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyDoctorName { get; set; }

        /// <summary>
        /// Desc:术前诊断
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PreoperativeDiagnosis { get; set; }

        /// <summary>
        /// Desc:申请手术台
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyOperatingTable { get; set; }

        /// <summary>
        /// Desc:打印时候的申请单号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyOrderNumber { get; set; }
        /// <summary>
        /// Desc:申请手术时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyOperatingTime { get; set; }

        /// <summary>
        /// Desc:申请手术号码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyOperatingNumber { get; set; }

        /// <summary>
        /// Desc:申请状态（1有已申请、2已审核、3已拒绝、4已取消）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? ApplyStatus { get; set; }
        /// <summary>
        /// Desc:安排手术时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AssignOperatingTime { get; set; }

        /// <summary>
        /// Desc:入院状态：（1 已签到，2 已入院，3 已出院 ）
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? AdmissionStatus { get; set; }

        /// <summary>
        /// Desc:取消时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? ApplyCancelTime { get; set; }

        /// <summary>
        /// Desc:取消原因
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ApplyCancelReasons { get; set; }

        /// <summary>
        /// Desc:审核时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? AuthTime { get; set; }



        /// <summary>
        /// Desc:安排床位号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AssignBedNumber { get; set; }

        /// <summary>
        /// Desc:安排床位时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string AssignBedTime { get; set; }

        /// <summary>
        /// Desc:创建人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreateUser { get; set; }

        /// <summary>
        /// 短信发送状态
        /// </summary>
        public string SendStatus { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Desc:修改人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UpdateUser { get; set; }

        /// <summary>
        /// Desc:修改时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UpdateTime { get; set; }
    }
}
