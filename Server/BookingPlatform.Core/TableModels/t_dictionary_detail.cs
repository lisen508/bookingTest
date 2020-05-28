/*----------------------------------------------------------------
* desc：yeheping.t_dictionary_detail  的基本增删改查操作
* date：2020-05-12 09:39:26 
*----------------------------------------------------------------*/
using System;
using System.Text;

namespace BookingPlatform.Core.TableModels 
{
    ///<summary>
	///
	///</summary>
	public partial class t_dictionary_detail
	{
		///<summary>
		///字典数据详情表，父节点在t_dictionary表中
		///</summary>
		public string ID { get; set; }

		///<summary>
		///字典表字段表主键
		///</summary>
		public string DictionaryKeyID { get; set; }

		///<summary>
		///具体字典数据详情分类表key
		///</summary>
		public string FieldKey { get; set; }

		///<summary>
		///具体字典数据详情分类表值/描述
		///</summary>
		public string FieldValue { get; set; }

		///<summary>
		///创建时间 yyyy-MM-dd HH:mm:ss
		///</summary>
		public string CreateDT { get; set; }

		///<summary>
		///软删标志 0/1 
		///</summary>
		public int? IsDelete { get; set; }
   }
}