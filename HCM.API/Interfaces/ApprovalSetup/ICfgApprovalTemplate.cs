using HCM.API.Models;

namespace HCM.API.Interfaces.ApprovalSetup
{
    public interface ICfgApprovalTemplate
    {
        Task<List<CfgApprovalTemplate>> GetAllData();
        Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<List<MstForm>> GetApprovalDocs();
        //int InsertDocApproval(int OriginatorID, int DocNum, string FLG, int FormCode, string FoamName, string UserCode);
        //Task<List<DocApproval>> GetAlerts(int UserID, string DocStatus);
        //Task<DocApproval> UpdateDocApprStatus(DocApproval oDocApproval);
    }
}
