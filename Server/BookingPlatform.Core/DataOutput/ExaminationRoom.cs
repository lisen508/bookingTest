using BookingPlatform.Core.TableModels;
using System;
using System.Collections.Generic;

namespace BookingPlatform.Core.DataOutput
{


    /// <summary>
    /// 检查科室接口输出参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Clinicintervals<T> : stHead where T : class
    {
        public T ret_data { get; set; }
    }

    /// <summary>
    /// 检查科室接口输出参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Clinicintervals : stHead
    {
        // public int IsShowSurplusBed = 0;
        public List<t_re_clinicinterval> ret_data = new List<t_re_clinicinterval>();
    }

    public class GetClinicinterval : stHead
    {
        public int IsShowExaminationRoom = 0;
        public List<Clinicinterval> ListClinicinterval = new List<Clinicinterval>();
    }


    public class Clinicinterval
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string ID { get; set; }
        /// <summary>
        /// 检查科室A的ID
        /// </summary>
        public string ClinicIdA { get; set; }
        /// <summary>
        /// 检查科室A的名称
        /// </summary>
        public string ClinicAName { get; set; }
        /// <summary>
        /// 检查科室B的ID
        /// </summary>
        public string ClinicIdB { get; set; }
        /// <summary>
        /// 检查科室B的名称
        /// </summary>
        public string ClinicBName { get; set; }
        /// <summary>
        ///时间间隔 0=0分钟 1=15分钟 2=30分钟 3=45分钟 4=60分钟
        /// </summary>
        public string TimeInterval { get; set; }
        /// <summary>
        ///时间间隔 0=0分钟 1=15分钟 2=30分钟 3=45分钟 4=60分钟
        /// </summary>
        public string TimeIntervalText { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public string IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDT { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDT { get; set; }

    }
    /// <summary>
    /// 科室时间间隔
    /// </summary>
    public class EmIntervalText
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string TimeInterval { get; set; }

        /// <summary>
        /// 支持
        /// </summary>
        public string TimeIntervalText { get; set; }
    }
    /// <summary>
    /// 检查科室接口输出参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Examqueueintervals<T> : stHead where T : class
    {
        public T ret_data { get; set; }
    }

    /// <summary>
    /// 检查科室接口输出参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Examqueueintervals : stHead
    {
        // public int IsShowSurplusBed = 0;
        public List<t_re_examqueueinterval> ret_data = new List<t_re_examqueueinterval>();
    }
    public class GetListDevicegroup : stHead
    {
        public int IsShowExamqueueinterval = 0;

        public List<t_mt_Devicegroup> ListDevicegroup = new List<t_mt_Devicegroup>();
    }

    public class GetExamqueueinterval : stHead
    {
        public int IsShowExamqueueinterval = 0;

        public List<t_re_Examqueueintervals> ListExamqueueinterval = new List<t_re_Examqueueintervals>();
    }

    public partial class t_mt_Devicegroup
    {

        ///<summary>
        ///主键
        ///</summary>
        public string ID { get; set; }

        ///<summary>
        ///检查类型id
        ///</summary>
        public string ClinicID { get; set; }

        ///<summary>
        ///检查类型
        ///</summary>
        public string ClinicName { get; set; }

        ///<summary>
        ///群组名称
        ///</summary>
        public string GroupName { get; set; }



    }

    /// <summary>
    /// 队列时间间隔
    /// </summary>
    public class EmCheckqueueType
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string TimeInterval { get; set; }

        /// <summary>
        /// 支持
        /// </summary>
        public string TimeIntervalText { get; set; }
    }




    public partial class t_re_Examqueueintervals
    {


        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// 检查队列类型B的名称
        /// </summary>
        public string ClinicIDA { get; set; }

        /// <summary>
        /// 检查队列类型B的Id
        /// </summary>
        public string ClinicIDB { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 检查队列A的Id
        /// </summary>ClinicDesc
        public string QueueIdA { get; set; }
        /// <summary>
        /// 检查队列A的名称
        /// </summary>
        public string QueueNameA { get; set; }

        /// <summary>
        /// 检查队列B的Id
        /// </summary>
        public string QueueIdB { get; set; }

        /// <summary>
        /// 检查队列B的名称
        /// </summary>
        public string QueueNameB { get; set; }

        /// <summary>
        ///时间间隔 0=0分钟 1=15分钟 2=30分钟 3=45分钟 4=60分钟
        /// </summary>
        public string TimeInterval { get; set; }
        /// <summary>
        ///时间间隔0=0分钟 1=15分钟 2=30分钟 3=45分钟 4=60分钟
        /// </summary>
        public string TimeIntervalText { get; set; }


    }
}
