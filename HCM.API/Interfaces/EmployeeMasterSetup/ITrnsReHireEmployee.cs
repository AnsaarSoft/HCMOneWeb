using HCM.API.HCMModels;
using HCM.API.Models;

namespace HCM.API.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsReHireEmployee
    {
        Task<List<TrnsEmployeeReHire>> GetAllData();
        Task<ApiResponseModel> Insert(VMEmployeeReHire pVMEmployeeReHire);
        Task<ApiResponseModel> Update(VMEmployeeReHire pVMEmployeeReHire);
    }
}
