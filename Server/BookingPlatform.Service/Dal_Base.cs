using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Core.DataOutput;
using BookingPlatform.Core.TableModels;
using BookingPlatform.Models.LogManage;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookingPlatform.Service
{
    public class Dal_Base
    {
        protected string _dbConntion = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"];

        protected int _canAddNextWeekCount = int.Parse(ConfigExtensions.Configuration["appSettings:CanAddNextWeekCount"]);

        public Dal_Base()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigExtensions.Configuration["DbConnection:MySqlConnectionString"],
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string s = sql;
                //Console.WriteLine(sql + "\r\n" +
                //    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        public SqlSugarClient db;//用来处理事务多表查询和复杂的操作

        public string GetBookingID(string hospitalId, string bookingListId, SqlSugarClient db = null, string userSourceId = "医技预约")
        {
            try
            {
                var info = new t_bookingid();
                info.ID = CreateID.GetID();
                info.CreateDT = DateTime.Now.ToDate4();
                info.HospitalID = hospitalId;
                info.TOutpatSourcePoolConfigID = userSourceId;
                info.TOutpatSourcePoolConfigID = bookingListId;
                var count = db.Insertable<t_bookingid>(info).ExecuteCommand();
                if (count < 1)
                {
                    throw new ParmsException("预约单号生成失败!");
                }
                return info.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 根据系统配置Id获取系统key/value
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public t_mt_systemconfig GetSystemConfigKeyValueById(SqlSugarClient db, string guid)
        {
            try
            {
                var systemConfig = new t_mt_systemconfig();
                var rs = db.Queryable<t_mt_systemconfig>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid).ToList();
                if (rs.Any() == false)
                {
                    return systemConfig;
                }
                return rs.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
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
        public class ParmsException : Exception
        {
            public ParmsException(String message) : base(message)
            {
            }
            public ParmsException()
            {

            }
        }
        protected T returnMsgError<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "") where T : stMTHead, new()
        {
            if (code == 0) LogManage.LogError(msg, errorType);
            T t = new T();
            t.mErrCode = code;
            t.mMsg = msg;

            return t;
        }
        protected T returnMsgNormal<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "") where T : reStMTHead, new()
        {
            if (code == 0) LogManage.LogError(msg, errorType);
            T t = new T();
            t.mHead.mErrCode = code;
            t.mHead.mMsg = msg;

            return t;
        }

        /// <summary>
        /// 验证用户ID和院区ID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public T VerInput<T>(string userID, string hospitalID) where T : stHead, new()
        {
            if (string.IsNullOrEmpty(userID)) return returnMsg<T>("用户异常，请重新登录", ErrCode.ERR_UserID_IsNull);
            if (string.IsNullOrEmpty(hospitalID)) return returnMsg<T>("医院ID不能为空", ErrCode.ERR_HospitalID);
            return null;
        }


        /// <summary>
        /// 计算号源
        /// </summary>
        /// <param name="colAD"></param>
        /// <returns></returns>
        public int SourceCount(t_arrangedetail row)
        {
            //var num = ((int)((DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + colAD.PeriodEnd) - DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " " + colAD.PeriodStart)).TotalMinutes / (int)(colAD.TimeSpacs))) * (colAD.SameSourceNum == null ? 0 : (int)(colAD.SameSourceNum));
            //return num;

            if (!row.PeriodStart.IsDateTime() || !row.PeriodEnd.IsDateTime() || !row.TimeSpacs.HasValue || !row.SameSourceNum.HasValue)
                return 0;

            DateTime dtPeriodStart = row.PeriodStart.ToDateTime();
            //if (false == DateTime.TryParse("2019-03-29 " + row["PeriodStart"].ToString(), out dtPeriodStart)) break;

            DateTime dtPeriodEnd = row.PeriodEnd.ToDateTime();
            //if (false == DateTime.TryParse("2019-03-29 " + row["PeriodEnd"].ToString(), out dtPeriodEnd)) break;

            int nTimeSpacs = row.TimeSpacs.Value;
            //if (false == int.TryParse(row["TimeSpacs"].ToString(), out nTimeSpacs)) break;

            int nSameSourceNum = row.SameSourceNum.Value;
            //if (false == int.TryParse(row["SameSourceNum"].ToString(), out nSameSourceNum)) break;

            if (nTimeSpacs <= 0)
                return 0;

            int nSourceCount = (int)(nSameSourceNum * (dtPeriodEnd - dtPeriodStart).TotalMinutes / nTimeSpacs);
            return nSourceCount;
        }
        /// <summary>
        /// 获取长期停诊数据
        /// </summary>
        /// <param name="hospitalID"></param> 
        /// <param name="clinicID"></param>
        /// <param name="arrageDate"></param> 
        /// <returns></returns>
        protected IList<t_arrangedoctorstop> DoctorstopListFromClinicid(string hospitalID, string clinicID, DateTime arrageDate)
        {

            //获取长期停诊信息
            var docstopSql = @" select * from t_arrangedoctorstop  p 
                                where p.TClinicID = '{0}'
                                and p.`Status`=1   
                                AND p.HospitalID = @hospitalID  and p.IsDelete=0
                                AND (  
		                                p.StopStartDate <= @arrageDate
		                                AND p.StopEndDate >= @arrageDate 
                                  ) ";
            docstopSql = string.Format(docstopSql, clinicID);
            var lsPara = new List<SugarParameter>();
            lsPara = new List<SugarParameter>();
            lsPara.Add(new SugarParameter("@hospitalID", hospitalID));
            lsPara.Add(new SugarParameter("@arrageDate", arrageDate.ToDate1()));
            var lstop = db.Ado.SqlQuery<t_arrangedoctorstop>(docstopSql, lsPara).ToList();
            return lstop;
        }
        

        public bool EntityOperation(List<object> data)
        {
            bool result = true;
            try
            {
                db.Ado.BeginTran();
                //操作
                foreach (var model in data)
                {
                    //var info = model.Entity;
                    //Type type = model.GetType();

                    //switch (model.) {
                    //    case "Add":
                    //        db.Insertable<item.>().ExecuteCommand();
                    //        continue;
                    //    case "Update":
                    //        db.Updateable<item.Entity>().ExecuteCommand();
                    //        continue;
                    //    case "Delete":
                    //        db.Deleteable<item.Entity>().ExecuteCommand();
                    //        continue;
                    //}
                }
                db.Ado.CommitTran();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.Ado.RollbackTran();
                throw ex;
            }
            return result;

        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        protected string GetUserName()
        {
            return "";//todo:返回用户名
        }
    }
}
