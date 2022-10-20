using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsReHireEmployee
    {
        Task<List<TrnsEmployeeReHire>> GetAllData();
        Task<ApiResponseModel> Insert(VMEmployeeReHire pVMEmployeeReHire);
        Task<ApiResponseModel> Update(VMEmployeeReHire pVMEmployeeReHire);
    }
}
