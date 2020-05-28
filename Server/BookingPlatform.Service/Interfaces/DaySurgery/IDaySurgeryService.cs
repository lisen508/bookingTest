
using BookingPlatform.Core;
using BookingPlatform.Core.TableModelExs;
using BookingPlatform.Core.TableModels;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System.Collections.Generic;

namespace BookingPlatform.Service.Interfaces
{
    public interface IDaySurgeryService : IBaseService<t_day_surgical_system_config>
    {
        #region 1.日间手术配置方法
        /// <summary>
        /// 保存日间手术系统配置
        /// </summary>
        /// <param name="systemConfigInfo">{ConfigKey:"配置key",ConfigKeyComment:"配置key描述"}</param>
        /// <returns></returns>
        CommonOutputData<object> SaveSurgerySystemConfig(List<t_day_surgical_system_config> listSystemConfig, string userid, string hospitalId);

        /// <summary>
        /// 检查是否有使用的床位分配信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="configValue"></param>
        /// <returns></returns>
        bool CheckIsExistBookBedNumber(string Id, string hospitalId, string configValue);
        /// <summary>
        /// 更新配置项的value
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        CommonOutputData<object> UpdateSurgerySystemConfig(string Id, string configValue, string hospitalId, string userId);
        CommonOutputData<List<t_day_surgical_system_config>> GetSurgerySystemConfig(string hospitalId);
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
        CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryTypeNameList(string hospitalID, string deptCode, int PageNo, int OnePageCount);
        /// <summary>
        /// 判断手术名称是否存在
        /// </summary>
        /// <param name="hospitalId">医院ID </param>
        /// <param name="DeptCode">科室id</param>
        /// <param name="OperativeDiseases">手术名称</param>
        /// <returns></returns>
        bool CheckIsExistDaySurgeryeName(string hospitalId, string DeptCode, string OperativeDiseases);

        /// <summary>
        /// 保存日间手术维护列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        CommonOutputData<object> SaveDaySurgeryTypeName(t_day_surgical_name model, string hospitalId);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        void DeleteDaySurgeryTypeNameById(string Id);

        #endregion

        #region 3.日间手术号源管理

        /// <summary>
        /// 获取号源列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        CommonOutputData<List<t_day_surgical_source_config>> GetSurgerySourceConfig(string hospitalId);

        /// <summary>
        /// 设置日间手术预约号源数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        void SetUpSurgerySourceConfig(string userId, string hospitalId, string week, int? sourceCount);

        #endregion

        #region  6. 日间手术申请接口
        /// <summary>
        /// 通过科室编号获取手术名称
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <param name="deptCode">科室名称</param>
        /// <returns></returns>
        CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryNameByDeptCode(string hospitalID, string deptCode);
        /// <summary>
        /// 获取在院患者列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        CommonOutputData<List<JObject>> GetInHospitalPatientList(string hospitalID);
        /// <summary>
        /// 获取床号列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        CommonOutputData<List<JObject>> GetDeptSourceList(string hospitalID, string deptCode);

        /// <summary>
        /// 获取床号列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        CommonOutputData<List<JObject>> GetBedNumberUsageList(string hospitalID);
        /// <summary>
        /// 判断是否有需要签到的数据
        /// </summary>
        /// <param name="patientId">病例号</param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        string GetBookInfoPatientSignInByIpoNo(string patientId, string hospitalId);

        /// <summary>
        /// 根据IpoNo进行签到
        /// </summary>
        /// <param name="patientId">病例号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        CommonOutputData<object> SurgeryBookInfoPatientSignIn(string patientId, string hospitalId);


        /// <summary>
        /// 申请预手术预约的号源接口
        /// </summary>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">用户ID</param>
        /// <param name="surgeryBookId">患者信息id</param>
        /// <param name="sourceNumber">号源编号</param>
        /// <returns></returns>
        CommonOutputData<object> ApplySurgeryBookSource(string hospitalId, string userId, string deptCode, string surgeryBookId, string sourceDate, string sourceNumber);



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
        CommonOutputData<object> ApprovalSurgeryBookInfo(string approvalType, string hospitalId, string userId, string surgeryBookId, string content, string assignOperatingTime);

        /// <summary>
        /// /获取要发送的消息内容
        /// </summary>
        /// <param name="hospitalId">医院ID</param>
        /// <param name="surgeryBookId">预约的ID</param>
        /// <param name="type">类型：1 获取审批时的短信内容，0获取重发当前状态的短信内容（默认）</param>
        /// <returns></returns>
        string GetReSendMessageContent(string hospitalId, string surgeryBookId, string type);

