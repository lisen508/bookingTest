/*----------------------------------------------------------------
* desc：yeheping.t_mt_sourcepoollog  的基本增删改查操作
* date：2019-08-30 14:50:58 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_sourcepoollog_copy
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///号源池ID
        ///</summary>
        public string PoolID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDate { get; set; }

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
		public string BooklistID { get; set; }

        ///<summary>
		///发送标志  0-未发送 1-已发送
		///</summary>
		public int SendFlag { get; set; }
    }
}