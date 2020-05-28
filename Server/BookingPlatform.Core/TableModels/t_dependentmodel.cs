/*----------------------------------------------------------------
* desc：yeheping.t_dependentmodel  的基本增删改查操作
* date：2019-12-27 19:52:02 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_dependentmodel
    {
        ///<summary>
        ///统一版本 第三方系统依赖表 主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///依赖系统名称
        ///</summary>
        public string SystemName { get; set; }

        ///<summary>
        ///依赖系统模块系统ID
        ///</summary>
        public string SystemID { get; set; }

        ///<summary>
        ///当前依赖系统版本
        ///</summary>
        public string SystemVersion { get; set; }

        ///<summary>
        ///依赖系统最新更新时间
        ///</summary>
        public string LatestUpdateTime { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int? IsDelete { get; set; }
    }
}