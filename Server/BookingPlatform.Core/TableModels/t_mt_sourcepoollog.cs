/*----------------------------------------------------------------
* desc：yeheping.t_mt_sourcepoollog  的基本增删改查操作
* date：2019-08-30 14:50:58 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_sourcepoollog
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///号源池ID
        ///</summary>
        public string SourcePoolID { get; set; }

        ///<summary>
		///队列ID
		///</summary>
		public string QueueID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///发送时间
        ///</summary>
        public string SendDT { get; set; }

        ///<summary>
        ///操作内容
        ///</summary>
        public string OperationMsg { get; set; }

        ///<summary>
        ///操作类型  1-预约  -1-取消预约
        ///</summary>
        public int? OperationType { get; set; }

        ///<summary>
        ///操作人ID
        ///</summary>
        public string OperationUserID { get; set; }

        ///<summary>
        ///操作人姓名
        ///</summary>
        public string OperationUserName { get; set; }

        ///<summary>
		///预约记录ID
		///</summary>
		public string BookListID { get; set; }

        ///<summary>
		///错误消息
		///</summary>
		public string ErrMessage { get; set; }

        ///<summary>
		/// 操作的系统ID
		///</summary>
		public string SystemID { get; set; }

        ///<summary>
		///发送标志  0-未发送 1-已发送
		///</summary>
		public int SendFlag { get; set; }

        ///<summary>
		///软删标志
		///</summary>
		public int IsDelete { get; set; }
    }
}