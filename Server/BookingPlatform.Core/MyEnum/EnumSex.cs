namespace BookingPlatform.Common.MyEnum
{
    public static class EnumSex
    {
        public static string EnumSex_GetExplain(string s)
        {
            switch (s)
            {
                case "F": return "女";
                case "M": return "男";
                default: return "其他";
            }
        }

        public static string EnumSex_GetLetter(string s)
        {
            switch (s)
            {
                case "女": return "F";
                case "男": return "M";
                default: return "O";
            }
        }
    }
}