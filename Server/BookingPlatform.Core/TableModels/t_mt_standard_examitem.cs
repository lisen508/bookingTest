/*----------------------------------------------------------------
* desc：yeheping.t_mt_standard_examitem  的基本增删改查操作
* date：2020-01-17 17:28:18 
*----------------------------------------------------------------*/

namespace BookingPlatform_Common.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_standard_examitem
    {
        ///<summary>
        ///标准库检查项目ID
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查部位ID
        ///</summary>
        public string ExamBodyID { get; set; }

        ///<summary>
        ///检查项目编码
        ///</summary>
        public string ExamItemCode { get; set; }

        ///<summary>
        ///检查项目名称
        ///</summary>
        public string ExamItemName { get; set; }

        ///<summary>
        ///检查项目HIS编码
        ///</summary>
        public string ExamItem_HisCode { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///检查项目修改时间
        ///</summary>
        public string UpdateDT { get; set; }
    }
}