using HCM.API.Models;

namespace HCM.API.Interfaces.ClientSpecific
{
    public interface IMstTarget
    {
        Task<List<TrnsProductStage>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsProductStage pTrnsProductStage);
        Task<ApiResponseModel> Update(TrnsProductStage pTrnsProductStage);
        Task<ApiResponseModel> Insertlist(List<TrnsProductStage> pTrnsProductStage);
        Task<ApiResponseModel> Updatelist(List<TrnsProductStage> pTrnsProductStage);
    }
}
