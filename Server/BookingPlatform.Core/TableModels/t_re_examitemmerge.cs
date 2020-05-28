using SqlSugar;
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///日间手术科室每日最大号源设置
    ///</summary>
    [SugarTable("t_re_examitemmerge")]
    public partial class t_re_examitemmerge
    {

        /// <summary>
        /// Desc:自增主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string ID { get; set; }

        /// <summary>
        /// Desc:医院ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string HospitalID { get; set; }

        /// <summary>
        /// Desc:排序
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int OrderNumber { get; set; }


        /// <summary>
        /// Desc:合并关系名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string MergeExamItemName { get; set; }

        /// <summary>
        /// Desc:合并关系的检查项目id 逗号隔开
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string MergeExamItemIds { get; set; }

        /// <summary>
        /// Desc:是否置顶
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? IsTop { get; set; }

        /// <summary>
        /// Desc:是否置顶
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? IsForce { get; set; }


        /// <summary>
        /// Desc:检查类型名称
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string ExamTypeName { get; set; }

        /// <summary>
        /// Desc:检查类编码
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string ExamTypeCode { get; set; }

        /// <summary>
        /// Desc:软删除标准（0 标识可用 1表示删除 ）
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string IsDelete { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Desc:更新时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Desc:创建人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string CreateUser { get; set; }

        /// <summary>
        /// Desc:修改人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string UpdateUser { get; set; }

    }
}
