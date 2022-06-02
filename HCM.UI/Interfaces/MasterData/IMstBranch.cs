using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstBranch
    {
        Task<List<MstBranch>> GetAllData();
        Task<ApiResponseModel> Insert(MstBranch oMstBranch);
        Task<ApiResponseModel> Update(MstBranch oMstBranch);
    }
}
