/*----------------------------------------------------------------
* desc：yeheping.t_operatelog  的基本增删改查操作
* date：2020-05-12 11:05:29 
*----------------------------------------------------------------*/
using System;
using System.Text;

namespace BookingPlatform.Core.TableModels 
{
    ///<summary>
	///
	///</summary>
	public partial class t_operatelog
	{
		///<summary>
		///用户操作日志记录表
		///</summary>
		public string ID { get; set; }

		///<summary>
		///医院ID
		///</summary>
		public string HospitalID { get; set; }

		/// <summary>
		/// 操作模块ID,表名
		/// </summary>
		public string OperateModuleID { get; set; }

		///<summary>
		///操作人ID
		///</summary>
		public string OperatorID { get; set; }

		///<summary>
		///操作前的内容
		///</summary>
		public string OperateContentBefore { get; set; }

		///<summary>
		///操作后的内容
		///</summary>
		public string RequestParameter { get; set; }

		///<summary>
		///操作时间 yyyy-MM-dd HH:mm:ss
		///</summary>
		public string OperateDT { get; set; }

		///<summary>
		///操作类型  0/1 新增/修改
		///</summary>
		public int? OperateType { get; set; }

		///<summary>
		///软删标志 0/1
		///</summary>
		public int? IsDelete { get; set; }
   }
}