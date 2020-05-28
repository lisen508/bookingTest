/*----------------------------------------------------------------
* desc：yeheping.t_system_parameter_config  的基本增删改查操作
* date：2020-05-12 09:37:04 
*----------------------------------------------------------------*/
using System;
using System.Text;

namespace BookingPlatform.Core.TableModels 
{
    ///<summary>
	///
	///</summary>
	public partial class t_system_parameter_config
	{
		///<summary>
		///系统参数配置表主键ID
		///</summary>
		public string ID { get; set; }

		///<summary>
		///医院ID
		///</summary>
		public string HospitalID { get; set; }

		///<summary>
		///系统参数名称
		///</summary>
		public string ParameterName { get; set; }

		///<summary>
		///系统参数字段key
		///</summary>
		public string ParameterKey { get; set; }

		///<summary>
		///系统参数名称
		///</summary>
		public string ParameterValue { get; set; }

		///<summary>
		///系统参数描述
		///</summary>
		public string ParameterComment { get; set; }

		///<summary>
		///系统参数创建时间 yyyy-MM-dd HH:mm:ss
		///</summary>
		public string CreateDT { get; set; }

		///<summary>
		///当前参数使用状态
		///</summary>
		public int? Status { get; set; }

		///<summary>
		///软删标志
		///</summary>
		public int? IsDelete { get; set; }
   }
}