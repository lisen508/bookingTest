/*----------------------------------------------------------------
* desc：yeheping.t_renotifymessagetask  的基本增删改查操作
* date：2019-08-30 14:50:42 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_renotifymessagetask
    {
        ///<summary>
		///
		///</summary>
		public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///所属平台ID
        ///</summary>
        public int PlatformID { get; set; }

        ///<summary>
        ///所属平台名称
        ///</summary>
        public string PlatformName { get; set; }

        ///<summary>
        ///消息类型  如：医技预约成功
        ///</summary>
        public string MessageType { get; set; }

        ///<summary>
        ///消息渠道 如：短信
        ///</summary>
        public string MessageChannel { get; set; }

        ///<summary>
        ///短信任务表主键
        ///</summary>
        public string MessageRecordId { get; set; }

        ///<summary>
        ///发送的消息内容
        ///</summary>
        public string MessageContent { get; set; }

        ///<summary>
        ///发送对象
        ///</summary>
        public string SendObject { get; set; }

        ///<summary>
        ///联系方式
        ///</summary>
        public string TeleNubmer { get; set; }

        ///<summary>
        ///任务创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///任务修改时间
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///短信发送时间
        ///</summary>
        public string SendDT { get; set; }

        ///<summary>
        ///任务执行时间
        ///</summary>
        public string ExcuteDT { get; set; }

        ///<summary>
        ///任务执行标记 0/1/2---未执行/已执行/取消执行
        ///</summary>
        public int ExcuteFlag { get; set; }

        ///<summary>
        ///消息发送状态 -1：发送失败，0：已发送，1：未发送
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///错误消息
        ///</summary>
        public string ErrorMessage { get; set; }
        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}