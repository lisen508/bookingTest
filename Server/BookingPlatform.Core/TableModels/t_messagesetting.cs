/*----------------------------------------------------------------
* desc：yeheping.t_messagesetting  的基本增删改查操作
* date：2019-08-30 14:50:46 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_messagesetting
    {
        ///<summary>
        ///消息发送设置表主键ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///平台ID
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
		///二次提醒短信发送时间类型 如0:提前24小时,1:提前一天
		///</summary>
		public string ReSendTimeType { get; set; }

        ///<summary>
		///二次提醒短信发送时间 如2019-10-14 10:30
		///</summary>
		public string ReSendMessageTime { get; set; }

        ///<summary>
        ///消息模板ID
        ///</summary>
        public string MessageTemplateID { get; set; }

        ///<summary>
        ///消息模板名称
        ///</summary>
        public string MessageTemplateName { get; set; }

        ///<summary>
        ///操作者ID
        ///</summary>
        public string OperatorID { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改日期
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志 0：存在，1：删除
        ///</summary>
        public string IsDelete { get; set; }
    }
}