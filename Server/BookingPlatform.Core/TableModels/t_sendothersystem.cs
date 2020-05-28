/*----------------------------------------------------------------
* desc：yeheping.t_sendothersystem  的基本增删改查操作
* date：2019-10-22 14:21:03 
*----------------------------------------------------------------*/
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_sendothersystem
    {
        ///<summary>
        ///任务主键
        ///</summary>
        public string SendQueueid { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BookListID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string DevicegroupID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SourcePoolID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? SendFlag { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? SendTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime? CreateTime { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ErrMsg { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SystemID { get; set; }

        ///<summary>
        ///第三方类型  1->医技预约 2->互联网医嘱
        ///</summary>
        public int? SendType { get; set; }
    }
}