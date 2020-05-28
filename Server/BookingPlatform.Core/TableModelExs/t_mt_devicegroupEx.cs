using SqlSugar;

namespace BookingPlatform.Core.TableModels
{
    public partial class t_mt_devicegroup
    {
        /// <summary>
        /// 序号前端展示时使用
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int Num { get; set; }

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

    }
}
