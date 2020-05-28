/*----------------------------------------------------------------
* desc：yeheping.t_mt_mattersneedattention  的基本增删改查操作
* date：2019-08-30 14:50:56 
*----------------------------------------------------------------*/
using SqlSugar;
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_mattersneedattention
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }
        /// <summary>
        /// 序列号 前端排序用与数据库无关
        /// 
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int? Num { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///注意事项编号
        ///</summary>
        public string MattersCode { get; set; }

        ///<summary>
        ///注意事项内容
        ///</summary>
        public string MattersContent { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }
    }
}