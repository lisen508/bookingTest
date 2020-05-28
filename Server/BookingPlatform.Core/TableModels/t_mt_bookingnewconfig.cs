/*----------------------------------------------------------------
* desc：yeheping.t_mt_bookingnewconfig  的基本增删改查操作
* date：2020-05-12 09:38:32 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_bookingnewconfig
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }
	
		///<summary>
		///医院组织机构代码
		///</summary>
		public string HospitalID { get; set; }

		///<summary>
		///配置key ID
		///</summary>
		public string ConfigKeyId { get; set; }

		///<summary>
		///配置key
		///</summary>
		public string ConfigKey { get; set; }

		///<summary>
		///配置的值
		///</summary>
		public string ConfigValue { get; set; }

		///<summary>
		///预约配置的Tab标签区分 1/2/3  PC功能配置/手机（自助机）功能配置/有效期配置
		///</summary>
		public int? ConfigTab { get; set; }

		///<summary>
		///软删标志 0/1
		///</summary>
		public int? IsDelete { get; set; }
   }
}