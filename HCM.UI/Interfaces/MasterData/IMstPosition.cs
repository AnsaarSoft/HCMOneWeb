using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstPosition
    {
        Task<List<MstPosition>> GetAllData();
        Task<ApiResponseModel> Insert(MstPosition oMstPosition);
        Task<ApiResponseModel> Update(MstPosition oMstPosition);
        Task<ApiResponseModel> Insert(List<MstPosition> oMstPosition);
        Task<ApiResponseModel> Update(List<MstPosition> oMstPosition);
    }
}
