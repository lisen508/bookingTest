using System.Collections.Generic;

namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 
    /// </summary>
    public class DoctorArrangeInput
    {
        /// <summary>
        /// 
        /// </summary>
        public class inUpdateDoctorArrangeInfo
        {
            public List<UpdateDoctorArrangeInfo> ListUpdateDoctorArrange = new List<UpdateDoctorArrangeInfo>();
        }

        /// <summary>
        /// 
        /// </summary>
        public class UpdateDoctorArrangeInfo
        {
            public string TArrangeDetailID = "";
            public string TOutpatientTypeID = "";
            public string PeriodStart = "";
            public string PeriodEnd = "";
            public int TimeSpacs = 0;
            public int SameSourceNum = 0;
        }
    }
}