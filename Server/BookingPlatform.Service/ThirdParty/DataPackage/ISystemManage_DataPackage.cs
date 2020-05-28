using System.Collections.Generic;

namespace BookingPlatform.ThirdParty
{
    #region 用户中心---医院信息详情
    public class UserPlatform_GetHospitalDetail
    {
        public int ret_code;
        public string ret_info;
        public UserPlatform_GetHospitalDetailData ret_data = new UserPlatform_GetHospitalDetailData();
    }

    public class UserPlatform_GetHospitalDetailData
    {
        public UserPlatform_GetHospitalDetailData()
        {
            UnionList = new List<string>();
        }
        public string HospitalId;
        public string OrgCode;
        public string AllHosName;
        public string ShortHosName;
        public string AddressCode;
        public string ExtProperty;
        public double longitude;
        public double latitude;
        public double distance;
        public string HosLeveName;
        public int HosLevel;
        public string contacts;
        public string contact_phone;
        public string HosLogo;
        public string Address;
        public int OrgType;
        public string OrgTypeName;
        public List<string> UnionList { get; set; }
    }
    #endregion

    #region 用户中心---医院信息列表
    public class UserPlatform_GetHospitalList
    {
        public int ret_code;
        public string ret_info;
        public UserPlatform_GetHospitalInfo ret_data = new UserPlatform_GetHospitalInfo();
    }

    public class UserPlatform_GetHospitalInfo
    {
        public int total_count;
        public List<UserPlatform_GetHospital> list = new List<UserPlatform_GetHospital>();
    }

    public class UserPlatform_GetHospital
    {
        public string HospitalId;
        public string OrgCode;
        public string AllHosName;
        public string ShortHosName;
        public string AddressCode;
        public string ExtProperty;
        public double longitude;
        public double latitude;
        public double distance;
        public string HosLeveName;
        public int HosLevel;
        public string contacts;
        public string contact_phone;
        public string HosLogo;
        public string Address;
        public int OrgType;
        public string OrgTypeName;
    }
    #endregion

    #region 用户中心---科室信息列表
    public class UserPlatform_GetClinicList
    {
        public int ret_code;
        public string ret_info;
        public UserPlatform_GetClinicInfo ret_data = new UserPlatform_GetClinicInfo();
    }

    public class UserPlatform_GetClinicInfo
    {
        public int total_count;
        public List<UserPlatform_GetClinic> list = new List<UserPlatform_GetClinic>();
    }

    public class UserPlatform_GetClinic
    {
        public string SectionId;
        public string HospitalId;
        public string SectionName;
        public int CommonClassId;
        public string ParentId;
        public int SectionType;
        public string SectionPhone;
        public string UpdateTime;
        public string ExtProperty;
        public string address_code;
        public string areainfo;
        public string S_Address;
        public string shop_no;
        public string contacts;
        public string contact_phone;
        public double longitude;
        public double latitude;
        public double distance;
        public string logo;
        public string SectionDetail;
    }

    public class UserPlatform_GetClinic_ExtProperty
    {
        public string his_setion_id = "";
        public string his_setion_addr = "";
    }
    #endregion

    #region 用户中心---医生信息列表
    public class UserPlatform_GetDoctorList
    {
        public int ret_code;
        public string ret_info;
        public UserPlatform_GetDoctorInfo ret_data = new UserPlatform_GetDoctorInfo();
    }

    public class UserPlatform_GetDoctorInfo
    {
        public int total_count;
        public List<UserPlatform_GetDoctor> list = new List<UserPlatform_GetDoctor>();
    }

    public class UserPlatform_GetDoctor
    {
        public int user_state = 0;
        public string DoctorId = "";
        public string UserId = "";
        public string SectionId = "";
        public string HospitalId = "";
        public string Name = "";
        public int Sex = 0;
        public string WorkId = "";
        public string SectionName = "";
        public string Phone;

        /// <summary>
        /// 擅长
        /// </summary>
        public string SpecialTech = "";

        /// <summary>
        /// 简介
        /// </summary>
        public string Remark = "";

        /// <summary>
        /// 医生职称
        /// </summary>
        public string LinChuangTitleName = "";
    }
    #endregion


    #region 用户中心-用心信息

    public class DoctorDetail_GetUserInfo
    {
        public int ret_code;
        public string ret_info;
        public DoctorDetail ret_data = new DoctorDetail();
    }


    /// <summary>
    /// 用户中心对象
    /// </summary>
    public class DoctorDetail
    {
        public string DoctorId { get; set; }

        public string UnitId { get; set; }

        public string UnitName { get; set; }

        public string UnitOrgCode { get; set; }

        public string union_id { get; set; }

        public IList<DJDoctorInfo> DoctorInfos { get; set; }
    }

    /// <summary>
    /// 用户院区对象
    /// </summary>
    public class DJDoctorInfo
    {
        public string DoctorId { get; set; }

        public string HospitalId { get; set; }


        public string AllHosName { get; set; }


        public string SectionId { get; set; }
        public string SectionName { get; set; }

    }

    #endregion
}