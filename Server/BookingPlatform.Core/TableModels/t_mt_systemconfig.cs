/*----------------------------------------------------------------
* desc：yeheping.t_doctor  的基本增删改查操作
* date：2019-08-30 14:50:42 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_systemconfig
    {
        ///<summary>
		///
		///</summary>
		public string ID { get; set; }

        ///<summary>
        ///配置key
        ///</summary>
        public string ConfigKey { get; set; }

        ///<summary>
        ///配置key描述
        ///</summary>
        public string ConfigKeyComment { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}