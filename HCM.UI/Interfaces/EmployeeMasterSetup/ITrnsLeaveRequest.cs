using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsLeaveRequest
    {
        Task<List<TrnsLeavesRequest>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsLeavesRequest pTrnsLeavesRequest);
        Task<ApiResponseModel> Update(TrnsLeavesRequest pTrnsLeavesRequest);
        Task<ApiResponseModel> Insert(List<TrnsLeavesRequest> pTrnsLeavesRequest);
        Task<ApiResponseModel> Update(List<TrnsLeavesRequest> pTrnsLeavesRequest);
    }
}
