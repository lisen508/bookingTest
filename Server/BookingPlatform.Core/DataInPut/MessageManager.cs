
using BookingPlatform.Common.MyEnum;
using System.Collections.Generic;

namespace BookingPlatform.Core.DataInPut
{
    public class MessageTemplateList : stHead
    {
        public MessageTemplateList()
        {
            TemplateList = new List<MessageTemplateMain>();
        }
        public List<MessageTemplateMain> TemplateList { get; set; }
    }
    /// <summary>
    /// 消息模板对象
    /// </summary>
    public class MessageTemplateMain
    {
        /// <summary>
        /// 消息模板GUID
        /// </summary>
        public string MessageTemplateGUID { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 检查类型名称
        /// </summary>
        public string ModalityName { get; set; }
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string MessageTypeName { get; set; }
        /// <summary>
        /// 消息渠道名称
        /// </summary>
        public string MessageChannelName { get; set; }
        /// <summary>
        /// 消息模板名称
        /// </summary>
        public string MessageTemplateName { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateDT { get; set; }
        public MessageTemplateMain()
        {
            TemplateContentList = new List<MessageTemplateContent>();
        }
        /// <summary>
        /// 消息模板包含的内容子项
        /// </summary>
        public List<MessageTemplateContent> TemplateContentList { get; set; }
    }

    /// <summary>
    /// 消息模板子项对象
    /// </summary>
    public class MessageTemplateContent
    {
        /// <summary>
        /// 消息模板子项GUID
        /// </summary>
        public string MessageTemplateContentGUID { get; set; }
        /// <summary>
        /// 消息模板子项序号
        /// </summary>
        public int SeqNumber { get; set; }
        /// <summary>
        /// 消息模板子项类型
        /// </summary>
        public string FieldType { get; set; }
        /// <summary>
        /// 消息模板子项内容
        /// </summary>
        public string FieldContent { get; set; }
    }
    /// <summary>
    /// 跨院区对象 消息类型获取使用
    /// </summary>
    public class CrossHospitalInfo
    {
        //预约单Id
        public string BookingListId { get; set; }
        //检查类型Id
        public string ModalityId { get; set; }
        //检查项目Id
        public string ExamItemId { get; set; }
    }
    public class MessageRecordList : stHead
    {
        public MessageRecordList()
        {
            RecordList = new List<MessageRecord>();
        }
        public List<MessageRecord> RecordList { get; set; }
    }
    /// <summary>
    /// 消息记录对象
    /// </summary>
    public class MessageRecord
    {
        /// <summary>
        /// 消息记录GUID
        /// </summary>
        public string MessageRecordGUID { get; set; }
        /// <summary>
        /// 医院组织机构代码
        /// </summary>
        public string HospitalID { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 检查类型
        /// </summary>
        public string Modality { get; set; }
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string MessageTypeName { get; set; }
        /// <summary>
        /// 消息渠道名称
        /// </summary>
        public string MessageChannelName { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageContent { get; set; }
        /// <summary>
        /// 发送对象
        /// </summary>
        public string SendObject { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string TeleNumber { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendDT { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }

    /// <summary>
    /// 统一平台对象
    /// </summary>
    public class PlatformInfo : stHead
    {
        //统一号源池对象
        public UniformSourcePoolInfo SourcePool { get; set; }
        //床位预约对象
        public BerthBookingInfo BerthBooking { get; set; }
        //手术预约对象
        public SurgeryBookingInfo SurgeryBooking { get; set; }
        //医技预约对象
        public MedicalTechBookingInfo MedicalTechBooking { get; set; }
        //日间手术预约对象
        public DaySurgeryBookingInfo DaySurgeryBooking { get; set; }
    }

    /// <summary>
    /// 统一号源池对象
    /// </summary>
    public class UniformSourcePoolInfo
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 门诊科室
        /// </summary>
        public string OutPatientDepartment { get; set; }
        /// <summary>
        /// 就诊序号
        /// </summary>
        public string ExamSequenceNumber { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 医生排班日期
        /// </summary>
        public string DoctorArrangeDate { get; set; }
        /// <summary>
        /// 门诊类型
        /// </summary>
        public string OutPatientType { get; set; }
        /// <summary>
        /// 医生排班时段
        /// </summary>
        public string DoctorArrangePeriod { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 【医生停诊时使用】停诊结束日期
        /// </summary>
        public string DoctorStopEndDate { get; set; }
        /// <summary>
        /// 【医生停诊时使用】停诊结束时段
        /// </summary>
        public string DoctorStopEndPeriod { get; set; }
    }

    /// <summary>
    /// 床位预约对象
    /// </summary>
    public class BerthBookingInfo
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 申请病房类型
        /// </summary>
        public string ApplyWardType { get; set; }
        /// <summary>
        /// 入院日期
        /// </summary>
        public string AdmissionDate { get; set; }
        /// <summary>
        /// 申请科室
        /// </summary>
        public string ApplyDepartment { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
    }

    /// <summary>
    /// 手术预约对象
    /// </summary>
    public class SurgeryBookingInfo
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 安排手术时间
        /// </summary>
        public string ArrangeOperationTime { get; set; }
        /// <summary>
        /// 申请手术时间
        /// </summary>
        public string ApplyOperationTime { get; set; }
        /// <summary>
        /// 安排手术地点
        /// </summary>
        public string ArrangeSurgerySite { get; set; }
        /// <summary>
        /// 申请手术地点
        /// </summary>
        public string ApplySurgerySite { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
    }

    /// <summary>
    /// 医技预约对象
    /// </summary>
    public class MedicalTechBookingInfo
    {
        public MedicalTechBookingInfo()
        {
            ModalityID = new List<string>();
            ExamDepartment = new List<string>();
            ExamSequenceNumber = new List<string>();
            ExamItem = new List<string>();
            ExamSite = new List<string>();
            Attention = new List<string>();
            ExamDate = new List<string>();
            ExamPeriod = new List<string>();
            CheckStartTime = new List<string>();
            CheckEndTime = new List<string>();
            QueueName = new List<string>();
            QueueRemark = new List<string>();
            APM = new List<string>();
        }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 脱敏姓名**
        /// </summary>
        public string DesensePatientNameBack { get; set; }
        /// <summary>
        /// 脱敏**姓名
        /// </summary>
        public string DesensePatientNameMiddle { get; set; }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
        public List<string> ModalityID { get; set; }
        /// <summary>
        /// 检查科室名称
        /// </summary>
        public List<string> ExamDepartment { get; set; }
        /// <summary>
        /// 就诊序号
        /// </summary>
        public List<string> ExamSequenceNumber { get; set; }
        /// <summary>
        /// 检查项目名称
        /// </summary>
        public List<string> ExamItem { get; set; }
        /// <summary>
        /// 检查地点
        /// </summary>
        public List<string> ExamSite { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public List<string> Attention { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        public List<string> ExamDate { get; set; }
        /// <summary>
        /// 检查时段
        /// </summary>
        public List<string> ExamPeriod { get; set; }
        /// <summary>
        /// 检查开始时间
        /// </summary>
        public List<string> CheckStartTime { get; set; }
        /// <summary>
        /// 检查结束时间
        /// </summary>
        public List<string> CheckEndTime { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public List<string> QueueName { get; set; }
        /// <summary>
        /// 队列备注
        /// </summary>
        public List<string> QueueRemark { get; set; }
        /// <summary>
        /// 上下午标志
        /// </summary>
        public List<string> APM { get; set; }
    }

    /// <summary>
    /// 日间手术预约对象
    /// </summary>
    public class DaySurgeryBookingInfo
    {
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName { get; set; }
        /// <summary>
        /// 安排手术时间
        /// </summary>
        public string ArrangeOperationTime { get; set; }
        /// <summary>
        /// 申请手术时间
        /// </summary>
        public string ApplyOperationTime { get; set; }
        /// <summary>
        /// 手术预约序号
        /// </summary>
        public string SurgeryBookingNumber { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
    }

    /// <summary>
    /// 短信发送需要处理的ID
    /// </summary>
    public class MessageIDInfo
    {
        /// <summary>
        /// 是否传递数据包标志，true:带数据传输/false:需要自行查询数据
        /// </summary>
        public bool DataPackageFlag { get; set; }
        public MessageIDInfo()
        {
            BookingIDModalityIDList = new List<BookingIDModalityID>();
        }
        /// <summary>
        /// 统一号源池ID
        /// </summary>
        public string SourcePoolID { get; set; }
        /// <summary>
        /// 床位预约ID
        /// </summary>
        public string BerthBookingID { get; set; }
        /// <summary>
        /// 手术预约ID
        /// </summary>
        public string SurgeryBookingID { get; set; }
        public List<BookingIDModalityID> BookingIDModalityIDList { get; set; }

        //医技预约对象
        public MedicalTechBookingInfo MedicalTechBooking { get; set; }
        //统一号源池对象集合
        public UniformSourcePoolInfo UniPlatformSourcePool { get; set; }
        public string DaySurgeryBookingID { get; set; }
    }
    /// <summary>
    /// 预约单-检查类型ID
    /// </summary>
    public class BookingIDModalityID
    {
        /// <summary>
        /// 预约单ID
        /// </summary>
        public string BookingListID { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
    }

    public class MessageFieldTypeValueList : stHead
    {
        public MessageFieldTypeValueList()
        {
            MessageFieldTypeAndValueList = new List<MessageFieldTypeAndValue>();
        }
        public List<MessageFieldTypeAndValue> MessageFieldTypeAndValueList { get; set; }
    }

    /// <summary>
    /// 消息字段对象
    /// </summary>
    public class MessageFieldTypeAndValue
    {
        /// <summary>
        /// 消息字段类型
        /// </summary>
        public EnumMessageFieldType MessageFieldType { get; set; }
        /// <summary>
        /// 消息字段类型名称
        /// </summary>
        public string MessageFieldTypeName { get; set; }
        /// <summary>
        /// 消息字段名称
        /// </summary>
        public string MessageFieldValue { get; set; }
        /// <summary>
        /// 对应的字段属性
        /// </summary>
        public EnumMessageField MessageFieldProperty { get; set; }
    }

    /// <summary>
    /// 消息内容key-value
    /// </summary>
    public class MessageContentKeyValue
    {
        /// <summary>
        /// 消息内容模板Key
        /// </summary>
        public string ContentKey { get; set; }
        /// <summary>
        /// 消息内容模板Value值
        /// </summary>
        public string ContentValue { get; set; }
    }

    public class MessageTemplateKeyValueList : stHead
    {
        public MessageTemplateKeyValueList()
        {
            TemplateKeyValueList = new List<MessageTemplateKeyValue>();
        }
        public List<MessageTemplateKeyValue> TemplateKeyValueList { get; set; }
    }
    /// <summary>
    /// 消息模板ID/Name 对象
    /// </summary>
    public class MessageTemplateKeyValue
    {
        /// <summary>
        /// 消息模板GUID
        /// </summary>
        public string MessageTemplateGUID { get; set; }
        /// <summary>
        /// 消息模板名称
        /// </summary>
        public string MessageTempalteName { get; set; }
    }
    public class MessageChannelKeyValueList : stHead
    {
        public MessageChannelKeyValueList()
        {
            MessageChannelList = new List<MessageChannelKeyValue>();
        }
        public List<MessageChannelKeyValue> MessageChannelList { get; set; }
    }
    /// <summary>
    /// 消息渠道键值对
    /// </summary>
    public class MessageChannelKeyValue
    {
        /// <summary>
        /// 消息渠道ID
        /// </summary>
        public string MessageChannelID { get; set; }
        /// <summary>
        /// 消息渠道名称
        /// </summary>
        public string MessageChannelName { get; set; }
        /// <summary>
        /// 选择标志，0：可选，1：禁选
        /// </summary>
        public int SelectFlag { get; set; }
    }

    public class MessageSettingList : stHead
    {
        public MessageSettingList()
        {
            SettingList = new List<MessageSetting>();
        }
        public List<MessageSetting> SettingList { get; set; }
    }
    /// <summary>
    /// 消息设置对象
    /// </summary>
    public class MessageSetting
    {
        /// <summary>
        /// 消息设置GUID
        /// </summary>
        public string MessageSettingGUID { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 平台名称
        /// </summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 检查类型
        /// </summary>
        public string Modality { get; set; }
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string MessageTypeName { get; set; }
        /// <summary>
        /// 消息渠道名称
        /// </summary>
        public string MessageChannelName { get; set; }
        /// <summary>
        /// 二次提醒消息类型名称
        /// </summary>
        public string ReSendTimeTypeName { get; set; }
        /// <summary>
        /// 二次提醒短信发送时间
        /// </summary>
        public string ReSendMessageTime { get; set; }
        /// <summary>
        /// 消息模板ID
        /// </summary>
        public string MessageTemplateID { get; set; }
        /// <summary>
        /// 消息模板名称
        /// </summary>
        public string MessageTemplateName { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateDT { get; set; }
    }

    /// <summary>
    /// 消息模板名称搜索条件
    /// </summary>
    public class MsgTemplateSearchCondition
    {
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType { get; set; }
        /// <summary>
        /// 消息渠道
        /// </summary>
        public string MessageChannel { get; set; }
    }

    /// <summary>
    /// 消息发送记录搜索条件
    /// </summary>
    public class MessageRecordSearchCondition
    {
        /// <summary>
        /// 平台ID
        /// </summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public string StartDT { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDT { get; set; }
        /// <summary>
        /// 消息渠道
        /// </summary>
        public string MessageChannel { get; set; }
        /// <summary>
        /// 短信发送状态
        /// </summary>
        public string SendState { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Telephone { get; set; }
    }

    /// <summary>
    /// 统一号源池调用短信任务服务所需字段结构
    /// </summary>
    public class MessageFieldInfo
    {
        /// <summary>
        /// 统一号源池具体操作枚举
        /// </summary>
        public EnumMessageType EnumData { get; set; }
        /// <summary>
        /// 医院组织机构代码
        /// </summary>
        public string HospitalID { get; set; }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 预约记录ID
        /// </summary>
        public string BookingID { get; set; }
    }

    /// <summary>
    /// 二次消息提醒内容
    /// </summary>
    public class ResendMessageModel
    {
        /// <summary>
        /// 检查日期
        /// </summary>
        public string ExamDate { get; set; }
        /// <summary>
        /// 检查时段
        /// </summary>
        public string ExamPeriod { get; set; }
        /// <summary>
        /// 二次发送消息内容
        /// </summary>
        public string ResendMessageContent { get; set; }
    }
}
