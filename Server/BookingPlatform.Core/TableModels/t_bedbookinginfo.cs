/*----------------------------------------------------------------
* desc：yeheping.t_bedbookinginfo  的基本增删改查操作
* date：2019-08-30 14:50:40 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_bedbookinginfo
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
        ///预约单号
        ///</summary>
        public string BookingID { get; set; }

        ///<summary>
        ///用户ID
        ///</summary>
        public string UserID { get; set; }

        ///<summary>
        ///患者信息表ID
        ///</summary>
        public string TPatientID { get; set; }

        ///<summary>
        ///病历号
        ///</summary>
        public string OrderID { get; set; }

        ///<summary>
        ///申请单号
        ///</summary>
        public string ApplyID { get; set; }

        ///<summary>
        ///申请医生ID
        ///</summary>
        public string TApplyDoctorID { get; set; }

        ///<summary>
        ///申请医生名字
        ///</summary>
        public string ApplyDoctorName { get; set; }

        ///<summary>
        ///HIS科室ID
        ///</summary>
        public string HISClinicID { get; set; }

        ///<summary>
        ///申请科室ID
        ///</summary>
        public string TApplyClinicID { get; set; }

        ///<summary>
        ///申请科室名字
        ///</summary>
        public string ApplyClinicName { get; set; }

        ///<summary>
        ///病房表ID
        ///</summary>
        public string TInfectedPatchRoomID { get; set; }

        ///<summary>
        ///申请病床描述
        ///</summary>
        public string ApplyBedDesc { get; set; }

        ///<summary>
        ///入院日期：近3天1；一周内2；一月内3
        ///</summary>
        public int? InHospitalDate { get; set; }

        ///<summary>
        ///是否接受调剂
        ///</summary>
        public int? IsAllowAdjust { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsNotidy { get; set; }

        ///<summary>
        ///是否入院
        ///</summary>
        public int? IsInHospital { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDate { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///号源ID
        ///</summary>
        public string SourceID { get; set; }

        ///<summary>
        ///号源类型
        ///</summary>
        public int? SourceType { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///待申请0；已申请1；已审核2；已入院3；已取消4；已拒绝5；已出院6；
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///未入院0;已入院1
        ///</summary>
        public int? InHospitalStatus { get; set; }

        ///<summary>
        ///审核原因
        ///</summary>
        public string VerifyResult { get; set; }

        ///<summary>
        ///床位价格
        ///</summary>
        public string BedPrice { get; set; }

        ///<summary>
        ///拒绝理由
        ///</summary>
        public string RefuseResult { get; set; }

        ///<summary>
        ///入院时间
        ///</summary>
        public string InHospitalDT { get; set; }
    }
}