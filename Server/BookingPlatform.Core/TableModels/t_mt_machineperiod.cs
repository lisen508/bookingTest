/*----------------------------------------------------------------
* desc：yeheping.t_mt_machineperiod  的基本增删改查操作
* date：2019-10-17 09:58:04 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_machineperiod
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///时令表ID
        ///</summary>
        public string TMachinePeriodSummary { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///队列ID
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///周几
        ///</summary>
        public int? Week { get; set; }

        ///<summary>
        ///时段
        ///</summary>
        public int? PeriodTime { get; set; }

        ///<summary>
        ///起始时间
        ///</summary>
        public string StartDT { get; set; }

        ///<summary>
        ///结束时间
        ///</summary>
        public string EndDT { get; set; }

        ///<summary>
        ///每小时分多少段
        ///</summary>
        public int? SegmentsNum { get; set; }

        ///<summary>
        ///每小段多少号源
        ///</summary>
        public int? EverySegmentsNum { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///比例独享
        ///</summary>
        public int? Proportion { get; set; }

        ///<summary>
        ///比例独享类型
        ///</summary>
        public int? ProportionType { get; set; }

        ///<summary>
        ///具体号数独享
        ///</summary>
        public int? SpecificSource { get; set; }

        ///<summary>
        ///具体号数独享类型
        ///</summary>
        public int? SpecificSourceType { get; set; }

        ///<summary>
        ///排序字段
        ///</summary>
        public int? Sequeue { get; set; }
    }
}