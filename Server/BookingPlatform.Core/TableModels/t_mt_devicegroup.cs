/*----------------------------------------------------------------
* desc：yeheping.t_mt_devicegroup  的基本增删改查操作
* date：2019-10-17 10:58:22 
*----------------------------------------------------------------*/

namespace BookingPlatform.Core.TableModels
{
    ///<summary>
	///
	///</summary>
	public partial class t_mt_devicegroup
    {

        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查类型
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///群组CODE
        ///</summary>
        public string GroupCode { get; set; }

        ///<summary>
        ///群组名称
        ///</summary>
        public string GroupName { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string Remark { get; set; }

        ///<summary>
        ///队列属性  0表示全部勾选 1,2,3,4分别表示门诊、住院、急诊、VIP
        ///</summary>
        public string GroupProperty { get; set; }

        ///<summary>
        ///队列当前状态   0/1 表示关闭/开启
        ///</summary>
        public int? State { get; set; }

        ///<summary>
        ///创建日期
        ///</summary>
        public string CreateDT { get; set; }

        ///<summary>
        ///软删标志
        ///</summary>
        public string IsDelete { get; set; }

        ///<summary>
        ///PC端号源生成日期  0-7天、1-14天、2-30天、3-60天
        ///</summary>
        public string SourceDisplayOrderStyle { get; set; }

        ///<summary>
        ///手机端号源生成日期  0-7天、1-14天、2-30天、3-60天
        ///</summary>
        public string PhoneSourceDisplayOrderStyle { get; set; }

        ///<summary>
        ///自助机端号源生成日期  0-7天、1-14天、2-30天、3-60天
        ///</summary>
        public string AutoSourceDisplayOrderStyle { get; set; }
    }
}