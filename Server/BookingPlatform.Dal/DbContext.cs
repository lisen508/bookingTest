using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Models.LogManage;
using SqlSugar;

namespace BookingPlatform.Dal
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext
    {
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"],
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string s = sql;
                //Console.WriteLine(sql + "\r\n" +
                //    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        protected T returnMsg<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "SystemManage") where T : stHead, new()
        {
            if (code == 0)
                LogManage.LogError(msg, errorType);
            T t = new T();
            t.Head.ErrCode = code;
            t.Head.Msg = msg;

            return t;
        }
        public static SqlSugarClient sdb
        {
            get
            {
                var db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"],
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true
                });
                return db;
            }
        }

    }
}
