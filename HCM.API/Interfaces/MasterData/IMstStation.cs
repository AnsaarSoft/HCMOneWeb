using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstStation
    {
        Task<List<MstStation>> GetAllData();
        Task<ApiResponseModel> Insert(MstStation oMstStation);
        Task<ApiResponseModel> Update(MstStation oMstStation);
        Task<ApiResponseModel> Insert(List<MstStation> oMstStation);
        Task<ApiResponseModel> Update(List<MstStation> oMstStation);
    }
}
