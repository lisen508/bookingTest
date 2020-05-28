/*----------------------------------------------------------------
* desc：t_wechat_log  的基本增删改查操作
* date：2020-05-07 14:51:06 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    /// <summary>
    /// 黑龙江微信消息返回模型
    /// </summary>
    public class MessageResult
    {
        public int code { get; set; }
        public object data { get; set; }

        public string msg { get; set; }
    }

    ///<summary>
	///
	///</summary>
	public partial class t_wechat_log
    {
        ///<summary>
        ///id主键
        ///</summary>
        public string ID { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public string HospitalID { get; set; }
        ///<summary>
        ///平台ID
        ///</summary>
        public int PlatformID { get; set; }
        /// <summary>
        /// 子标题
        /// </summary>
        public string SubTitle { get; set; }

        ///<summary>
        ///患者OpenID
        ///</summary>
        public string OpenID { get; set; }
        ///<summary>
        ///患者GUID
        ///</summary>
        public string PatientGUID { get; set; }
        ///<summary>
        ///患者姓名
        ///</summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 发送文本
        /// </summary>
        public string ContentText { get; set; }
        /// <summary>
        /// 发送的内容包
        /// </summary>
        public string SendContent { get; set; }
        ///<summary>
        ///状态 1成功 0失败
        ///</summary>
        public int Status { get; set; }

        /// <summary>
        /// 删除标志：0正常，1删除
        /// </summary>
        public int IsDelete { get; set; }
        ///<summary>
        ///创建时间
        ///</summary>
        public string CreateDT { get; set; }
    }
}