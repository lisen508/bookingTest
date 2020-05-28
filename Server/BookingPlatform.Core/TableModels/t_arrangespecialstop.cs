/*----------------------------------------------------------------
* desc：yeheping.t_arrangespecialstop  的基本增删改查操作
* date：2019-08-30 14:50:38 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_arrangespecialstop
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
        ///主题
        ///</summary>
        public string Theme { get; set; }

        ///<summary>
        ///停诊开始日期
        ///</summary>
        public DateTime StopStartDate { get; set; }

        ///<summary>
        ///停诊开始时间段
        ///</summary>
        public int? StopStartPeriod { get; set; }

        ///<summary>
        ///停诊结束日期
        ///</summary>
        public DateTime StopEndDate { get; set; }

        ///<summary>
        ///停诊结束时间段
        ///</summary>
        public int? StopEndPeriod { get; set; }

        ///<summary>
        ///停诊状态
        ///</summary>
        public int? State { get; set; }

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