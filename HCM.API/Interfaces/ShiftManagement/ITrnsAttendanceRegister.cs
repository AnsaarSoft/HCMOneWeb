using HCM.API.Models;

namespace HCM.API.Interfaces.ShiftManagement
{
    public interface ITrnsAttendanceRegister
    {
        Task<List<TrnsAttendanceRegister>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsAttendanceRegister pTrnsAttendanceRegister);
        Task<ApiResponseModel> Update(TrnsAttendanceRegister pTrnsAttendanceRegister);
        Task<ApiResponseModel> Insert(List<TrnsAttendanceRegister> pTrnsAttendanceRegister);
        Task<ApiResponseModel> Update(List<TrnsAttendanceRegister> pTrnsAttendanceRegister);
    }
}
