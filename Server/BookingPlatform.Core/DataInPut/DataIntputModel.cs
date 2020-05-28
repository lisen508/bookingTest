namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 模拟入参
    /// </summary>
    public class DataIntputModel
    {
        /// <summary>
        /// app_id
        /// </summary>
        public string app_id { get; set; }

        /// <summary>
        /// app_key
        /// </summary>
        public string app_key { get; set; }


        /// <summary>
        /// coder
        /// </summary>
        public string coder { get; set; }

        ///// <summary>
        ///// 是否手机端（0-不是，1-是）
        ///// </summary>
        //public int isCell { get; set; }


        /// <summary>
        /// 调用路径
        /// </summary>
        public string api_name { get; set; }

        /// <summary>
        /// 入参
        /// </summary>
        public string Data { get; set; }
    }
}