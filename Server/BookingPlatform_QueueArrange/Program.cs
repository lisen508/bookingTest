using BookingPlatform_QueueArrange.EntityModel;
using System;
using System.Configuration;
using System.Threading;

namespace BookingPlatform_QueueArrange
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置控制台标题
            Console.Title = ConfigurationManager.AppSettings["DisplayFormTitle"].ToString().Trim();
            //服务运行时间
            var runTime = ConfigurationManager.AppSettings["RunTime"].ToString().Trim();
            while (true)
            {
                var server = new Server();
                var db = SqlSugarManager.DB;
                //获取医院ID列表
                var hospitalList = db.Queryable<t_hospital>().Where(n => n.IsDelete == 0).ToList();
                for (var i = 0; i < hospitalList.Count; i++)
                {
                    YLog.LogInfo($"....................................【开始处理】:{hospitalList[i].HospitalName}....................................");
                    //每天定时滚动生成下周号源
                    if (DateTime.Now.ToDate6() == runTime)
                    {
                        server.CheckAddNextQueueArrange(db, hospitalList[i].HospitalID);
                    }
                    YLog.LogInfo($"开始执行队列排班............");
                    server.GenerateQueueArrange(db, hospitalList[i].HospitalID);
                    YLog.LogInfo($"队列排班执行结束............");
                    YLog.LogInfo($"开始进入休眠............");
                    Thread.Sleep(5 * 1000);
                    YLog.LogInfo($"休眠结束............");
                    YLog.LogInfo($"开始清理脏数据............");
                    YLog.LogInfo($"脏数据清理中:{server.WashBadData(db, hospitalList[i].HospitalID)}");
                    Thread.Sleep(5 * 1000);
                    YLog.LogInfo($"脏数据清理结束............");
                    YLog.LogInfo($"....................................【结束处理】:{hospitalList[i].HospitalName}....................................\r\n");
                }
            }
        }

    }
}
