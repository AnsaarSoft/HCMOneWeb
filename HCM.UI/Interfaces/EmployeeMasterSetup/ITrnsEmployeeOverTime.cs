using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsEmployeeOverTime
    {
        Task<List<TrnsEmployeeOvertime>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeOvertime pTrnsEmployeeOvertime);
        Task<ApiResponseModel> Update(TrnsEmployeeOvertime pTrnsEmployeeOvertime);
        Task<ApiResponseModel> Insertlist(List<TrnsEmployeeOvertime> pTrnsEmployeeOvertime);
        Task<ApiResponseModel> Updatelist(List<TrnsEmployeeOvertime> pTrnsEmployeeOvertime);
    }
}
