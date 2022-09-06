using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstDepartment
    {
        Task<List<MstDepartment>> GetAllData();
        Task<ApiResponseModel> Insert(MstDepartment oMstDepartment);
        Task<ApiResponseModel> Update(MstDepartment oMstDepartment);
        Task<ApiResponseModel> Insert(List<MstDepartment> oMstDepartment);
        Task<ApiResponseModel> Update(List<MstDepartment> oMstDepartment);
    }
}
