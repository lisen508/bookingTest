/*----------------------------------------------------------------
* desc：yeheping.t_mt_sourcepool  的基本增删改查操作
* date：2019-10-17 15:59:49 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_sourcepool
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///科室信息表ID
        ///</summary>
        public string TClinicID { get; set; }

        ///<summary>
        ///队列表ID
        ///</summary>
        public string DeviceGroupID { get; set; }

        ///<summary>
        ///日期
        ///</summary>
        public string YMD { get; set; }

        ///<summary>
        ///时间段，上午、中午、下午、夜间
        ///</summary>
        public int? Period { get; set; }

        ///<summary>
        ///几号
        ///</summary>
        public int? SourceNo { get; set; }
        /// <summary>
        /// 号源类型 0自动添加，1手动新增的附加号
        /// </summary>
        public int? SourceType { get; set; }
        ///<summary>
        ///号源状态，0:未使用,1:已使用,2:已冻结
        ///</summary>
        public int? SourceStatus { get; set; }

        ///<summary>
        ///号源锁
        ///</summary>
        public int? IsLock { get; set; }

        ///<summary>
        ///号源被锁时间
        ///</summary>
        public DateTime? LockDT { get; set; }

        ///<summary>
        ///患者信息表ID
        ///</summary>
        public string TPatientID { get; set; }

        ///<summary>
        ///使用者名字
        ///</summary>
        public string UsedName { get; set; }

        ///<summary>
        ///时间段起始时间
        ///</summary>
        public string PeriodStart { get; set; }

        ///<summary>
        ///时间段结束时间
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
        ///自定义附加号字段前缀
        ///</summary>
        public string CustomPrefix { get; set; }

        ///<summary>
        ///每个号源占用时间
        ///</summary>
        public int? EverySegmentsTime { get; set; }

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