using BookingPlatform.Common.MyEnum;
using BookingPlatform.Models.LogManage;
using System;
using System.Collections.Generic;

namespace BookingPlatform.Core
{
    /// <summary>
    /// API 返回JSON字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> where T : class
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; } = true;
        /// <summary>
        /// 信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int statusCode { get; set; } = 200;
        /// <summary>
        /// 数据集
        /// </summary>
        public T data { get; set; }
    }


    /// <summary>
    /// 返回头信息
    /// </summary>
    public class stHead
    {

        /// <summary>
        /// 头信息
        /// </summary>
        public Head Head { get; set; } = new Head();
    }
    /// <summary>
    /// 根据出生日期获取年龄
    /// </summary>
    public static class GetAge
    {
        public static string get(string birthday)
        {
            try
            {
                return (DateTime.Now.Year - DateTime.Parse(birthday).Year).ToString() + "岁";
            }
            catch
            {
                return "";
            }
        }
    }
    /// <summary>
    /// 消息头
    /// </summary>
    public class Head
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public ErrCode ErrCode { get; set; } = ErrCode.SUCCESS;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; } = "成功";

        public int PageNo { get; set; } = 0;
        public int OnePageCount { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }


    public class stMTHead
    {

        public ErrCode mErrCode = ErrCode.SUCCESS;
        public string mSystemDT = DateTime.Now.ToString("yyyy-MM-dd");
        public string mMsg;
        public string mInfoID;
        public string mReturnID;
        public int mPage;
        public int mAllCount;
    }

    public class BasePage<T> where T : class
    {
        public int totalCount { get; set; }
        public List<T> list { get; set; }

        public BasePage()
        {
        }
        public BasePage(int totalCount, List<T> list)
        {
            this.totalCount = totalCount;
            this.list = list;
        }

    }
    public class reStMTHead
    {
        public stMTHead mHead = new stMTHead();
    }

    public class CommonOutputData<T> : stHead where T : class
    {
        public T ret_data { get; set; }

        public static CommonOutputData<T> Success()
        {
            return Success(null);
        }
        public static CommonOutputData<T> PageSuccess(T list, int total)
        {
            CommonOutputData<T> result = new CommonOutputData<T>();
            result.Head = new Head();
            result.Head.Msg = "成功";
            result.ret_data = list;
            result.Head.TotalCount = total;
            return result;
        }
        public static CommonOutputData<T> Success(T data)
        {

            CommonOutputData<T> result = new CommonOutputData<T>();
            result.Head = new Head();
            result.Head.Msg = "成功";
            result.ret_data = data;
            return result;
        }
        public static CommonOutputData<T> Error(Exception ex)
        {
            LogManage.LogError(ex.Message + "--------" + ex.StackTrace);
            return Error();
        }
        public static CommonOutputData<T> Error()
        {
            return Error("系统错误，请稍后重试!");
        }

        public static CommonOutputData<T> Error(String message)
        {
            return Error(message, ErrCode.ERROR);
        }
        public static CommonOutputData<T> Error(String message, ErrCode code)
        {
            CommonOutputData<T> result = new CommonOutputData<T>();
            result.Head = new Head();
            result.Head.ErrCode = ErrCode.ERROR;
            result.Head.Msg = message;
            result.ret_data = null;
            return result;
        }
    }
}
