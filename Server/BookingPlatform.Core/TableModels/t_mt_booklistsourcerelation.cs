/*----------------------------------------------------------------
* desc：yeheping.t_mt_booklistsourcerelation  的基本增删改查操作
* date：2019-09-17 17:02:50 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	/// 预约单ID和号源ID的关联表：存在1单申请单单个检查项目占用多个号源
	///</summary>
	public partial class t_mt_booklistsourcerelation
    {
        ///<summary>
        ///预约单ID和号源ID的关联表主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///预约单ID
        ///</summary>
        public string BookListID { get; set; }

        ///<summary>
        ///号源ID
        ///</summary>
        public string SourcePoolID { get; set; }
        ///<summary>
		///创建时间
		///</summary>
		public string CreateDT { get; set; }

        ///<summary>
		///修改时间
		///</summary>
		public string AlterDT { get; set; }

        ///<summary>
		///软删标志
		///</summary>
		public int IsDelete { get; set; }
    }
}