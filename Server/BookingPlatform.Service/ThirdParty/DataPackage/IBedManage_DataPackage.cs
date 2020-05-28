using BookingPlatform.Core;
using System;
using System.Collections.Generic;

namespace BookingPlatform.ThirdParty.DataPackage
{
    #region 就诊人信息接口--返回值
    public class ConsultPersonListInfo : stHead
    {
        public List<ConsultPersonInfo> ListConsultPersonInfo = new List<ConsultPersonInfo>();
    }

    public class ConsultPersonInfo
    {
        public string PatientVisitId { get; set; }
        public string PatientName { get; set; }
        public string PatientSex { get; set; }
        public string PatientSexText { get; set; }
        public string IDCard { get; set; }
        public string PatientAge { get; set; }
        public string Phone { get; set; }
        public string CardNo { get; set; }
        public string ThirdUserId { get; set; }
        public string ThirdProjectId { get; set; }
    }
    #endregion

    #region Rubik-U
    public class ConsultPerson_ListInfo
    {
        public List<ConsultPerson_Info> ListConsultPersonInfo = new List<ConsultPerson_Info>();
    }

    public class ConsultPerson_Info
    {
        public string pvPatientVisitId { get; set; }
        public string patientName { get; set; }
        public string gender { get; set; }
        public string genderValue { get; set; }
        public string idCard { get; set; }
        public string age { get; set; }
        public string phoneNumber { get; set; }
        public string cardNumber { get; set; }
        public string scyUserId { get; set; }
        public string vcProjectId { get; set; }
    }
    #endregion

    #region 随访
    public class ConsultPerson_ListInfo_SUIFANG
    {
        public int ret_code = 0;
        public string ret_info = "";
        public List<ConsultPerson_Info_SUIFANG> ret_data = new List<ConsultPerson_Info_SUIFANG>();
    }

    public class ConsultPerson_Info_SUIFANG
    {
        public string serial_no = "";
        public string user_id = "";
        public string age = "";
        public string id_no = "";
        public string patient_id = "";
        public string update_datetime = "";
        public string patient_name = "";
        public string pnmp = "";
        public string sex = "";
        public string date_of_birth = "";
        public string birth_place = "";
        public string mobile = "";
        public string contact_phone = "";
        public string phone = "";
        public string fu_flup_state = "";
        public string fu_flup_time = "";
    }
    #endregion

    #region 橄榄云
    public class ConsultPerson_ListInfo_GANLANYUN
    {
        public int code = 0;
        public string message = "";
        public ConsultPerson_ListData_GANLANYUN data = new ConsultPerson_ListData_GANLANYUN();

    }

    public class ConsultPerson_ListData_GANLANYUN
    {
        public int total = 0;
        public List<ConsultPerson_Info_GANLANYUN> list = new List<ConsultPerson_Info_GANLANYUN>();
    }

    public class ConsultPerson_Info_GANLANYUN
    {
        public string patientId = "";
        public string patientName = "";
        public string patientPhone = "";
        public int patientSex = 0;
        public string patientIdCard = "";
        public string patientBirth = "";
    }
    #endregion


    #region 掌医
    public class ConsultPerson_ListInfo_ZHANGYI
    {
        public int ret_code = 0;
        public string ret_info = "";
        public IList<ConsultPerson_ListData_ZHANGYI> ret_data = new List<ConsultPerson_ListData_ZHANGYI>();

    }

    public class ConsultPerson_ListData_ZHANGYI
    {

        public string scyUserId { get; set; }
        public string groupId { get; set; }
        public string hospitalId { get; set; }
        public string userId { get; set; }
        public string patientName { get; set; }
        public string genderValue { get; set; }
        public string age { get; set; }
        public string idCard { get; set; }
        public string patientCardType { get; set; }
        public string cardNumber { get; set; }
        public string phoneNumber { get; set; }
        public string patientEmrId { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public string isDelete { get; set; }
        public string tempIsRubik { get; set; }
        public string tempRubikPvid { get; set; }
        public string identification { get; set; }
        public string pastMedicalHistory { get; set; }
        public string pastMedicalHistoryExtra { get; set; }
        public string obstetricalHistory { get; set; }
        public string allergicHistory { get; set; }
        public string allergicHistoryExtra { get; set; }
        public string familyMedicalHistory { get; set; }
        public string patientVisitType { get; set; }
        public string familyMedicalHistoryExtra { get; set; }
        public string personalHabits { get; set; }
        public string personalHabitsExtra { get; set; }
        public string vcProjectId { get; set; }
        public string pvPatientVisitId { get; set; }
        public string userCenterOpenId { get; set; }

    }
    #endregion


    public class ConsultPerson_ListInfo_XIANGYA
    {

        public int return_code { get; set; }
        public ConsultPerson_ListInfo_XIANGYA_In return_params { get; set; }

    }
    public class ConsultPerson_ListInfo_XIANGYA_In
    {
        public int ret_code { get; set; }
        public string ret_info { get; set; }
        public List<ConsultPerson_ListData_XIANGYA> list { get; set; }
    }

    public class ConsultPerson_ListData_XIANGYA
    {
        public int id { get; set; }
        public String user_id { get; set; }
        public String name { get; set; }
        public String gender { get; set; }
        public String nation { get; set; }
        public String birthday { get; set; }
        public String id_card { get; set; }
        public String id_type { get; set; }
        public String phone1 { get; set; }
        public String patid { get; set; }
        public String health_card_id { get; set; }
        public String qr_code_text { get; set; }
        public String is_effect { get; set; }
    }

}