using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstAttendanceRules
    {
        //Task<List<MstAttendanceRule>> GetAllData();
        Task<MstAttendanceRule> GetAllData();
        Task<ApiResponseModel> Insert(MstAttendanceRule mstAttendanceRule);
        Task<ApiResponseModel> Update(MstAttendanceRule mstAttendanceRule);
    }
}
