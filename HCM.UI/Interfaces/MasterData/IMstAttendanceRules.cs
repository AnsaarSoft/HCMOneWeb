using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstAttendanceRules
    {
        Task<MstAttendanceRule> GetAllData();
        Task<ApiResponseModel> Insert(MstAttendanceRule mstAttendanceRule);
        Task<ApiResponseModel> Update(MstAttendanceRule mstAttendanceRule);
    }
}
