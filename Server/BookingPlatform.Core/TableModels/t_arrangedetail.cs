/*----------------------------------------------------------------
* desc：yeheping.t_arrangedetail  的基本增删改查操作
* date：2019-08-30 14:50:36 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    public partial class t_arrangedetail
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///排班表ID
        ///</summary>
        public string TArrangeID { get; set; }

        ///<summary>
        ///门诊类型表ID
        ///</summary>
        public string TOutpatientTypeID { get; set; }

        ///<summary>
        ///医生表ID
        ///</summary>
        public string TDoctorID { get; set; }

        ///<summary>
        ///时间段，1上午、2中午、3下午、4晚上
        ///</summary>
        public int? Period { get; set; }

        ///<summary>
        ///开始时间
        ///</summary>
        public string PeriodStart { get; set; }

        ///<summary>
        ///结束时间
        ///</summary>
        public string PeriodEnd { get; set; }

        ///<summary>
        ///前面标识。预留，未用
        ///</summary>
        public string SourceBefore { get; set; }

        ///<summary>
        ///号源长度。预留，未用
        ///</summary>
        public int? SourceLength { get; set; }

        ///<summary>
        ///时间间隔
        ///</summary>
        public int? TimeSpacs { get; set; }

        ///<summary>
        ///同一时段号源数量
        ///</summary>
        public int? SameSourceNum { get; set; }

        ///<summary>
        ///排班状态
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///停诊排班原因
        ///</summary>
        public string Reason { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}