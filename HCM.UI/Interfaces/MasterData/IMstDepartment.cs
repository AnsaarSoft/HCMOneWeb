using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstDepartment
    {
        Task<List<MstDepartment>> GetAllData();
        Task<ApiResponseModel> Insert(MstDepartment oMstDepartment);
        Task<ApiResponseModel> Update(MstDepartment oMstDepartment);
    }
}
