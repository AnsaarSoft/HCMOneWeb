using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstCalendar
    {
        Task<List<MstCalendar>> GetAllData();
        Task<ApiResponseModel> Insert(MstCalendar oMstCalendar);
        Task<ApiResponseModel> Update(MstCalendar oMstCalendar);
        Task<ApiResponseModel> Insert(MstPayrollPeriod oMstPayrollPeriod);
        Task<ApiResponseModel> Insert(List<MstPayrollPeriod> oMstPayrollPeriod);
    }
}
