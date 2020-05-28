namespace BookingPlatform.Common.MyEnum
{
    public enum ErrCode
    {
        ERROR = 0,
        SUCCESS = 1,

        ERR_UserID_IsNull = -1100,
        ERR_UserID_Error = -1101,

        ERR_DbConntion = -1200,
        ERR_DbSelect = -1201,
        ERR_DbUpdate = -1202,
        ERR_DbInseart = -1203,
        ERR_DbDelete = -1203,

        ERR_ThirdParty_GetHospitalList = -1301,
        ERR_ThirdParty_GetClinicList = -1302,
        ERR_ThirdParty_GetDoctorList = -1303,

        ERR_DateTime = -1400,
        ERR_HospitalID = -1401,
        ERR_ClinicID = -1402,
        ERR_DoctorID = -1403,
        ERR_InfectedPatchList = -1404,
        ERR_InfectedPatchName = -1405,
        ERR_InfectedPatchID = -1406,
        ERR_InfectedPatchRoomList = -1407,
        ERR_InfectedPatchRoomName = -1408,
        ERR_InfectedPatchRoomID = -1409,
        ERR_InfectedPatchBedList = -1410,
        ERR_InfectedPatchBedName = -1411,
        ERR_InfectedPatchBedID = -1412,

        ERR_OpsRoomList = -1413,
        ERR_OpsRoomName = -1414,
        ERR_OpsRoomID = -1415,
        ERR_OpsStageList = -1416,
        ERR_OpsStageName = -1417,
        ERR_OpsStageID = -1418,
        ERR_OutPatientTypeName = -1419,
        ERR_OutPatientTypeID = -1420,
        ERR_OpsClinicList = -1421,
        ERR_OpsClinicName = -1422,
        ERR_OpsClinicID = -1423,
        ERR_OpsClinicSite = -1424,

        ERR_PeriodID = -1500,
        ERR_PeriodName = -1501,
        ERR_DateStart = -1502,
        ERR_DateEnd = -1503,
        ERR_MorningStart = -1504,
        ERR_MorningEnd = -1505,
        ERR_NooningStart = -1506,
        ERR_NooningEnd = -1507,
        ERR_AfternoonStart = -1508,
        ERR_AfternoonEnd = -1509,
        ERR_NightStart = -1510,
        ERR_NightEnd = -1511,
        ERR_Run = -1600,
    }
}