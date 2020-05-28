using System;

namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// 检查科室间隔表
    /// </summary>
    public partial class t_re_clinicinterval
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 检查科室A的ID（检查类型）
        /// </summary>
        public string ClinicIdA { get; set; }
        /// <summary>
        /// 检查科室B的ID（检查类型）
        /// </summary>
        public string ClinicIdB { get; set; }

        /// <summary>
        ///时间间隔 0=15分钟 1=30分钟 2=45分钟 3=60分钟
        /// </summary>
        public string TimeInterval { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDT { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDT { get; set; }

    }
}
