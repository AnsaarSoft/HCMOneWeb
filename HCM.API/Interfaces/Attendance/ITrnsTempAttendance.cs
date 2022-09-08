using HCM.API.Models;

namespace HCM.API.Interfaces.Attendance
{
    public interface ITrnsTempAttendance
    {
        Task<List<TrnsTempAttendance>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsTempAttendance oTrnsTempAttendance);
        Task<ApiResponseModel> Update(TrnsTempAttendance oTrnsTempAttendance);
        Task<ApiResponseModel> Insert(List<TrnsTempAttendance> oTrnsTempAttendance);
        Task<ApiResponseModel> Update(List<TrnsTempAttendance> oTrnsTempAttendance);
    }
}
