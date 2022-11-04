using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstGldetermination
    {
        Task<List<MstGldetermination>> GetAllData();
        Task<ApiResponseModel> Insert(MstGldetermination oMstGldetermination);
        Task<ApiResponseModel> Update(MstGldetermination oMstGldetermination);
        Task<ApiResponseModel> Insert(List<MstGldetermination> oMstGldetermination);
        Task<ApiResponseModel> Update(List<MstGldetermination> oMstGldetermination);
    }
}
