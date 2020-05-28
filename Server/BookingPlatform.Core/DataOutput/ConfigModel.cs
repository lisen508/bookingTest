using System;
using System.Collections.Generic;
using System.Text;

namespace BookingPlatform.Core.DataOutput
{
    /// <summary>
    /// 签到码显示配置选择模型
    /// </summary>
    public class CheckInConfigModel
    {
          public CheckInConfigModel checkInConfigModel;

     
        /// <summary>
        /// his申请单号
        /// </summary>
        public string ApplyID { get; set; } = string.Empty;
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PatientID { get; set; } = string.Empty;
        /// <summary>
        /// 患者身份证号码
        /// </summary>
        public string IDCard { get; set; } = string.Empty;
        /// <summary>
        /// 患者手机号码
        /// </summary>
        public string Telephone { get; set; } = string.Empty;
        /// <summary>
        /// 患者门站/住院号
        /// </summary>
        public string OutInPatientNo { get; set; } = string.Empty;
        //public CheckInConfigModel(string applyID, string patientID, string iDCard, string telephone, string outInPatientNo)
        //{
        //    ApplyID = applyID = string.Empty;
        //    PatientID = patientID = string.Empty;
        //    IDCard = iDCard = string.Empty;
        //    Telephone = telephone = string.Empty;
        //    OutInPatientNo = outInPatientNo = string.Empty;
        //}
        public CheckInConfigModel()
        { }
            /// <summary>
            /// 根据入参返回相应对象
            /// </summary>
            /// <param name="configKey"></param>
            /// <returns></returns>
            public CheckInConfigModel GetCheckInConfigModel(int configKey)
        {
            CheckInConfigModel checkInConfigModel = new CheckInConfigModel();
            switch (configKey)
            {
                case 1:
                    checkInConfigModel.ApplyID = "1";
                    break;
                case 2:
                    checkInConfigModel.PatientID = "2";
                    break;
                case 3:
                    checkInConfigModel.IDCard = "3";
                    break;
                case 4:
                    checkInConfigModel.Telephone = "4";
                    break;
                case 5:
                    checkInConfigModel.OutInPatientNo = "5";
                    break;
            }
            return checkInConfigModel;
        }
    }
}
