/*----------------------------------------------------------------
* desc：yeheping.t_mt_queuearrangedetail  的基本增删改查操作
* date：2019-09-17 16:45:08 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_queuearrangedetail
    {
        ///<summary>
        ///队列排班表详情表
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///队列排班表主表主键ID
        ///</summary>
        public string QueueArrangeMainID { get; set; }

        ///<summary>
        ///队列排班日期
        ///</summary>
        public string QueueArrangeDate { get; set; }

        /// <summary>
        /// 队列排班周几
        /// </summary>
        public string QueueArrangeWeekDay { get; set; }

        ///<summary>
        ///队列排班时段
        ///</summary>
        public int QueueArrangePeriod { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改日期
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志 0/1
        ///</summary>
        public int IsDelete { get; set; }
    }
}