using BookingPlatform.Core.TableModels;
using System.Collections.Generic;

namespace BookingPlatform.Core
{
    /// <summary>
    /// 检查项目对应号源列表
    /// </summary>
    public class TExamItemSourceInfo : stHead
    {
        /// <summary>
        /// 
        /// </summary>
        public TExamItemSourceInfo()
        {
            SourcePoolInfoList = new List<t_mt_sourcepool>();
        }

        /// <summary>`
        /// 检查项目信息
        /// </summary>
        public t_mt_examitem ExamItemInfo { get; set; }

        /// <summary>
        /// 对应号源列表
        /// </summary>
        public List<t_mt_sourcepool> SourcePoolInfoList { get; set; }
    }


}
