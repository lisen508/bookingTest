using BookingPlatform_QueueArrange.DTO;
using BookingPlatform_QueueArrange.EntityModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace BookingPlatform_QueueArrange
{
    public class Server
    {
        public static string _hospitalId = ConfigurationManager.AppSettings["HospitalId"].ToString().Trim();
        /// <summary>
        /// 生成队列排班
        /// </summary>
        public void GenerateQueueArrange(SqlSugarClient db, string hospitalId)
        {
            try
            {
                var validDTO = GetSystemConfig(db, hospitalId);
                //当前该医院已有的排班日期段
                var rsMain = db.Queryable<t_mt_queuearrangemain>().Where(n => n.IsDelete == 0)
                    .Where(n => n.HospitalID == hospitalId).ToList();
                //获取当前医院所有检查类型
                var rsModality = db.Queryable<t_mt_clinic>().Where(n => n.IsDelete == 0)
                    .Where(n => n.HospitalID == hospitalId).ToList();
                //已经参与排班的检查类型
                var rsModalityMain = rsMain.Select(n => n.ModalityID).ToList();
                //当前存在未生成队列排班的检查类型
                var rsRemain = rsModality.Select(n => n.ID).ToList().Except(rsModalityMain).ToList();
                var modalityDateList = new List<ModalityArrangeDate>();
                //检查类型-队列排班日期列表
                rsModality.ForEach(item =>
                {
                    var modalityDate = new ModalityArrangeDate();
                    modalityDate.ModalityId = item.ID;
                    modalityDate.Modality = CommonHandleMethod.GetModalityNameByGUID(item.ID);
                    rsMain.ForEach(ele =>
                    {
                        if (item.ID == ele.ModalityID)
                        {
                            modalityDate.ArrangeDateList.Add(ele);
                        }
                    });
                    if (modalityDate.ArrangeDateList.Count > 0)
                    {
                        modalityDateList.Add(modalityDate);
                    }
                });
                YLog.LogInfo($"获取检查类型/队列排班日期列表............");
                //清洗后的数据列表
                var tempList = ClearData(db, modalityDateList);
                YLog.LogInfo($"数据清洗完成............");
                var listModalityArrangeDate = new List<ModalityArrangeDate>();
                //检查类型-队列排班日期列表
                tempList.ForEach(item =>
                {
                    var modalityArrangeDate = new ModalityArrangeDate();
                    modalityArrangeDate.ModalityId = item.ModalityId;
                    modalityArrangeDate.Modality = item.Modality;
                    if (item.ArrangeDateList.Count >= validDTO.WeekNums)
                    {
                        YLog.LogInfo($"当前检查类型:{item.Modality}的队列排班已满足号源生成周数............");
                        return;
                    }
                    var listArrangeMain = new List<t_mt_queuearrangemain>();
                    //生成其余几周的队列排班
                    for (var i = 0; i < (validDTO.WeekNums - item.ArrangeDateList.Count); i++)
                    {
                        var info = new t_mt_queuearrangemain();
                        info.ID = CommonHandleMethod.GetID();
                        info.IsDelete = 0;
                        info.CreateDT = DateTime.Now.ToDate4();
                        info.HospitalID = hospitalId;
                        info.Modality = CommonHandleMethod.GetModalityNameByGUID(item.ModalityId);
                        info.ModalityID = item.ModalityId;
                        //获取当前日期列表的 最大序号
                        var maxSequenceNo = item.ArrangeDateList.Max(n => n.SequenceNumber);
                        var maxSequenceInfo = item.ArrangeDateList.Where(n => n.SequenceNumber == maxSequenceNo).FirstOrDefault();
                        info.SequenceNumber = maxSequenceNo + (i + 1);
                        info.QueueArrangeStartDate = CommonHandleMethod.GetWeekFirstDayMon(maxSequenceInfo.QueueArrangeEndDate.ToDateTime().AddDays(7 * i + 1)).ToDate1();
                        info.QueueArrangeEndDate = CommonHandleMethod.GetWeekLastDaySun(maxSequenceInfo.QueueArrangeEndDate.ToDateTime().AddDays(7 * i + 1)).ToDate1();
                        listArrangeMain.Add(info);
                    }

                    modalityArrangeDate.ArrangeDateList = listArrangeMain;
                    listModalityArrangeDate.Add(modalityArrangeDate);
                });

                //添加队列排班主业务
                CreateQueueArrange(db, hospitalId, listModalityArrangeDate, rsRemain);

                //提交事务
                db.CommitTran();
                YLog.LogInfo($"队列排班生成完成............");
            }
            catch (Exception ex)
            {
                db.RollbackTran();
                YLog.LogSystemError(ex.Message);
            }
        }

        /// <summary>
        /// 数据清洗
        /// </summary>
        /// <param name="db">dbClient</param>
        /// <param name="listModalityDate">检查类型对应排班日期段列表</param>
        private List<ModalityArrangeDate> ClearData(SqlSugarClient db, List<ModalityArrangeDate> listModalityDate)
        {
            var returnList = new List<ModalityArrangeDate>();
            try
            {
                db.BeginTran();
                listModalityDate.ForEach(item =>
                {
                    var newInfoList = new List<t_mt_queuearrangemain>();
                    List<String> deleteList = new List<string>();
                    item.ArrangeDateList.ForEach(ele =>
                    {

                        //当前时间和结束之间差值
                        var dateDistance = CommonHandleMethod.DateDiff(DateTime.Now.ToDate1().ToDateTime(), ele.QueueArrangeEndDate.ToDateTime());
                        if (dateDistance > 0)
                        {
                            if (!deleteList.Contains(ele.ModalityID))
                            {
                                deleteList.Add(ele.ModalityID);
                            }
                            ele.AlterDT = DateTime.Now.ToDate4();
                            ele.IsDelete = 1;
                            db.Updateable<t_mt_queuearrangemain>(ele).ExecuteCommand();

                        }
                        else
                        {
                            newInfoList.Add(ele);
                        }
                    });
                    newInfoList.ForEach(element =>
                    {
                        if (element.SequenceNumber > 1 && deleteList.Contains(element.ModalityID))
                        {
                            element.SequenceNumber = element.SequenceNumber - 1;
                            db.Updateable<t_mt_queuearrangemain>(element).ExecuteCommand();
                        }
                    });
                    returnList.Add(new ModalityArrangeDate
                    {
                        ModalityId = item.ModalityId,
                        Modality = item.Modality,
                        ArrangeDateList = newInfoList
                    });
                });

                return returnList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 创建队列排班
        /// </summary>
        /// <param name="modalityId">检查类型Id</param>
        /// <param name="db">dbClient</param>
        /// <param name="listMainInfo">排班日期主表列表</param>
        private void CreateQueueArrange(SqlSugarClient db, string hospitalId, List<ModalityArrangeDate> listModalityDate, List<string> remainModalityList)
        {
            YLog.LogInfo($"开始生成队列排班............");
            try
            {
                if (listModalityDate.Count > 0)
                {
                    listModalityDate.ForEach(item =>
                    {
                        //获取该检查类型下的所有队列
                        var queueList = db.Queryable<t_mt_devicegroup>().Where(n => n.IsDelete == "0")
                            .Where(n => n.State == 1).Where(n => n.ClinicID == item.ModalityId)
                            .ToList().Select(n => new
                            {
                                QueueId = n.ID,
                                QueueName = n.GroupName
                            }).ToList();
                        item.ArrangeDateList.ForEach(ele =>
                        {
                            var listDetailInfo = new List<t_mt_queuearrangedetail>();
                            var listRelationInfo = new List<t_mt_queuerearrangerelation>();

                            #region "detail表"            
                            for (var i = 0; i < 7; i++)
                            {
                                for (var j = 1; j <= 4; j++)
                                {
                                    var detailInfo = new t_mt_queuearrangedetail();
                                    detailInfo.ID = CommonHandleMethod.GetID();
                                    detailInfo.QueueArrangeMainID = ele.ID;
                                    detailInfo.QueueArrangeDate = ele.QueueArrangeStartDate.ToDateTime().AddDays(i).ToDate1();
                                    detailInfo.QueueArrangeWeekDay = CommonHandleMethod.CaculateWeekDay(ele.QueueArrangeStartDate.ToDateTime().AddDays(i));
                                    detailInfo.QueueArrangePeriod = j;
                                    detailInfo.CreateDT = DateTime.Now.ToDate4();
                                    detailInfo.IsDelete = 0;
                                    listDetailInfo.Add(detailInfo);

                                    #region "relation表"
                                    queueList.ForEach(element =>
                                    {
                                        var relationInfo = new t_mt_queuerearrangerelation();
                                        relationInfo.ID = CommonHandleMethod.GetID();
                                        relationInfo.QueueArrangeDetailID = detailInfo.ID;
                                        relationInfo.QueueID = element.QueueId;
                                        relationInfo.QueueName = element.QueueName;
                                        relationInfo.State = 0;
                                        relationInfo.CreateDT = DateTime.Now.ToDate4();
                                        relationInfo.IsDelete = 0;
                                        listRelationInfo.Add(relationInfo);
                                    });
                                    #endregion
                                }
                            }
                            #endregion

                            db.Insertable<t_mt_queuearrangemain>(ele).ExecuteCommand();
                            db.Insertable<t_mt_queuearrangedetail>(listDetailInfo).ExecuteCommand();
                            db.Insertable<t_mt_queuerearrangerelation>(listRelationInfo).ExecuteCommand();

                        });
                    });
                }

                //存在未曾添加过队列排班的检查类型
                if (remainModalityList.Any())
                {
                    var listMainInfo = new List<t_mt_queuearrangemain>();
                    var listDetailInfo = new List<t_mt_queuearrangedetail>();
                    var listRelationInfo = new List<t_mt_queuerearrangerelation>();
                    Dictionary<string, int> modalityCountMap = new Dictionary<string, int>();

                    int count = 1;
                    remainModalityList.ForEach(item =>
                    {

                        if (modalityCountMap.TryGetValue(item, out count))
                        {
                            modalityCountMap[item] = count++;
                        }
                        else
                        {
                            modalityCountMap.Add(item, 1);
                            count = 1;
                        }
                        YLog.LogInfo($"新增检查类型:{CommonHandleMethod.GetModalityNameByGUID(item)}的队列排班............");
                        var mainInfo = new t_mt_queuearrangemain();
                        var firstDay = CommonHandleMethod.GetWeekFirstDayMon(DateTime.Now);
                        var lastDay = CommonHandleMethod.GetWeekLastDaySun(DateTime.Now);
                        //获取该检查类型下的所有队列
                        var queueList = db.Queryable<t_mt_devicegroup>().Where(n => n.IsDelete == "0").Where(n => n.State == 1).Where(n => n.ClinicID == item).ToList().Select(n => new
                        {
                            QueueId = n.ID,
                            QueueName = n.GroupName
                        }).ToList();
                        mainInfo.ID = CommonHandleMethod.GetID();
                        mainInfo.HospitalID = hospitalId;
                        mainInfo.ModalityID = item;
                        mainInfo.Modality = CommonHandleMethod.GetModalityNameByGUID(item);
                        mainInfo.IsDelete = 0;
                        mainInfo.CreateDT = DateTime.Now.ToDate4();
                        mainInfo.QueueArrangeStartDate = firstDay.ToDate1();
                        mainInfo.QueueArrangeEndDate = lastDay.ToDate1();
                        mainInfo.SequenceNumber = count;

                        YLog.LogInfo($"当前生成序号:{count}");
                        for (var i = 0; i < 7; i++)
                        {
                            for (var j = 1; j <= 4; j++)
                            {
                                var detailInfo = new t_mt_queuearrangedetail();
                                detailInfo.ID = CommonHandleMethod.GetID();
                                detailInfo.QueueArrangeMainID = mainInfo.ID;
                                detailInfo.QueueArrangeDate = firstDay.AddDays(i).ToDate1();
                                detailInfo.QueueArrangeWeekDay = CommonHandleMethod.CaculateWeekDay(firstDay.AddDays(i));
                                detailInfo.QueueArrangePeriod = j;
                                detailInfo.CreateDT = DateTime.Now.ToDate4();
                                detailInfo.IsDelete = 0;
                                listDetailInfo.Add(detailInfo);

                                #region "relation表"
                                queueList.ForEach(ele =>
                                {
                                    var relationInfo = new t_mt_queuerearrangerelation();
                                    relationInfo.ID = CommonHandleMethod.GetID();
                                    relationInfo.QueueArrangeDetailID = detailInfo.ID;
                                    relationInfo.QueueID = ele.QueueId;
                                    relationInfo.QueueName = ele.QueueName;
                                    relationInfo.State = 0;
                                    relationInfo.CreateDT = DateTime.Now.ToDate4();
                                    relationInfo.IsDelete = 0;
                                    listRelationInfo.Add(relationInfo);
                                });
                                #endregion
                            }
                        }
                        listMainInfo.Add(mainInfo);
                    });
                    db.Insertable<t_mt_queuearrangemain>(listMainInfo).ExecuteCommand();
                    db.Insertable<t_mt_queuearrangedetail>(listDetailInfo).ExecuteCommand();
                    db.Insertable<t_mt_queuerearrangerelation>(listRelationInfo).ExecuteCommand();
                }
            }
            catch (Exception ex)
            {
                db.RollbackTran();
                throw (ex);
            }
        }

        /// <summary>
        /// 清理脏数据-清理detail表、relation表与main表相关联的isdelete为1的值
        /// </summary>
        /// <returns></returns>
        public string WashBadData(SqlSugarClient db, string hospitalId)
        {
            try
            {
                var rsMain = db.Queryable<t_mt_queuearrangemain>().Where(n => n.HospitalID == hospitalId).Where(n => n.IsDelete == 1).ToList();
                var rsDetail = db.Queryable<t_mt_queuearrangedetail>().Where(n => n.IsDelete == 0).In(n => n.QueueArrangeMainID, rsMain.Select(n => n.ID).ToList()).ToList();
                var rsRelation = db.Queryable<t_mt_queuerearrangerelation>().Where(n => n.IsDelete == 0).In(n => n.QueueArrangeDetailID, rsDetail.Select(n => n.ID).ToList()).ToList();
                var listDetail = new List<t_mt_queuearrangedetail>();
                var listRelation = new List<t_mt_queuerearrangerelation>();
                //待更新为删除标志的排班详情
                rsDetail.ForEach(item =>
                {
                    item.IsDelete = 1;
                    item.AlterDT = DateTime.Now.ToDate4();
                    listDetail.Add(item);
                });
                //待更新为删除标志的 队列排班关系
                rsRelation.ForEach(item =>
                {
                    item.IsDelete = 1;
                    item.AlterDT = DateTime.Now.ToDate4();
                    listRelation.Add(item);
                });
                db.BeginTran();
                if (listDetail.Any())
                {
                    db.Updateable<t_mt_queuearrangedetail>(listDetail).ExecuteCommand();
                }
                if (listRelation.Any())
                {
                    db.Updateable<t_mt_queuerearrangerelation>(listRelation).ExecuteCommand();
                }
                db.CommitTran();
                return string.Empty;
            }
            catch (Exception ex)
            {
                db.RollbackTran();
                YLog.LogSystemError(ex.Message);
                return ex.Message;
            }
        }

        /// <summary>
        /// 检查并添加下周排班
        /// </summary>
        public void CheckAddNextQueueArrange(SqlSugarClient db, string hospitalId)
        {
            try
            {
                var listModalityMaxDate = GetModalityMaxDateList(db, hospitalId);
                listModalityMaxDate = listModalityMaxDate.Where(n => n.WeekCount > 0).ToList();
                //添加需要添加的队列排班
                listModalityMaxDate.ForEach(item =>
                {
                    for (var i = 0; i < item.WeekCount; i++)
                    {
                        AddNextWeeekQueueArrange(db, hospitalId, item.ModalityId);
                    }
                });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 添加下周排班
        /// </summary>
        /// <param name="listModalityMaxDate">检查类型</param>
        private void AddNextWeeekQueueArrange(SqlSugarClient db, string hospitalId, string modalityId)
        {
            try
            {
                //队列排班显示日期条数
                var _queueArrangeDisplayCount = Convert.ToInt32(ConfigurationManager.AppSettings["QueueArrangeDisplayCount"].Trim());

                //当前医院当前检查类型下已存在的排班日期
                var existArrangeList = db.Queryable<t_mt_queuearrangemain>()
                    .Where(n => n.IsDelete == 0)
                    .Where(n => n.HospitalID == hospitalId)
                    .Where(n => n.ModalityID == modalityId).ToList();
                if (existArrangeList.Any() == false)
                {
                    Console.WriteLine($"当前检查类型下不存在排班日期，无法添加下周排班!");
                }
                if (existArrangeList.Count < _queueArrangeDisplayCount)
                {
                    var info = new t_mt_queuearrangemain();
                    info.ID = CommonHandleMethod.GetID();
                    info.IsDelete = 0;
                    info.CreateDT = DateTime.Now.ToDate4();
                    info.HospitalID = hospitalId;
                    info.Modality = CommonHandleMethod.GetModalityNameByGUID(modalityId);
                    info.ModalityID = modalityId;
                    //获取当前日期列表的 最大序号
                    var maxSequenceNo = existArrangeList.Max(n => n.SequenceNumber);
                    var maxSequenceInfo = existArrangeList.Where(n => n.SequenceNumber == maxSequenceNo).FirstOrDefault();
                    info.SequenceNumber = maxSequenceNo + 1;
                    info.QueueArrangeStartDate = CommonHandleMethod.GetWeekFirstDayMon(maxSequenceInfo.QueueArrangeEndDate.ToDateTime().AddDays(1)).ToDate1();
                    info.QueueArrangeEndDate = CommonHandleMethod.GetWeekLastDaySun(maxSequenceInfo.QueueArrangeEndDate.ToDateTime().AddDays(1)).ToDate1();
                    //调用内部方法，新增detail表、relation表记录
                    AddDateFormat(hospitalId, modalityId, db, info);
                }
                else
                {
                    Console.WriteLine($"当前配置仅支持最多{_queueArrangeDisplayCount}周排班!");
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 添加 队列排班detail表、relation表
        /// </summary>
        /// <param name="hospitalId">医院组织机构代码</param>
        /// <param name="modalityId">检查类型Id</param>
        /// <param name="db">数据库连接对象</param>
        /// <param name="info">队列排班主表</param>
        private void AddDateFormat(string hospitalId, string modalityId, SqlSugarClient db, t_mt_queuearrangemain info = null)
        {
            var mainInfo = new t_mt_queuearrangemain();
            var listDetailInfo = new List<t_mt_queuearrangedetail>();
            var listRelationInfo = new List<t_mt_queuerearrangerelation>();
            try
            {
                var firstDay = CommonHandleMethod.GetWeekFirstDayMon(DateTime.Now);
                var lastDay = CommonHandleMethod.GetWeekLastDaySun(DateTime.Now);
                //获取该检查类型下的所有队列
                var queueList = db.Queryable<t_mt_devicegroup>().Where(n => n.IsDelete == "0").Where(n => n.State == 1).Where(n => n.ClinicID == modalityId).ToList().Select(n => new
                {
                    QueueId = n.ID,
                    QueueName = n.GroupName
                }).ToList();

                #region "main表"

                if (info == null)
                {
                    mainInfo.ID = CommonHandleMethod.GetID();
                    mainInfo.HospitalID = hospitalId;
                    mainInfo.ModalityID = modalityId;
                    mainInfo.Modality = CommonHandleMethod.GetModalityNameByGUID(modalityId);
                    mainInfo.IsDelete = 0;
                    mainInfo.CreateDT = DateTime.Now.ToDate4();
                    mainInfo.QueueArrangeStartDate = firstDay.ToDate1();
                    mainInfo.QueueArrangeEndDate = lastDay.ToDate1();
                    mainInfo.SequenceNumber = 1;
                }
                else
                {
                    mainInfo = info;
                    firstDay = mainInfo.QueueArrangeStartDate.ToDateTime();
                }

                #endregion

                #region "detail表"
                for (var i = 0; i < 7; i++)
                {
                    for (var j = 1; j <= 4; j++)
                    {
                        var detailInfo = new t_mt_queuearrangedetail();
                        detailInfo.ID = CommonHandleMethod.GetID();
                        detailInfo.QueueArrangeMainID = mainInfo.ID;
                        detailInfo.QueueArrangeDate = firstDay.AddDays(i).ToDate1();
                        detailInfo.QueueArrangeWeekDay = CommonHandleMethod.CaculateWeekDay(firstDay.AddDays(i));
                        detailInfo.QueueArrangePeriod = j;
                        detailInfo.CreateDT = DateTime.Now.ToDate4();
                        detailInfo.IsDelete = 0;
                        listDetailInfo.Add(detailInfo);

                        #region "relation表"
                        queueList.ForEach(item =>
                        {
                            var relationInfo = new t_mt_queuerearrangerelation();
                            relationInfo.ID = CommonHandleMethod.GetID();
                            relationInfo.QueueArrangeDetailID = detailInfo.ID;
                            relationInfo.QueueID = item.QueueId;
                            relationInfo.QueueName = item.QueueName;
                            relationInfo.State = 0;
                            relationInfo.CreateDT = DateTime.Now.ToDate4();
                            relationInfo.IsDelete = 0;
                            listRelationInfo.Add(relationInfo);
                        });
                        #endregion
                    }
                }
                #endregion

                //开始事务
                db.BeginTran();

                db.Insertable<t_mt_queuearrangemain>(mainInfo).ExecuteCommand();
                db.Insertable<t_mt_queuearrangedetail>(listDetailInfo).ExecuteCommand();
                db.Insertable<t_mt_queuerearrangerelation>(listRelationInfo).ExecuteCommand();
                //提交事务
                db.CommitTran();
            }
            catch (Exception ex)
            {
                db.RollbackTran();
                throw (ex);
            }
        }

        /// <summary>
        /// 获取检查类型下排班最后截止日期
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns></returns>
        private List<ModalityMaxDate> GetModalityMaxDateList(SqlSugarClient db, string hospitalId)
        {
            var rsMain = db.Queryable<t_mt_queuearrangemain>().Where(n => n.IsDelete == 0).Where(n => n.HospitalID == hospitalId).ToList();
            var rsModality = db.Queryable<t_mt_clinic>().Where(n => n.IsDelete == 0).Where(n => n.HospitalID == hospitalId).ToList();
            var listModalityDate = new List<ModalityMaxDate>();
            var listModality = new List<string>();
            //检查类型和生成队列排班中的检查类型交集
            rsModality.ForEach(item =>
            {
                rsMain.ForEach(ele =>
                {
                    if (item.ID == ele.ModalityID)
                    {
                        listModality.Add(item.ID);
                    }
                });
            });
            listModality = listModality.Distinct().ToList();
            listModality.ForEach(ele =>
            {
                var modalityDate = new ModalityMaxDate();
                modalityDate.ModalityId = ele;
                var maxSeq = rsMain.Where(n => n.ModalityID == ele).Max(q => q.SequenceNumber);
                modalityDate.MaxDate = rsMain.Where(n => n.ModalityID == ele).Where(n => n.SequenceNumber == maxSeq).FirstOrDefault().QueueArrangeEndDate;
                listModalityDate.Add(modalityDate);
            });
            //获取当前医院预约系统配置
            var validDTO = GetSystemConfig(db, hospitalId);
            var currentMaxDate = DateTime.Now.AddDays(validDTO.DayNums).ToDate1();
            listModalityDate.ForEach(item =>
            {
                //计算差值
                var subData = CommonHandleMethod.DateDiff(currentMaxDate.ToDateTime(), item.MaxDate.ToDateTime());
                if (subData > 0)
                {
                    item.WeekCount = CommonHandleMethod.ReturnWeekNums(subData);
                }
            });
            return listModalityDate;
        }

        /// <summary>
        /// 获取系统配置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns></returns>
        private ValideTimeDTO GetSystemConfig(SqlSugarClient db, string hospitalId)
        {
            var rs = new ValideTimeDTO();

            //获取当前医院预约系统配置
            var systemConfig = GetBookingConfigInfo(hospitalId, db);
            //PC版号源时间标志 0,1,2
            var sourcePCValidTime = systemConfig.PC_SourceValidTime;
            //手机端号源时间标志 0,1,2
            var sourcePhoneValidTime = systemConfig.Phone_SourceValidTime;
            //自助机号源时间标志 0,1,2
            var sourceAutoValidTime = systemConfig.Auto_SourceValidTime;

            var list = new List<int>();
            list.Add(sourceAutoValidTime);
            list.Add(sourcePCValidTime);
            list.Add(sourcePhoneValidTime);
            // 号源对应的时间长度：天
            var dayNums = CommonHandleMethod.TransferToEnumData(list.Max());
            //PC版号源时间标志对应的时间长度：周
            var weekNums = CommonHandleMethod.GenerateArrangeWeeks(dayNums);
            rs.DayNums = dayNums;
            rs.WeekNums = weekNums;
            return rs;
        }
        private BookingConfigInfo GetBookingConfigInfo(string hospitalId, SqlSugarClient db = null)
        {
            if (db == null)
            {
                db = SqlSugarManager.DB;
            }
            List<t_mt_bookingnewconfig> list = GetSystemConfigList(hospitalId);
            var systemConfig = new BookingConfigInfo();

            //通过反射给系统配置赋值
            PropertyInfo[] properties = systemConfig.GetType().GetProperties();
            for (var i = 0; i < properties.Length; i++)
            {
                list.ForEach(item =>
                {
                    if (item.ConfigKey == properties[i].Name)
                    {
                        if (typeof(string).Equals(properties[i].PropertyType))
                        {
                            properties[i].SetValue(systemConfig, item.ConfigValue);
                        }
                        else
                        {
                            properties[i].SetValue(systemConfig, Convert.ToInt32(item.ConfigValue));
                        }
                    }
                });
            }
            return systemConfig;
        }
        private List<t_mt_bookingnewconfig> GetSystemConfigList(string hospitalId, SqlSugarClient db = null)
        {
            if (db == null)
            {
                db = SqlSugarManager.DB;
            }
            var result = new List<t_mt_bookingnewconfig>();

            try
            {
                var rs = db.Queryable<t_mt_bookingnewconfig>()
                .Where(n => n.HospitalID == hospitalId).Where(n => n.IsDelete == 0).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
