using HCM.API.Models;

namespace HCM.API.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsEmployeeTransfer
    {
        Task<List<TrnsEmployeeTransfer>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
        Task<ApiResponseModel> Update(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
    }
}
