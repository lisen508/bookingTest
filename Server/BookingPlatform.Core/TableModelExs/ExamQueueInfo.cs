using BookingPlatform.Core.TableModels;
using System.Collections.Generic;

namespace BookingPlatform.Core.TableModelExs
{
    /// <summary>
    /// 检查项目-队列 model
    /// </summary>
    public class ExamQueueModel
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public ExamQueueModel()
        {
            QueueIdList = new List<string>();
            IsRemainSource = 1;
            SourcePoolList = new List<t_mt_sourcepool>();
        }
        /// <summary>
        /// 检查项目Id
        /// </summary>
        public string ExamItemId { get; set; }
        /// <summary>
        /// 检查项目绑定的有效队列
        /// </summary>
        public List<string> QueueIdList { get; set; }
        /// <summary>
        /// 是否剩余号源 0/1 无/有
        /// </summary>
        public int IsRemainSource { get; set; }
        /// <summary>
        /// 号源列表
        /// </summary>
        public List<t_mt_sourcepool> SourcePoolList { get; set; }
    }
}
