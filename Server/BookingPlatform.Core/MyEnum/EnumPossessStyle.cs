using System.ComponentModel;

namespace BookingPlatform.Common.MyEnum
{
    /// <summary>
    /// PC保留号源位置类型
    /// </summary>
    public enum EnumPossessStyle
    {
        /// <summary>
        /// 初始号源
        /// </summary>
        [Description("初始号源")]
        InitialSource = 0,

        /// <summary>
        /// 尾部号源
        /// </summary>
        [Description("尾部号源")]
        TailSource = 1,

        /// <summary>
        /// 交叉号源
        /// </summary>
        [Description("交叉号源")]
        CrossSource = 2
    }

    public class EnumPossessStyleEx
    {
        public static string EnumToStr(EnumPossessStyle eps)
        {
            switch (eps)
            {
                case EnumPossessStyle.InitialSource:
                    return "初始号源";
                case EnumPossessStyle.TailSource:
                    return "尾部号源";
                case EnumPossessStyle.CrossSource:
                    return "交叉号源";
                default:
                    return "";
            }
        }

        public static string EnumToStr(int? eps)
        {
            switch (eps)
            {
                case 0:
                    return "初始号源";
                case 1:
                    return "尾部号源";
                case 2:
                    return "交叉号源";
                default:
                    return "";
            }
        }
    }
}
