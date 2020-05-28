using System.Collections.Generic;

namespace BookingPlatform.Core.TableModelExs
{
    public class AddSourceDtoMain
    {
        public string UserID { get; set; }
        public string HospitalID { get; set; }
        public string customPrefix { get; set; }
        public string date { get; set; }

        public string deviceGroupID { get; set; }
        public List<AddSourceDto> addList { get; set; }

    }
    public class AddSourceDto
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        /// <summary>
        /// 每小时段数
        /// </summary>
        public int countTime { get; set; }
        /// <summary>
        /// 每段个数
        /// </summary>
        public int countSource { get; set; }
        public int period { get; set; }
    }
}
