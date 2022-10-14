using HCM.API.Models;

namespace HCM.UI.Interfaces.ApprovalSetup
{
    public interface IMstStages
    {
        Task<List<MstStage>> GetAllData();
        Task<ApiResponseModel> Insert(MstStage oMstStage);
        Task<ApiResponseModel> Update(MstStage oMstStage);
    }
}
