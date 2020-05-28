using SqlSugar;

namespace BookingPlatform_QueueArrange.EntityModel
{
    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_devicegroup
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        /// <summary>
        /// 序号前端展示时使用
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int Num { get; set; }
        ///<summary>
        ///检查类型
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///群组CODE
        ///</summary>
        public string GroupCode { get; set; }

        ///<summary>
        ///群组名称
        ///</summary>
        public string GroupName { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///队列属性  0表示全部勾选 1,2,3,4分别表示住院、急诊、门诊、VIP
        ///</summary>
        public string GroupProperty { get; set; }
        /// <summary>
        /// 队列是否被绑定
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int IsSelect { get; set; } = 0;
        ///<summary>
        ///队列属性  前端显示
        ///</summary>
        [SugarColumn(IsIgnore = true)]
        public string FullProperyText { get; set; }
        ///<summary>
        ///队列当前状态   0/1 表示关闭/开启
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}
