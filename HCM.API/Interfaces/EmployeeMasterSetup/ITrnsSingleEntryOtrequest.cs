using HCM.API.HCMModels;
using HCM.API.Models;

namespace HCM.API.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsSingleEntryOtrequest
    {
        Task<List<TrnsSingleEntryOtrequest>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsSingleEntryOtrequest pTrnsSingleEntryOtrequest);
        Task<ApiResponseModel> Update(TrnsSingleEntryOtrequest pTrnsSingleEntryOtrequest);
        Task<ApiResponseModel> InsertUpdate(VMMonthlyOverTime vMMonthlyOverTime);
    }
}
