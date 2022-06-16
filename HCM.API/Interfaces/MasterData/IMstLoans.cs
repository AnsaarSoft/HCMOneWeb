using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstLoans
    {
        Task<List<MstLoan>> GetAllData();
        Task<ApiResponseModel> Insert(MstLoan pMstLoans);
        Task<ApiResponseModel> Update(MstLoan pMstLoans);
        
    }
}