/*----------------------------------------------------------------
* desc：yeheping.t_patientinfo  的基本增删改查操作
* date：2019-08-30 14:51:06 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
	///<summary>
	///
	///</summary>
	public partial class t_patientinfo
	{
		///<summary>
		///
		///</summary>
		public string ID { get; set; }

		///<summary>
		///患者姓名
		///</summary>
		public string PatientName { get; set; }

		///<summary>
		///性别 "M"--男 "F"--女
		///</summary>
		public string PatientSex { get; set; }

		///<summary>
		///年龄
		///</summary>
		public string PatientAge { get; set; }

		///<summary>
		///生日
		///</summary>
		public DateTime? Birthday { get; set; }

		///<summary>
		///住院号
		///</summary>
		public string AdNo { get; set; }

		///<summary>
		///病历号
		///</summary>
		public string MrNo { get; set; }

		///<summary>
		///体重
		///</summary>
		public string Weight { get; set; }

		///<summary>
		///当前床位
		///</summary>
		public string CurrentBedNo { get; set; }

		///<summary>
		///医院id
		///</summary>
		public string HId { get; set; }

		///<summary>
		///
		///</summary>
		public string PatientID { get; set; }

		///<summary>
		///病人类型
		///</summary>
		public int? PatientType { get; set; }

		///<summary>
		///住院号
		///</summary>
		public string InPatientID { get; set; }

		///<summary>
		///门诊号
		///</summary>
		public string OutPatientID { get; set; }

		///<summary>
		///
		///</summary>
		public string IdentificationID { get; set; }

		///<summary>
		///家庭地址
		///</summary>
		public string Address { get; set; }

		///<summary>
		///身份证号
		///</summary>
		public string IDCard { get; set; }

		///<summary>
		///电话号码
		///</summary>
		public string Telephone { get; set; }

		///<summary>
		///创建时间
		///</summary>
		public DateTime? CreateDT { get; set; }

		///<summary>
		///软删除标志
		///</summary>
		public string IsDelete { get; set; }

		///<summary>
		///
		///</summary>
		public int? IsFinish { get; set; }

		///<summary>
		///卡号
		///</summary>
		public string CardNo { get; set; }

		///<summary>
		///第三方系统ID
		///</summary>
		public string SystemID { get; set; }
		/// <summary>
		/// 微信的OpenId
		/// </summary>
		public string OpenID { get; set; }

	}
}