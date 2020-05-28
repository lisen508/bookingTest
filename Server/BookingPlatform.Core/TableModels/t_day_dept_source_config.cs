using SqlSugar;
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///日间手术科室每日最大号源设置
    ///</summary>
    [SugarTable("t_day_dept_source_config")]
    public partial class t_day_dept_source_config
    {
        public t_day_dept_source_config()
        {


        }
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
        /// Desc:科室名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeptName { get; set; }

        /// <summary>
        /// Desc:科室编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DeptCode { get; set; }

        /// <summary>
        /// Desc:号源数量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? SourceCount { get; set; }

        /// <summary>
        /// Desc:软删除标准（0 标识可用 1表示删除 ）
        /// Default:
        /// Nullable:True
        /// </summary>  
        public int IsDelete { get; set; }

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
