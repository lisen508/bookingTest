/*----------------------------------------------------------------
* desc：yeheping.t_mt_standard_exambody  的基本增删改查操作
* date：2020-01-17 17:27:47 
*----------------------------------------------------------------*/

namespace BookingPlatform_Common.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_standard_exambody
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查类型ID
        ///</summary>
        public string ModalityID { get; set; }

        ///<summary>
        ///检查部位编码
        ///</summary>
        public string ExamBodyCode { get; set; }

        ///<summary>
        ///检查部位名称
        ///</summary>
        public string ExamBodyName { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///软删标志 0/1 未删除/删除
        ///</summary>
        public int? IsDelete { get; set; }
    }
}