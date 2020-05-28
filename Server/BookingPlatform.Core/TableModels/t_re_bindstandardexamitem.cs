/*----------------------------------------------------------------
* desc：yeheping.t_re_bindstandardexamitem  的基本增删改查操作
* date：2020-01-17 17:28:54 
*----------------------------------------------------------------*/

namespace BookingPlatform_Common.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_re_bindstandardexamitem
    {
        ///<summary>
        ///检查项目标准库和各院区检查项目绑定关联表
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///标准库检查项目主键ID
        ///</summary>
        public string StandardExamItemID { get; set; }

        ///<summary>
        ///匹配的检查项目所属院区
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///医联体ID
        ///</summary>
        public string UnionID { get; set; }

        ///<summary>
        ///匹配的检查项目ID
        ///</summary>
        public string ExamItemID { get; set; }

        ///<summary>
        ///关联关系创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///操作者ID
        ///</summary>
        public string OperatorID { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int? IsDelete { get; set; }
    }
}