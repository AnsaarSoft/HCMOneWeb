using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsSingleEntryOtrequest
    {
        Task<List<TrnsSingleEntryOtrequest>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsSingleEntryOtrequest pTrnsSingleEntryOtrequest);
        Task<ApiResponseModel> Update(TrnsSingleEntryOtrequest pTrnsSingleEntryOtrequest);
    }
}
