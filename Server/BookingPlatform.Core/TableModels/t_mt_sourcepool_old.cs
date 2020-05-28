/*----------------------------------------------------------------
* desc：yeheping.t_mt_sourcepool_old  的基本增删改查操作
* date：2019-10-17 15:59:51 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_sourcepool_old
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string YMD { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int Period { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int SourceNo { get; set; }

        /// <summary>
        /// 号源类型 0自动添加，1手动新增的附加号
        /// </summary>
        public int? SourceType { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? SourceStatus { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsLock { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? LockDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TPatientID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string UsedName { get; set; }

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
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///预约系统 0-自动接口  1-手工  2-其他
        ///</summary>
        public int? BookPlatform { get; set; }

        ///<summary>
        ///PC端保留号源 0-不是 1-是
        ///</summary>
        public int? PCReservationNumber { get; set; }

        ///<summary>
        ///自定义字段前缀
        ///</summary>
        public string CustomPrefix { get; set; }

        ///<summary>
        ///每个号源占用时间
        ///</summary>
        public int? EverySegmentsTime { get; set; }

        /// <summary>
        /// 是否显示排队号
        /// </summary>
        //public int Auto_ShowQueueConfig { get; set; }


        ///<summary>
        ///号源所在小段规则
        ///</summary>
        public string MachineperiodID { get; set; }

        ///<summary>
        ///病人类型
        ///</summary>
        public int? PatientType { get; set; }
    }
}