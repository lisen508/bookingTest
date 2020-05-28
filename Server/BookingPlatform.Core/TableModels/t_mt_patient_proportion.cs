using System;

namespace BookingPlatform.Core.TableModels
{
    public class t_mt_patient_proportion
    {

        public string ID { get; set; }
        public string GroupID { get; set; }
        public string MachineperiodID { get; set; }
        public string SummaryID { get; set; }
        public int? Week { get; set; }
        public int? PatientType { get; set; }

        public int? Proportion { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
