using System.Collections.Generic;

namespace BookingPlatform_InitialHospital.DTO
{
    public class UserPlatformHospitalInfo
    {
        public int ret_code;
        public string ret_info;
        public HospitalInfoDetail ret_data = new HospitalInfoDetail();
    }

    public class HospitalInfoDetail
    {
        public HospitalInfoDetail()
        {
            UnionList = new List<string>();
        }
        public string HospitalId;
        public string OrgCode;
        public string AllHosName;
        public string ShortHosName;
        public string AddressCode;
        public string ExtProperty;
        public double Longitude;
        public double Latitude;
        public double Distance;
        public string HosLeveName;
        public string Area;
        public int HosLevel;
        public string Contacts;
        public string Contact_phone;
        public string Province;
        public string HosLogo;
        public string Address;
        public int OrgType;
        public string OrgTypeName;
        public string Remark;
        public List<string> UnionList { get; set; }
    }
}
