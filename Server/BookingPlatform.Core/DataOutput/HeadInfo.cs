using System.Collections.Generic;

namespace BookingPlatform.Core.DataOutput
{

    /// <summary>
    /// 系统配置专用model
    /// </summary>
    public class ConfigModel
    {
        public bool IsSuccess { get; set; } = true;
        public string KeyValue { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// 校验空腹检查项目上午号源提示
    /// </summary>
    public class stPeriodNotify : stHead
    {
        public stPeriodNotify()
        {
            NotifyMessage = new List<string>();
        }
        public List<string> NotifyMessage;
    }
}