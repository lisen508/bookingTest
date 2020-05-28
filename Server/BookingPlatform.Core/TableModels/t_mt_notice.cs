using SqlSugar;
using System.Collections.Generic;

namespace BookingPlatform.Core.TableModels
{
    public class t_mt_notice
    {
        public string ID { get; set; }
        public string Content { get; set; }
        public string ClinicID { get; set; }
        [SugarColumn(IsIgnore = true)]
        public string ClinicName { get; set; }
        public string HospitalID { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public int IsDelete { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<t_mt_mattersneedattention> matter { get; set; }
    }
}
