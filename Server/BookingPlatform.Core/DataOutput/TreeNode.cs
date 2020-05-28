using System.Collections.Generic;

namespace BookingPlatform.Core.DataOutput
{  /// <summary>
   /// 检查项目合并弹出提示
   /// </summary>
    public class ExamItemCheckList
    {
        /// <summary>
        /// 检查结果的title
        /// </summary>
        public string checkTitle { get; set; }
        /// <summary>
        ///检查结果的提示信息
        /// </summary>
        public List<string> checkList { get; set; }
    }


    /// <summary>
    /// 树节点集合
    /// </summary>
    public class TreeNodeList : stHead
    {
        public TreeNodeList()
        {
            treeNodeList = new List<TreeNode>();
        }
        public IList<TreeNode> treeNodeList { get; set; }
    }
    /// <summary>
    /// 树节点
    /// </summary>
    public class TreeNode
    {
        public TreeNode()
        {
            children = new List<TreeNode>();
        }
        /// <summary>
        /// 节点ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 节点类型：1类型 2部位3 项目
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 节点级别 根节点Level=1
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 节点描述
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 所属检查类型id
        /// </summary>
        public string clinicid { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public IList<TreeNode> children { get; set; }
    }
}
