/*----------------------------------------------------------------
* desc：yeheping.t_mt_exambody  的基本增删改查操作
* date：2019-08-30 14:50:53 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_exambody
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///检查部位CODE
        ///</summary>
        public string ExamBodyCode { get; set; }

        ///<summary>
        ///检查部位名称
        ///</summary>
        public string ExamBodyName { get; set; }

        /// <summary>
        /// 检查部位最大可预约数限制标志  0/1 关闭/开启
        /// </summary>
        public int MaxBodyCanBookingFlag { get; set; }

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

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public int? IsDelete { get; set; }
    }

    public partial class Exambodys
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///科室ID
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///检查部位CODE
        ///</summary>
        public string ExamBodyCode { get; set; }

        ///<summary>
        ///检查部位名称
        ///</summary>
        public string ExamBodyName { get; set; }

        /// <summary>
        /// 检查部位最大可预约数限制标志  0/1 关闭/开启
        /// </summary>
        public int MaxBodyCanBookingFlag { get; set; }

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

        /// <summary>
        /// 号源最大可预约数
        /// </summary>
        public string MaxCount { get; set; }
    }
}