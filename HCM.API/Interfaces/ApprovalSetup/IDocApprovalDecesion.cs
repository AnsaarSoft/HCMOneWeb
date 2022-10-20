using HCM.API.Models;

namespace HCM.API.Interfaces.ApprovalSetup
{
    public interface IDocApprovalDecesion
    {
        Task<List<DocApprovalDecesion>> GetAllData(string EmpID, string DocStatus);
        int InsertDocApprovalDecesion(string OriginatorID, int DocNum, int FormCode, string FoamName);
        Task<ApiResponseModel> UpdateDocApprStatus(DocApprovalDecesion oDocApproval);
    }
}
