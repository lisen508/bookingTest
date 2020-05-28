/*----------------------------------------------------------------
* desc：yeheping.t_re_clinicpositionclosing  的基本增删改查操作
* date：2019-08-30 14:51:09 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_re_clinicpositionclosing
    {
        ///<summary>
        ///科室平仓关联表主键GUID
        ///</summary>
        public string ReClinicPositionClosingGUID { get; set; }

        ///<summary>
        ///医院组织机构代码
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///科室主键GUID
        ///</summary>
        public string ClinicGUID { get; set; }

        ///<summary>
        ///平仓表主键GUID
        ///</summary>
        public string PositionClosingGUID { get; set; }

        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///修改时间
        ///</summary>
        public string AlterDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public string IsDelete { get; set; }
    }
}