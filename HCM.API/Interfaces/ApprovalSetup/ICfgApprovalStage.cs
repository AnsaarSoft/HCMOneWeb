using HCM.API.Models;

namespace HCM.API.Interfaces.ApprovalSetup
{
    public interface ICfgApprovalStage
    {
        Task<List<CfgApprovalStage>> GetAllData();
        Task<ApiResponseModel> Insert(CfgApprovalStage oCfgApprovalStage);
        Task<ApiResponseModel> Update(CfgApprovalStage oCfgApprovalStage);
    }
}
