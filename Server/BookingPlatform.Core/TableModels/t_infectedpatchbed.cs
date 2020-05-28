/*----------------------------------------------------------------
* desc：yeheping.t_infectedpatchbed  的基本增删改查操作
* date：2019-08-30 14:50:44 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_infectedpatchbed
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///病区表ID
        ///</summary>
        public string TInfectedPatchID { get; set; }

        ///<summary>
        ///病房表ID
        ///</summary>
        public string TInfectedPatchRoomID { get; set; }

        ///<summary>
        ///床号
        ///</summary>
        public string BedNo { get; set; }

        ///<summary>
        ///价格
        ///</summary>
        public double? Price { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public DateTime CreateDT { get; set; }

        ///<summary>
        ///删除标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}