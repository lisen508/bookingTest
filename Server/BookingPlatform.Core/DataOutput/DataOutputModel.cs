namespace BookingPlatform.Core.DataOutput
{

    public class DataOutputModel
    {
        /// <summary>
        /// 返回值
        /// </summary>
        public int return_code { get; set; }

        /// <summary>
        /// 返回对象
        /// </summary>
        public return_data return_data { get; set; }
    }


    public class return_data
    {
        /// <summary>
        /// 操作码
        /// </summary>
        public int ret_code { get; set; }


        public string result { get; set; }
    }
}