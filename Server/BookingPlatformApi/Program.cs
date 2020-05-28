using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
namespace BookingPlatformApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseKestrel(options =>
                    {
                        options.Limits.MaxRequestBufferSize = 302768;
                        options.Limits.MaxRequestLineSize = 302768;
                    })
                    .UseIIS()
                    .UseStartup<Startup>().ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();//去掉默认添加的日志提供程序	
                        logging.AddNLog("nlog.config");
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                        logging.AddConsole();
                    }).UseNLog();


                });
    }
}
