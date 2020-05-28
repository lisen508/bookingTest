/*----------------------------------------------------------------
* desc：yeheping.t_messagetemplatecontent  的基本增删改查操作
* date：2019-08-30 14:50:47 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_messagetemplatecontent
    {
        ///<summary>
        ///消息模板表副表主键ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///消息模板表主表ID
        ///</summary>
        public string MessageTemplateMainID { get; set; }

        ///<summary>
        ///消息模板段内容序号，如[PatientName] SeqNumber为1
        ///</summary>
        public int? MessageTemplateSeqNumber { get; set; }

        ///<summary>
        ///消息模板字段类型 0：自定义字段,1：预先定义好的字段
        ///</summary>
        public string MessageTemplateFieldType { get; set; }

        ///<summary>
        ///消息模板段内容，如[PatientName]，请携带好身份证件
        ///</summary>
        public string MessageTemplateField { get; set; }

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