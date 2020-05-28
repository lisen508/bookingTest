namespace BookingPlatform.Core.DataInPut
{
    /// <summary>
    /// 用户中心完整医联体信息
    /// </summary>
    public class CompleteUnionInfo
    {
        public string address_code_text { get; set; }

        public string isopen_text { get; set; }

        public string full_code_text { get; set; }

        public string ExtProperties { get; set; }

        public string ext_prop_value { get; set; }

        public string union_id { get; set; }

        public string union_name { get; set; }

        public string union_short_name { get; set; }

        public string union_pinyin { get; set; }

        public string expert_hospital_id { get; set; }

        public string models { get; set; }

        public string union_token { get; set; }

        public int is_summary { get; set; }

        public string address_code { get; set; }

        public string union_detail { get; set; }

        public string contacts { get; set; }

        public string contact_phone { get; set; }

        public string web_url { get; set; }

        public string Createtime { get; set; }

        public string CreateUserid { get; set; }

        public string Updatetime { get; set; }

        public string Updateuserid { get; set; }

        public int isopen { get; set; }

        public int hospitalcount { get; set; }

        public int usercount { get; set; }

        public string logourl { get; set; }

        public string address { get; set; }
    }

    /// <summary>
    /// 用户中心返回医联体信息
    /// </summary>
    public class ReturnUnionInfo
    {
        public int ret_code { get; set; } = 0;

        public string ret_info { get; set; }

        public ret_data ret_data { get; set; }
    }

    public class ret_data
    {
        public string address_code_text { get; set; }

        public string isopen_text { get; set; }

        public string full_code_text { get; set; }

        public string ExtProperties { get; set; }

        public string ext_prop_value { get; set; }

        public string union_id { get; set; }

        public string union_name { get; set; }

        public string union_short_name { get; set; }

        public string union_pinyin { get; set; }

        public string expert_hospital_id { get; set; }

        public string models { get; set; }

        public string union_token { get; set; }

        public int is_summary { get; set; }

        public string address_code { get; set; }

        public string union_detail { get; set; }

        public string contacts { get; set; }

        public string contact_phone { get; set; }

        public string web_url { get; set; }

        public string Createtime { get; set; }

        public string CreateUserid { get; set; }

        public string Updatetime { get; set; }

        public string Updateuserid { get; set; }

        public int isopen { get; set; }

        public int hospitalcount { get; set; }

        public int usercount { get; set; }

        public string logourl { get; set; }

        public string address { get; set; }
    }
}
