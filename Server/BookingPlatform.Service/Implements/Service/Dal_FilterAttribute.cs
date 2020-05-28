using BookingPlatform.Common;
using BookingPlatform.Common.MyEnum;
using BookingPlatform.Core;
using BookingPlatform.Core.DataInPut;
using BookingPlatform.Core.DataOutput;
using BookingPlatform.Core.TableModels;
using BookingPlatform.Models.LogManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingPlatform.Service
{
    public class Dal_FilterAttribute : Dal_Base
    {

        private static Dictionary<string, string> _startDate = new Dictionary<string, string>();

        /// <summary>
        /// 是否存在当前院区
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        public Tuple<bool, string> HasHosptial(string hospitalID)
        {

            try
            {
                var rs = db.Queryable<t_hospital>().Where(n => n.HospitalID == hospitalID).Where(n => n.IsDelete == 0).ToList();
                if (rs.Any() == false)
                {
                    return Tuple.Create(false, "未找到院区信息");
                }
                return Tuple.Create(true, string.Empty);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public Tuple<bool, string> StartAutoContinue(string HospitalID)
        {
            try
            {
                string sd = DateTime.Now.ToString("yyyy-MM-dd");
                if (_startDate.ContainsKey(HospitalID) == false || sd != _startDate[HospitalID])
                {

                    IList<t_outpatreleasesourcerule> listOPRSR = db.Queryable<t_outpatreleasesourcerule>().Where(p => p.HospitalID == HospitalID && p.IsDelete == "0").ToList();

                    //获取门诊类型列表
                    IList<t_outpatienttype> listOutpatientType = db.Queryable<t_outpatienttype>().Where(p => p.HospitalID == HospitalID && p.IsDelete == "0").ToList();
                    Dictionary<string, t_outpatienttype> dicOutpatientType = new Dictionary<string, t_outpatienttype>();
                    foreach (var v in listOutpatientType) { dicOutpatientType.Add(v.ID, v); }

                    int nDays = 7;
                    foreach (var v in listOPRSR) { if (v.BeforeWeek.Trim() == "两周") nDays = 14; }

                    //ToolsSoftwareORM.HTableColumn.Ht_clinic_Column colClinicWhere = new ToolsSoftwareORM.HTableColumn.Ht_clinic_Column();
                    //colClinicWhere.HospitalID = HospitalID;
                    //colClinicWhere.IsDelete = "0";
                    string sqlClinic = string.Format("select * from t_arrange where HospitalID='{0}' GROUP BY TClinicID", HospitalID);
                    foreach (t_arrange colA in db.SqlQueryable<t_arrange>(sqlClinic).ToList())
                    {
                        //获取排班最后一天时间
                        string sqlArrangeLastDate = string.Format("select * from t_arrange t where HospitalID='{0}' and TClinicID='{1}' ORDER BY ArrangeDate DESC LIMIT 0,1", HospitalID, colA.TClinicID);
                        System.Data.DataTable dt = db.Ado.GetDataTable(sqlArrangeLastDate);
                        if (dt == null) { return new Tuple<bool, string>(false, "查询排班信息错误"); }
                        if (dt.Rows.Count == 0) { return new Tuple<bool, string>(false, "未能查到排班信息"); }

                        DateTime dtRunNow = DateTime.Parse(dt.Rows[0]["ArrangeDate"].ToString());
                        string lastArrangeDate = dtRunNow.AddDays(1).ToString("yyyy-MM-dd");
                        string endDate = (EnumWeek_Class.EnumWeek_GetMonday(DateTime.Now)).AddDays(6 + nDays).ToString("yyyy-MM-dd");
                        //if ((int)((DateTime.Parse(endDate) - DateTime.Now.AddDays(nDays)).TotalDays) < 0) return new Tuple<bool, string>(true, "");
                        int nTotalDays = (int)((DateTime.Parse(endDate) - dtRunNow).TotalDays);
                        if (nTotalDays <= 0) continue;

                        string sql = string.Format("select * from t_autocontinue where  HospitalID = '{0}' and StartDate >='{1}' and StartDate<='{2}' order by StartDate", HospitalID, lastArrangeDate, endDate);
                        IList<t_autocontinue> listAutoContinue = db.SqlQueryable<t_autocontinue>(sql).ToList();
                        Dictionary<string, t_autocontinue> dicAutoContinue = new Dictionary<string, t_autocontinue>();
                        foreach (t_autocontinue col in listAutoContinue)
                        {
                            if (dicAutoContinue.ContainsKey(col.StartDate) == false) dicAutoContinue.Add(col.StartDate, col);
                        }


                        for (int i = 1; i <= nTotalDays; i++)
                        {
                            string nowDate = dtRunNow.AddDays(i).ToString("yyyy-MM-dd");
                            if (dicAutoContinue.ContainsKey(nowDate) == false)
                            {
                                //开始自动延续数据
                                for (int j = 1; j <= 4; j++)
                                {
                                    //延续排版
                                    //添加下周排班
                                    string strArrangeID = CreateID.GetID();
                                    t_arrange colInseart = new t_arrange();
                                    colInseart.ID = strArrangeID;
                                    colInseart.CreateDT = DateTime.Now;
                                    colInseart.ArrangeDate = nowDate;
                                    colInseart.HospitalID = HospitalID;
                                    colInseart.Period = j;
                                    colInseart.TClinicID = colA.TClinicID;
                                    // _ht_arrange.InsertInto(colInseart);
                                    db.Insertable(colInseart).ExecuteCommand();


                                    //延续上周排版
                                    //t_arrange colArrangeWhere = new t_arrange();
                                    //colArrangeWhere.HospitalID = HospitalID;
                                    //colArrangeWhere.TClinicID = colA.TClinicID;
                                    //colArrangeWhere.Period = j;
                                    // colArrangeWhere.ArrangeDate = dtRunNow.AddDays(i).AddDays(-7).ToString("yyyy-MM-dd");
                                    IList<t_arrange> listArrange = db.Queryable<t_arrange>().Where(p => p.HospitalID == HospitalID && p.TClinicID == colA.TClinicID && p.Period == j && p.ArrangeDate == dtRunNow.AddDays(i).AddDays(-7).ToString("yyyy-MM-dd"))
                                        .ToList();
                                    if (listArrange.Count == 0) continue;

                                    //t_arrangedetail colArrangeDetailWhere = new t_arrangedetail();
                                    //colArrangeDetailWhere.TArrangeID = listArrange[0].ID;
                                    IList<t_arrangedetail> listArrangeDetail = db.Queryable<t_arrangedetail>().Where(p => p.TArrangeID == listArrange[0].ID).ToList();
                                    foreach (t_arrangedetail colArrangeDetail in listArrangeDetail)
                                    {
                                        string strArrangeDetailID = CreateID.GetID();
                                        t_arrangedetail colArrangeDetailInseart = new t_arrangedetail();
                                        colArrangeDetailInseart.ID = strArrangeDetailID;
                                        colArrangeDetailInseart.CreateDT = DateTime.Now;
                                        colArrangeDetailInseart.IsDelete = "0";
                                        colArrangeDetailInseart.Period = colArrangeDetail.Period;
                                        colArrangeDetailInseart.PeriodEnd = colArrangeDetail.PeriodEnd;
                                        colArrangeDetailInseart.PeriodStart = colArrangeDetail.PeriodStart;
                                        colArrangeDetailInseart.SameSourceNum = colArrangeDetail.SameSourceNum;
                                        colArrangeDetailInseart.SourceBefore = colArrangeDetail.SourceBefore;
                                        colArrangeDetailInseart.SourceLength = colArrangeDetail.SourceLength;
                                        colArrangeDetailInseart.State = 1;
                                        colArrangeDetailInseart.TArrangeID = strArrangeID;
                                        colArrangeDetailInseart.TDoctorID = colArrangeDetail.TDoctorID;
                                        colArrangeDetailInseart.TimeSpacs = colArrangeDetail.TimeSpacs;
                                        colArrangeDetailInseart.TOutpatientTypeID = colArrangeDetail.TOutpatientTypeID;
                                        //_ht_arrangedetail.InsertInto(colArrangeDetailInseart);

                                        db.Insertable(colArrangeDetailInseart).ExecuteCommand();


                                        //延续号源
                                        //t_outpatsourcepoolconfig colOutpatientPoolConfigWhere = new t_outpatsourcepoolconfig();
                                        //colOutpatientPoolConfigWhere.HospitalID = HospitalID;
                                        //colOutpatientPoolConfigWhere.SourcePoolType = 0;
                                        //colOutpatientPoolConfigWhere.TClinicID = colA.TClinicID;
                                        //colOutpatientPoolConfigWhere.TArrangeDetailID = colArrangeDetail.ID;
                                        //colOutpatientPoolConfigWhere.BookingPeriod = j;
                                        IList<t_outpatsourcepoolconfig> listOutpatSourcePoolConfig = db.Queryable<t_outpatsourcepoolconfig>().Where(p => p.HospitalID == HospitalID && p.TClinicID == colA.TClinicID)
                                            .Where(p => p.SourcePoolType == 0 && p.TArrangeDetailID == colArrangeDetail.ID && p.BookingPeriod == j).ToList();
                                        foreach (t_outpatsourcepoolconfig colOutpatientPoolConfig in listOutpatSourcePoolConfig)
                                        {
                                            t_outpatsourcepoolconfig colOutpatientPoolConfigInseart = new t_outpatsourcepoolconfig();
                                            colOutpatientPoolConfigInseart.BookingDate = nowDate;
                                            colOutpatientPoolConfigInseart.BookingPeriod = j;
                                            colOutpatientPoolConfigInseart.BookingPlatformName = colOutpatientPoolConfig.BookingPlatformName;
                                            colOutpatientPoolConfigInseart.ClinicName = colOutpatientPoolConfig.ClinicName;
                                            colOutpatientPoolConfigInseart.CreateDT = DateTime.Now;
                                            colOutpatientPoolConfigInseart.DoctorName = colOutpatientPoolConfig.DoctorName;
                                            colOutpatientPoolConfigInseart.HospitalID = HospitalID;
                                            colOutpatientPoolConfigInseart.ID = CreateID.GetID();
                                            colOutpatientPoolConfigInseart.IDCard = colOutpatientPoolConfig.IDCard;
                                            colOutpatientPoolConfigInseart.LockState = 0;
                                            if (dicOutpatientType.ContainsKey(colOutpatientPoolConfig.TOutpatientTypeID) == true)
                                            {
                                                colOutpatientPoolConfigInseart.OutpatientTypeName = dicOutpatientType[colOutpatientPoolConfig.TOutpatientTypeID].TypeName;
                                                colOutpatientPoolConfigInseart.Price = dicOutpatientType[colOutpatientPoolConfig.TOutpatientTypeID].Price;
                                            }

                                            colOutpatientPoolConfigInseart.SourceNo = colOutpatientPoolConfig.SourceNo;
                                            colOutpatientPoolConfigInseart.SourcePoolType = 0;
                                            colOutpatientPoolConfigInseart.State = 0;
                                            colOutpatientPoolConfigInseart.TArrangeDetailID = strArrangeDetailID;
                                            colOutpatientPoolConfigInseart.TBookingPlatformID = colOutpatientPoolConfig.TBookingPlatformID;
                                            colOutpatientPoolConfigInseart.TClinicID = colOutpatientPoolConfig.TClinicID;
                                            colOutpatientPoolConfigInseart.TDoctorID = colOutpatientPoolConfig.TDoctorID;
                                            colOutpatientPoolConfigInseart.TOutpatientTypeID = colOutpatientPoolConfig.TOutpatientTypeID;
                                            // _ht_outpatsourcepoolconfig.InsertInto(colOutpatientPoolConfigInseart);
                                            db.Insertable(colOutpatientPoolConfigInseart).ExecuteCommand();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    _startDate[HospitalID] = DateTime.Now.ToString("yyyy-MM-dd");
                }

                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        /// <summary>
        /// 保存请求的用户Id和请求接口信息
        /// </summary>
        /// <param name="model"></param>
        public void SaveInterfaceInvokeRecord(FilterModel model)
        {
            try
            {
                var info = new t_requestrecord();
                info.ID = CreateID.GetID();
                info.IsDelete = 0;
                info.HospitalID = model.HospitalId;
                info.OperatorID = model.UserId;
                info.RequestPath = model.AbsolutePath;
                info.RequestUri = model.AbsoluteUri;
                info.CreateDT = DateTime.Now.ToDate4();
                db.Insertable<t_requestrecord>(info).ExecuteCommand();
            }
            catch (Exception ex)
            {
                LogManage.LogInfo($"错误信息:{ex.Message},错误堆栈:{ex.StackTrace}");
                return;
            }
        }
    }
}
