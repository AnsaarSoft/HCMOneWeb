using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface ITrnsEmployeeTransfer
    {
        Task<List<TrnsEmployeeTransfer>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
        Task<ApiResponseModel> Update(TrnsEmployeeTransfer pTrnsEmployeeTransfer);
    }
}
