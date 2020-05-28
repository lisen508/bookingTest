using BookingPlatform_InitialHospital.DTO;
using BookingPlatform_InitialHospital.EntityModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookingPlatform_InitialHospital
{
    public partial class MainForm : Form
    {
        private string _apiAddress
        {
            get
            {
                try
                {
                    return System.Configuration.ConfigurationManager.AppSettings["UserPlatfromAddress"].Trim();
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        private string _appId
        {
            get
            {
                try
                {
                    return System.Configuration.ConfigurationManager.AppSettings["UserPlatformAppID"].Trim();
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_initialHospital_Click(object sender, EventArgs e)
        {
            try
            {
                var printMessage = string.Empty;
                var hospitalName = string.Empty;
                var extralFlag = false;
                if (this.txb_hospitalId.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("医院ID不可为空！");
                    return;
                }
                if (cb_select.Checked)
                {
                    extralFlag = true;
                }
                var flag = SynThirdPartData(txb_hospitalId.Text, extralFlag);
                if (!flag)
                {
                    YLog.LogInfo("院区数据初始化失败!");
                    return;
                }
                printMessage = "院区数据初始化成功!";
                YLog.LogInfo(printMessage);

                flag = InitialSystemConfig(txb_hospitalId.Text);
                if (!flag)
                {
                    YLog.LogInfo("系统配置初始化失败!");
                    MessageBox.Show("系统配置初始化失败!");
                    return;
                }
                printMessage = $".{printMessage}\r\n.系统配置初始化成功!";
                MessageBox.Show(printMessage);
            }
            catch (Exception ex)
            {
                YLog.LogError($"初始化失败:{ex.Message},错误堆栈:{ex.StackTrace}");
            }
        }

        /// <summary>
        /// 同步第三方数据
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="extralFlag">是否额外初始化院区配置,默认false:否</param>
        /// <returns></returns>
        private bool SynThirdPartData(string hospitalId, bool extralFlag = false)
        {
            try
            {
                var db = SqlSugarManager.DB;
                var dic = new Dictionary<string, string>();
                var hospitalInfo = new t_hospital();
                var hospitalConfig = new t_hospitalareaconfig();
                dic.Add("hospid", hospitalId);
                dic.Add("getUnion", "1");
                var userCenterRs = MyWebApi_Get.Get(_apiAddress + "/api/DjHospital/GetHospitalDetail", dic, _appId);
                var thirdResult = Newtonsoft.Json.JsonConvert.DeserializeObject<UserPlatformHospitalInfo>(userCenterRs);
                if (thirdResult.ret_code != 0)
                {
                    return false;
                }
                hospitalInfo.ID = CreateID.GetID();
                hospitalInfo.CreateDT = DateTime.Now;
                hospitalInfo.HospitalArea = thirdResult.ret_data.Area;
                hospitalInfo.HospitalCode = thirdResult.ret_data.HospitalId;
                hospitalInfo.HospitalDesc = thirdResult.ret_data.ShortHosName;
                hospitalInfo.HospitalID = thirdResult.ret_data.HospitalId;
                hospitalInfo.HospitalName = thirdResult.ret_data.AllHosName;
                hospitalInfo.IsDelete = 0;
                hospitalInfo.ProvinceID = thirdResult.ret_data.Province;
                hospitalInfo.ProvinceName = thirdResult.ret_data.Province;
                hospitalInfo.Remark = thirdResult.ret_data.Remark;
                hospitalInfo.UnionID = string.Join(",", thirdResult.ret_data.UnionList);
                var count = db.Insertable<t_hospital>(hospitalInfo).ExecuteCommand();
                if (extralFlag)
                {
                    hospitalConfig.ID = CreateID.GetID();
                    hospitalConfig.HospitalID = hospitalId;
                    hospitalConfig.HospitalName = hospitalInfo.HospitalName;
                    hospitalConfig.IsApplyOpenBooking = 0;
                    hospitalConfig.IsSourceOpenBooking = 0;
                    hospitalConfig.IsDelete = 0;
                    hospitalConfig.CreateDT = DateTime.Now.ToDate4();
                    count = count + db.Insertable<t_hospitalareaconfig>(hospitalConfig).ExecuteCommand();
                }
                if (count > 0)
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
        /// 初始化系统配置
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        private bool InitialSystemConfig(string hospitalId)
        {
            var db = SqlSugarManager.DB;
            try
            {
                var insertList = new List<t_mt_bookingnewconfig>();
                var configList = db.Queryable<t_mt_systemconfig>().Where(n => n.IsDelete == 0);
                if (configList.Any() == false)
                {
                    YLog.LogError("系统配置暂无数据!");
                    return false;
                }
                configList.ToList().ForEach(item =>
                {
                    var info = new t_mt_bookingnewconfig();
                    info.ID = CreateID.GetID();
                    info.ConfigKey = item.ConfigKey;
                    info.ConfigKeyId = item.ID;
                    info.ConfigValue = "0";
                    info.HospitalID = hospitalId;
                    info.IsDelete = 0;
                    insertList.Add(info);
                });
                db.BeginTran();
                db.Insertable<t_mt_bookingnewconfig>(insertList).ExecuteCommand();
                db.CommitTran();
                return true;
            }
            catch (Exception ex)
            {
                YLog.LogSystemError($@"系统错误:{ex.Message},错误堆栈:{ex.StackTrace}");
                throw (ex);
            }
        }
    }
}
