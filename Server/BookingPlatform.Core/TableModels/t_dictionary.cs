/*----------------------------------------------------------------
* desc：yeheping.t_dictionary  的基本增删改查操作
* date：2020-05-12 09:38:59 
*----------------------------------------------------------------*/
using System;
using System.Text;

namespace BookingPlatform.Core.TableModels 
{
    ///<summary>
	///
	///</summary>
	public partial class t_dictionary
	{
		///<summary>
		///数据字典表主键
		///</summary>
		public string ID { get; set; }

		///<summary>
		///医院Id
		///</summary>
		public string HospitalID { get; set; }

		///<summary>
		///字典数据关键字节点key
		///</summary>
		public string DictionaryKey { get; set; }

		///<summary>
		///字典数据关键字描述
		///</summary>
		public string DictionaryComment { get; set; }

		///<summary>
		///创建时间
		///</summary>
		public string CreateDT { get; set; }

		///<summary>
		///软删除标志 0/1
		///</summary>
		public int? IsDelete { get; set; }
   }
}