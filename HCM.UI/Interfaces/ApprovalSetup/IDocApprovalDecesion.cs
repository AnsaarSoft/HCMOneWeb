using HCM.API.Models;

namespace HCM.UI.Interfaces.ApprovalSetup
{
    public interface IDocApprovalDecesion
    {
        Task<List<DocApprovalDecesion>> GetAllData(string EmpID, string DocStatus);

        Task<ApiResponseModel> UpdateDocApproval(DocApprovalDecesion oDocApproval);
    }
}
