//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ToolsSoftwareORM.HTableColumn;
//using ToolsSoftwareORM.HTable;
//using BookingPlatform.Models;

//using SqlSugar;

//namespace BookingPlatform.Commom
//{
//    /// <summary>
//    /// 通过GUID获取其他属性值
//    /// </summary>
//    public class GetAttributeByGUID:
//    {
//        private static Ht_outpatsourcebookingplatform _ht_outpatsourcebookingplatform = null;
//        private static Ht_mt_examitem _ht_examItem = null;
//        private static Ht_mt_devicegroup _ht_deviceGroup = null;
//        private static string _dbConntion = System.Configuration.ConfigurationManager.AppSettings["dbConntion"].Trim();

//        /// <summary>
//        /// 通过医院ID获取医院名称
//        /// </summary>
//        /// <param name="guid"></param>
//        /// <returns></returns>
//        public static string GetHospiatlNameByGUID(string guid)
//        {
//            var db = SqlSugarManager.DB;
//            try
//            {
//                var result = db.Queryable<t_hospital>().Where(n => n.IsDelete == 0).Where(n => n.HospitalID == guid);
//                if (result.Any())
//                {
//                    return result.ToList().FirstOrDefault().HospitalName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 通过平台GUID获取平台名称
//        /// </summary>
//        /// <param name="guid"></param>
//        /// <returns></returns>
//        public static string GetPlatformNameByGUID(string guid)
//        {
//            #region 初始化数据库
//            if (_ht_outpatsourcebookingplatform == null)
//            {
//                _ht_outpatsourcebookingplatform = new Ht_outpatsourcebookingplatform();
//                Tuple<bool, string> tu = _ht_outpatsourcebookingplatform.InitTup(_dbConntion, false);
//                if (tu.Item1 == false) return "连接数据库失败:" + tu.Item2;
//            }
//            #endregion
//            try
//            {
//                var sql = string.Format(" {0}='{1}' and ({2}='0' or {2} is null)", Ht_outpatsourcebookingplatform_Column.HColName_ID, guid, Ht_outpatsourcebookingplatform_Column.HColName_IsDelete);
//                var result = _ht_outpatsourcebookingplatform.Select(sql).FirstOrDefault();
//                if (result != null)
//                {
//                    return result.BookingPlatformName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 根据检查类型Id 获取检查类型名称
//        /// </summary>
//        /// <param name="guid">检查类型Id</param>
//        /// <returns></returns>
//        public static string GetModalityNameByGUID(string guid)
//        {
//            var db = SqlSugarManager.DB;
//            try
//            {
//                var result = db.Queryable<t_mt_clinic>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid);
//                if (result.Any())
//                {
//                    return result.ToList().FirstOrDefault().ClinicName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 根据手术室Id 获取手术室名称
//        /// </summary>
//        /// <param name="guid">手术室Id</param>
//        /// <returns></returns>
//        public static string GetOpsClinicNameByGUID(string guid)
//        {
//            var db = SqlSugarManager.DB;
//            try
//            {
//                var result = db.Queryable<t_opsclinic>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid);
//                if (result.Any())
//                {
//                    return result.ToList().FirstOrDefault().OpsClinicName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 根据手术间Id 获取手术间名称
//        /// </summary>
//        /// <param name="guid">手术间Id</param>
//        /// <returns></returns>
//        public static string GetOpsRoomNameByGUID(string guid)
//        {
//            var db = SqlSugarManager.DB;
//            try
//            {
//                var result = db.Queryable<t_opsroom>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid);
//                if (result.Any())
//                {
//                    return result.ToList().FirstOrDefault().OpsName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 根据手术台Id 获取手术台名称
//        /// </summary>
//        /// <param name="guid">手术间Id</param>
//        /// <returns></returns>
//        public static string GetOpsStageNameByGUID(string guid)
//        {
//            var db = SqlSugarManager.DB;
//            try
//            {
//                var result = db.Queryable<t_opsstage>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid);
//                if (result.Any())
//                {
//                    return result.ToList().FirstOrDefault().OpsStage;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 通过检查项目GUID获取检查项目名称
//        /// </summary>
//        /// <param name="guid"></param>
//        /// <returns></returns>
//        public static string GetExamItemNameByGUID(string guid)
//        {
//            #region 初始化数据库
//            if (_ht_examItem == null)
//            {
//                _ht_examItem = new Ht_mt_examitem();
//                Tuple<bool, string> tu = _ht_examItem.InitTup(_dbConntion, false);
//                if (tu.Item1 == false) return "连接数据库失败:" + tu.Item2;
//            }
//            #endregion
//            try
//            {
//                var sql = string.Format(" {0}='{1}' and ({2}='0' or {2} is null)", Ht_mt_examitem.HColName_ID, guid, Ht_mt_examitem.HColName_IsDelete);
//                var result = _ht_examItem.Select(sql).FirstOrDefault();
//                if (result != null)
//                {
//                    return result.ExamItemName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }
//        /// <summary>
//        /// 通过检查队列ID获取检查队列名称
//        /// </summary>
//        /// <param name="guid"></param>
//        /// <returns></returns>
//        public static string GetDeviceGroupNameByGUID(string guid, SqlSugarClient db = null)
//        {
//            if (db == null)
//            {
//                db = SqlSugarManager.DB;
//            }

//            try
//            {

//                var result = db.Queryable<t_mt_devicegroup>().Where(n => n.ID == guid).Where(n => n.IsDelete == "0").ToList().FirstOrDefault();
//                if (result != null)
//                {
//                    return result.GroupName;
//                }
//                return "";
//            }
//            catch (Exception ex)
//            {
//                return "最大捕获:" + ex.Message;
//            }
//        }

//        /// <summary>
//        /// 通过传入的检查项目时段ID获取时段名称
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public static string GetExamItemPeriodNameByID(int id)
//        {
//            switch (id)
//            {
//                case 0:
//                    return "无限制";
//                case 1:
//                    return "上午";
//                case 2:
//                    return "中午";
//                case 3:
//                    return "下午";
//                case 4:
//                    return "夜间";
//                default:
//                    return "无限制";
//            }
//        }

//        /// <summary>
//        /// 根据系统配置Id获取系统key/value
//        /// </summary>
//        /// <param name="guid"></param>
//        /// <returns></returns>
//        public static t_mt_systemconfig GetSystemConfigKeyValueById(SqlSugarClient db, string guid)
//        {
//            try
//            {
//                var systemConfig = new t_mt_systemconfig();
//                var rs = db.Queryable<t_mt_systemconfig>().Where(n => n.IsDelete == 0).Where(n => n.ID == guid).ToList();
//                if (rs.Any() == false)
//                {
//                    return systemConfig;
//                }
//                return rs.FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//}
