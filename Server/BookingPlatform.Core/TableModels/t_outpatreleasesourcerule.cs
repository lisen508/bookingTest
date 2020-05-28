/*----------------------------------------------------------------
* desc：yeheping.t_outpatreleasesourcerule  的基本增删改查操作
* date：2019-08-30 14:51:01 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatreleasesourcerule
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///提前几周
        ///</summary>
        public string BeforeWeek { get; set; }

        ///<summary>
        ///释放号源时间
        ///</summary>
        public string ReleaseSourceTime { get; set; }

        ///<summary>
        ///释放号源数量
        ///</summary>
        public int? BeforeReleaseArrange { get; set; }

        ///<summary>
        ///状态
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}