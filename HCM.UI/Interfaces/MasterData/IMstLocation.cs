using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstLocation
    {
        Task<List<MstLocation>> GetAllData();
        Task<ApiResponseModel> Insert(MstLocation oMstLocation);
        Task<ApiResponseModel> Update(MstLocation oMstLocation);
    }
}
