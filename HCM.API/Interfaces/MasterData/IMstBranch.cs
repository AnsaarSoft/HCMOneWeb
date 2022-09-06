using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstBranch
    {
        Task<List<MstBranch>> GetAllData();
        Task<ApiResponseModel> Insert(MstBranch oMstBranch);
        Task<ApiResponseModel> Update(MstBranch oMstBranch);
        Task<ApiResponseModel> Insert(List<MstBranch> oMstBranch);
        Task<ApiResponseModel> Update(List<MstBranch> oMstBranch);
    }
}
