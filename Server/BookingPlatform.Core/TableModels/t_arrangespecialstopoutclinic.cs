/*----------------------------------------------------------------
* desc：yeheping.t_arrangespecialstopoutclinic  的基本增删改查操作
* date：2019-08-30 14:50:38 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_arrangespecialstopoutclinic
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///特殊停诊表ID
        ///</summary>
        public string TArrangeSpecialStopID { get; set; }

        ///<summary>
        ///科室表ID
        ///</summary>
        public string TClinicID { get; set; }

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