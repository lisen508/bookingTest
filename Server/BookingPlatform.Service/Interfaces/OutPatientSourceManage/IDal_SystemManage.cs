using BookingPlatform.Core;
using BookingPlatform.Core.DataInPut;
using BookingPlatform.Core.DataOutput;
using BookingPlatform.Core.TableModels;
using System.Collections.Generic;


namespace BookingPlatform.Service.Interfaces
{
    public interface IDal_SystemManage
    {


        #region 床位管理
        /// <summary>
        /// 床位管理---病区--设置是否显示余床信息提醒
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="HospitalID">医院ID</param>
        /// <param name="IsShowSurplusBed">是否显示余床信息提醒：1表示选择，0表示未选中</param>
        /// <returns></returns>

        CommonOutputData<object> SetHospitalSurplusBed(string UserID, string HospitalID, int IsShowSurplusBed = 0);



        /// <summary>
        /// 床位管理---病区---删除病区名称
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="HospitalID">医院ID</param>
        /// <param name="TInfectedPatchID">病区ID</param>
        /// <returns></returns>
        /// 
        CommonOutputData<object> DeleteInfectedPatch(string UserID, string HospitalID, string TInfectedPatchID);


        /// <summary>
        /// 床位管理---病区---创建病区
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="HospitalID">医院ID</param>
        /// <param name="InfectedPatchName">病区名称</param>
        /// <returns></returns>


        CommonOutputData<object> CreateInfectedPatchList(string UserID, string HospitalID, string InfectedPatchName);

        /// <summary>
        /// 床位管理---病区---编辑病区名称
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="HospitalID">医院ID</param>
        /// <param name="TInfectedPatchID">病区ID</param>
        /// <param name="NewInfectedPatchName">病区新名称</param>
        /// <returns></returns>

        CommonOutputData<object> UpdateInfectedPatch(string UserID, string HospitalID, string TInfectedPatchID, string NewInfectedPatchName);

        #endregion
         /// <summary>
        /// 床位管理---病房---创建病房
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="hospitalID">院区ID</param>
        /// <param name="InfectedPatchRoom">房间类型id</param>
        /// <param name="InfectedPatchBedPrice">病房价格</param>
        /// <returns></returns>

        CommonOutputData<object> CreateInfectedPatchRoomList(string UserID, string hospitalID, string InfectedPatchRoom, string InfectedPatchBedPrice = "");


        /// <summary>
        /// 床位管理---病房---编辑病房名称
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="hospitalID">院区ID</param>
        /// <param name="TInfectedPatchRoomID">病房id</param>
        /// <param name="NewInfectedPatchRoomName">新房间类型id</param>
        /// <param name="NewInfectedPatchBedPrice">新病房价格</param>
        /// <returns></returns>

        CommonOutputData<object> UpdateInfectedPatchRoom(string UserID, string hospitalID, string TInfectedPatchRoomID, string NewInfectedPatchRoomName, string NewInfectedPatchBedPrice = "");
        /// <summary>
        /// 床位管理---病房---删除病房名称
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="hospitalID">院区ID</param>
        /// <param name="TInfectedPatchRoomID">病房id</param>
        /// <returns></returns>

        CommonOutputData<object> DeleteInfectedPatchRoom(string UserID, string hospitalID, string TInfectedPatchRoomID);
      

    }
}
