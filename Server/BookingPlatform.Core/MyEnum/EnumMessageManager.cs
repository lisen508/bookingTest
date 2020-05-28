using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    /// <summary>
    /// 消息发送所属平台
    /// </summary>
    public enum EnumPlatform
    {
        [Description("统一号源池")]
        UniformSourcePool = 1,
        [Description("床位预约")]
        BerthBooking = 2,
        [Description("手术预约")]
        SurgeryBooking = 3,
        [Description("医技预约")]
        MedicalTechBooking = 4,
        [Description("日间手术预约")]
        DaySurgicalBooking = 5
    }

    /// <summary>
    /// 枚举平台操作类
    /// </summary>
    public static class EnumPlatform_Class
    {
        /// <summary>
        /// 通过平台代码获取消息发送平台名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumPlatform_GetPlatformNameByCode(int code)
        {
            var platformName = "";
            switch (code)
            {
                case 1:
                    platformName = "统一号源池";
                    break;
                case 2:
                    platformName = "床位预约";
                    break;
                case 3:
                    platformName = "手术预约";
                    break;
                case 4:
                    platformName = "医技预约";
                    break;
                case 5:
                    platformName = "日间手术预约";
                    break;
            }
            return platformName;
        }
        /// <summary>
        /// 通过平台名称获取平台枚举值
        /// </summary>
        /// <param name="platformName"></param>
        /// <returns></returns>
        public static EnumPlatform EnumPlatform_GetPlatformEnumByName(string platformName)
        {
            var platformEnum = new EnumPlatform();
            switch (platformName)
            {
                case "统一号源池":
                    platformEnum = EnumPlatform.UniformSourcePool;
                    break;
                case "床位预约":
                    platformEnum = EnumPlatform.BerthBooking;
                    break;
                case "手术预约":
                    platformEnum = EnumPlatform.SurgeryBooking;
                    break;
                case "医技预约":
                    platformEnum = EnumPlatform.MedicalTechBooking;
                    break;
                case "日间手术预约":
                    platformEnum = EnumPlatform.DaySurgicalBooking;
                    break;
            }
            return platformEnum;
        }
        /// <summary>
        /// 通过平台枚举值获取平台名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumPlatform_GetPlatformNameByEnum(EnumPlatform em)
        {
            var platformName = "";
            switch (em)
            {
                case EnumPlatform.UniformSourcePool:
                    platformName = "统一号源池";
                    break;
                case EnumPlatform.BerthBooking:
                    platformName = "床位预约";
                    break;
                case EnumPlatform.SurgeryBooking:
                    platformName = "手术预约";
                    break;
                case EnumPlatform.MedicalTechBooking:
                    platformName = "医技预约";
                    break;
                case EnumPlatform.DaySurgicalBooking:
                    platformName = "日间手术预约";
                    break;
            }
            return platformName;
        }
        /// <summary>
        /// 通过平台枚举值获取平台代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumPlatform_GetPlatformCodeByEnum(EnumPlatform em)
        {
            var platformCode = 0;
            switch (em)
            {
                case EnumPlatform.UniformSourcePool:
                    platformCode = 1;
                    break;
                case EnumPlatform.BerthBooking:
                    platformCode = 2;
                    break;
                case EnumPlatform.SurgeryBooking:
                    platformCode = 3;
                    break;
                case EnumPlatform.MedicalTechBooking:
                    platformCode = 4;
                    break;
                case EnumPlatform.DaySurgicalBooking:
                    platformCode = 5;
                    break;
            }
            return platformCode;
        }
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum EnumMessageType
    {
        /// <summary>
        /// 预约成功
        /// </summary>
        [Description("预约成功")]
        BookingSuccess = 1001,
        /// <summary>
        /// 取消预约成功
        /// </summary>
        [Description("取消预约成功")]
        CancelBooking = 1002,
        /// <summary>
        /// 医生停诊成功
        /// </summary>
        [Description("医生停诊成功")]
        StopExaming = 1003,
        /// <summary>
        /// 医生取消停诊成功
        /// </summary>
        [Description("医生取消停诊成功")]
        CancelStopExaming = 1004,
        /// <summary>
        /// 床位申请成功
        /// </summary>
        [Description("床位申请成功")]
        BerthApply = 1005,
        /// <summary>
        /// 通知入院
        /// </summary>
        [Description("通知入院")]
        InformAdmission = 1006,
        /// <summary>
        /// 床位取消成功
        /// </summary>
        [Description("床位取消成功")]
        CancelBerth = 1007,
        /// <summary>
        /// 手术申请成功
        /// </summary>
        [Description("手术申请成功")]
        SurgeryApply = 1008,
        /// <summary>
        /// 手术审核成功
        /// </summary>
        [Description("手术审核成功")]
        SurgeryVerify = 1009,
        /// <summary>
        /// 手术拒绝成功
        /// </summary>
        [Description("手术拒绝成功")]
        SurgeryRefuse = 1010,
        /// <summary>
        /// 手术取消成功
        /// </summary>
        [Description("手术取消成功")]
        SurgeryCancel = 1011,
        /// <summary>
        /// 医技预约成功
        /// </summary>
        [Description("医技预约成功")]
        MedicalBookingSuccess = 1012,
        /// <summary>
        /// 医技取消预约成功
        /// </summary>
        [Description("医技取消预约成功")]
        MedicalCancelBookingSuccess = 1013,
        /// <summary>
        /// 医技修改预约成功
        /// </summary>
        [Description("医技修改预约成功")]
        AlterMedicalBookingSuccess = 1014,
        /// <summary>
        /// 医技预约再次提醒
        /// </summary>
        [Description("医技预约再次提醒")]
        BookingSuccessReNotify = 1015,
        /// <summary>
        /// 患者签到成功
        /// </summary>
        [Description("患者签到成功")]
        CheckingInSuccess = 1016
    }

    /// <summary>
    /// 消息类型操作类
    /// </summary>
    public static class EnumMessageType_Class
    {
        /// <summary>
        /// 通过消息类型代码获取消息类型名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumMessageType_GetTypeNameByCode(int code)
        {
            var messageTypeName = "";
            switch (code)
            {
                case 1001:
                    messageTypeName = "预约成功";
                    break;
                case 1002:
                    messageTypeName = "取消预约成功";
                    break;
                case 1003:
                    messageTypeName = "医生停诊成功";
                    break;
                case 1004:
                    messageTypeName = "医生取消停诊成功";
                    break;
                case 1005:
                    messageTypeName = "床位申请成功";
                    break;
                case 1006:
                    messageTypeName = "通知入院";
                    break;
                case 1007:
                    messageTypeName = "床位取消成功";
                    break;
                case 1008:
                    messageTypeName = "手术申请成功";
                    break;
                case 1009:
                    messageTypeName = "手术审核成功";
                    break;
                case 1010:
                    messageTypeName = "手术拒绝成功";
                    break;
                case 1011:
                    messageTypeName = "手术取消成功";
                    break;
                case 1012:
                    messageTypeName = "医技预约成功";
                    break;
                case 1013:
                    messageTypeName = "医技取消预约成功";
                    break;
                case 1014:
                    messageTypeName = "医技修改预约成功";
                    break;
                case 1015:
                    messageTypeName = "医技预约再次提醒";
                    break;
                case 1016:
                    messageTypeName = "患者签到成功";
                    break;
            }
            return messageTypeName;
        }
        /// <summary>
        /// 通过消息类型名称获取消息类型枚举值
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static EnumMessageType EnumMessageType_GetTypeEnumByName(string typeName)
        {
            var messageTypeEnum = new EnumMessageType();
            switch (typeName)
            {
                case "预约成功":
                    messageTypeEnum = EnumMessageType.BookingSuccess;
                    break;
                case "取消预约成功":
                    messageTypeEnum = EnumMessageType.CancelBooking;
                    break;
                case "医生停诊成功":
                    messageTypeEnum = EnumMessageType.StopExaming;
                    break;
                case "医生取消停诊成功":
                    messageTypeEnum = EnumMessageType.CancelStopExaming;
                    break;
                case "床位申请成功":
                    messageTypeEnum = EnumMessageType.BerthApply;
                    break;
                case "通知入院":
                    messageTypeEnum = EnumMessageType.InformAdmission;
                    break;
                case "床位取消成功":
                    messageTypeEnum = EnumMessageType.CancelBerth;
                    break;
                case "手术申请成功":
                    messageTypeEnum = EnumMessageType.SurgeryApply;
                    break;
                case "手术审核成功":
                    messageTypeEnum = EnumMessageType.SurgeryVerify;
                    break;
                case "手术拒绝成功":
                    messageTypeEnum = EnumMessageType.SurgeryRefuse;
                    break;
                case "手术取消成功":
                    messageTypeEnum = EnumMessageType.SurgeryCancel;
                    break;
                case "医技预约成功":
                    messageTypeEnum = EnumMessageType.MedicalBookingSuccess;
                    break;
                case "医技取消预约成功":
                    messageTypeEnum = EnumMessageType.MedicalCancelBookingSuccess;
                    break;
                case "医技修改预约成功":
                    messageTypeEnum = EnumMessageType.AlterMedicalBookingSuccess;
                    break;
                case "医技预约再次提醒":
                    messageTypeEnum = EnumMessageType.BookingSuccessReNotify;
                    break;
                case "患者签到成功":
                    messageTypeEnum = EnumMessageType.CheckingInSuccess;
                    break;
            }
            return messageTypeEnum;
        }
        /// <summary>
        /// 通过消息类型枚举值获取消息类型名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumMessageType_GetTypeNameByEnum(EnumMessageType em)
        {
            var typeName = "";
            switch (em)
            {
                case EnumMessageType.BookingSuccess:
                    typeName = "预约成功";
                    break;
                case EnumMessageType.CancelBooking:
                    typeName = "取消预约成功";
                    break;
                case EnumMessageType.StopExaming:
                    typeName = "医生停诊成功";
                    break;
                case EnumMessageType.CancelStopExaming:
                    typeName = "医生取消停诊成功";
                    break;
                case EnumMessageType.BerthApply:
                    typeName = "床位申请成功";
                    break;
                case EnumMessageType.InformAdmission:
                    typeName = "通知入院";
                    break;
                case EnumMessageType.CancelBerth:
                    typeName = "床位取消成功";
                    break;
                case EnumMessageType.SurgeryApply:
                    typeName = "手术申请成功";
                    break;
                case EnumMessageType.SurgeryVerify:
                    typeName = "手术审核成功";
                    break;
                case EnumMessageType.SurgeryRefuse:
                    typeName = "手术拒绝成功";
                    break;
                case EnumMessageType.SurgeryCancel:
                    typeName = "手术取消成功";
                    break;
                case EnumMessageType.MedicalBookingSuccess:
                    typeName = "医技预约成功";
                    break;
                case EnumMessageType.MedicalCancelBookingSuccess:
                    typeName = "医技取消预约成功";
                    break;
                case EnumMessageType.AlterMedicalBookingSuccess:
                    typeName = "医技修改预约成功";
                    break;
                case EnumMessageType.BookingSuccessReNotify:
                    typeName = "医技预约再次提醒";
                    break;
                case EnumMessageType.CheckingInSuccess:
                    typeName = "患者签到成功";
                    break;
            }
            return typeName;
        }
        /// <summary>
        /// 通过消息类型枚举值获取消息类型代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumMessageType_GetTypeCodeByEnum(EnumMessageType em)
        {
            var typeCode = 0;
            switch (em)
            {
                case EnumMessageType.BookingSuccess:
                    typeCode = 1001;
                    break;
                case EnumMessageType.CancelBooking:
                    typeCode = 1002;
                    break;
                case EnumMessageType.StopExaming:
                    typeCode = 1003;
                    break;
                case EnumMessageType.CancelStopExaming:
                    typeCode = 1004;
                    break;
                case EnumMessageType.BerthApply:
                    typeCode = 1005;
                    break;
                case EnumMessageType.InformAdmission:
                    typeCode = 1006;
                    break;
                case EnumMessageType.CancelBerth:
                    typeCode = 1007;
                    break;
                case EnumMessageType.SurgeryApply:
                    typeCode = 1008;
                    break;
                case EnumMessageType.SurgeryVerify:
                    typeCode = 1009;
                    break;
                case EnumMessageType.SurgeryRefuse:
                    typeCode = 1010;
                    break;
                case EnumMessageType.SurgeryCancel:
                    typeCode = 1011;
                    break;
                case EnumMessageType.MedicalBookingSuccess:
                    typeCode = 1012;
                    break;
                case EnumMessageType.MedicalCancelBookingSuccess:
                    typeCode = 1013;
                    break;
                case EnumMessageType.AlterMedicalBookingSuccess:
                    typeCode = 1014;
                    break;
                case EnumMessageType.BookingSuccessReNotify:
                    typeCode = 1015;
                    break;
                case EnumMessageType.CheckingInSuccess:
                    typeCode = 1016;
                    break;
            }
            return typeCode;
        }
    }

    /// <summary>
    /// 消息渠道
    /// </summary>
    public enum EnumMessageChannel
    {
        [Description("短信")]
        BriefMessage = 1,
        [Description("微信公众号")]
        WechatPublicNumber = 2,
    }

    /// <summary>
    /// 消息渠道操作类
    /// </summary>
    public static class EnumMessageChannel_Class
    {
        /// <summary>
        /// 通过消息渠道代码获取消息渠道名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumMessageChannel_GetChannelNameByCode(int code)
        {
            var channelName = "";
            switch (code)
            {
                case 1:
                    channelName = "短信";
                    break;
                case 2:
                    channelName = "微信公众号";
                    break;
            }
            return channelName;
        }
        /// <summary>
        /// 通过消息渠道名称获取消息渠道枚举值
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static EnumMessageChannel EnumMessageChannel_GetChannelEnumByName(string channelName)
        {
            var channelEnum = new EnumMessageChannel();
            switch (channelName)
            {
                case "短信":
                    channelEnum = EnumMessageChannel.BriefMessage;
                    break;
                case "微信公众号":
                    channelEnum = EnumMessageChannel.WechatPublicNumber;
                    break;
            }
            return channelEnum;
        }
        /// <summary>
        /// 通过消息渠道枚举值获取消息渠道名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumMessageChannel_GetTypeNameByEnum(EnumMessageChannel em)
        {
            var channelName = "";
            switch (em)
            {
                case EnumMessageChannel.BriefMessage:
                    channelName = "短信";
                    break;
                case EnumMessageChannel.WechatPublicNumber:
                    channelName = "微信公众号";
                    break;
            }
            return channelName;
        }
        /// <summary>
        /// 通过消息渠道枚举值获取消息渠道代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumMessageChannel_GetChannelCodeByEnum(EnumMessageChannel em)
        {
            var channelCode = 0;
            switch (em)
            {
                case EnumMessageChannel.BriefMessage:
                    channelCode = 1;
                    break;
                case EnumMessageChannel.WechatPublicNumber:
                    channelCode = 2;
                    break;
            }
            return channelCode;
        }
    }

    /// <summary>
    /// 消息字段类型
    /// </summary>
    public enum EnumMessageFieldType
    {
        [Description("自定义字段")]
        CustomField = 1,
        [Description("短信字段")]
        MessageField = 2
    }

    /// <summary>
    /// 消息字段类型操作类
    /// </summary>
    public static class EnumMessageFieldType_Class
    {
        /// <summary>
        /// 通过消息字段类型代码获取消息字段类型名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumMessageFieldType_GetFieldTypeNameByCode(int code)
        {
            var fieldTypeName = "";
            switch (code)
            {
                case 1:
                    fieldTypeName = "自定义字段";
                    break;
                case 2:
                    fieldTypeName = "短信字段";
                    break;
            }
            return fieldTypeName;
        }
        /// <summary>
        /// 通过消息字段类型名称获取消息字段类型枚举值
        /// </summary>
        /// <param name="fieldTypeName"></param>
        /// <returns></returns>
        public static EnumMessageFieldType EnumMessageFieldType_GetFieldEnumByName(string fieldTypeName)
        {
            var fieldTypeEnum = new EnumMessageFieldType();
            switch (fieldTypeName)
            {
                case "自定义字段":
                    fieldTypeEnum = EnumMessageFieldType.CustomField;
                    break;
                case "短信字段":
                    fieldTypeEnum = EnumMessageFieldType.MessageField;
                    break;
            }
            return fieldTypeEnum;
        }
        /// <summary>
        /// 通过消息字段类型枚举值获取消息字段类型名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumMessageFieldType_GetFieldTypeNameByEnum(EnumMessageFieldType em)
        {
            var fieldTypeName = "";
            switch (em)
            {
                case EnumMessageFieldType.CustomField:
                    fieldTypeName = "自定义字段";
                    break;
                case EnumMessageFieldType.MessageField:
                    fieldTypeName = "短信字段";
                    break;
            }
            return fieldTypeName;
        }
        /// <summary>
        /// 通过消息字段类型枚举值获取消息字段类型代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumMessageFieldType_GetFieldTypeCodeByEnum(EnumMessageFieldType em)
        {
            var fieldTypeCode = 0;
            switch (em)
            {
                case EnumMessageFieldType.CustomField:
                    fieldTypeCode = 1;
                    break;
                case EnumMessageFieldType.MessageField:
                    fieldTypeCode = 2;
                    break;
            }
            return fieldTypeCode;
        }
    }

    /// <summary>
    /// 消息内容字段
    /// </summary>
    public enum EnumMessageField
    {
        [Description("患者姓名")]
        PatientName = 1001,
        [Description("医院名称")]
        HospitalName = 1002,
        [Description("门诊科室")]
        OutPatientDepartment = 1003,
        [Description("检查科室")]
        ExamDepartment = 1004,
        [Description("就诊序号")]
        ExamSequenceNumber = 1005,
        [Description("检查项目")]
        ExamItem = 1006,
        [Description("医生姓名")]
        DoctorName = 1007,
        [Description("检查地点")]
        ExamSite = 1008,
        [Description("注意事项")]
        Attention = 1009,
        [Description("医生排班日期")]
        DoctorArrangeDate = 1010,
        [Description("申请病房类型")]
        ApplyWardType = 1011,
        [Description("安排手术时间")]
        ArrangeOperationTime = 1012,
        [Description("申请手术时间")]
        ApplyOperationTime = 1013,
        [Description("安排手术地点")]
        ArrangeSurgerySite = 1014,
        [Description("申请手术地点")]
        ApplySurgerySite = 1015,
        [Description("入院日期")]
        AdmissionDate = 1016,
        [Description("门诊类型")]
        OutPatientType = 1017,
        [Description("医生排班时段")]
        DoctorArrangePeriod = 1018,
        [Description("检查日期")]
        ExamDate = 1019,
        [Description("申请科室")]
        ApplyDepartment = 1020,
        [Description("检查时段")]
        ExamPeriod = 1021,
        [Description("医生停诊结束日期")]
        DoctorStopEndDate = 1022,
        [Description("医生停诊结束时段")]
        DoctorStopEndPeriod = 1023,
        [Description("队列名称")]
        QueueName = 1024,
        [Description("队列说明")]
        QueueRemark = 1025,
        [Description("患者ID")]
        PatientID = 1026,
        [Description("上下午标志")]
        APM = 1027,
        [Description("脱敏姓名 【名字内容脱敏,如张嘉译--->张**】")]
        DesensePatientNameBack = 1028,
        [Description("脱敏姓名 【中间内容脱敏,如张嘉译--->张*译】")]
        DesensePatientNameMiddle = 1029,
        [Description("检查开始时间")]
        CheckStartTime = 1030,
        [Description("检查结束时间")]
        CheckEndTime = 1031,
        [Description("检查类型ID")]
        ModalityID = 1032,
        [Description("手术预约序号")]
        SurgeryBookingNumber = 1033
    }

    /// <summary>
    /// 消息内容字段操作类
    /// </summary>
    public static class EnumMessageField_Class
    {
        /// <summary>
        /// 通过消息内容字段代码获取消息内容字段名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumMessageField_GetFieldNameByCode(int code)
        {
            var fieldName = "";
            switch (code)
            {
                case 1001:
                    fieldName = "患者姓名";
                    break;

                case 1002:
                    fieldName = "医院名称";
                    break;
                case 1003:
                    fieldName = "门诊科室";
                    break;
                case 1004:
                    fieldName = "检查科室";
                    break;
                case 1005:
                    fieldName = "就诊序号";
                    break;
                case 1006:
                    fieldName = "检查项目";
                    break;
                case 1007:
                    fieldName = "医生姓名";
                    break;
                case 1008:
                    fieldName = "检查地点";
                    break;
                case 1009:
                    fieldName = "注意事项";
                    break;
                case 1010:
                    fieldName = "医生排班日期";
                    break;
                case 1011:
                    fieldName = "申请病房类型";
                    break;
                case 1012:
                    fieldName = "安排手术时间";
                    break;
                case 1013:
                    fieldName = "申请手术时间";
                    break;
                case 1014:
                    fieldName = "安排手术地点";
                    break;
                case 1015:
                    fieldName = "申请手术地点";
                    break;
                case 1016:
                    fieldName = "入院日期";
                    break;
                case 1017:
                    fieldName = "门诊类型";
                    break;
                case 1018:
                    fieldName = "医生排班时段";
                    break;
                case 1019:
                    fieldName = "检查日期";
                    break;
                case 1020:
                    fieldName = "申请科室";
                    break;
                case 1021:
                    fieldName = "检查时段";
                    break;
                case 1022:
                    fieldName = "医生停诊结束日期";
                    break;
                case 1023:
                    fieldName = "医生停诊结束时段";
                    break;
                case 1024:
                    fieldName = "队列名称";
                    break;
                case 1025:
                    fieldName = "队列说明";
                    break;
                case 1026:
                    fieldName = "患者ID";
                    break;
                case 1027:
                    fieldName = "上下午标志";
                    break;
                case 1028:
                    fieldName = "脱敏姓名 【名字内容脱敏,如张嘉译--->张**】";
                    break;
                case 1029:
                    fieldName = "脱敏姓名 【中间内容脱敏,如张嘉译--->张*译】";
                    break;
                case 1030:
                    fieldName = "检查开始时间";
                    break;
                case 1031:
                    fieldName = "检查结束时间";
                    break;
                case 1032:
                    fieldName = "检查类型ID";
                    break;
                case 1033:
                    fieldName = "手术预约序号";
                    break;
            }
            return fieldName;
        }
        /// <summary>
        /// 通过消息内容字段名称获取消息内容字段枚举值
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static EnumMessageField EnumMessageField_GetFieldEnumByName(string fieldName)
        {
            var fieldEnum = new EnumMessageField();
            switch (fieldName)
            {
                case "患者姓名":
                    fieldEnum = EnumMessageField.PatientName;
                    break;
                case "医生姓名":
                    fieldEnum = EnumMessageField.DoctorName;
                    break;
                case "医院名称":
                    fieldEnum = EnumMessageField.HospitalName;
                    break;
                case "门诊科室":
                    fieldEnum = EnumMessageField.OutPatientDepartment;
                    break;
                case "检查科室":
                    fieldEnum = EnumMessageField.ExamDepartment;
                    break;
                case "就诊序号":
                    fieldEnum = EnumMessageField.ExamSequenceNumber;
                    break;
                case "检查项目":
                    fieldEnum = EnumMessageField.ExamItem;
                    break;
                case "检查地点":
                    fieldEnum = EnumMessageField.ExamSite;
                    break;
                case "注意事项":
                    fieldEnum = EnumMessageField.Attention;
                    break;
                case "医生排班日期":
                    fieldEnum = EnumMessageField.DoctorArrangeDate;
                    break;
                case "申请病房类型":
                    fieldEnum = EnumMessageField.ApplyWardType;
                    break;
                case "安排手术时间":
                    fieldEnum = EnumMessageField.ArrangeOperationTime;
                    break;
                case "申请手术时间":
                    fieldEnum = EnumMessageField.ApplyOperationTime;
                    break;
                case "安排手术地点":
                    fieldEnum = EnumMessageField.ArrangeSurgerySite;
                    break;
                case "申请手术地点":
                    fieldEnum = EnumMessageField.ApplySurgerySite;
                    break;
                case "入院日期":
                    fieldEnum = EnumMessageField.AdmissionDate;
                    break;
                case "门诊类型":
                    fieldEnum = EnumMessageField.OutPatientType;
                    break;
                case "医生排班时段":
                    fieldEnum = EnumMessageField.DoctorArrangePeriod;
                    break;
                case "检查日期":
                    fieldEnum = EnumMessageField.ExamDate;
                    break;
                case "申请科室":
                    fieldEnum = EnumMessageField.ApplyDepartment;
                    break;
                case "检查时段":
                    fieldEnum = EnumMessageField.ExamPeriod;
                    break;
                case "医生停诊结束日期":
                    fieldEnum = EnumMessageField.DoctorStopEndDate;
                    break;
                case "医生停诊结束时段":
                    fieldEnum = EnumMessageField.DoctorStopEndPeriod;
                    break;
                case "队列名称":
                    fieldEnum = EnumMessageField.QueueName;
                    break;
                case "队列说明":
                    fieldEnum = EnumMessageField.QueueRemark;
                    break;
                case "患者ID":
                    fieldEnum = EnumMessageField.PatientID;
                    break;
                case "上下午标志":
                    fieldEnum = EnumMessageField.APM;
                    break;
                case "脱敏姓名 【名字内容脱敏,如张嘉译--->张**】":
                    fieldEnum = EnumMessageField.DesensePatientNameBack;
                    break;
                case "脱敏姓名 【中间内容脱敏,如张嘉译--->张*译】":
                    fieldEnum = EnumMessageField.DesensePatientNameMiddle;
                    break;
                case "检查开始时间":
                    fieldEnum = EnumMessageField.CheckStartTime;
                    break;
                case "检查结束时间":
                    fieldEnum = EnumMessageField.CheckEndTime;
                    break;
                case "检查类型ID":
                    fieldEnum = EnumMessageField.ModalityID;
                    break;
                case "手术预约序号":
                    fieldEnum = EnumMessageField.SurgeryBookingNumber;
                    break;
            }
            return fieldEnum;
        }
        /// <summary>
        /// 通过消息内容字段枚举值获取消息内容字段名称
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static string EnumMessageField_GetFieldNameByEnum(EnumMessageField em)
        {
            var fieldName = "";
            switch (em)
            {
                case EnumMessageField.PatientName:
                    fieldName = "患者姓名";
                    break;
                case EnumMessageField.DoctorName:
                    fieldName = "医生姓名";
                    break;
                case EnumMessageField.HospitalName:
                    fieldName = "医院名称";
                    break;
                case EnumMessageField.OutPatientDepartment:
                    fieldName = "门诊科室";
                    break;
                case EnumMessageField.ExamDepartment:
                    fieldName = "检查科室";
                    break;
                case EnumMessageField.ExamSequenceNumber:
                    fieldName = "就诊序号";
                    break;
                case EnumMessageField.ExamItem:
                    fieldName = "检查项目";
                    break;
                case EnumMessageField.ExamSite:
                    fieldName = "检查地点";
                    break;
                case EnumMessageField.Attention:
                    fieldName = "注意事项";
                    break;
                case EnumMessageField.DoctorArrangeDate:
                    fieldName = "医生排班日期";
                    break;
                case EnumMessageField.ApplyWardType:
                    fieldName = "申请病房类型";
                    break;
                case EnumMessageField.ArrangeOperationTime:
                    fieldName = "安排手术时间";
                    break;
                case EnumMessageField.ApplyOperationTime:
                    fieldName = "申请手术时间";
                    break;
                case EnumMessageField.ArrangeSurgerySite:
                    fieldName = "安排手术地点";
                    break;
                case EnumMessageField.ApplySurgerySite:
                    fieldName = "申请手术地点";
                    break;
                case EnumMessageField.AdmissionDate:
                    fieldName = "入院日期";
                    break;
                case EnumMessageField.OutPatientType:
                    fieldName = "门诊类型";
                    break;
                case EnumMessageField.DoctorArrangePeriod:
                    fieldName = "医生排班时段";
                    break;
                case EnumMessageField.ExamDate:
                    fieldName = "检查日期";
                    break;
                case EnumMessageField.ApplyDepartment:
                    fieldName = "申请科室";
                    break;
                case EnumMessageField.ExamPeriod:
                    fieldName = "检查时段";
                    break;
                case EnumMessageField.DoctorStopEndDate:
                    fieldName = "医生停诊结束日期";
                    break;
                case EnumMessageField.DoctorStopEndPeriod:
                    fieldName = "医生停诊结束时段";
                    break;
                case EnumMessageField.QueueName:
                    fieldName = "队列名称";
                    break;
                case EnumMessageField.QueueRemark:
                    fieldName = "队列说明";
                    break;
                case EnumMessageField.PatientID:
                    fieldName = "患者ID";
                    break;
                case EnumMessageField.APM:
                    fieldName = "上下午标志";
                    break;
                case EnumMessageField.DesensePatientNameBack:
                    fieldName = "脱敏姓名 【名字内容脱敏,如张嘉译--->张**】";
                    break;
                case EnumMessageField.DesensePatientNameMiddle:
                    fieldName = "脱敏姓名 【中间内容脱敏,如张嘉译--->张*译】";
                    break;
                case EnumMessageField.CheckStartTime:
                    fieldName = "检查开始时间";
                    break;
                case EnumMessageField.CheckEndTime:
                    fieldName = "检查结束时间";
                    break;
                case EnumMessageField.ModalityID:
                    fieldName = "检查类型ID";
                    break;
                case EnumMessageField.SurgeryBookingNumber:
                    fieldName = "手术预约序号";
                    break;
            }
            return fieldName;
        }
        /// <summary>
        /// 通过消息内容字段枚举值获取消息内容字段代码
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static int EnumMessageField_GetFieldCodeByEnum(EnumMessageField em)
        {
            var fieldCode = 0;
            switch (em)
            {
                case EnumMessageField.PatientName:
                    fieldCode = 1001;
                    break;
                case EnumMessageField.DoctorName:
                    fieldCode = 1007;
                    break;
                case EnumMessageField.HospitalName:
                    fieldCode = 1002;
                    break;
                case EnumMessageField.OutPatientDepartment:
                    fieldCode = 1003;
                    break;
                case EnumMessageField.ExamDepartment:
                    fieldCode = 1004;
                    break;
                case EnumMessageField.ExamSequenceNumber:
                    fieldCode = 1005;
                    break;
                case EnumMessageField.ExamItem:
                    fieldCode = 1006;
                    break;
                case EnumMessageField.ExamSite:
                    fieldCode = 1008;
                    break;
                case EnumMessageField.Attention:
                    fieldCode = 1009;
                    break;
                case EnumMessageField.DoctorArrangeDate:
                    fieldCode = 1010;
                    break;
                case EnumMessageField.ApplyWardType:
                    fieldCode = 1011;
                    break;
                case EnumMessageField.ArrangeOperationTime:
                    fieldCode = 1012;
                    break;
                case EnumMessageField.ApplyOperationTime:
                    fieldCode = 1013;
                    break;
                case EnumMessageField.ArrangeSurgerySite:
                    fieldCode = 1014;
                    break;
                case EnumMessageField.ApplySurgerySite:
                    fieldCode = 1015;
                    break;
                case EnumMessageField.AdmissionDate:
                    fieldCode = 1016;
                    break;
                case EnumMessageField.OutPatientType:
                    fieldCode = 1017;
                    break;
                case EnumMessageField.DoctorArrangePeriod:
                    fieldCode = 1018;
                    break;
                case EnumMessageField.ExamDate:
                    fieldCode = 1019;
                    break;
                case EnumMessageField.ApplyDepartment:
                    fieldCode = 1020;
                    break;
                case EnumMessageField.ExamPeriod:
                    fieldCode = 1021;
                    break;
                case EnumMessageField.DoctorStopEndDate:
                    fieldCode = 1022;
                    break;
                case EnumMessageField.DoctorStopEndPeriod:
                    fieldCode = 1023;
                    break;
                case EnumMessageField.QueueName:
                    fieldCode = 1024;
                    break;
                case EnumMessageField.QueueRemark:
                    fieldCode = 1025;
                    break;
                case EnumMessageField.PatientID:
                    fieldCode = 1026;
                    break;
                case EnumMessageField.APM:
                    fieldCode = 1027;
                    break;
                case EnumMessageField.DesensePatientNameBack:
                    fieldCode = 1028;
                    break;
                case EnumMessageField.DesensePatientNameMiddle:
                    fieldCode = 1029;
                    break;
                case EnumMessageField.CheckStartTime:
                    fieldCode = 1030;
                    break;
                case EnumMessageField.CheckEndTime:
                    fieldCode = 1031;
                    break;
                case EnumMessageField.ModalityID:
                    fieldCode = 1032;
                    break;
                case EnumMessageField.SurgeryBookingNumber:
                    fieldCode = 1033;
                    break;
            }
            return fieldCode;
        }
    }

    /// <summary>
    /// 短信发送状态
    /// </summary>
    public enum EnumMessageSendState
    {
        [Description("发送失败")]
        SendFail = -1,
        [Description("已发送")]
        Sent = 0,
        [Description("未发送")]
        UnSent = 1
    }
    public static class EnumMessageSendState_Class
    {
        public static int EnumMessageSendState_GetCodeByName(string name)
        {
            var code = 1;
            switch (name)
            {
                case "发送失败":
                    code = -1;
                    break;
                case "已发送":
                    code = 0;
                    break;
                case "未发送":
                    code = 1;
                    break;
            }
            return code;
        }
        public static string EnumMessageSendState_GetNameByCode(int code)
        {
            var name = string.Empty;
            switch (code)
            {
                case -1:
                    name = "发送失败";
                    break;
                case 0:
                    name = "已发送";
                    break;
                case 1:
                    name = "未发送";
                    break;
            }
            return name;
        }
    }

    /// <summary>
    /// 短信二次发送时间设置
    /// </summary>
    public enum EnumMessageReSendTime
    {
        [Description("检查前24小时")]
        Ahead24 = 0,
        [Description("检查前一天")]
        AheadOneDay = 1,
        [Description("检查当天")]
        CurrentDay = 2
    }
    /// <summary>
    /// 短信二次发送时间设置操作类
    /// </summary>
    public static class EnumMessageReSendTime_Class
    {
        /// <summary>
        /// 根据 代码获取名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EnumMessageReSendTime_GetNameByCode(int code)
        {
            var name = "";
            switch (code)
            {
                case 0:
                    name = "检查前24小时";
                    break;
                case 1:
                    name = "检查前一天";
                    break;
                case 2:
                    name = "检查当天";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 根据 名称获取枚举
        /// </summary>
        /// <param name="name">枚举名称</param>
        /// <returns></returns>
        public static EnumMessageReSendTime EnumMessageReSendTime_GetEnumByName(string name)
        {
            var eg = new EnumMessageReSendTime();
            switch (name)
            {
                case "检查前24小时":
                    eg = EnumMessageReSendTime.Ahead24;
                    break;
                case "检查前一天":
                    eg = EnumMessageReSendTime.AheadOneDay;
                    break;
                case "检查当天":
                    eg = EnumMessageReSendTime.CurrentDay;
                    break;
            }
            return eg;
        }
        /// <summary>
        /// 根据 代码获取枚举
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static EnumMessageReSendTime EnumMessageReSendTime_GetEnumByCode(int code)
        {
            var eg = new EnumMessageReSendTime();
            switch (code)
            {
                case 0:
                    eg = EnumMessageReSendTime.Ahead24;
                    break;
                case 1:
                    eg = EnumMessageReSendTime.AheadOneDay;
                    break;
                case 2:
                    eg = EnumMessageReSendTime.CurrentDay;
                    break;
            }
            return eg;
        }
        /// <summary>
        /// 根据 枚举获取名称
        /// </summary>
        /// <param name="eg"></param>
        /// <returns></returns>
        public static string EnumMessageReSendTimeName_GetNameByEnum(EnumMessageReSendTime eg)
        {
            var name = "";
            switch (eg)
            {
                case EnumMessageReSendTime.Ahead24:
                    name = "检查前24小时";
                    break;
                case EnumMessageReSendTime.AheadOneDay:
                    name = "检查前一天";
                    break;
                case EnumMessageReSendTime.CurrentDay:
                    name = "检查当天";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 根据 枚举获取代码
        /// </summary>
        /// <param name="eg"></param>
        /// <returns></returns>
        public static int EnumMessageReSendTimeName_GetCodeByEnum(EnumMessageReSendTime eg)
        {
            var code = 0;
            switch (eg)
            {
                case EnumMessageReSendTime.Ahead24:
                    code = 0;
                    break;
                case EnumMessageReSendTime.AheadOneDay:
                    code = 1;
                    break;
                case EnumMessageReSendTime.CurrentDay:
                    code = 2;
                    break;
            }
            return code;
        }
    }
}
