/*----------------------------------------------------------------
* desc：yeheping.t_infectedpatch  的基本增删改查操作
* date：2019-08-30 14:50:44 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_infectedpatch
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///病区名称
        ///</summary>
        public string InfectedPatchName { get; set; }

        ///<summary>
        ///HIS病区ID
        ///</summary>
        public string HIS_InfectedPatchID { get; set; }

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