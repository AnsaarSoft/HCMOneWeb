using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstLoans
    {
        Task<List<MstLoan>> GetAllData();
        Task<ApiResponseModel> Insert(MstLoan pMstLoans);
        Task<ApiResponseModel> Update(MstLoan pMstLoans);
        
    }
}