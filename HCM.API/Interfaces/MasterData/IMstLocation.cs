using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstLocation
    {
        Task<List<MstLocation>> GetAllData();
        Task<ApiResponseModel> Insert(MstLocation oMstLocation);
        Task<ApiResponseModel> Update(MstLocation oMstLocation);
        Task<ApiResponseModel> Insert(List<MstLocation> oMstLocation);
        Task<ApiResponseModel> Update(List<MstLocation> oMstLocation);
    }
}
