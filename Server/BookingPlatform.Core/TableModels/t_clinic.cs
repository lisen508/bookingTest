/*----------------------------------------------------------------
* desc：yeheping.t_clinic  的基本增删改查操作
* date：2019-08-30 14:50:42 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_clinic
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 父元素节点ID
        /// </summary>
        public string ParentID { get; set; }

        ///<summary>
        ///第三方科室ID，如用户中心科室ID
        ///</summary>
        public string ThirdClinicID { get; set; }

        ///<summary>
        ///HIS科室ID
        ///</summary>
        public string His_ClinicID { get; set; }

        ///<summary>
        ///科室名称
        ///</summary>
        public string ClinicName { get; set; }

        ///<summary>
        ///科室描述
        ///</summary>
        public string ClinicDesc { get; set; }

        ///<summary>
        ///科室位置
        ///</summary>
        public string ClinicSite { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}