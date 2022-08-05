using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterDataImport
{
    public interface IMstDataImport
    {
        Task<List<MstDepartment>> GetAllData();
        Task<ApiResponseModel> Insert(MstDepartment oMstDepartment);
        Task<ApiResponseModel> Update(MstDepartment oMstDepartment);
    }
}
