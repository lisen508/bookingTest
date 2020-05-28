/*----------------------------------------------------------------
* desc：yeheping.t_outpatsourcepoolconfig  的基本增删改查操作
* date：2019-08-30 14:51:03 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatsourcepoolconfig
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
        ///号源池类型：0自动生成；1加号
        ///</summary>
        public int? SourcePoolType { get; set; }

        ///<summary>
        ///预约单号
        ///</summary>
        public string BookingID { get; set; }

        ///<summary>
        ///检查类型信息表ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///科室名称
        ///</summary>
        public string ClinicName { get; set; }

        ///<summary>
        ///医生信息表ID
        ///</summary>
        public string TDoctorID { get; set; }

        ///<summary>
        ///医生名字
        ///</summary>
        public string DoctorName { get; set; }

        ///<summary>
        ///排班详情表ID
        ///</summary>
        public string TArrangeDetailID { get; set; }

        ///<summary>
        ///预约平台表ID
        ///</summary>
        public string TBookingPlatformID { get; set; }

        ///<summary>
        ///平台名称
        ///</summary>
        public string BookingPlatformName { get; set; }

        ///<summary>
        ///门诊类型ID
        ///</summary>
        public string TOutpatientTypeID { get; set; }

        ///<summary>
        ///门诊类型名称
        ///</summary>
        public string OutpatientTypeName { get; set; }

        ///<summary>
        ///价格
        ///</summary>
        public double? Price { get; set; }

        ///<summary>
        ///预约时间
        ///</summary>
        public string BookingDate { get; set; }

        ///<summary>
        ///预约时段
        ///</summary>
        public int? BookingPeriod { get; set; }

        ///<summary>
        ///时段起始时间
        ///</summary>
        public string PeriodStart { get; set; }

        ///<summary>
        ///时段结束时间
        ///</summary>
        public string PeriodEnd { get; set; }

        ///<summary>
        ///几号
        ///</summary>
        public int? SourceNo { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///是否被使用：0未使用；1使用
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///锁号标识位；0未锁
        ///</summary>
        public int? LockState { get; set; }

        ///<summary>
        ///患者ID
        ///</summary>
        public string PatientID { get; set; }

        ///<summary>
        ///患者名字
        ///</summary>
        public string PatientName { get; set; }

        ///<summary>
        ///使用时间
        ///</summary>
        public DateTime? UseDT { get; set; }

        ///<summary>
        ///门诊号
        ///</summary>
        public string OutPatientID { get; set; }

        ///<summary>
        ///性别
        ///</summary>
        public string PatientSex { get; set; }

        ///<summary>
        ///出生日期
        ///</summary>
        public string PatientBirthday { get; set; }

        ///<summary>
        ///身份证号码
        ///</summary>
        public string IDCard { get; set; }

        ///<summary>
        ///手机号码
        ///</summary>
        public string Phone { get; set; }
    }
}