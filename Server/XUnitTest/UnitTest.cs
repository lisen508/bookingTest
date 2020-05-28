using BookingPlatform.Common.CacheManage;
using BookingPlatform.Service.Implements;
using BookingPlatform.Service.Interfaces;
using NPOI.SS.Formula.Functions;
using Xunit;



namespace XUnitTestProject
{
    public class UnitTest
    {
        private string hospitalID = null;


        private string hospitalId = null;
        private string userId = null;
        private IDaySurgeryService service;
        private readonly IDataCache _dataCache;
   
        public UnitTest()
        {
            hospitalID = " 1118011815000575310";
            hospitalId = "1118011814561100810";
            userId = "1222222222";
            service = new DaySurgeryService();

        }



        #region 日间手术部分 单元测试

        [Fact]
        public void Test_GetSurgerySystemConfig()
        {
            var result = service.GetSurgerySystemConfig(hospitalId);
            var r = string.Empty;
        }


        #endregion



   





    }




}


