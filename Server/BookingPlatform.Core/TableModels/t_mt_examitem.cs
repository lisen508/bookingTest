/*----------------------------------------------------------------
* desc：yeheping.t_mt_examitem  的基本增删改查操作
* date：2020-01-17 17:35:23 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_examitem
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ExamBodyID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ExamItemCode { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ExamItemName { get; set; }

        ///<summary>
        ///项目耗费检查时间
        ///</summary>
        public int? CheckSpendTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ExamItem_HisCode { get; set; }

        ///<summary>
        ///是否强制单独预约模式  0/1 不强制单独预约/强制单独预约
        ///</summary>
        public int? IsSingleBookingMode { get; set; }

        ///<summary>
        ///检查项目匹配标准库模式  0/1 不匹配/自动匹配
        ///</summary>
        public int? IsAutoMatch { get; set; }

        ///<summary>
        ///匹配状态  0/1  匹配失败/匹配成功
        ///</summary>
        public int? MatchStatus { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? ExamItemBkPeriod { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsLimosis { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsHoldBackUrine { get; set; }

        ///<summary>
        ///预约方式（渠道），是自动接口/手机/PC/自助机  默认0 全选
        ///</summary>
        public string BookingChannel { get; set; }

        ///<summary>
        ///上午可约号源数  0表示可约号源数为0，不填表示号源不受限制
        ///</summary>
        public int? MorningSourceCount { get; set; }

        ///<summary>
        ///中午可约号源数 0表示可约号源数为0，不填表示号源不受限制
        ///</summary>
        public int? NoonSourceCount { get; set; }

        ///<summary>
        ///下午可约号源数 0表示可约号源数为0，不填表示号源不受限制
        ///</summary>
        public int? AfterNoonSourceCount { get; set; }

        ///<summary>
        ///夜间可约号源数 0表示可约号源数为0，不填表示号源不受限制
        ///</summary>
        public int? NightSourceCount { get; set; }
    }
}