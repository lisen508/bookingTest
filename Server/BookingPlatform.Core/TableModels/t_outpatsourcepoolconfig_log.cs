/*----------------------------------------------------------------
* desc：yeheping.t_outpatsourcepoolconfig_log  的基本增删改查操作
* date：2019-08-30 14:51:05 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatsourcepoolconfig_log
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TSourcePoolConfigID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? SourcePoolType { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BookingID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ClinicName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TDoctorID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string DoctorName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TArrangeDetailID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TBookingPlatformID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BookingPlatformName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TOutpatientTypeID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string OutpatientTypeName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public double? Price { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BookingDate { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? BookingPeriod { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PeriodStart { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PeriodEnd { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? SourceNo { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? LockState { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? UseDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string OutPatientID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientSex { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PatientBirthday { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IDCard { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsBooking { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsLockBooking { get; set; }
    }
}