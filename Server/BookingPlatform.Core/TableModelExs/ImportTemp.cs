using BookingPlatform_Common.TableModels;
using System.Collections.Generic;

namespace BookingPlatform_Common.TableModelExs
{
    /// <summary>
    /// 标准库检查项目模板导入
    /// </summary>
    public class ImportTemp
    {
        /// <summary>
        /// 院区id
        /// </summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// excel文件
        /// </summary>
        public string ExamStr { get; set; }

    }

    /// <summary>
    /// 临时对象
    /// </summary>
    public class StandardLibraryTempDTO
    {
        /// <summary>
        /// 标准库检查类型
        /// </summary>
        public IList<t_mt_standard_modality> ListModality { get; set; } = new List<t_mt_standard_modality>();

        /// <summary>
        /// 标准库检查部位
        /// </summary>
        public IList<t_mt_standard_exambody> ListExamBody { get; set; } = new List<t_mt_standard_exambody>();


        /// <summary>
        /// 标准库检查项目
        /// </summary>
        public IList<t_mt_standard_examitem> ListExamItem { get; set; } = new List<t_mt_standard_examitem>();
    }
}
