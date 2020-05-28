using BookingPlatform.Core.TableModels;

namespace BookingPlatform.Service.Interfaces
{
    public interface IDalMessageService : IBaseService<t_day_surgical_name>
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        string ITransferMsgFormatToMsgContent(string hospitalID);

    }
}
