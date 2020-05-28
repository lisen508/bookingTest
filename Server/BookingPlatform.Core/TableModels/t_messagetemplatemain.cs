/*----------------------------------------------------------------
* desc：yeheping.t_messagetemplatemain  的基本增删改查操作
* date：2019-08-30 14:50:47 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_messagetemplatemain
    {
        ///<summary>
        ///消息模板主键ID
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
        ///平台名称
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
        ///消息模板名称
        ///</summary>
        public string MessageTemplateName { get; set; }

        ///<summary>
        ///操作者ID
        ///</summary>
        public string OperatorID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}