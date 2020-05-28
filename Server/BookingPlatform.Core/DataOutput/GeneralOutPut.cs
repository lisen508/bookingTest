namespace BookingPlatform.Core.DataOutput
{
    /// <summary>
    /// 通用出参
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneralOutput<T> : stHead where T : class
    {
        public GeneralOutput()
        {
            ret_data = default(T);
        }

        public T ret_data { get; set; }
    }
}
