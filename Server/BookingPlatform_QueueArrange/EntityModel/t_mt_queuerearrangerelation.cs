namespace BookingPlatform_QueueArrange.EntityModel
{

    ///<summary>
    ///
    ///</summary>
    public partial class t_mt_queuerearrangerelation
    {
        ///<summary>
        ///队列排班关系表主键ID  每天每个时段对应的队列关系
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///队列排班详情表ID
        ///</summary>
        public string QueueArrangeDetailID { get; set; }

        ///<summary>
        ///队列ID
        ///</summary>
        public string QueueID { get; set; }
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }

        ///<summary>
        //当前队列状态  0：未停诊,1：停诊
        ///</summary>
        public int State { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改日期
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志 0/1
        ///</summary>
        public int IsDelete { get; set; }
    }
}
