using HCM.API.Models;

namespace HCM.API.Interfaces.ApprovalSetup
{
    public interface ICfgApprovalTemplate
    {
        Task<List<CfgApprovalTemplate>> GetAllData();
        Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate);
        Task<List<MstForm>> GetApprovalDocs();
        int InsertDocApprovalDecesion(string OriginatorID, int DocNum, string FLG, int FormCode, string FoamName, int EmpID);
        Task<List<DocApprovalDecesion>> GetAlerts(int EmpID, string DocStatus);
        //Task<DocApprovalDecesion> UpdateDocApprStatus(DocApprovalDecesion oDocApprovalDecesion);
    }
}
