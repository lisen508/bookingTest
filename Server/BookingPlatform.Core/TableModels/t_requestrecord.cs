/*----------------------------------------------------------------
* desc：yeheping.t_requestrecord  的基本增删改查操作
* date：2020-01-20 15:54:08 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_requestrecord
    {
        ///<summary>
        ///请求的接口记录
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///请求的路径+请求参数
        ///</summary>
        public string RequestUri { get; set; }

        ///<summary>
        ///请求的绝对路径
        ///</summary>
        public string RequestPath { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        public string HospitalID { get; set; }
        ///<summary>
        ///操作者ID
        ///</summary>
        public string OperatorID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///软删标志 0/1
        ///</summary>
        public int? IsDelete { get; set; }
    }
}