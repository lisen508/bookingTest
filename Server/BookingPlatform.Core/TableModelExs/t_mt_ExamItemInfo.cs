namespace BookingPlatform_Common.TableModelExs
{
    /// <summary>
    /// 重新匹配检查项目列表信息
    /// </summary>
    public class t_mt_ExamItemInfo
    {

        /// <summary>
        /// 检查类型ID
        /// </summary>
        public string ModalityID { get; set; }

        /// <summary>
        /// 检查类型名称
        /// </summary>
        public string ModalityName { get; set; }

        /// <summary>
        /// 检查部位ID
        /// </summary>
        public string ExambodyID { get; set; }

        /// <summary>
        /// 检查部位名称
        /// </summary>
        public string ExambodyName { get; set; }

        /// <summary>
        /// 检查项目ID
        /// </summary>
        public string ExamItemID { get; set; }

        /// <summary>
        /// 检查项目名称
        /// </summary>
        public string ExamItemName { get; set; }

        /// <summary>
        /// 检查项目编码
        /// </summary>
        public string ExamItemCode { get; set; }

        /// <summary>
        /// 检查项目HIS编码
        /// </summary>
        public string ExamItem_HisCode { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
