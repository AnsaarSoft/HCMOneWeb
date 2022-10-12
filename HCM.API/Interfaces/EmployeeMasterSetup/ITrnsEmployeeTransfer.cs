using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface ITrnsEmployeeTransfer
    {
        Task<List<TrnsEmployeeTransfer>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
        Task<ApiResponseModel> Update(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
    }
}
