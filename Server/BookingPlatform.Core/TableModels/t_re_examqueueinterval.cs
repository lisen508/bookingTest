using System;
using System.Collections.Generic;

namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// 检查队列间隔表
    /// </summary>
    public partial class t_re_examqueueinterval
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 检查队列A的ID
        /// </summary>
        public string QueueIdA { get; set; }
        /// <summary>
        /// 检查队列A的名称
        /// </summary>
        public string QueueNameA { get; set; }

        /// <summary>
        /// 检查队列B的ID
        /// </summary>
        public string QueueIdB { get; set; }
        /// <summary>
        /// 检查队列B的名称
        /// </summary>
        public string QueueNameB { get; set; }
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

    public partial class ClinicsDevicegroupsList
    {
        /// <summary>
        /// 获取科室
        /// </summary>
        public List<t_mt_clinic> t_Mt_ClinicsList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<t_mt_devicegroup> t_mt_Devicegroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<t_re_examqueueinterval> t_Re_examqueueintervalB { get; set; }

    }
}
