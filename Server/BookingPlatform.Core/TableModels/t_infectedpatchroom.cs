/*----------------------------------------------------------------
* desc：yeheping.t_infectedpatchroom  的基本增删改查操作
* date：2019-08-30 14:50:45 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_infectedpatchroom
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///所在院区ID
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///病房名称类型/枚举值
        ///</summary>
        public string InfectedPatchRoom { get; set; }

        ///<summary>
        ///价格
        ///</summary>
        public string InfectedPatchBedPrice { get; set; }

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