using HCM.API.Models;

namespace HCM.UI.Interfaces.ClientSpecific
{
    public interface ITrnsProductStage
    {
        Task<List<TrnsProductStage>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsProductStage pTrnsProductStage);
        Task<ApiResponseModel> Update(TrnsProductStage pTrnsProductStage);
        Task<ApiResponseModel> Insertlist(List<TrnsProductStage> pTrnsProductStage);
        Task<ApiResponseModel> Updatelist(List<TrnsProductStage> pTrnsProductStage);
    }
}
