/*----------------------------------------------------------------
* desc：yeheping.t_arrangemould  的基本增删改查操作
* date：2019-08-30 14:50:37 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_arrangemould
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///院区ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室表ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///门诊类型表ID
        ///</summary>
        public string TOutpatientType { get; set; }

        ///<summary>
        ///时间段，1上午、2中午、3下午、4晚上
        ///</summary>
        public int? Period { get; set; }

        ///<summary>
        ///时间间隔
        ///</summary>
        public int? SpaceTime { get; set; }

        ///<summary>
        ///同一时段号源数量
        ///</summary>
        public int? SourceCount { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}