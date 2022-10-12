using HCM.API.Models;

namespace HCM.UI.Interfaces.Loan
{
    public interface ITrnsLoanRequest
    {
        Task<List<TrnsLoanRequest>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsLoanRequest pTrnsLoanRequest);
        Task<ApiResponseModel> Update(TrnsLoanRequest pTrnsLoanRequest);
        Task<ApiResponseModel> Insert(List<TrnsLoanRequest> pTrnsLoanRequest);
        Task<ApiResponseModel> Update(List<TrnsLoanRequest> pTrnsLoanRequest);
    }
}
