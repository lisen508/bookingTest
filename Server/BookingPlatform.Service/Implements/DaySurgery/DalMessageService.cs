

using BookingPlatform.Core.TableModels;
using BookingPlatform.Service.Interfaces;
using System;

namespace BookingPlatform.Service.Implements
{
    public class DalMessageService : BaseService<t_day_surgical_name>, IDalMessageService
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public string ITransferMsgFormatToMsgContent(string hospitalID)
        {
            try
            {
                return hospitalID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
