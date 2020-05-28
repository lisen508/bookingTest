using BookingPlatform.Core.TableModels;
using System.Collections.Generic;

namespace BookingPlatform.Core.TableModelExs
{
    /// <summary>
    /// 检查类型日规则
    /// </summary>
    public class PatientProportionDto : t_mt_machineperiod
    {

        public PatientProportionDto() { }
        public PatientProportionDto(t_mt_machineperiod jitem)
        {
            this.ClinicID = jitem.ClinicID;
            this.CreateDT = jitem.CreateDT;
            this.DeviceGroupID = jitem.DeviceGroupID;
            this.EndDT = jitem.EndDT;
            this.EverySegmentsNum = jitem.EverySegmentsNum;
            this.ID = jitem.ID;
            this.PeriodTime = jitem.PeriodTime;
            this.Proportion = jitem.Proportion;
            this.ProportionType = jitem.ProportionType;
            this.SegmentsNum = jitem.SegmentsNum;
            this.Sequeue = jitem.Sequeue;
            this.SpecificSource = jitem.SpecificSource;
            this.SpecificSourceType = jitem.SpecificSourceType;
            this.StartDT = jitem.StartDT;
            this.TMachinePeriodSummary = jitem.TMachinePeriodSummary;
            this.Week = jitem.Week;
        }

        public IList<t_mt_patient_proportion> PatientProps { get; set; } = new List<t_mt_patient_proportion>();
    }

}
