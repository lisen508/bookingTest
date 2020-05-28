namespace BookingPlatform_Common.TableModelExs
{
    /// <summary>
    /// 标准库检查项目信息
    /// </summary>
    public class StandardLibraryInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }

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
        /// 是否关联
        /// </summary>
        public bool IsBind { get; set; }
    }
}
