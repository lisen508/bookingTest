using System.ComponentModel;

namespace BookingPlatform_Common
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum EnumSendOtherType
    {
        [Description("医技预约")]
        Booking = 1,

        [Description("互联网医院")]
        NetWookHosptial = 2,

        [Description("医技取消预约")]
        CancleBooking = 3,
        [Description("修改预约")]
        ChangeBooking = 4
    }
}
