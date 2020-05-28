using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Models.LogManage;

namespace BookingPlatformApi.Controllers
{
    /// <summary> 
    /// 医技ApiController重写
    /// </summary>
    public class MyApiMTController : MyApiController
    {
        /// <summary>
        /// 
        /// </summary>
        protected MyApiMTController()
        {
            //Module.Log.LogManager3.LogManage.StrLogPath = ConfigurationManager.AppSettings["LogPath"].Trim();
            //获取扩展号源
            //InitAllowBooking();
            //if (string.IsNullOrWhiteSpace(_medicalTechSourcePool.DBConntion))
            //{
            //    _medicalTechSourcePool.DBConntion = _dbConntion;
            //} 
            //if (_thInitSourcePool == null)
            //{
            //    Models.LogManage.LogManage.LogInfo("启动一下医技号源池信息");
            //    _thInitSourcePool = new Thread(new ParameterizedThreadStart(FunInitSourcePool));
            //    _thInitSourcePool.IsBackground = true;
            //    _thInitSourcePool.Start(_medicalTechSourcePool);
            //}
        }

        ///// <summary>
        ///// 初始化生成配置
        ///// </summary>
        ///// <param name="hosptialid"></param>
        //protected void InitAllowBooking(string hosptialid)
        //{
        //    try
        //    {
        //        GetBookingConfigInfo(hosptialid);
        //        if (_medicalTechSourcePool.AllowBooking != g_allowBooking)
        //        {
        //            _medicalTechSourcePool.AllowBooking = g_allowBooking;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        ///// <summary>
        ///// 启动医技号源池
        ///// </summary>
        ///// <param name="obj"></param>
        //private void FunInitSourcePool(object obj)
        //{
        //    var p = obj as MedicalTechSourcePool;
        //    p.InitSourcePool(_dbConntion, g_startBooking, G_allowBooking);
        //}
        //protected static MedicalTechSourcePool _medicalTechSourcePool = new MedicalTechSourcePool();//号源池信息


        /// <summary>
        /// 
        /// </summary>
        protected int g_startBooking = 1;
        /// <summary>
        /// 
        /// </summary>
        protected int todayBooking = 0;//迭代6支持 当天预约

        #region 可约时间
        private int g_allowBooking = 1;//可预约时间 
        /// <summary>
        /// 可约时间
        /// </summary>
        protected int G_allowBooking
        {
            get
            {
                return g_allowBooking;
            }
            set
            {
                g_allowBooking = value;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <param name="errorType"></param>
        /// <returns></returns>
        protected T returnMsgNormal<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "") where T : reStMTHead, new()
        {
            if (code == 0) LogManage.LogError(msg, errorType);
            T t = new T();
            t.mHead.mErrCode = code;
            t.mHead.mMsg = msg;

            return t;
        }
        /// <summary>
        /// 统一返回数据包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg">信息</param>
        /// <param name="code">错误码</param>
        /// <param name="errorType">错误类型</param>
        /// <returns></returns>
        protected T returnMsg<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "SystemManage") where T : stHead, new()
        {
            if (code == 0)
                Logger.Default.Error(msg, errorType);
            T t = new T();
            t.Head.ErrCode = code;
            t.Head.Msg = msg;

            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <param name="errorType"></param>
        /// <returns></returns>
        protected T returnMsgError<T>(string msg, ErrCode code = ErrCode.ERROR, string errorType = "") where T : stMTHead, new()
        {
            if (code == 0) LogManage.LogError(msg, errorType);
            T t = new T();
            t.mErrCode = code;
            t.mMsg = msg;

            return t;
        }



        /// <summary>
        /// 验证用户ID和院区ID
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        protected T VerInput<T>(string userID, string hospitalID) where T : stHead, new()
        {
            if (string.IsNullOrWhiteSpace(userID)) return returnMsg<T>("用户异常，请重新登录", ErrCode.ERR_UserID_IsNull);
            if (string.IsNullOrWhiteSpace(hospitalID)) return returnMsg<T>("医院ID不能为空", ErrCode.ERR_HospitalID);
            return null;
        }



    }
}
