/*----------------------------------------------------------------
* desc：yeheping.t_mt_bookinglist  的基本增删改查操作
* date：2019-09-17 16:13:50 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_bookinglist
    {
        ///<summary>
        ///ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        /// 申请院区ID
        ///</summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 检查院区ID---迭代11新增
        /// </summary>
        public string ExamHospitalID { get; set; }

        /// <summary>
        /// 检查院区名称---迭代11新增
        /// </summary>
        public string ExamHospitalName { get; set; }
        ///<summary>
        ///患者信息表ID
        ///</summary>
        public string TPatientID { get; set; }

        ///<summary>
        ///系统ID，标记数据来源
        ///</summary>
        public string SystemID { get; set; }

        ///<summary>
        ///医嘱号
        ///</summary>
        public string OrderID { get; set; }

        ///<summary>
        ///申请单号
        ///</summary>
        public string ApplyID { get; set; }

        ///<summary>
        ///申请单开单时间
        ///</summary>
        public DateTime? ApplyDT { get; set; }

        ///<summary>
        ///申请单开单医生ID
        ///</summary>
        public string ApplyDoctorID { get; set; }

        ///<summary>
        ///申请单开单医生名字
        ///</summary>
        public string ApplyDoctorName { get; set; }

        ///<summary>
        ///申请科室ID
        ///</summary>
        public string ApplyClinicID { get; set; }

        ///<summary>
        ///申请科室名称
        ///</summary>
        public string ApplyClinicName { get; set; }

        ///<summary>
        ///检查部位
        ///</summary>
        public string ExamBody { get; set; }

        ///<summary>
        ///检查项目ID
        ///</summary>
        public string ExamItemID { get; set; }

        ///<summary>
        ///检查项目名称
        ///</summary>
        public string ExamItemName { get; set; }

        ///<summary>
        ///检查科室ID
        ///</summary>
        public string ExamClinicID { get; set; }

        ///<summary>
        ///检查科室名称
        ///</summary>
        public string ExamClinicName { get; set; }

        ///<summary>
        ///号源池表ID
        ///</summary>
        public string TSourcePoolID { get; set; }

        ///<summary>
        ///设备群组ID
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///设备群组名称
        ///</summary>
        public string DeviceGroupName { get; set; }

        ///<summary>
        ///设备ID
        ///</summary>
        public string DeviceID { get; set; }

        ///<summary>
        ///设备名称
        ///</summary>
        public string DeviceName { get; set; }

        ///<summary>
        ///预约检查日期
        ///</summary>
        public string BookingDate { get; set; }

        ///<summary>
        ///时间段
        ///</summary>
        public int? PeriodTime { get; set; }

        ///<summary>
        ///几号
        ///</summary>
        public string QueueNo { get; set; }

        /// <summary>
        /// 预约渠道 1/2/3/4 自动预约/手机预约/PC预约/自助机预约
        /// </summary>
        public int BookingChannel { get; set; }

        ///<summary>
        ///预约单操作时间
        ///</summary>
        public DateTime? BookingDT { get; set; }

        ///<summary>
        ///预约单号
        ///</summary>
        public string BookingID { get; set; }

        ///<summary>
        ///预约时间段
        ///</summary>
        public string BookingPeriod { get; set; }

        ///<summary>
        ///体征、主诉
        ///</summary>
        public string PhysicalSign { get; set; }

        ///<summary>
        ///病史摘要
        ///</summary>
        public string AnamnesisRemark { get; set; }

        ///<summary>
        ///临床诊断
        ///</summary>
        public string Disease { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string ReMark { get; set; }

        ///<summary>
        ///是否付费:0否；1是
        ///</summary>
        public int? IsPay { get; set; }

        ///<summary>
        ///费用价格
        ///</summary>
        public double? PayMoney { get; set; }

        ///<summary>
        ///状态：未预约1000;已预约1001;
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///状态：未检查1100;已检查1101;取消登记2001、删除2101、检查1101、报告1201、审核1301、打印1401
        ///</summary>
        public int? ExamStatus { get; set; }

        ///<summary>
        ///检查时间
        ///</summary>
        public string ExamDT { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///软删除标识
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///是否加急：0不是；1加急
        ///</summary>
        public int IsUrgent { get; set; }

        ///<summary>
        ///席强测试需求
        ///</summary>
        public int? IsSendFilm { get; set; }

        ///<summary>
        ///住院还是门诊，0.默认门诊，1 住院
        ///</summary>
        public int? PatientType { get; set; }

        ///<summary>
        ///辅助检查
        ///</summary>
        public string AccessoryExam { get; set; }
    }
}