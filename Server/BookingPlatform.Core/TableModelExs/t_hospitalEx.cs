namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// t_hospital扩展类
    /// </summary>
    public class t_hospitalEx : t_hospital
    {
        /// <summary>
        /// 是否选中,默认0-不选中
        /// </summary>
        public int IsSelect { get; set; } = 0;
        /// <summary>
        /// 展示序号
        /// </summary>
        public int DisplayNo { get; set; }

        /// <summary>
        /// 设置IsSelect的值
        /// </summary>
        public void SetSelection()
        {
            this.IsSelect = 1;
        }
        /// <summary>
        /// 设置DisplayNo=1
        /// </summary>
        public void SetDisplayNo()
        {
            this.DisplayNo = 1;
        }
    }
}
