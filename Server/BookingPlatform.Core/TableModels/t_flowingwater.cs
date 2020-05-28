/*----------------------------------------------------------------
* desc：yeheping.t_flowingwater  的基本增删改查操作
* date：2019-09-17 17:02:50 
*----------------------------------------------------------------*/

namespace Model
{
    ///<summary>
	///
	///</summary>
	public partial class t_flowingwater
    {
        ///<summary>
        ///流水号主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///流水号名称
        ///</summary>
        public string FlowingWaterName { get; set; }

        ///<summary>
        ///流水号序号
        ///</summary>
        public int? FlowingWaterNum { get; set; }

        ///<summary>
        ///流水号增加值
        ///</summary>
        public int? FlowingWaterAddNum { get; set; }
    }
}