        /// <summary>
        /// 封装发送短消息接口
        /// </summary>
        /// <param name="db">链接字符串</param>
        /// <param name="modelInfo">日间手术模型</param>
        /// <param name="patientinfo">患者信息模型</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        bool SendMessageContentInsrtMessageRecord(SqlSugarClient db, t_day_surgical_book_info modelInfo, t_patientinfo patientinfo, string content);

        /// <summary>
        /// 补发短信接口
        /// </summary>
        /// <param name="hospitalId">医院组织机构代码</param>
        /// <param name="userId">用户Id</param>
        /// <param name="surgeryBookId">申请记录ID</param>
        /// <param name="content">消息记录内容</param>
        /// <returns></returns>
        CommonOutputData<object> ReSendMessage(string hospitalId, string userId, string surgeryBookId, string content);

        /// <summary>
        /// 检查病例号是否存在
        /// </summary>
        /// <param name="hospitalId">医院id</param>
        /// <param name="PatientID">病例号</param>
        /// <returns></returns>
        bool CheckExistPatientID(string hospitalId, string PatientID);

        /// <summary>
        /// 日间手术保存患者接口
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        CommonOutputData<object> SaveSurgeryBookInfo(t_day_surgical_book_infoEx modelEx, string hospitalId, string userId);




        /// <summary>
        /// 获取手术详情接口
        /// </summary>
        /// <param name="surgeryBookId">手术详情Id号</param>
        /// <returns></returns>
        CommonOutputData<JObject> GetSurgeryDetailInfo(string ID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        string GetApprovalSurgeryCount(string hospitalId);



        #endregion

        #region 4.设置科室预约数

        /// <summary>
        ///获取手术预约列表
        /// </summary>
        /// <param name="hospitalID">医院ID</param>
        /// <param name="InpNumber">病例号</param>
        /// <param name="name">患者姓名</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="listType">列表类型：1申请手术本人 2申请手术科室 3申请列表 4手术审核列表 5.床位分配列表</param>
        /// <param name="status">ALL[1有已申请、2已审核、3已拒绝、4已取消 5已签到] 入院状态[1已签到 2已入院 3已出院]</param>
        /// <returns></returns>
        CommonOutputData<List<t_day_surgical_book_infoEx>> GetSurgeryBookList(string hospitalID, string userId, string deptCode, string InpNumber, string patientName, string startDate, string endDate, string listType, string status, int pageIndex, int pageSize, ref int totalCount);


        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        IList<t_clinic> GetClinicList(string hospitalId);


        CommonOutputData<List<t_day_dept_source_config>> GetDayDeptSourceMaxCountList(string hospitalId, int pageIndex, int pageSize);

        void SetUpDayDeptSourceMaxCount(string userId, string hospitalId, string deptCode, int? sourceCount);

        /// <summary>
        /// 初始科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        void GetInitDeptSourceCount(string hospitalId);

        #endregion

        #region 7.获取患者日间手术预约信息

        /// <summary>
        /// 根据患者表主键和日间预约表主键获取日间手术预约信息
        /// </summary>
        /// <param name="patientGuid">患者表主键</param>
        /// <param name="dayBookingId">日间预约表主键</param>
        /// <returns></returns>
        t_day_surgical_book_info GetDaySurgicalBookingInfo(string patientGuid, string dayBookingId, SqlSugarClient db = null);

        public t_clinic CheckClinic(string hospitalId, string deptCode);
        #endregion

        #region 5.科室医生信息维护
        /// <summary>
        /// 科室医生信息维护科室列表获
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        CommonOutputData<IList<DoctorInfoDTO>> GetDoctorInfo(string hospitalId, int pageIndex, int pageSize, string doctorName, string deptId);

        /// <summary>
        /// 判断是否存在这个科室
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <param name="TClinicID"></param>
        /// <returns></returns>
        bool HasTClinicID(string hospitalID, string TClinicID);


        /// <summary>
        /// 查询当前医院的科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        // IList<t_clinic> IGetClinicList(string hospitalId,SqlSugarClient db=null)
        //{
        //    if(db==null)
        //    {
        //        db = Db;
        //    }
        //    try
        //    {
        //        var rsClinic = db.Queryable<t_clinic>().Where(n => n.HospitalID == hospitalId).Where(n => n.IsDelete == "0").ToList();
        //        return rsClinic;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        #endregion
    }
}