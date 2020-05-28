/*----------------------------------------------------------------
* desc：yeheping.t_periodtime  的基本增删改查操作
* date：2019-08-30 14:51:07 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_periodtime
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
        ///时令名称
        ///</summary>
        public string PeriodName { get; set; }

        ///<summary>
        ///起始日期
        ///</summary>
        public string DateStart { get; set; }

        ///<summary>
        ///结束日期
        ///</summary>
        public string DateEnd { get; set; }

        ///<summary>
        ///上午起始时间
        ///</summary>
        public string MorningStart { get; set; }

        ///<summary>
        ///上午结束时间
        ///</summary>
        public string MorningEnd { get; set; }

        ///<summary>
        ///中午起始时间
        ///</summary>
        public string NooningStart { get; set; }

        ///<summary>
        ///中午结束时间
        ///</summary>
        public string NooningEnd { get; set; }

        ///<summary>
        ///下午起始时间
        ///</summary>
        public string AfternoonStart { get; set; }

        ///<summary>
        ///下午结束时间
        ///</summary>
        public string AfternoonEnd { get; set; }

        ///<summary>
        ///晚上起始时间
        ///</summary>
        public string NightStart { get; set; }

        ///<summary>
        ///晚上结束时间
        ///</summary>
        public string NightEnd { get; set; }

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