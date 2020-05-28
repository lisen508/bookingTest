/*----------------------------------------------------------------
* desc：yeheping.t_outpatsourcemanagerule  的基本增删改查操作
* date：2019-08-30 14:51:02 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_outpatsourcemanagerule
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
        ///号源规则类型ID
        ///</summary>
        public int RuleMouldType { get; set; }

        ///<summary>
        ///是否交叉
        ///</summary>
        public int IsAcross { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateDT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string IsDelete { get; set; }
    }
}