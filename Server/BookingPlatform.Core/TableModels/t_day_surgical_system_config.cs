using SqlSugar;
using System;

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
    ///日间手术系统配置
    ///</summary>
    public partial class t_day_surgical_system_config
    {
        public t_day_surgical_system_config()
        {


        }
        /// <summary>
        /// Desc:
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
        /// Desc:配置key ID
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ConfigKeyId { get; set; }
        /// <summary>
        /// Desc:配置key
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ConfigKey { get; set; }
        /// <summary>
        /// Desc:配置的值
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ConfigValue { get; set; }

        /// <summary>
        /// Desc:配置的值的标题
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ConfigTitle { get; set; }


        /// <summary>
        /// Desc:控件类型 控件类型1文本框 2 下拉框3. 单选 4 复选框 
        /// Default:
        /// Nullable:True
        public int? ControlType { get; set; }

        /// <summary>
        /// Desc:排序序号
        /// Default:
        /// Nullable:True
        public int? SortOrdinal { get; set; }


        /// <summary>
        /// Desc:软删标志
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? IsDelete { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Desc:修改时间
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
