using HCM.API.Models;

namespace HCM.API.Interfaces.ApprovalSetup
{
    public interface ICfgApprovalTemplate
    {
        Task<List<CfgApprovalTemplate>> GetAllData();
        Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<List<MstForm>> GetApprovalDocs();
    }
}
