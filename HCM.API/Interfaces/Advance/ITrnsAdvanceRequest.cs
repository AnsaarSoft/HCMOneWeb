using HCM.API.Models;

namespace HCM.API.Interfaces.Advance
{
    public interface ITrnsAdvanceRequest
    {
        Task<List<TrnsAdvanceRequest>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsAdvanceRequest pTrnsAdvanceRequest);
        Task<ApiResponseModel> Update(TrnsAdvanceRequest pTrnsAdvanceRequest);
        Task<ApiResponseModel> Insert(List<TrnsAdvanceRequest> pTrnsAdvanceRequest);
        Task<ApiResponseModel> Update(List<TrnsAdvanceRequest> pTrnsAdvanceRequest);
    }
}
