/*----------------------------------------------------------------
* desc：yeheping.t_mt_standard_modality  的基本增删改查操作
* date：2020-01-17 17:28:36 
*----------------------------------------------------------------*/

namespace BookingPlatform_Common.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_standard_modality
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查类型名称
        ///</summary>
        public string ModalityName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ModalityCode { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///软删标志 0/1 未删除/删除
        ///</summary>
        public int? IsDelete { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///检查类型描述
        ///</summary>
        public string ModalityDesc { get; set; }

        ///<summary>
        ///检查类型中文名称
        ///</summary>
        public string ModalityChineseName { get; set; }

        /////<summary>
        /////检查类型描述图片地址
        /////</summary>
        //public string ModalityImageUrl { get; set; }
    }
}