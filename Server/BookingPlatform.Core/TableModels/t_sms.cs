/*----------------------------------------------------------------
* desc：yeheping.t_sms  的基本增删改查操作
* date：2019-08-30 14:51:10 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_sms
    {
        ///<summary>
        ///
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///手机号码
        ///</summary>
        public string Phone { get; set; }

        ///<summary>
        ///消息内容
        ///</summary>
        public string Msg { get; set; }

        ///<summary>
        ///0未发送；100发送成功；-1Post失败；其他看MSG
        ///</summary>
        public int? Status { get; set; }

        ///<summary>
        ///错误信息
        ///</summary>
        public string ErrorMsg { get; set; }
    }
}