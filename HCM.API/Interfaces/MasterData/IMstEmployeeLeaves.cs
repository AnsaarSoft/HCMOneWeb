using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstEmployeeLeaves
    {
        Task<List<MstEmployeeLeaf>> GetAllData();
        Task<ApiResponseModel> Insert(MstEmployeeLeaf oMstEmployeeLeaf);
        Task<ApiResponseModel> Update(MstEmployeeLeaf oMstEmployeeLeaf);
        Task<ApiResponseModel> Insert(List<MstEmployeeLeaf> oMstEmployeeLeaf);
        Task<ApiResponseModel> Update(List<MstEmployeeLeaf> oMstEmployeeLeaf);
    }
}
