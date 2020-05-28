/*----------------------------------------------------------------
* desc：yeheping.t_autocontinue  的基本增删改查操作
* date：2019-08-30 14:50:39 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_autocontinue
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///院区ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///起始时间
        ///</summary>
        public string StartDate { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsError { get; set; }

        ///<summary>
        ///错误信息
        ///</summary>
        public string ErrorMsg { get; set; }
    }
}