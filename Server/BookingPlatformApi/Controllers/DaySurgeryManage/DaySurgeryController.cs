using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Core.TableModelExs;
using BookingPlatform.Core.TableModels;
using BookingPlatform.Service.Implements;
using BookingPlatform.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingPlatformApi.Controllers.DaySurgeryManage
{

    /// <summary>
    ///  日间手术配置，申请及审批 ---迭代十  开发中
    /// </summary>
    //[JwtAuthorize]
    [Route("api/[controller]/[action]")]
    public class DaySurgeryController : ControllerBase
    {

        private readonly IDaySurgeryService service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DaySurgery"></param>
        public DaySurgeryController(IDaySurgeryService DaySurgery)
        {
            //log = LogManager.GetLogger(Startup.repository.Name, typeof(DaySurgeryController));
            Logger.Default.Debug("test测试");
            service = DaySurgery;

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

        #region 1.获取日间手术配置
        /// <summary>
        /// 获取日间手术配置
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <returns>对象</returns>
        //[HttpGet, ApiAuthorize(Modules = "Role", Methods = "Authorize", LogType = LogEnum.AUTHORIZE)]
        [HttpGet]
        public CommonOutputData<List<t_day_surgical_system_config>> GetSurgerySystemConfig(String hospitalID)
        {
            try
            {
                var result = service.GetSurgerySystemConfig(hospitalID);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_surgical_system_config>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_surgical_system_config>>.Error("失败");
            }
        }
        /// <summary>
        /// 保存日间手术配置
        /// </summary>
        /// <param name="info">模型参数</param>
        /// <param name="userId">用户Id</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SaveSurgerySystemConfig(List<t_day_surgical_system_config> info, string userId, string hospitalId)
        {
            try
            {
                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);

                #endregion

                var result = service.SaveSurgerySystemConfig(info, userId, hospitalId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error("失败");
            }
        }
        /// <summary>
        /// 根据配置项的id，修改配置项的值
        /// </summary>
        /// <param name="surgeryConfigId">配置项的ID号</param>
        /// <param name="configValue">配置项的值</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">操作人</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> UpdateSurgerySystemConfig(string surgeryConfigId, string configValue, string hospitalId, string userId)
        {
            try
            {

                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);

                if (service.CheckIsExistBookBedNumber(surgeryConfigId, hospitalId, configValue))
                    return returnMsg<CommonOutputData<object>>("床位已经被预约,不可更改比当前更小的床位数");

                #endregion



                var result = service.UpdateSurgerySystemConfig(surgeryConfigId, configValue, hospitalId, userId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error("失败");
            }
        }
        #endregion


        #region 2.日间手术名称维护

        /// <summary>
        /// 获取日间手术类型名称列表
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <param name="deptCode">科室编码： ""为全部科室</param>
        /// <param name="PageNo">页码，从1开始</param>
        /// <param name="OnePageCount">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryTypeNameList(string hospitalID, string deptCode = "", int PageNo = 1, int OnePageCount = 10)
        {
            try
            {

                var result = service.GetDaySurgeryTypeNameList(hospitalID, deptCode, PageNo, OnePageCount);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_surgical_name>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_surgical_name>>.Error("失败");
            }
        }
        /// <summary>
        /// 保存日间手术类型名称
        /// </summary>
        /// <param name="modelStr">对象格式：{"ID": "191209170758309_DA744D964871231A","DeptName": "string","DeptCode": "string","OperativeDiseases": "string","Remark": "string"}</param>
        /// <param name="hospitalId">医院id</param>
        ///<param name="userId">操作人</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SaveDaySurgeryTypeName(string modelStr, string hospitalId, string userId)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<t_day_surgical_name>(modelStr);
                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
                if (string.IsNullOrEmpty(userId))
                    return returnMsg<CommonOutputData<object>>("操作人不能为空", ErrCode.ERR_UserID_IsNull);
                if (string.IsNullOrEmpty(model.DeptCode))
                    return returnMsg<CommonOutputData<object>>("科室编码不能为空");

                if (string.IsNullOrWhiteSpace(model.OperativeDiseases))
                {
                    return CommonOutputData<object>.Error("手术名称不能为空");
                }
                #endregion




                if (string.IsNullOrWhiteSpace(model.ID))
                {
                    model.CreateUser = userId;
                    bool IsExistName = service.CheckIsExistDaySurgeryeName(hospitalId, model.DeptCode, model.OperativeDiseases.Trim());
                    if (IsExistName)
                    {
                        return CommonOutputData<object>.Error("手术名称已存在");
                    }

                }
                model.UpdateUser = userId;
                var result = service.SaveDaySurgeryTypeName(model, hospitalId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error("失败");
            }
        }
        /// <summary>
        /// 删除日间手术名称
        /// </summary>
        /// <param name="surgeryIdStr">surgeryId号串</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> DeleteDaySurgeryTypeNameById(string surgeryIdStr)
        {
            try
            {

                String[] split = surgeryIdStr.Split(',');
                for (int i = 0; i < split.Length; i++)
                {
                    var surgeryId = split[i];
                    service.DeleteDaySurgeryTypeNameById(surgeryId);
                }

                return CommonOutputData<object>.Success();

            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error("失败");
            }
        }


        #endregion

        #region 3.日间手术号源管理

        /// <summary>
        /// 获取日间手术号源列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<t_day_surgical_source_config>> GetDaySurgerySourceList(String hospitalId)
        {
            try
            {

                var result = service.GetSurgerySourceConfig(hospitalId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_surgical_source_config>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_surgical_source_config>>.Error("失败");
            }
        }
        /// <summary>
        /// 设置日间手术预约号源数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="hospitalId">医院Id</param>
        /// <param name="week">日期</param>
        /// <param name="sourceCount">号源数</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SetUpDaySurgerySourceCount(string userId, string hospitalId, string week, int? sourceCount = 0)
        {
            try
            {
                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
                #endregion
                sourceCount = sourceCount == null ? 0 : sourceCount;

                service.SetUpSurgerySourceConfig(userId, hospitalId, week, sourceCount);
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error(ex);
            }
        }


        #endregion

        #region 4.设置科室预约数

        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<t_clinic>> GetClinicList(string hospitalId)
        {
            try
            {
                var rs = new CommonOutputData<List<t_clinic>>();

                var result = service.GetClinicList(hospitalId).ToList();
                rs.ret_data = result;
                return rs;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_clinic>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_clinic>>.Error("失败");
            }
        }
        /// <summary>
        /// 获取科室每日最大可预约数列表
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<t_day_dept_source_config>> GetDayDeptSourceMaxCountList(string hospitalId, int pageIndex, int pageSize)
        {
            try
            {

                var result = service.GetDayDeptSourceMaxCountList(hospitalId, pageIndex, pageSize);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_dept_source_config>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_dept_source_config>>.Error("失败");
            }
        }

        /// <summary>
        /// 设置科室每日最大可预约数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="hospitalId">医院Id</param>
        /// <param name="deptCode">科室Id</param>
        /// <param name="sourceCount">预约数</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SetUpDayDeptSourceMaxCount(string userId, string hospitalId, string deptCode, int? sourceCount = null)
        {
            try
            {
                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
                if (string.IsNullOrEmpty(deptCode))
                    return returnMsg<CommonOutputData<object>>("科室编码不能为空");
                if (service.CheckClinic(hospitalId, deptCode) == null)
                    return returnMsg<CommonOutputData<object>>("科室信息中不存在该科室编码");
                #endregion


                service.SetUpDayDeptSourceMaxCount(userId, hospitalId, deptCode, sourceCount);
                return CommonOutputData<object>.Success();
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error(ex);
            }
        }
        /// <summary>
        /// 初始科室列表
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> InitDeptSourceCount(string hospitalId)
        {
            try
            {
                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);

                #endregion


                service.GetInitDeptSourceCount(hospitalId);
                return CommonOutputData<object>.Success();
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error(ex);
            }
        }
        #endregion

        #region 5.科室医生信息维护

        /// <summary>
        /// 获取科室医生信息维护列表
        /// </summary>
        /// <param name="hospitalId">医院Id</param>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="doctorName">医生名</param>
        /// <param name="deptId">科室Id</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<IList<DoctorInfoDTO>> GetDoctorInfo(string hospitalId, int pageIndex, int pageSize, string doctorName = "", string deptId = "")
        {
            try
            {

                var result = service.GetDoctorInfo(hospitalId, pageIndex, pageSize, doctorName, deptId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<IList<DoctorInfoDTO>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<IList<DoctorInfoDTO>>.Error(ex);
            }
        }

        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="userId">用户Id</param>s
        /// <param name="hospitalId">医院Id</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SynchronizedClinicAndDoctor(string userId, string hospitalId)
        {
            try
            {
                #region 入参检验

                if (string.IsNullOrEmpty(userId))
                    return returnMsg<CommonOutputData<object>>("用户ID不能为空", ErrCode.ERROR);
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);

                #endregion

                var service = new DaySurgeryService();

                //var _dalSystemManage = new Dal_SystemManage();

                ////同步科室数据 并拿到科室的id 列表返回值
                //var rsClinicId = _dalSystemManage.SynchronizedClinic(hospitalId).ListClinic.Select(n => n.ThirdClinicID).ToList();

                ////同步医生数据
                //rsClinicId.ForEach(item =>
                //{
                //    _dalSystemManage.SynchronizedDoctor(hospitalId, item, false);
                //});

                return CommonOutputData<object>.Success();
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error(ex);
            }
        }
        #endregion


        #region  8. 日间手术申请接口


        /// <summary>
        /// 通过科室编号获取手术名称
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <param name="deptCode">科室名称</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryNameByDeptCode(string hospitalID, string deptCode)
        {
            try
            {

                var result = service.GetDaySurgeryNameByDeptCode(hospitalID, deptCode);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_surgical_name>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_surgical_name>>.Error("失败");
            }
        }

        /// <summary>
        ///获取手术预约列表
        /// </summary>
        /// <param name="hospitalID">医院ID</param>
        /// <param name="PageNo">页码，从1开始</param>
        /// <param name="OnePageCount">每页数量</param>
        /// <param name="userId">创建人，默认为""</param>
        /// <param name="deptCode">科室id，默认为""</param>
        /// <param name="ipoNumber">病例号，默认为""</param>
        /// <param name="patientName">患者姓名</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="status">ALL 全部 申请单状态[1有已申请、2已审核、3已拒绝、4已取消 5已签到] 入院状态[1已签到 2已入院 3已出院]</param>
        /// <param name="listType">列表类型：1申请手术本人 2申请手术科室 3申请列表 4手术审核列表 5.床位分配列表</param>
        /// <returns>SendStatus:-1：发送失败，0：已发送，1：未发送</returns>
        [HttpGet]
        public CommonOutputData<List<t_day_surgical_book_infoEx>> GetSurgeryBookList(string hospitalID, int PageNo = 1, int OnePageCount = 10, string userId = "", string deptCode = "", string ipoNumber = "", string patientName = "", string startDate = "", string endDate = "", string status = "", string listType = "")
        {
            try
            {

                var totalCount = 0;
                var result = service.GetSurgeryBookList(hospitalID, userId, deptCode, ipoNumber, patientName, startDate, endDate, listType, status, PageNo, OnePageCount, ref totalCount);
                result.Head.TotalCount = totalCount;
                result.Head.PageNo = PageNo;
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<t_day_surgical_book_infoEx>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<t_day_surgical_book_infoEx>>.Error("失败");
            }
        }



        /// <summary>
        /// 获取手术详情接口
        /// </summary>
        /// <param name="surgeryBookId">手术详情Id号</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<JObject> GetSurgeryDetailInfo(string surgeryBookId)
        {
            try
            {

                var result = service.GetSurgeryDetailInfo(surgeryBookId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<JObject>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<JObject>.Error("失败");
            }
        }
        /// <summary>
        /// 审批通过，审批拒绝，取消申请接口,分配床号,出院
        /// </summary>
        /// <param name="approvalType">操作类型：1.取消申请 2审批通过 3审批拒绝  4.分配床号 5.出院</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">用户ID</param>
        /// <param name="surgeryBookId">患者申请单id</param>
        /// <param name="content">内容（审批通过或取消的短信内容或者提示内容，或者分配的床号）</param>
        /// <param name="assignOperatingTime">安排手术日期</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> ApprovalSurgeryBookInfo(string approvalType, string hospitalId, string userId, string surgeryBookId, string content = "", string assignOperatingTime = "")
        {

            #region "入参校验"
            if (string.IsNullOrEmpty(hospitalId))
                return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
            if (string.IsNullOrEmpty(userId))
                return returnMsg<CommonOutputData<object>>("操作人不能为空", ErrCode.ERR_UserID_IsNull);
            #endregion



            var result = service.ApprovalSurgeryBookInfo(approvalType, hospitalId, userId, surgeryBookId, content, assignOperatingTime);
            return result;

        }
        /// <summary>
        /// 申请预手术预约的号源接口
        /// </summary>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">用户ID</param>
        /// <param name="deptCode">科室编码</param>
        /// <param name="surgeryBookId">患者信息id</param>
        /// <param name="sourceDate">号源日期（2019-12-10）</param>
        /// <param name="sourceNumber">号源编号</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> ApplySurgeryBookSource(string hospitalId, string userId, string deptCode, string surgeryBookId, string sourceDate, string sourceNumber)
        {

            #region "入参校验"
            if (string.IsNullOrEmpty(hospitalId))
                return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
            if (string.IsNullOrEmpty(userId))
                return returnMsg<CommonOutputData<object>>("操作人不能为空", ErrCode.ERR_UserID_IsNull);
            #endregion



            var result = service.ApplySurgeryBookSource(hospitalId, userId, deptCode, surgeryBookId, sourceDate, sourceNumber);
            return result;

        }

        /// <summary>
        /// 获取当日审批通过的数量
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetApprovalSurgeryCount(string hospitalId)
        {


            string result = service.GetApprovalSurgeryCount(hospitalId);
            return result;
        }
        /// <summary>
        /// 患者根据病案号，签到接口
        /// </summary>
        /// <param name="patientId">病例号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SurgeryBookInfoPatientSignIn(string patientId, string hospitalId)
        {

            #region "入参校验"
            if (string.IsNullOrEmpty(hospitalId))
            {
                return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
            }
            #endregion


            string message = service.GetBookInfoPatientSignInByIpoNo(patientId, hospitalId);
            if (message != "")
            {
                return returnMsg<CommonOutputData<object>>(message, ErrCode.ERROR);
            }

            var result = service.SurgeryBookInfoPatientSignIn(patientId, hospitalId);
            return result;

        }

        /// <summary>
        /// 日间手术患者保存接口--含新增和修改
        /// </summary>
        /// <param name="modelStr">对象字符串格式 {"ID": "string","HospitalID": "string","PatientID": "string","PatientName": "string","InpNo": "string","Sex": "string","SexCode": "string","Age": "string","IdNo": "string","Phone": "string","OperationName": "string","OperationCode": "string","OperationType": "string","IncisionLocation": "string","IsFirstOperation": 0,"OperativeFreezing": "string","OperationSurgeonID": "string","OperationSurgeonName": "string","AssistantDoctorID": "string","AssistantDoctorName": "string","AnesthesiaMethod": "string", "AnesthesiaDoctorID": "string","AnesthesiaDoctorName": "string","ApplyDeptCode": "string","ApplyDeptName": "string","ApplyDoctorID": "string","ApplyDoctorName": "string","PreoperativeDiagnosis": "string"}</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> SaveSurgeryBookInfo(string modelStr, string hospitalId, string userId)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<t_day_surgical_book_infoEx>(modelStr);


                #region "入参校验"
                if (string.IsNullOrEmpty(hospitalId))
                    return returnMsg<CommonOutputData<object>>("医院ID不能为空", ErrCode.ERR_HospitalID);
                if (string.IsNullOrEmpty(userId))
                    return returnMsg<CommonOutputData<object>>("操作人不能为空", ErrCode.ERR_UserID_IsNull);
                if (string.IsNullOrWhiteSpace(model.PatientName))
                {
                    return CommonOutputData<object>.Error("患者姓名不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.Sex))
                {
                    return CommonOutputData<object>.Error("患者性别不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.Phone))
                {
                    return CommonOutputData<object>.Error("手机号不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.IdNo))
                {
                    return CommonOutputData<object>.Error("身份证号不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.InpNo))
                {
                    return CommonOutputData<object>.Error("住院号不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.OperationName))
                {
                    return CommonOutputData<object>.Error("手术名称不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.IncisionLocation))
                {
                    return CommonOutputData<object>.Error("切口位置不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.OperationSurgeonName))
                {
                    return CommonOutputData<object>.Error("主刀医师不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.OperativeFreezing))
                {
                    return CommonOutputData<object>.Error("手术冰冻不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.AnesthesiaDoctorName))
                {
                    return CommonOutputData<object>.Error("麻醉师不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.AnesthesiaMethod))
                {
                    return CommonOutputData<object>.Error("麻醉方法不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.PreoperativeDiagnosis))
                {
                    return CommonOutputData<object>.Error("术前诊断不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.ApplyDeptName))
                {
                    return CommonOutputData<object>.Error("申请科室不能为空");
                }
                if (string.IsNullOrWhiteSpace(model.ApplyDeptName))
                {
                    return CommonOutputData<object>.Error("申请医生不能为空");
                }
                //检查是否有相同的病例号
                if (string.IsNullOrWhiteSpace(model.PatientID))
                {
                    return CommonOutputData<object>.Error("病例号不能为空");
                }
                if (service.CheckExistPatientID(hospitalId, model.PatientID))
                {
                    return CommonOutputData<object>.Error("该病历号已存在");
                }
                #endregion

                var result = service.SaveSurgeryBookInfo(model, hospitalId, userId);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<object>.Error("失败");
            }
        }
        /// <summary>
        /// /获取要发送的消息内容
        /// </summary>
        /// <param name="hospitalId">医院ID</param>
        /// <param name="surgeryBookId">预约的ID</param>
        /// <param name="type">类型：1 获取审批时的短信内容，0获取重发当前状态的短信内容（默认）</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<string> GetReSendMessageContent(string hospitalId, string surgeryBookId, string type = "0")
        {
            try
            {

                var result = service.GetReSendMessageContent(hospitalId, surgeryBookId, type);
                return CommonOutputData<string>.Success(result);
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<string>.Error(ex.Message);
            }


        }

        /// <summary>
        /// 补发短信接口
        /// </summary>
        /// <param name="hospitalId">医院组织机构代码</param>
        /// <param name="userId">用户Id</param>
        /// <param name="surgeryBookId">申请记录ID</param>
        /// <param name="content">消息记录内容</param>
        /// <returns></returns>
        [HttpPost]
        public CommonOutputData<object> ReSendMessage(string hospitalId, string userId, string surgeryBookId, string content)
        {
            #region 数据校验
            if (string.IsNullOrWhiteSpace(userId))
            {
                return CommonOutputData<object>.Error("用户异常，请重新登录!");
            }
            if (string.IsNullOrWhiteSpace(hospitalId))
            {
                return CommonOutputData<object>.Error("医院组织机构代码不能为空!");
            }
            if (string.IsNullOrWhiteSpace(surgeryBookId))
            {
                return CommonOutputData<object>.Error("申请记录ID必能为空!");
            }
            if (string.IsNullOrWhiteSpace(surgeryBookId))
            {
                return CommonOutputData<object>.Error("补发短信内容不能为空!");
            }
            #endregion

            var rs = new CommonOutputData<object>();
            try
            {

                var result = service.ReSendMessage(hospitalId, userId, surgeryBookId, content);
                return CommonOutputData<object>.Success();
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<object>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                return CommonOutputData<object>.Error(ex);
            }
        }
        #endregion

        #region 9.获取号源列表和可分配的床位列表，在院患者列表（床位列表）
        /// <summary>
        /// 获取科室可使用的号源数量列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<JObject>> GetDeptSourceList(string hospitalID, string deptCode)
        {
            try
            {

                var result = service.GetDeptSourceList(hospitalID, deptCode);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<JObject>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<JObject>>.Error("失败");
            }
        }
        /// <summary>
        /// 获取床号使用情况清单
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<JObject>> GetBedNumberUsageList(String hospitalID)
        {
            try
            {

                var result = service.GetBedNumberUsageList(hospitalID);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<JObject>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<JObject>>.Error("失败");
            }
        }
        /// <summary>
        /// 获取在院患者床号列表清单
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <returns></returns>
        [HttpGet]
        public CommonOutputData<List<JObject>> GetInHospitalPatientList(String hospitalID)
        {
            try
            {

                var result = service.GetInHospitalPatientList(hospitalID);
                return result;
            }
            catch (ParmsException ex)
            {
                return CommonOutputData<List<JObject>>.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("", ex);
                return CommonOutputData<List<JObject>>.Error("失败");
            }
        }
        #endregion





    }
}
