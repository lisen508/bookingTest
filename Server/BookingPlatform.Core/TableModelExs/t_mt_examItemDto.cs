using BookingPlatform.Core.TableModels;
using BookingPlatform_Common.TableModels;

namespace BookingPlatform_Common.TableModelExs
{
    /// <summary>
    /// 检查项目列表（包含匹配状态和操作状态）
    /// </summary>
    public class t_mt_examItemDto : t_mt_examitem
    {
        // 是否匹配成功 0-匹配成功，1-匹配失败
        public int IsSuccess { get; set; }

        // 操作状态 0-再次匹配，1-手动匹配
        public int OperationStatus { get; set; }

    }

    /// <summary>
    /// 手动匹配-标准库列表
    /// </summary>

    /// <summary>
    /// 标准库列表
    /// </summary>
    public class t_mt_standard_examitemDto : t_mt_standard_examitem
    {
        /// <summary>
        /// 检查类型名称
        /// </summary>
        public string ModalityName { get; set; }
        /// <summary>
        /// 标准检查类型ID
        /// </summary>
        public string ModalityId { get; set; }
        /// <summary>
        /// 检查部位名称
        /// </summary>
        public string ExamBodyName { get; set; }
        /// <summary>
        /// 标准检查部位ID
        /// </summary>
        public string ExamBodyId { get; set; }
    }

    public class StandardExamItemDto : t_mt_standard_examitemDto
    {

        /// <summary>
        ///  是否被选中 0-未被选择,1-选中
        /// </summary>
        public int isSelect { get; set; }
    }

    /// <summary>
    /// 已关联医院列表
    /// </summary>
    public class HasBindHospitalDetailDto
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string hospitalName { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        public string hospitalId { get; set; }

        /// <summary>
        /// 检查项目编码
        /// </summary>
        public string examItemCode { get; set; }

        /// <summary>
        /// 检查项目名称
        /// </summary>
        public string examItemName { get; set; }

        /// <summary>
        /// His编码
        /// </summary>
        public string examItem_HisCode { get; set; }
    }
}
