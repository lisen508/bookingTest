using System;

namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// 
    /// </summary>
    public class t_infectedpatchroomtbedbookinginfo
    {
        /// <summary>
        /// 房间类型id
        /// </summary>
        public string ID { get; set; }


        /// <summary>
        /// 状态  已申请1；已审核2；已入院3；已取消4；已拒绝5；已出院6
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string IsDelete { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDT { get; set; }


        /// <summary>
        /// 房间类型
        /// </summary>
        public string InfectedPatchRoom { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Count { get; set; }
    }
}
