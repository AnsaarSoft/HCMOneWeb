using HCM.API.Models;

namespace HCM.API.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsEmployeeOverTime
    {
        Task<List<TrnsEmployeeOvertime>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeOvertime pTrnsEmployeeOvertime);
        Task<ApiResponseModel> Update(TrnsEmployeeOvertime pTrnsEmployeeOvertime);
    }
}
