using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstCalendar
    {
        Task<List<MstCalendar>> GetAllData();
        Task<ApiResponseModel> Insert(MstCalendar oMstCalendar);
        Task<ApiResponseModel> Update(MstCalendar oMstCalendar);
        Task<ApiResponseModel> Insert(MstPayrollPeriod pMstPayrollPeriod);
    }
}
