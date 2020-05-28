/*----------------------------------------------------------------
* desc：yeheping.t_mt_queuearrangemain  的基本增删改查操作
* date：2019-09-17 16:45:08 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_queuearrangemain
    {
        ///<summary>
        ///队列排班表主键ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///检查类型ID
        ///</summary>
        public string ModalityID { get; set; }

        ///<summary>
        ///检查类型名称
        ///</summary>
        public string Modality { get; set; }

        ///<summary>
        ///队列排班日期
        ///</summary>
        public string QueueArrangeStartDate { get; set; }

        ///<summary>
        ///队列排班时段
        ///</summary>
        public string QueueArrangeEndDate { get; set; }

        ///<summary>
        ///排班日期的序号  如第一周：1，第二周：2
        ///</summary>
        public int? SequenceNumber { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改日期
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志  0/1 
        ///</summary>
        public int IsDelete { get; set; }
    }
}