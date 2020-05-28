/*----------------------------------------------------------------
* desc：yeheping.t_outpatienttype  的基本增删改查操作
* date：2019-08-30 14:51:01 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatienttype
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///门诊类型名称
        ///</summary>
        public string TypeName { get; set; }

        ///<summary>
        ///价格
        ///</summary>
        public double? Price { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}