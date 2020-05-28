/*----------------------------------------------------------------
* desc：yeheping.t_messagesendrecord  的基本增删改查操作
* date：2019-08-30 14:50:45 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_messagesendrecord
    {
        ///<summary>
        ///消息记录写入时间
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///所属平台ID
        ///</summary>
        public int? PlatformID { get; set; }

        ///<summary>
        ///所属平台名称
        ///</summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 检查类型
        /// </summary>
        public string Modality { get; set; }
        ///<summary>
        ///消息类型  如0：预约成功,1:取消预约等
        ///</summary>
        public string MessageType { get; set; }

        ///<summary>
        ///消息渠道 如0：短信
        ///</summary>
        public string MessageChannel { get; set; }

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
        ///发送时间
        ///</summary>
        public string SendDT { get; set; }

        ///<summary>
        ///消息发送状态 -1：发送失败，0：已发送，1：未发送
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///短信任务表插入数据时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///软删标志 0：存在，1：已删除
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
		///错误信息
		///</summary>
		public string ErrorMessage { get; set; }
    }
}