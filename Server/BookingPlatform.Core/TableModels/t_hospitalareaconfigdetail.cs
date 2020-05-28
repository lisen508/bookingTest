/*----------------------------------------------------------------
* desc：yeheping.t_hospitalareaconfigdetail  的基本增删改查操作
* date：2020-01-18 15:39:49 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_hospitalareaconfigdetail
    {
        ///<summary>
        /// 院区配置表副表，主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        /// 院区绑定类型，0/1 申请单可约院区/号源可约院区
        ///</summary>
        public int BindType { get; set; }

        ///<summary>
        /// 院区配置表主表ID
        ///</summary>
        public string HospitalAreaConfigID { get; set; }

        ///<summary>
        /// 院区ID
        ///</summary>
        public string HospitalID { get; set; }

        /// <summary>
        /// 该院区所在医联体ID
        /// </summary>
        public string UnionID { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string UpdateDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public int IsDelete { get; set; }
    }
}