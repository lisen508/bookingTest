
using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Core.DataInPut;
using BookingPlatform.Core.DataOutput;
using BookingPlatform.Core.TableModelExs;
using BookingPlatform.Core.TableModels;
using BookingPlatform.Service.Interfaces;
using Newtonsoft.Json.Linq;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BookingPlatform.Service.Implements
{
    public class DaySurgeryService : BaseService<t_day_surgical_system_config>, IDaySurgeryService
    {
        //private readonly IDaySurgeryService service;
        //public SystemConfigService(IDaySurgeryService DaySurgery)
        //{

        //    service = DaySurgery;
        //}


        #region 1.日间手术配置方法
        /// <summary>
        /// 保存日间手术系统配置
        /// </summary>
        /// <param name="systemConfigInfo">{ConfigKey:"配置key",ConfigKeyComment:"配置key描述"}</param>
        /// <returns></returns>
        public CommonOutputData<object> SaveSurgerySystemConfig(List<t_day_surgical_system_config> listSystemConfig, string userid, string hospitalId)
        {
            try
            {

                var sugricalConfigList = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalId).ToList();
                if (sugricalConfigList.Count > 0)
                {
                    if (listSystemConfig.Any())
                    {
                        Db.Updateable<t_day_surgical_system_config>(listSystemConfig).ExecuteCommand();
                    }

                }
                else
                {
                    foreach (var item in listSystemConfig)
                    {
                        item.ID = CreateID.GetID();
                        item.ConfigKey = CreateID.GetID();
                        item.CreateTime = item.UpdateTime = System.DateTime.Now;
                        item.CreateUser = userid;
                        Db.Insertable<t_day_surgical_system_config>(item).ExecuteCommand();
                    }

                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 检查是否有使用的床位分配信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="hospitalId">医院id</param>
        /// <param name="configValue"></param>
        /// <returns></returns>
        public bool CheckIsExistBookBedNumber(string Id, string hospitalId, string configValue)
        {

            try
            {
                var sugricalConfig = Db.Queryable<t_day_surgical_system_config>().Where(n => n.ID == Id).Single();
                if (sugricalConfig != null)
                {
                    if (sugricalConfig.ConfigKey == "surgicalCount")
                    { //床位配置
                        var listBookInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.HospitalID == hospitalId && n.AssignBedNumber != ""
                        && n.AssignBedNumber != null && n.AdmissionStatus == (int)EnumDaySurgicalAdmissionStatus.Admitted).ToList();
                        if (listBookInfo.Count > 0 && (int.Parse(configValue) < int.Parse(sugricalConfig.ConfigValue)))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 更新配置项的value
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public CommonOutputData<object> UpdateSurgerySystemConfig(string Id, string configValue, string hospitalId, string userId)
        {

            try
            {
                var sugricalConfig = Db.Queryable<t_day_surgical_system_config>().Where(n => n.ID == Id).Single();
                if (sugricalConfig != null)
                {
                    //执行更改
                    sugricalConfig.UpdateUser = userId;
                    sugricalConfig.UpdateTime = System.DateTime.Now;
                    sugricalConfig.ConfigValue = configValue;
                    Db.Updateable<t_day_surgical_system_config>(sugricalConfig).ExecuteCommand();

                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public CommonOutputData<List<t_day_surgical_system_config>> GetSurgerySystemConfig(string hospitalId)
        {
            var result = new CommonOutputData<List<t_day_surgical_system_config>>();

            try
            {
                var rs = Db.Queryable<t_day_surgical_system_config>()
                .Where(n => n.HospitalID == hospitalId).ToList();
                result.ret_data = rs;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
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
        public CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryTypeNameList(string hospitalID, string deptCode, int PageNo, int OnePageCount)
        {
            var result = new CommonOutputData<List<t_day_surgical_name>>();
            try
            {

                var totalCount = 0;
                var exp = Expressionable.Create<t_day_surgical_name>()
                         .And(n => n.HospitalID == hospitalID && n.IsDelete == 0)
                         .AndIF(!string.IsNullOrWhiteSpace(deptCode), it => it.DeptCode == deptCode).ToExpression();//拼接表达式
                var rs = Db.Queryable<t_day_surgical_name>().Where(exp).ToPageList(PageNo, OnePageCount, ref totalCount);

                result.Head.PageNo = PageNo;
                result.Head.TotalCount = totalCount;
                result.Head.OnePageCount = OnePageCount;
                result.ret_data = rs;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 判断手术名称是否存在
        /// </summary>
        /// <param name="hospitalId">医院ID </param>
        /// <param name="DeptCode">科室id</param>
        /// <param name="OperativeDiseases">手术名称</param>
        /// <returns></returns>
        public bool CheckIsExistDaySurgeryeName(string hospitalId, string DeptCode, string OperativeDiseases)
        {

            try
            {
                var sugricalConfigList = Db.Queryable<t_day_surgical_name>().Where(n => n.HospitalID == hospitalId && n.DeptCode == DeptCode && n.OperativeDiseases == OperativeDiseases && n.IsDelete == 0).ToList();
                if (sugricalConfigList.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 保存日间手术维护列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public CommonOutputData<object> SaveDaySurgeryTypeName(t_day_surgical_name model, string hospitalId)
        {

            try
            {
                var sugricalConfigList = Db.Queryable<t_day_surgical_name>().Where(n => n.HospitalID == hospitalId && n.ID == model.ID).ToList();
                var info = new t_day_surgical_name();
                if (sugricalConfigList.Count > 0)
                {
                    info.ID = sugricalConfigList[0].ID;//主键
                    //执行更改
                    info.UpdateUser = model.UpdateUser;
                    info.UpdateTime = System.DateTime.Now;
                    info.HospitalID = hospitalId;
                    info.DeptCode = model.DeptCode;
                    info.DeptName = model.DeptName;
                    info.OperativeDiseases = model.OperativeDiseases;
                    info.Remark = model.Remark;
                    info.IsDelete = 0;
                    Db.Updateable<t_day_surgical_name>(info).ExecuteCommand();

                }
                else
                {
                    info.ID = CreateID.GetID();
                    info.HospitalID = hospitalId;
                    info.DeptCode = model.DeptCode;
                    info.IsDelete = 0;
                    info.DeptName = model.DeptName;
                    info.OperativeDiseases = model.OperativeDiseases;
                    info.Remark = model.Remark;
                    info.CreateTime = info.UpdateTime = System.DateTime.Now;
                    info.CreateUser = model.CreateUser;
                    Db.Insertable<t_day_surgical_name>(info).ExecuteCommand();
                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public void DeleteDaySurgeryTypeNameById(string Id)
        {
            var result = new CommonOutputData<List<t_day_surgical_name>>();

            try
            {
                var deleteList = Db.Queryable<t_day_surgical_name>().Where(n => n.ID == Id).ToList();
                var rs = Db.Updateable<t_day_surgical_name>(deleteList).ReSetValue(n => n.IsDelete == 1).ExecuteCommand();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #endregion

        #region 3.日间手术号源管理

        /// <summary>
        /// 获取号源列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public CommonOutputData<List<t_day_surgical_source_config>> GetSurgerySourceConfig(string hospitalId)
        {
            var result = new CommonOutputData<List<t_day_surgical_source_config>>();

            try
            {
                string[] orderArr = new string[] { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                var rs = Db.Queryable<t_day_surgical_source_config>()
                    .Where(n => n.HospitalID == hospitalId).ToList().OrderBy(n =>
                    {
                        var index = 0;
                        index = Array.IndexOf(orderArr, n.Week);
                        if (index != -1) { return index; }
                        else { return int.MaxValue; }
                    }).ToList();
                result.ret_data = rs;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 设置日间手术预约号源数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public void SetUpSurgerySourceConfig(string userId, string hospitalId, string week, int? sourceCount)
        {

            try
            {
                var surgicalSourceConfig = Db.Queryable<t_day_surgical_source_config>()
                    .Where(n => n.HospitalID == hospitalId && n.Week == week).ToList().FirstOrDefault();

                if (surgicalSourceConfig != null)
                {
                    surgicalSourceConfig.SourceCount = sourceCount;
                    surgicalSourceConfig.UpdateTime = System.DateTime.Now;
                    surgicalSourceConfig.UpdateUser = userId;
                    Db.Updateable<t_day_surgical_source_config>(surgicalSourceConfig).ExecuteCommand();
                }
                else
                {
                    t_day_surgical_source_config info = new t_day_surgical_source_config();
                    info.ID = CreateID.GetID();
                    info.HospitalID = hospitalId;
                    info.Week = week;
                    info.SourceCount = sourceCount;
                    info.CreateTime = System.DateTime.Now;
                    info.UpdateTime = System.DateTime.Now;
                    info.CreateUser = userId;
                    info.UpdateUser = userId;
                    Db.Insertable<t_day_surgical_source_config>(info).ExecuteCommand();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region  6. 日间手术申请接口
        /// <summary>
        /// 通过科室编号获取手术名称
        /// </summary>
        /// <param name="hospitalID">医院id</param>
        /// <param name="deptCode">科室名称</param>
        /// <returns></returns>
        public CommonOutputData<List<t_day_surgical_name>> GetDaySurgeryNameByDeptCode(string hospitalID, string deptCode)
        {
            var result = new CommonOutputData<List<t_day_surgical_name>>();

            try
            {
                var rs = Db.Queryable<t_day_surgical_name, t_clinic>((f, c) => new object[] { JoinType.Left, f.DeptCode == c.ThirdClinicID })
                .Where((f, c) => c.HospitalID == hospitalID && c.ThirdClinicID == deptCode && f.IsDelete == 0).ToList();
                result.ret_data = rs;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 获取在院患者列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public CommonOutputData<List<JObject>> GetInHospitalPatientList(string hospitalID)
        {
            var result = new CommonOutputData<List<JObject>>();

            try
            {
                List<JObject> listSource = new List<JObject>();
                var rs = Db.Queryable<t_day_surgical_book_info, t_patientinfo>((st, sc) => new object[] { JoinType.Left, st.PatientGUID == sc.ID })
                    .Select((st, sc) => new t_day_surgical_book_infoEx
                    {
                        ID = st.ID,
                        PatientName = sc.PatientName,
                        SexCode = sc.PatientSex,
                        PatientID = sc.MrNo,
                        Sex = sc.PatientSex == "M" ? "男" : "女",
                        Age = sc.PatientAge,
                        HospitalID = st.HospitalID,
                        InpNo = sc.AdNo,
                        IdNo = sc.IDCard,
                        Phone = sc.Telephone,
                        OperationName = st.OperationName,
                        OperationCode = st.OperationCode,
                        OperationSurgeonName = st.OperationSurgeonName,
                        ApplyDeptCode = st.ApplyDeptCode,
                        ApplyDeptName = st.ApplyDeptName,
                        ApplyDoctorName = st.ApplyDoctorName,
                        ApplyDoctorID = st.ApplyDoctorID,
                        ApplyOperatingTime = st.ApplyOperatingTime,
                        ApplyOperatingNumber = st.ApplyOperatingNumber,
                        ApplyOrderNumber = st.ApplyOrderNumber,
                        ApplyStatus = st.ApplyStatus,
                        AssignBedNumber = st.AssignBedNumber,
                        AdmissionStatus = st.AdmissionStatus,
                        CreateTime = st.CreateTime,
                        CreateUser = st.CreateUser,
                    })
                    .MergeTable().Where(n => n.HospitalID == hospitalID && n.ApplyStatus == (int)EnumDaySurgicalStatus.CheckIn && n.AdmissionStatus == (int)EnumDaySurgicalAdmissionStatus.Admitted)
                .OrderBy(n => n.AssignBedNumber).ToList();


                //获取手术间系统配置信息t_day_surgical_system_config
                var system_config = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalID && n.ConfigKey == "surgicalCount").ToList().FirstOrDefault();
                if (system_config != null)
                {
                    int bedCount = 0;
                    int.TryParse(system_config.ConfigValue, out bedCount);

                    for (int i = 1; i <= bedCount; i++)
                    {
                        var inHostpitalInfo = rs.Find(p => p.AssignBedNumber == (i.ToString() + "号床"));
                        JObject jsonObj = new JObject();
                        jsonObj.Add("AssignBedNumber", i);
                        jsonObj.Add("AssignBedTitle", i + "号床");

                        if (inHostpitalInfo != null)
                        {
                            jsonObj.Add("BookInfoId", inHostpitalInfo.ID);
                            //var rsPatient = db.Queryable<t_patientinfo>().Where(n => n.ID == inHostpitalInfo.PatientGUID).ToList().FirstOrDefault();

                            jsonObj.Add("PatientName", inHostpitalInfo.PatientName);
                            jsonObj.Add("PatientID", inHostpitalInfo.PatientID);
                            jsonObj.Add("SexCode", inHostpitalInfo.SexCode);
                            jsonObj.Add("Sex", inHostpitalInfo.Sex);
                            jsonObj.Add("Age", inHostpitalInfo.Age);
                            jsonObj.Add("InpNo", inHostpitalInfo.InpNo);
                            jsonObj.Add("Phone", inHostpitalInfo.Phone);
                            jsonObj.Add("ApplyOperatingTime", inHostpitalInfo.ApplyOperatingTime);
                        }
                        listSource.Add(jsonObj);
                    }
                }
                result.ret_data = listSource;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 获取床号列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public CommonOutputData<List<JObject>> GetDeptSourceList(string hospitalID, string deptCode)
        {

            var result = new CommonOutputData<List<JObject>>();
            try
            {
                //1.获取已经在使用的号源取出来 出院后号源不释放
                var rs = Db.Queryable<t_day_surgical_book_info>()
                .Where(n => n.HospitalID == hospitalID && n.ApplyDeptCode == deptCode &&
                //(n.AdmissionStatus != 3|| n.AdmissionStatus ==null) &&
                (n.ApplyStatus == (int)EnumDaySurgicalStatus.WaitAuth || n.ApplyStatus == (int)EnumDaySurgicalStatus.Approval || n.ApplyStatus == (int)EnumDaySurgicalStatus.CheckIn)
                 ).OrderBy(n => n.AssignBedNumber).ToList();

                //2.获取科室配置的每天应显示的号源数
                var sourceWeekList = Db.Queryable<t_day_surgical_source_config>()
               .Where(n => n.HospitalID == hospitalID).ToList();

                List<JObject> bedDictionary = new List<JObject>();

                //3.获取手术间系统配置信息,取得号源的有效期
                var sourceValidity = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalID && n.ConfigKey == "sourceValidity").ToList().FirstOrDefault();
                //4.号源显示配置(是否显示全部号源)
                var sourceDisplay = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalID && n.ConfigKey == "sourceDisplay").ToList().FirstOrDefault();
                //5.今日预约启用是否启用
                var todaySource = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalID && n.ConfigKey == "todayBookSourceEnable").ToList().FirstOrDefault();

                //6.获取科室配置的最大可预约数
                var deptSource = Db.Queryable<t_day_dept_source_config>()
               .Where(n => n.HospitalID == hospitalID && n.DeptCode == deptCode).Single();

                if (sourceValidity != null && sourceDisplay != null && todaySource != null)
                {
                    int sourceCount = 0;// 需要生成几天的号源头
                    int sourceDeptMaxCount = 0;// 科室最大的号源数
                    int.TryParse(sourceValidity.ConfigValue, out sourceCount);
                    if (deptSource != null)
                    {
                        int.TryParse(deptSource.SourceCount.ToString(), out sourceDeptMaxCount);
                    }

                    bool displayFullSource = sourceDisplay.ConfigValue == "1" ? false : true;//true只显示可预约号源 /false 全部号源
                    bool todaySourceEnable = todaySource.ConfigValue == "1" ? true : false;//true包含今天号源，false不包含今天号源

                    int today = 1;
                    if (todaySourceEnable) //包含今天的号源，
                    {
                        today = 0;
                        sourceCount = sourceCount + 1;//包含今天的号源后再加7天
                    }
                    for (int i = today; i < sourceCount + today; i++) //天数
                    {
                        JObject jsonObj = new JObject();
                        jsonObj.Add("Title", System.DateTime.Now.AddDays(i).ToString("MM-dd  dddd"));
                        string week = System.DateTime.Now.AddDays(i).ToString("dddd");
                        var sourceConfig = sourceWeekList.Find(p => p.Week == week);
                        int daySourceCount = 0;
                        int.TryParse(sourceConfig.SourceCount.ToString(), out daySourceCount);
                        string applyOperatDate = System.DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                        List<JObject> listSource = new List<JObject>();
                        for (int j = 1; j <= daySourceCount; j++) //天数
                        {

                            string patientId = "", patientName = "", enableBook = "1";
                            if (displayFullSource && sourceDeptMaxCount > 0)  //显示可预约的号源
                            {
                                if (j <= sourceDeptMaxCount)
                                {

                                    string sourceTitle = j + "号";
                                    if (rs.Count > 0)
                                    {
                                        var patientObject = rs.Where(p => p.ApplyOperatingNumber == sourceTitle && p.ApplyOperatingTime.Contains(applyOperatDate)).FirstOrDefault();
                                        if (patientObject != null)
                                        {
                                            patientId = patientObject.PatientGUID;
                                            var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == patientObject.PatientGUID).ToList().FirstOrDefault();
                                            patientName = patientObject == null ? "" : rsPatient.PatientName;
                                            enableBook = "0";
                                        }
                                        else
                                        {
                                            //比如当天有20个号源
                                            JObject jsonSource = new JObject();
                                            jsonSource.Add("SourceId", j);
                                            jsonSource.Add("SourceDate", applyOperatDate);
                                            jsonSource.Add("SourceTitle", sourceTitle);

                                            jsonSource.Add("PatientId", patientId);
                                            jsonSource.Add("PatientName", patientName);
                                            jsonSource.Add("EnableBook", enableBook);
                                            listSource.Add(jsonSource);

                                        }
                                    }

                                }


                            }
                            else
                            {
                                //比如当天有20个号源
                                JObject jsonSource = new JObject();
                                jsonSource.Add("SourceId", j);
                                jsonSource.Add("SourceDate", applyOperatDate);
                                string sourceTitle = j + "号";
                                jsonSource.Add("SourceTitle", sourceTitle);
                                if (rs.Count > 0)
                                {
                                    var patientObject = rs.Where(p => p.ApplyOperatingNumber == sourceTitle && p.ApplyOperatingTime.Contains(applyOperatDate)).FirstOrDefault();
                                    if (patientObject != null)
                                    {
                                        patientId = patientObject.PatientGUID;
                                        var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == patientObject.PatientGUID).ToList().FirstOrDefault();
                                        patientName = patientObject == null ? "" : rsPatient.PatientName;
                                        enableBook = "0";
                                    }
                                }
                                jsonSource.Add("PatientId", patientId);
                                jsonSource.Add("PatientName", patientName);
                                jsonSource.Add("EnableBook", enableBook);
                                listSource.Add(jsonSource);

                            }
                        }
                        jsonObj.Add("Source", JToken.FromObject(listSource));

                        //添加到每天的号源
                        bedDictionary.Add(jsonObj);
                    }
                }
                result.ret_data = bedDictionary;
                return result;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 获取床号列表
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public CommonOutputData<List<JObject>> GetBedNumberUsageList(string hospitalID)
        {

            var result = new CommonOutputData<List<JObject>>();

            try
            {
                //获取已经在使用的床号
                var rs = Db.Queryable<t_day_surgical_book_info>()
                .Where(n => n.HospitalID == hospitalID && n.ApplyStatus == (int)EnumDaySurgicalStatus.CheckIn &&
                n.AdmissionStatus == (int)EnumDaySurgicalAdmissionStatus.Admitted).OrderBy(n => n.AssignBedNumber).ToList();
                List<JObject> bedDictionary = new List<JObject>();

                //获取手术间系统配置信息t_day_surgical_system_config
                var system_config = Db.Queryable<t_day_surgical_system_config>().Where(n => n.HospitalID == hospitalID && n.ConfigKey == "surgicalCount").ToList().FirstOrDefault();
                if (system_config != null)
                {
                    int bedCount = 0;
                    int.TryParse(system_config.ConfigValue, out bedCount);

                    for (int i = 1; i < bedCount + 1; i++)
                    {
                        var bookInfo = rs.Find(p => p.AssignBedNumber == (i.ToString() + "号床"));
                        JObject jsonObj = new JObject();

                        if (bookInfo == null)
                        {
                            jsonObj.Add("BedNum", i.ToString() + "号床");
                            jsonObj.Add("PatientName", "");
                            jsonObj.Add("PatientId", "");
                            jsonObj.Add("BookInfoId", "");
                            jsonObj.Add("EnableBook", "1");
                        }
                        else
                        {
                            jsonObj.Add("BedNum", i.ToString() + "号床");
                            var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == bookInfo.PatientGUID).ToList().FirstOrDefault();
                            jsonObj.Add("PatientName", rsPatient == null ? "" : rsPatient.PatientName);

                            jsonObj.Add("PatientId", bookInfo.PatientGUID);
                            jsonObj.Add("BookInfoId", bookInfo.ID);
                            jsonObj.Add("EnableBook", "0");
                        }
                        bedDictionary.Add(jsonObj);
                    }
                }
                result.ret_data = bedDictionary;
                return result;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 判断是否有需要签到的数据
        /// </summary>
        /// <param name="patientId">病例号</param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public string GetBookInfoPatientSignInByIpoNo(string patientId, string hospitalId)
        {
            string messageReturn = "";

            //根据InpNo查出patientid,
            var patientInfo = Db.Queryable<t_patientinfo>().Where(n => n.HId == hospitalId && n.PatientID == patientId).ToList().FirstOrDefault();
            string patientGUID = "";
            if (patientInfo == null)
            {
                messageReturn = "患者信息不存在";
            }
            else
            {
                patientGUID = patientInfo.ID;//guid
                                             //已申请的单子才能签到
                var modelInf = Db.Queryable<t_day_surgical_book_info>().Where(n => n.HospitalID == hospitalId && n.PatientGUID == patientGUID && n.ApplyStatus == 2).ToList().FirstOrDefault();
                if (modelInf != null)
                {
                    //安排手术时间不为空
                    if (!string.IsNullOrWhiteSpace(modelInf.AssignOperatingTime))
                    {

                        //将日期字符串转换为日期对象
                        DateTime t1 = Convert.ToDateTime(modelInf.AssignOperatingTime);
                        DateTime t2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        //通过DateTIme.Compare()进行比较（）
                        int compNum = DateTime.Compare(t1, t2);
                        if (compNum > 0)
                        {
                            messageReturn = "还没到手术安排日期,不能签到";
                        }
                        if (compNum == 0)
                        {
                            messageReturn = "";//签到日期，可正常签到
                        }
                        if (compNum < 0)
                        {
                            messageReturn = "手术安排时间日期已过，不能签到";
                        }
                    }
                    else
                    {
                        messageReturn = "手术安排时间日期为空";
                    }
                }
                else
                {
                    messageReturn = "没有查询到要签到的数据";
                }
            }

            return messageReturn;
        }
        /// <summary>
        /// 根据IpoNo进行签到
        /// </summary>
        /// <param name="patientId">病例号</param>
        /// <param name="hospitalId">医院id</param>
        /// <returns></returns>
        public CommonOutputData<object> SurgeryBookInfoPatientSignIn(string patientId, string hospitalId)
        {

            try
            {
                //根据InpNo查出patientid,
                var patientInfo = Db.Queryable<t_patientinfo>().Where(n => n.HId == hospitalId && n.PatientID == patientId).ToList().FirstOrDefault();
                string patientGUID = "";
                if (patientInfo != null)
                {
                    patientGUID = patientInfo.ID;
                }

                //已申请的单子才能签到
                var modelInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.HospitalID == hospitalId && n.PatientGUID == patientGUID && n.ApplyStatus == 2).ToList().FirstOrDefault();
                if (modelInfo != null)
                {
                    modelInfo.AdmissionStatus = (int)EnumDaySurgicalAdmissionStatus.CheckIn;
                    modelInfo.ApplyStatus = (int)EnumDaySurgicalStatus.CheckIn;
                    //执行更改
                    modelInfo.UpdateTime = System.DateTime.Now;
                    Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();


                    //配置列表
                    var bookingIDModalityIDList = new List<BookingIDModalityID>();
                    bookingIDModalityIDList.Add(new BookingIDModalityID
                    {
                        BookingListID = modelInfo.ID,
                        ModalityID = modelInfo.ApplyDeptCode
                    });
                    //签到后，发送短信逻辑
                    var msgInfo = new MessageIDInfo();
                    msgInfo.DaySurgeryBookingID = modelInfo.ID;
                    msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                    //var result = new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.CheckingInSuccess, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);



                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// 申请预手术预约的号源接口
        /// </summary>
        /// <param name="hospitalId">医院id</param>
        /// <param name="userId">用户ID</param>
        /// <param name="surgeryBookId">患者信息id</param>
        /// <param name="sourceNumber">号源编号</param>
        /// <returns></returns>
        public CommonOutputData<object> ApplySurgeryBookSource(string hospitalId, string userId, string deptCode, string surgeryBookId, string sourceDate, string sourceNumber)
        {

            try
            {
                //1.获取科室设置的最大号源数
                int sourceDeptMaxCount = 0;// 科室最大的号源数
                var deptSource = Db.Queryable<t_day_dept_source_config>().Where(n => n.HospitalID == hospitalId && n.DeptCode == deptCode).ToList().FirstOrDefault();
                if (deptSource != null)
                {
                    // 如果科室最大号源设置的为null值，则为当日最大号源数
                    if (deptSource.SourceCount == null)
                    {
                        // 获取当日最大号源数
                        var today = DateTime.Now.ToString("dddd");
                        var todaySource = Db.Queryable<t_day_surgical_source_config>().Where(n => n.HospitalID == hospitalId && n.Week == today).ToList().FirstOrDefault().SourceCount;
                        sourceDeptMaxCount = todaySource == null ? 0 : Convert.ToInt32(todaySource);
                    }
                    else
                    {
                        int.TryParse(deptSource.SourceCount.ToString(), out sourceDeptMaxCount);
                    }
                }
                else
                {
                    return CommonOutputData<object>.Error("科室编码在科室号源配置中不存在!");

                }

                //2.获取本人该已申请的科室的最大号源数据
                int applySourceCount = 0;// 科室最大的号源数
                applySourceCount = Db.Queryable<t_day_surgical_book_info>().Where(n => n.HospitalID == hospitalId && n.ApplyDeptCode == deptCode
                && n.ApplyOperatingTime.Contains(sourceDate) && (n.ApplyStatus == (int)EnumDaySurgicalStatus.WaitAuth || n.ApplyStatus == (int)EnumDaySurgicalStatus.Approval || n.ApplyStatus == (int)EnumDaySurgicalStatus.CheckIn)).ToList().Count;
                if (applySourceCount >= sourceDeptMaxCount)
                {
                    return CommonOutputData<object>.Error("您已达到每日最大可预约数！不能继续预约!");
                }
                else
                {
                    var modelInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == surgeryBookId).ToList().FirstOrDefault();
                    if (modelInfo != null)
                    {

                        modelInfo.ApplyStatus = (int)EnumDaySurgicalStatus.WaitAuth;//待审批
                        modelInfo.ApplyOperatingTable = "";//申请手术台 预留
                        modelInfo.ApplyCancelTime = System.DateTime.Now;
                        modelInfo.ApplyOrderNumber = "AP" + sourceDate.Replace("-", "") + "-" + sourceNumber.Replace("号", "");//打印时候的申请单号
                        modelInfo.ApplyOperatingNumber = sourceNumber;
                        modelInfo.ApplyOperatingTime = sourceDate;

                        //执行更改
                        modelInfo.UpdateUser = userId;
                        modelInfo.UpdateTime = System.DateTime.Now;
                        Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();

                        //发送短信逻辑
                        //配置列表
                        var bookingIDModalityIDList = new List<BookingIDModalityID>();
                        bookingIDModalityIDList.Add(new BookingIDModalityID
                        {
                            BookingListID = modelInfo.ID,
                            ModalityID = modelInfo.ApplyDeptCode
                        });

                        var msgInfo = new MessageIDInfo();
                        msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                        msgInfo.DaySurgeryBookingID = surgeryBookId;
                        //var result = new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryApply, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);




                    }
                }
                return CommonOutputData<object>.Success();

            }
            catch (Exception ex)
            {
                throw (ex);
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
        public CommonOutputData<object> ApprovalSurgeryBookInfo(string approvalType, string hospitalId, string userId, string surgeryBookId, string content, string assignOperatingTime)
        {

            try
            {
                var modelInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == surgeryBookId).ToList().FirstOrDefault();
                if (modelInfo != null)
                {
                    //配置列表
                    var bookingIDModalityIDList = new List<BookingIDModalityID>();

                    bookingIDModalityIDList.Add(new BookingIDModalityID
                    {
                        BookingListID = modelInfo.ID,
                        ModalityID = modelInfo.ApplyDeptCode
                    });
                    var msgInfo = new MessageIDInfo();

                    switch (approvalType)
                    {
                        case "1":
                            modelInfo.ApplyStatus = (int)EnumDaySurgicalStatus.Cancel;//取消申请
                            modelInfo.ApplyCancelReasons = content;
                            modelInfo.ApplyCancelTime = System.DateTime.Now;
                            modelInfo.AssignOperatingTime = "";//手术安排时间
                            //执行更改
                            modelInfo.UpdateUser = userId;
                            modelInfo.UpdateTime = System.DateTime.Now;
                            Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();
                            //发送短信逻辑
                            msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                            msgInfo.DaySurgeryBookingID = surgeryBookId;
                            //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryCancel, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);

                            break;
                        case "2":

                            modelInfo.ApplyStatus = (int)EnumDaySurgicalStatus.Approval;//审批通过
                            if (string.IsNullOrWhiteSpace(content))//不发送短信
                            {

                                modelInfo.MessageGUID = "";
                            }
                            //执行更改
                            modelInfo.UpdateUser = userId;
                            modelInfo.AssignOperatingTime = (assignOperatingTime == "" ? modelInfo.ApplyOperatingTime : assignOperatingTime);//手术安排时间
                            modelInfo.UpdateTime = modelInfo.AuthTime = System.DateTime.Now;
                            Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();
                            if (!string.IsNullOrWhiteSpace(content))//不为空，即是要发送
                            {
                                //发送短信逻辑
                                msgInfo.DaySurgeryBookingID = surgeryBookId;
                                msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryVerify, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true, content);
                            }
                            break;
                        case "3":
                            modelInfo.ApplyStatus = (int)EnumDaySurgicalStatus.Rejection;//审批拒绝
                            //执行更改
                            modelInfo.UpdateUser = userId;
                            modelInfo.AssignOperatingTime = "";//手术安排时间
                            modelInfo.UpdateTime = modelInfo.AuthTime = System.DateTime.Now;
                            Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();
                            //发送短信逻辑
                            msgInfo.DaySurgeryBookingID = surgeryBookId;
                            msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                           // new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryRefuse, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);

                            break;
                        case "4":
                            modelInfo.AdmissionStatus = (int)EnumDaySurgicalAdmissionStatus.Admitted;//已入院
                            modelInfo.AssignBedNumber = content;//床号
                            modelInfo.AssignBedTime = System.DateTime.Now.ToString("yyyy-MM-dd");
                            //执行更改
                            modelInfo.UpdateUser = userId;
                            modelInfo.UpdateTime = System.DateTime.Now;
                            Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();
                            break;
                        case "5":
                            modelInfo.AdmissionStatus = (int)EnumDaySurgicalAdmissionStatus.Discharged;//已出院
                            //执行更改
                            modelInfo.UpdateUser = userId;
                            modelInfo.UpdateTime = System.DateTime.Now;
                            Db.Updateable<t_day_surgical_book_info>(modelInfo).ExecuteCommand();
                            break;
                    }



                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// /获取要发送的消息内容
        /// </summary>
        /// <param name="hospitalId">医院ID</param>
        /// <param name="surgeryBookId">预约的ID</param>
        /// <param name="type">类型：1 获取审批时的短信内容，0获取重发当前状态的短信内容（默认）</param>
        /// <returns></returns>
        public string GetReSendMessageContent(string hospitalId, string surgeryBookId, string type)
        {

            string content = "";
            try
            {
                var modelInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == surgeryBookId).ToList().FirstOrDefault();
                var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == modelInfo.PatientGUID.Trim()).ToList().FirstOrDefault();

                string messageType = "";
                switch (modelInfo.ApplyStatus)
                {
                    case 1:  //已申请
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryApply);
                        break;
                    case 2:  //已审核
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryVerify);
                        break;
                    case 3:  //已拒绝
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryRefuse);
                        break;
                    case 4:  //已取消
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryCancel);
                        break;
                    case 5:  //已签到
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.CheckingInSuccess);
                        break;

                }
                var rsMessage = Db.Queryable<t_messagesendrecord>().Where(n => n.PlatformID == 5 && n.ID == modelInfo.MessageGUID && n.MessageType == messageType).ToList().FirstOrDefault();
                if (rsMessage != null && type == "0")
                {
                    content = rsMessage.MessageContent;//已发送的记录
                }
                else
                {
                    //根据设置里找到唯一的模板
                    var messagesetting = Db.Queryable<t_messagesetting>().Where(n => n.PlatformID == 5 && n.IsDelete == "0" && n.MessageType == EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryVerify)).ToList().FirstOrDefault();

                    if (messagesetting != null)
                    {
                        //根据唯一的模板id去取模板数据
                        var temple = Db.Queryable<t_messagetemplatemain>().Where(n => n.ID == messagesetting.MessageTemplateID).ToList().FirstOrDefault();
                        //根据模板去取模板内的字段内容
                        var messageList = Db.Queryable<t_messagetemplatecontent>().Where(n => n.MessageTemplateMainID == temple.ID && n.IsDelete == "0").OrderBy(n => n.MessageTemplateSeqNumber).ToList();
                        content = "";
                        foreach (var item in messageList)
                        {
                            string replaceField = "";
                            if (item.MessageTemplateFieldType == "短信字段")
                            {
                                switch (item.MessageTemplateField)
                                {
                                    case "患者姓名":  //患者姓名
                                        replaceField = rsPatient.PatientName;
                                        break;
                                    case "医生姓名":  //主刀医生姓名
                                        replaceField = modelInfo.OperationSurgeonName;
                                        break;
                                    case "安排手术时间":  //安排手术时间
                                        replaceField = Convert.ToDateTime(modelInfo.ApplyOperatingTime).AddDays(1).ToDate1();
                                        break;
                                    case "申请手术时间":  //申请手术时间
                                        replaceField = modelInfo.ApplyOperatingTime;
                                        break;
                                    case "手术预约序号":  //手术预约号
                                        replaceField = modelInfo.ApplyOperatingNumber;
                                        break;
                                }
                                content += replaceField;
                            }
                            if (item.MessageTemplateFieldType == "自定义字段")
                            {
                                content += item.MessageTemplateField;
                            }

                        }
                    }

                }
                return content;
            }


            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// 封装发送短消息接口
        /// </summary>
        /// <param name="db">链接字符串</param>
        /// <param name="modelInfo">日间手术模型</param>
        /// <param name="patientinfo">患者信息模型</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        public bool SendMessageContentInsrtMessageRecord(SqlSugarClient db, t_day_surgical_book_info modelInfo, t_patientinfo patientinfo, string content)
        {
            try
            {
                string messageType = "";
                switch (modelInfo.ApplyStatus)
                {
                    case 1:  //已申请
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryApply);
                        break;
                    case 2:  //已审核
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryVerify);
                        break;
                    case 3:  //已拒绝
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryRefuse);
                        break;
                    case 4:  //已取消
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.SurgeryCancel);
                        break;
                    case 5:  //已签到
                        messageType = EnumMessageType_Class.EnumMessageType_GetTypeNameByEnum(EnumMessageType.CheckingInSuccess);
                        break;
                }

                var newInfo = new t_messagesendrecord();
                newInfo.ID = CreateID.GetID();
                newInfo.CreateDT = DateTime.Now.ToDate4();
                newInfo.IsDelete = "0";
                newInfo.Status = 1;
                newInfo.HospitalID = modelInfo.HospitalID;
                newInfo.MessageChannel = EnumMessageChannel_Class.EnumMessageChannel_GetTypeNameByEnum(EnumMessageChannel.BriefMessage);
                newInfo.MessageContent = content;
                newInfo.MessageType = messageType;
                newInfo.PlatformID = (int)EnumPlatform.DaySurgicalBooking;
                newInfo.PlatformName = EnumPlatform_Class.EnumPlatform_GetPlatformNameByEnum(EnumPlatform.DaySurgicalBooking);
                newInfo.SendDT = DateTime.Now.ToDate4();
                newInfo.SendObject = patientinfo.PatientName;
                newInfo.TeleNubmer = patientinfo.Telephone;
                db.Insertable<t_messagesendrecord>(newInfo).ExecuteCommand();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
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
        public CommonOutputData<object> ReSendMessage(string hospitalId, string userId, string surgeryBookId, string content)
        {

            try
            {
                var modelInfo = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == surgeryBookId).ToList().FirstOrDefault();
                if (modelInfo != null)
                {
                    if (!string.IsNullOrWhiteSpace(content))//不为空，即是要发送
                    {
                        //配置列表
                        var bookingIDModalityIDList = new List<BookingIDModalityID>();
                        bookingIDModalityIDList.Add(new BookingIDModalityID
                        {
                            BookingListID = modelInfo.ID,
                            ModalityID = modelInfo.ApplyDeptCode
                        });

                        //发送短信逻辑
                        var msgInfo = new MessageIDInfo();
                        msgInfo.DaySurgeryBookingID = surgeryBookId;
                        msgInfo.BookingIDModalityIDList = bookingIDModalityIDList;
                        switch (modelInfo.ApplyStatus)
                        {
                            case 1:  //已申请
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryApply, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);
                                break;
                            case 2:  //已审核
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryVerify, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true, content);
                                break;
                            case 3:  //已拒绝
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryRefuse, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);
                                break;
                            case 4:  //已取消
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.SurgeryCancel, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);
                                break;
                            case 5:  //已签到
                                //new Dal_Message().ITransferMsgFormatToMsgContent(hospitalId, EnumPlatform.DaySurgicalBooking, EnumMessageType.CheckingInSuccess, EnumMessageChannel.BriefMessage, modelInfo.PatientGUID, msgInfo, true);
                                break;
                        }
                    }
                }
                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 检查病例号是否存在
        /// </summary>
        /// <param name="hospitalId">医院id</param>
        /// <param name="PatientID">病例号</param>
        /// <returns></returns>
        public bool CheckExistPatientID(string hospitalId, string PatientID)
        {

            try
            {
                var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.PatientID == PatientID).Where(n => n.IsDelete == "0").ToList().FirstOrDefault();

                if (rsPatient != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 日间手术保存患者接口
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public CommonOutputData<object> SaveSurgeryBookInfo(t_day_surgical_book_infoEx modelEx, string hospitalId, string userId)
        {

            try
            {
                //var sugrical = db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == modelEx.ID).ToList();
                var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == modelEx.PatientID).Where(n => n.IsDelete == "0").ToList().FirstOrDefault();
                string PatientGUID = "";

                Db.BeginTran();

                if (modelEx.ID != null)
                {
                    var info = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == modelEx.ID).ToList().FirstOrDefault();
                    //var info = sugrical;
                    info.OperationName = modelEx.OperationName;
                    info.OperationCode = modelEx.OperationCode;
                    info.OperationType = modelEx.OperationType;
                    info.IncisionLocation = modelEx.IncisionLocation;
                    info.IsFirstOperation = modelEx.IsFirstOperation;
                    info.OperativeFreezing = modelEx.OperativeFreezing;
                    info.OperationSurgeonID = modelEx.OperationSurgeonID;
                    info.OperationSurgeonName = modelEx.OperationSurgeonName;
                    info.AssistantDoctorID = modelEx.AssistantDoctorID;
                    info.AssistantDoctorName = modelEx.AssistantDoctorName;
                    info.AnesthesiaMethod = modelEx.AnesthesiaMethod;
                    info.AnesthesiaDoctorID = modelEx.AnesthesiaDoctorID;
                    info.AnesthesiaDoctorName = modelEx.AnesthesiaDoctorName;
                    info.ApplyDeptCode = modelEx.ApplyDeptCode;
                    info.ApplyDeptName = modelEx.ApplyDeptName;
                    info.ApplyDoctorID = modelEx.ApplyDoctorID;
                    info.ApplyDoctorName = modelEx.ApplyDoctorName;
                    info.PreoperativeDiagnosis = modelEx.PreoperativeDiagnosis;
                    //执行更改
                    info.UpdateUser = userId;
                    info.HospitalID = hospitalId;
                    info.UpdateTime = System.DateTime.Now;
                    Db.Updateable<t_day_surgical_book_info>(info).ExecuteCommand();

                    if (rsPatient != null)
                    {
                        t_patientinfo patientinfo = new t_patientinfo();
                        patientinfo.ID = rsPatient.ID.Trim();
                        patientinfo.PatientID = modelEx.PatientID;
                        patientinfo.PatientName = modelEx.PatientName;
                        patientinfo.PatientSex = modelEx.SexCode;
                        patientinfo.PatientAge = modelEx.Age;
                        patientinfo.OutPatientID = modelEx.PatientID;
                        patientinfo.MrNo = modelEx.PatientID;
                        patientinfo.AdNo = modelEx.InpNo;
                        patientinfo.Telephone = modelEx.Phone;
                        patientinfo.IDCard = modelEx.IdNo;
                        patientinfo.HId = hospitalId;
                        patientinfo.IsDelete = "0";
                        patientinfo.CreateDT = System.DateTime.Now;
                        PatientGUID = patientinfo.ID;
                        Db.Updateable<t_patientinfo>(patientinfo).ExecuteCommand();
                    }

                }
                else
                {
                    if (rsPatient != null)
                    {
                        t_patientinfo patientinfo = new t_patientinfo();
                        patientinfo.ID = rsPatient.ID.Trim();
                        patientinfo.PatientID = modelEx.PatientID;
                        patientinfo.PatientName = modelEx.PatientName;
                        patientinfo.PatientSex = modelEx.SexCode;
                        patientinfo.PatientAge = modelEx.Age;
                        patientinfo.OutPatientID = modelEx.PatientID;
                        patientinfo.MrNo = patientinfo.PatientID = modelEx.PatientID;
                        patientinfo.AdNo = patientinfo.InPatientID = modelEx.InpNo;

                        patientinfo.Telephone = modelEx.Phone;
                        patientinfo.IDCard = modelEx.IdNo;
                        patientinfo.HId = hospitalId;
                        patientinfo.IsDelete = "0";
                        patientinfo.CreateDT = System.DateTime.Now;
                        PatientGUID = patientinfo.ID;
                        Db.Updateable<t_patientinfo>(patientinfo).ExecuteCommand();
                    }
                    else
                    {
                        t_patientinfo patientinfo = new t_patientinfo();
                        patientinfo.ID = CreateID.GetID().Trim();
                        patientinfo.PatientID = modelEx.PatientID;
                        patientinfo.PatientName = modelEx.PatientName;
                        patientinfo.PatientSex = modelEx.SexCode;
                        patientinfo.PatientAge = modelEx.Age;
                        patientinfo.OutPatientID = modelEx.PatientID;
                        patientinfo.MrNo = patientinfo.PatientID = modelEx.PatientID;
                        patientinfo.AdNo = patientinfo.InPatientID = modelEx.InpNo;
                        patientinfo.Telephone = modelEx.Phone;
                        patientinfo.IDCard = modelEx.IdNo;
                        patientinfo.IsDelete = "0";
                        patientinfo.HId = hospitalId;
                        patientinfo.CreateDT = System.DateTime.Now;
                        PatientGUID = patientinfo.ID;
                        Db.Insertable<t_patientinfo>(patientinfo).ExecuteCommand();

                    }

                    t_day_surgical_book_info model = new t_day_surgical_book_info();
                    model.ID = CreateID.GetID();
                    model.HospitalID = hospitalId;
                    model.PatientGUID = PatientGUID;//信息表GUID
                    model.OperationName = modelEx.OperationName;
                    model.OperationCode = modelEx.OperationCode;
                    model.OperationType = modelEx.OperationType;
                    model.IncisionLocation = modelEx.IncisionLocation;
                    model.IsFirstOperation = modelEx.IsFirstOperation;
                    model.OperativeFreezing = modelEx.OperativeFreezing;
                    model.OperationSurgeonID = modelEx.OperationSurgeonID;
                    model.OperationSurgeonName = modelEx.OperationSurgeonName;
                    model.AssistantDoctorID = modelEx.AssistantDoctorID;
                    model.AssistantDoctorName = modelEx.AssistantDoctorName;
                    model.AnesthesiaMethod = modelEx.AnesthesiaMethod;
                    model.AnesthesiaDoctorID = modelEx.AnesthesiaDoctorID;
                    model.AnesthesiaDoctorName = modelEx.AnesthesiaDoctorName;
                    model.ApplyDeptCode = modelEx.ApplyDeptCode;
                    model.ApplyDeptName = modelEx.ApplyDeptName;
                    model.ApplyDoctorID = modelEx.ApplyDoctorID;
                    model.ApplyDoctorName = modelEx.ApplyDoctorName;
                    model.PreoperativeDiagnosis = modelEx.PreoperativeDiagnosis;
                    model.AssignOperatingTime = "";
                    model.IsDelete = 0;
                    model.ApplyStatus = 0;//未预约
                    model.CreateTime = model.UpdateTime = System.DateTime.Now;
                    model.CreateUser = userId;
                    Db.Insertable<t_day_surgical_book_info>(model).ExecuteCommand();

                }

                Db.CommitTran();

                return CommonOutputData<object>.Success();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        /// <summary>
        /// 获取手术详情接口
        /// </summary>
        /// <param name="surgeryBookId">手术详情Id号</param>
        /// <returns></returns>
        public CommonOutputData<JObject> GetSurgeryDetailInfo(string ID)
        {
            var result = new CommonOutputData<JObject>();

            try
            {
                var rs = Db.Queryable<t_day_surgical_book_info>()
                .Where(n => n.ID == ID).First();



                DaySurgerDetailOutput dayDetail = new DaySurgerDetailOutput();
                if (rs != null)
                {

                    #region 拼返回的对象

                    dayDetail.surgeryBookId = rs.ID;
                    var rsPatient = Db.Queryable<t_patientinfo>().Where(n => n.ID == rs.PatientGUID.Trim()).ToList().FirstOrDefault();
                    dayDetail.PatientName = rsPatient == null ? "" : rsPatient.PatientName;
                    dayDetail.InpNo = rsPatient == null ? "" : rsPatient.AdNo;
                    dayDetail.Sex = rsPatient == null ? "" : rsPatient.PatientSex == "M" ? "男" : "女";
                    dayDetail.SexCode = rsPatient == null ? "" : rsPatient.PatientSex;
                    dayDetail.Age = rsPatient == null ? "" : rsPatient.PatientAge;
                    dayDetail.PatientGUID = rsPatient == null ? "" : rs.PatientGUID;
                    dayDetail.PatientID = rsPatient.PatientID;
                    dayDetail.IdNo = rsPatient == null ? "" : rsPatient.IDCard;
                    dayDetail.Phone = rsPatient == null ? "" : rsPatient.Telephone;
                    dayDetail.ApplyOperatingTime = rs.ApplyOperatingTime;
                    dayDetail.ApplyOperatingNumber = rs.ApplyOperatingNumber;
                    dayDetail.ApplyOrderNumber = rs.ApplyOrderNumber;
                    dayDetail.ApplyOperatingTable = rs.ApplyOperatingTable;
                    dayDetail.OperationName = rs.OperationName;
                    dayDetail.OperationCode = rs.OperationCode;
                    dayDetail.OperationType = rs.OperationType;
                    dayDetail.IncisionLocation = rs.IncisionLocation;
                    dayDetail.IsFirstOperation = rs.IsFirstOperation;
                    dayDetail.OperativeFreezing = rs.OperativeFreezing;
                    dayDetail.OperationSurgeonName = rs.OperationSurgeonName;
                    dayDetail.AssistantDoctorName = rs.AssistantDoctorName;

                    dayDetail.AnesthesiaMethod = rs.AnesthesiaMethod;
                    dayDetail.AnesthesiaDoctorName = rs.AnesthesiaDoctorName;
                    dayDetail.ApplyDeptName = rs.ApplyDeptName;
                    dayDetail.ApplyDeptCode = rs.ApplyDeptCode;
                    dayDetail.ApplyDoctorName = rs.ApplyDoctorName;
                    dayDetail.PreoperativeDiagnosis = rs.PreoperativeDiagnosis;
                    dayDetail.ApplyCancelTime = rs.ApplyCancelTime;
                    dayDetail.ApplyCancelReasons = rs.ApplyCancelReasons;
                    dayDetail.AssignBedNumber = rs.AssignBedNumber;
                    dayDetail.AssignBedTime = rs.AssignBedTime;
                    dayDetail.ApplyStatus = rs.ApplyStatus;
                    dayDetail.AdmissionStatus = rs.AdmissionStatus;

                    #endregion
                }
                result.ret_data = JObject.FromObject(dayDetail);
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public string GetApprovalSurgeryCount(string hospitalId)
        {

            try
            {
                string today = System.DateTime.Now.ToString("yyyy-MM-dd");
                //已申请的单子才能签到
                var rs = Db.Queryable<t_day_surgical_book_info>().Where(n => n.HospitalID == hospitalId && (n.ApplyStatus == (int)EnumDaySurgicalStatus.Approval || n.ApplyStatus == (int)EnumDaySurgicalStatus.CheckIn)).Where(n => n.AuthTime.ToString().Contains(today)).ToList();
                if (rs == null)
                    return "0";
                else
                {
                    return rs.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


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
        public CommonOutputData<List<t_day_surgical_book_infoEx>> GetSurgeryBookList(string hospitalID, string userId, string deptCode, string InpNumber, string patientName, string startDate, string endDate, string listType, string status, int pageIndex, int pageSize, ref int totalCount)
        {
            var result = new CommonOutputData<List<t_day_surgical_book_infoEx>>();

            try
            {

                var rs = new List<t_day_surgical_book_infoEx>();
                if (listType == "1")
                {
                    var exp = Expressionable.Create<t_day_surgical_book_infoEx>()
                           .And(n => n.HospitalID == hospitalID)
                           .AndIF(!string.IsNullOrWhiteSpace(InpNumber), n => n.PatientID == InpNumber)
                           .AndIF(!string.IsNullOrWhiteSpace(patientName), n => n.PatientName.Contains(patientName))
                           .AndIF(!string.IsNullOrWhiteSpace(startDate), n => n.CreateTime >= DateTime.Parse(startDate))
                            .AndIF(!string.IsNullOrWhiteSpace(endDate), n => n.CreateTime < DateTime.Parse(endDate).AddDays(1))
                             .AndIF(!string.IsNullOrWhiteSpace(userId), n => n.CreateUser == userId)
                                 .And(n => n.ApplyStatus == 0) //为待预约的
                            .ToExpression();//拼接表达式


                    rs = Db.Queryable<t_day_surgical_book_info, t_patientinfo>((st, sc) => new object[] { JoinType.Left, st.PatientGUID == sc.ID })
                    .Select((st, sc) => new t_day_surgical_book_infoEx
                    {
                        ID = st.ID,
                        PatientName = sc.PatientName,
                        SexCode = sc.PatientSex,
                        PatientID = sc.PatientID,
                        Sex = sc.PatientSex == "M" ? "男" : "女",
                        Age = sc.PatientAge,
                        HospitalID = st.HospitalID,
                        InpNo = sc.InPatientID,
                        IdNo = sc.IDCard,
                        Phone = sc.Telephone,
                        OperationName = st.OperationName,
                        OperationCode = st.OperationCode,
                        OperationSurgeonName = st.OperationSurgeonName,
                        ApplyDeptCode = st.ApplyDeptCode,
                        ApplyDeptName = st.ApplyDeptName,
                        ApplyDoctorName = st.ApplyDoctorName,
                        ApplyDoctorID = st.ApplyDoctorID,
                        ApplyOperatingTime = st.ApplyOperatingTime,
                        ApplyOperatingNumber = st.ApplyOperatingNumber,
                        ApplyOrderNumber = st.ApplyOrderNumber,
                        ApplyStatus = st.ApplyStatus,
                        AdmissionStatus = st.AdmissionStatus,
                        CreateTime = st.CreateTime,
                        CreateUser = st.CreateUser,
                    })
                    .MergeTable().Where(exp)
                    .OrderBy(p => p.ApplyOperatingTime, OrderByType.Asc)
                    .OrderBy(p => p.ApplyOperatingNumber, OrderByType.Asc)
                    .ToPageList(pageIndex, pageSize, ref totalCount);

                }
                else if (listType == "2")
                {
                    var exp = Expressionable.Create<t_day_surgical_book_infoEx>()
                        .And(n => n.HospitalID == hospitalID)
                        .AndIF(!string.IsNullOrWhiteSpace(InpNumber), it => it.PatientID == InpNumber)
                        .AndIF(!string.IsNullOrWhiteSpace(patientName), it => it.PatientName.Contains(patientName))
                        .AndIF(!string.IsNullOrWhiteSpace(startDate), it => it.CreateTime >= DateTime.Parse(startDate))
                         .AndIF(!string.IsNullOrWhiteSpace(endDate), it => it.CreateTime < DateTime.Parse(endDate).AddDays(1))
                         .And(n => n.ApplyStatus == 0) //为待预约的
                        .AndIF(!string.IsNullOrWhiteSpace(deptCode), it => it.ApplyDeptCode == deptCode).ToExpression();//拼接表达式
                    rs = Db.Queryable<t_day_surgical_book_info, t_patientinfo>((st, sc) => new object[] { JoinType.Left, st.PatientGUID == sc.ID })
                     .Select((st, sc) => new t_day_surgical_book_infoEx
                     {
                         ID = st.ID,
                         PatientName = sc.PatientName,
                         PatientID = sc.PatientID,
                         SexCode = sc.PatientSex,
                         Sex = sc.PatientSex == "M" ? "男" : "女",
                         Age = sc.PatientAge,
                         HospitalID = st.HospitalID,
                         InpNo = sc.InPatientID,
                         IdNo = sc.IDCard,
                         Phone = sc.Telephone,
                         OperationName = st.OperationName,
                         OperationCode = st.OperationCode,
                         OperationSurgeonName = st.OperationSurgeonName,
                         ApplyDeptCode = st.ApplyDeptCode,
                         ApplyDeptName = st.ApplyDeptName,
                         ApplyDoctorName = st.ApplyDoctorName,
                         ApplyDoctorID = st.ApplyDoctorID,
                         ApplyOperatingTime = st.ApplyOperatingTime,
                         ApplyOperatingNumber = st.ApplyOperatingNumber,
                         ApplyOrderNumber = st.ApplyOrderNumber,
                         ApplyStatus = st.ApplyStatus,
                         AdmissionStatus = st.AdmissionStatus,
                         CreateTime = st.CreateTime,
                         CreateUser = st.CreateUser,
                     })
                     .MergeTable().Where(exp)
                    .OrderBy(p => p.ApplyOperatingTime, OrderByType.Asc)
                    .OrderBy(p => p.ApplyOperatingNumber, OrderByType.Asc)
                    .ToList();

                }

                else if (listType == "3" || listType == "4")
                {
                    var exp = Expressionable.Create<t_day_surgical_book_infoEx>()
                        .And(n => n.HospitalID == hospitalID)
                        .AndIF(!string.IsNullOrWhiteSpace(InpNumber), it => it.PatientID == InpNumber)
                        .AndIF(!string.IsNullOrWhiteSpace(patientName), it => it.PatientName.Contains(patientName))
                         .AndIF(!string.IsNullOrWhiteSpace(userId), n => n.CreateUser == userId)
                        .AndIF(!string.IsNullOrWhiteSpace(startDate), it => DateTime.Parse(it.ApplyOperatingTime) >= DateTime.Parse(startDate))
                         .AndIF(!string.IsNullOrWhiteSpace(endDate), it => DateTime.Parse(it.ApplyOperatingTime) < DateTime.Parse(endDate).AddDays(1))
                          .AndIF(status != "0" && status != "ALL", it => it.ApplyStatus == int.Parse(status))
                          .And(n => n.ApplyStatus != 0) //为待预约的
                         .ToExpression();//拼接表达式
                    if (listType == "4")
                    {
                        exp = Expressionable.Create<t_day_surgical_book_infoEx>()
                            .And(n => n.HospitalID == hospitalID)
                            .AndIF(!string.IsNullOrWhiteSpace(InpNumber), it => it.PatientID == InpNumber)
                            .AndIF(!string.IsNullOrWhiteSpace(patientName), it => it.PatientName.Contains(patientName))
                            .AndIF(!string.IsNullOrWhiteSpace(startDate), it => DateTime.Parse(it.ApplyOperatingTime) >= DateTime.Parse(startDate))
                             .AndIF(!string.IsNullOrWhiteSpace(endDate), it => DateTime.Parse(it.ApplyOperatingTime) < DateTime.Parse(endDate).AddDays(1))
                              .AndIF(status != "0" && status != "ALL", it => it.ApplyStatus == int.Parse(status))
                              .And(n => n.ApplyStatus != 0) //为待预约的
                             .ToExpression();//拼接表达式}
                    }

                    rs = Db.Queryable<t_day_surgical_book_info, t_patientinfo, t_messagesendrecord>((st, sc, send) => new object[] { JoinType.Left, st.PatientGUID == sc.ID, JoinType.Left, st.MessageGUID == send.ID })
                   .Select((st, sc, send) => new t_day_surgical_book_infoEx
                   {
                       ID = st.ID,
                       PatientID = sc.PatientID,
                       PatientName = sc.PatientName,
                       SexCode = sc.PatientSex,
                       Sex = sc.PatientSex == "M" ? "男" : "女",
                       Age = sc.PatientAge,
                       HospitalID = st.HospitalID,
                       InpNo = sc.InPatientID,
                       IdNo = sc.IDCard,
                       Phone = sc.Telephone,
                       OperationName = st.OperationName,
                       OperationCode = st.OperationCode,
                       OperationSurgeonName = st.OperationSurgeonName,
                       ApplyDeptCode = st.ApplyDeptCode,
                       ApplyDeptName = st.ApplyDeptName,
                       ApplyDoctorName = st.ApplyDoctorName,
                       ApplyDoctorID = st.ApplyDoctorID,
                       ApplyOperatingTime = st.ApplyOperatingTime,
                       AssignOperatingTime = st.AssignOperatingTime,
                       ApplyOperatingNumber = st.ApplyOperatingNumber,
                       ApplyOrderNumber = st.ApplyOrderNumber,
                       ApplyStatus = st.ApplyStatus,
                       AdmissionStatus = st.AdmissionStatus,
                       CreateTime = st.CreateTime,
                       CreateUser = st.CreateUser,
                       SendStatus = string.IsNullOrEmpty(send.Status.ToString()) ? "1" : send.Status.ToString(),
                   })
                   .MergeTable().Where(exp)
                    .OrderBy(p => p.ApplyOperatingTime, OrderByType.Asc)
                    .OrderBy(p => p.ApplyOperatingNumber, OrderByType.Asc)
                    .ToPageList(pageIndex, pageSize, ref totalCount);
                }
                else if (listType == "5")
                {
                    var exp = Expressionable.Create<t_day_surgical_book_infoEx>()
                         .And(n => n.HospitalID == hospitalID)
                         .AndIF(!string.IsNullOrWhiteSpace(InpNumber), it => it.PatientID == InpNumber)
                         .AndIF(!string.IsNullOrWhiteSpace(patientName), it => it.PatientName.Contains(patientName))
                         .AndIF(!string.IsNullOrWhiteSpace(startDate), it => DateTime.Parse(it.ApplyOperatingTime) >= DateTime.Parse(startDate))
                          .AndIF(!string.IsNullOrWhiteSpace(endDate), it => DateTime.Parse(it.ApplyOperatingTime) < DateTime.Parse(endDate).AddDays(1))
                          .And(it => it.AdmissionStatus == 1 || it.AdmissionStatus == 2 || it.AdmissionStatus == 3)
                          .AndIF(status != "0" && status != "ALL", it => it.AdmissionStatus == int.Parse(status))
                        .ToExpression();//拼接表达式
                    rs = Db.Queryable<t_day_surgical_book_info, t_patientinfo>((st, sc) => new object[] { JoinType.Left, st.PatientGUID == sc.ID })
                   .Select((st, sc) => new t_day_surgical_book_infoEx
                   {
                       ID = st.ID,
                       PatientID = sc.PatientID,
                       PatientName = sc.PatientName,
                       SexCode = sc.PatientSex,
                       Sex = sc.PatientSex == "M" ? "男" : "女",
                       Age = sc.PatientAge,
                       HospitalID = st.HospitalID,
                       InpNo = sc.InPatientID,
                       IdNo = sc.IDCard,
                       Phone = sc.Telephone,
                       OperationName = st.OperationName,
                       OperationCode = st.OperationCode,
                       OperationSurgeonName = st.OperationSurgeonName,
                       ApplyDeptCode = st.ApplyDeptCode,
                       ApplyDeptName = st.ApplyDeptName,
                       ApplyDoctorName = st.ApplyDoctorName,
                       ApplyDoctorID = st.ApplyDoctorID,
                       ApplyOperatingTime = st.ApplyOperatingTime,
                       ApplyOperatingNumber = st.ApplyOperatingNumber,
                       AssignOperatingTime = st.AssignOperatingTime,
                       AssignBedNumber = st.AssignBedNumber,
                       AssignBedTime = st.AssignBedTime,
                       ApplyOrderNumber = st.ApplyOrderNumber,
                       ApplyStatus = st.ApplyStatus,
                       AdmissionStatus = st.AdmissionStatus,
                       CreateTime = st.CreateTime,
                       CreateUser = st.CreateUser
                   })
                   .MergeTable().Where(exp)
                    .OrderBy(p => p.ApplyOperatingTime, OrderByType.Asc)
                    .OrderBy(p => p.ApplyOperatingNumber, OrderByType.Asc)
                    .OrderBy(p => p.AssignBedNumber, OrderByType.Asc)
                    .OrderBy(p => p.AssignBedTime, OrderByType.Asc)
                   .ToPageList(pageIndex, pageSize, ref totalCount);

                }


                result.ret_data = rs;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public IList<t_clinic> GetClinicList(string hospitalId)
        {
            var result = new CommonOutputData<List<t_clinic>>();

            try
            {
                var rs = Db.Queryable<t_clinic>()
                    .Where(n => n.HospitalID == hospitalId && n.IsDelete == "0").ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public CommonOutputData<List<t_day_dept_source_config>> GetDayDeptSourceMaxCountList(string hospitalId, int pageIndex, int pageSize)
        {
            var totalCount = 0;
            var result = new CommonOutputData<List<t_day_dept_source_config>>();

            try
            {
                var rs = Db.Queryable<t_day_dept_source_config>()
                    .Where(n => n.HospitalID == hospitalId && n.IsDelete == 0).ToPageList(pageIndex, pageSize, ref totalCount);
                result.ret_data = rs;
                result.Head.TotalCount = totalCount;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public t_clinic CheckClinic(string hospitalId, string deptCode)
        {
            return Db.Queryable<t_clinic>().Where(n => n.HospitalID == hospitalId && n.ThirdClinicID == deptCode && n.IsDelete == "0").ToList().FirstOrDefault();

        }


        public void SetUpDayDeptSourceMaxCount(string userId, string hospitalId, string deptCode, int? sourceCount)
        {


            var deptInfo = Db.Queryable<t_clinic>()
                .Where(n => n.HospitalID == hospitalId && n.ThirdClinicID == deptCode && n.IsDelete == "0").ToList().FirstOrDefault();
            if (deptInfo == null)
            {

                throw new ParmsException("科室不存在！");
            }
            var dayDeptSourceMaxCount = Db.Queryable<t_day_dept_source_config>()
                .Where(n => n.HospitalID == hospitalId && n.DeptCode == deptCode).ToList().FirstOrDefault();
            if (dayDeptSourceMaxCount != null)
            {

                dayDeptSourceMaxCount.SourceCount = sourceCount;
                dayDeptSourceMaxCount.UpdateUser = userId;
                dayDeptSourceMaxCount.UpdateTime = System.DateTime.Now;
                Db.Updateable<t_day_dept_source_config>(dayDeptSourceMaxCount).ExecuteCommand();
            }
            else
            {
                t_day_dept_source_config info = new t_day_dept_source_config();
                info.ID = CreateID.GetID();
                info.HospitalID = hospitalId;
                info.DeptName = deptInfo.ClinicName;
                info.DeptCode = deptInfo.ThirdClinicID;
                info.SourceCount = sourceCount;
                info.CreateTime = System.DateTime.Now;
                info.UpdateTime = System.DateTime.Now;
                info.CreateUser = userId;
                info.UpdateUser = userId;
                Db.Insertable<t_day_dept_source_config>(info).ExecuteCommand();
            }
        }

        /// <summary>
        /// 初始科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public void GetInitDeptSourceCount(string hospitalId)
        {

            try
            {
                Db.BeginTran();
                List<t_day_dept_source_config> insertList = new List<t_day_dept_source_config>();
                var clinicList = Db.Queryable<t_clinic>().Where(n => n.HospitalID == hospitalId).ToList();
                var sourceCountList = Db.Queryable<t_day_dept_source_config>().Where(n => n.HospitalID == hospitalId).ToList();
                foreach (var item in clinicList)
                {
                    if (sourceCountList.Where(n => n.DeptCode == item.ThirdClinicID).Count() == 0)
                    {
                        insertList.Add(new t_day_dept_source_config
                        {
                            ID = CreateID.GetID(),
                            HospitalID = hospitalId,
                            DeptName = item.ClinicName,
                            DeptCode = item.ThirdClinicID,
                            SourceCount = null,
                            CreateTime = System.DateTime.Now,
                            UpdateTime = System.DateTime.Now,
                            CreateUser = null,
                            UpdateUser = null
                        });
                    }
                }
                Db.Insertable<t_day_dept_source_config>(insertList.ToArray()).ExecuteCommand();
            }
            catch (Exception ex)
            {
                Db.RollbackTran();
            }
            Db.CommitTran();
        }
        #endregion

        #region 7.获取患者日间手术预约信息

        /// <summary>
        /// 根据患者表主键和日间预约表主键获取日间手术预约信息
        /// </summary>
        /// <param name="patientGuid">患者表主键</param>
        /// <param name="dayBookingId">日间预约表主键</param>
        /// <returns></returns>
        public t_day_surgical_book_info GetDaySurgicalBookingInfo(string patientGuid, string dayBookingId, SqlSugarClient db = null)
        {

            try
            {
                var daySurgicalBookingInfoList = Db.Queryable<t_day_surgical_book_info>().Where(n => n.ID == dayBookingId).Where(n => n.PatientGUID == patientGuid)
                    .Where(n => n.IsDelete == 0).ToList();
                if (daySurgicalBookingInfoList.Any() == false)
                {
                    throw new ParmsException("不存在该日间手术预约信息");
                }
                return daySurgicalBookingInfoList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region 5.科室医生信息维护
        /// <summary>
        /// 科室医生信息维护科室列表获
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public CommonOutputData<IList<DoctorInfoDTO>> GetDoctorInfo(string hospitalId, int pageIndex, int pageSize, string doctorName, string deptId)
        {
            var result = new CommonOutputData<IList<DoctorInfoDTO>>();
            var totalCount = 0;

            try
            {
                var query = Db.Queryable<t_clinic, t_doctor>((c, d) => new object[] {
                   JoinType.Inner, c.ID == d.TClinicID });
                if (!string.IsNullOrWhiteSpace(doctorName))
                {
                    query.Where((c, d) => d.DoctorName.Contains(doctorName));
                }
                if (!string.IsNullOrWhiteSpace(deptId))
                {
                    query.Where((c, d) => c.ID.Contains(deptId));
                }
                var rs = query.Select((c, d) => new DoctorInfoDTO
                {
                    doctorId = d.ID,             //医生Id
                    doctorJobNo = d.DoctorJobNo, //工号
                    doctorNmae = d.DoctorName,   //姓名
                    doctorGrade = d.DoctorGrade, //职称
                    deptId = c.ID                //科室Id
                }).ToPageList(pageIndex, pageSize, ref totalCount);
                result.ret_data = rs;
                result.Head.TotalCount = totalCount;
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 判断是否存在这个科室
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <param name="TClinicID"></param>
        /// <returns></returns>
        public bool HasTClinicID(string hospitalID, string TClinicID)
        {
            try
            {

                List<t_clinic> clinicList = Db.Queryable<t_clinic>().Where(n => n.HospitalID == hospitalID && n.ID == TClinicID && n.IsDelete == "0").ToList();

                if (clinicList.Any())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 查询当前医院的科室列表
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        //public IList<t_clinic> IGetClinicList(string hospitalId,SqlSugarClient db=null)
        //{
        //    if(db==null)
        //    {
        //        Db = SqlSugarManager.DB;
        //    }
        //    try
        //    {
        //        var rsClinic = Db.Queryable<t_clinic>().Where(n => n.HospitalID == hospitalId).Where(n => n.IsDelete == "0").ToList();
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