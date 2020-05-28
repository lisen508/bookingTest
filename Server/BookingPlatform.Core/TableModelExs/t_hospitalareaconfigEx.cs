/*----------------------------------------------------------------
* desc：yeheping.t_hospitalareaconfigEx  的基本增删改查操作
* date：2019-08-30 14:50:43 
*----------------------------------------------------------------*/
using System.Collections.Generic;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///院区配置表扩展表
	///</summary>
	public partial class t_hospitalareaconfigEx
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public t_hospitalareaconfigEx()
        {
            hospitalareaconfigdetails = new List<t_hospitalareaconfigdetail>();
            hospitalareaconfig = new t_hospitalareaconfig();
        }
        /// <summary>
        /// 
        /// </summary>
        public List<t_hospitalareaconfigdetail> hospitalareaconfigdetails { get; set; }

        public t_hospitalareaconfig hospitalareaconfig { get; set; }
    }
}