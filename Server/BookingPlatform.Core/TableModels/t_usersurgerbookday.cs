/*----------------------------------------------------------------
* desc：yeheping.t_usersurgerbookday  的基本增删改查操作
* date：2019-08-30 14:51:16 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_usersurgerbookday
    {
        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///用户表主键
        ///</summary>
        public string UserID { get; set; }

        ///<summary>
        ///院区主键
        ///</summary>
        public string HospitalID { get; set; }

        ///<summary>
        ///可预约天数
        ///</summary>
        public int? SurgerBookDay { get; set; }

        ///<summary>
        ///是否可以超越 0-可以  1-不可以
        ///</summary>
        public int? CanTranscend { get; set; }
    }
}