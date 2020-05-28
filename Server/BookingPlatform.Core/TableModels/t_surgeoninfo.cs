/*----------------------------------------------------------------
* desc：yeheping.t_surgeoninfo  的基本增删改查操作
* date：2019-08-30 14:51:11 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_surgeoninfo
    {
        ///<summary>
        ///
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///手术预约id
        ///</summary>
        public string TSurgerApplyInfoId { get; set; }

        ///<summary>
        ///主刀医师id
        ///</summary>
        public string SurgeonId { get; set; }

        ///<summary>
        ///主刀医生姓名
        ///</summary>
        public string SurgeonName { get; set; }

        ///<summary>
        ///三助id
        ///</summary>
        public string ThrAidId { get; set; }

        ///<summary>
        ///二助id
        ///</summary>
        public string SecAidId { get; set; }

        ///<summary>
        ///一助id
        ///</summary>
        public string FirstAidId { get; set; }

        ///<summary>
        ///三助姓名
        ///</summary>
        public string ThrAidName { get; set; }

        ///<summary>
        ///二助姓名
        ///</summary>
        public string SecAidName { get; set; }

        ///<summary>
        ///一助姓名
        ///</summary>
        public string FirstAidName { get; set; }

        ///<summary>
        ///麻醉师id
        ///</summary>
        public string AnesthetistId { get; set; }

        ///<summary>
        ///麻醉师一id
        ///</summary>
        public string AnesthetistOneId { get; set; }

        ///<summary>
        ///麻醉师二id
        ///</summary>
        public string AnesthetistTwoId { get; set; }

        ///<summary>
        ///麻醉师姓名
        ///</summary>
        public string AnesthetisName { get; set; }

        ///<summary>
        ///麻醉师一姓名
        ///</summary>
        public string AnesthetistOneName { get; set; }

        ///<summary>
        ///麻醉师二姓名
        ///</summary>
        public string AnesthetistTwoName { get; set; }

        ///<summary>
        ///麻醉方法
        ///</summary>
        public string AnesthesiaMethod { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        public DateTime? UpdateDT { get; set; }

        ///<summary>
        ///修改人ID
        ///</summary>
        public string UpDateUId { get; set; }
    }
}