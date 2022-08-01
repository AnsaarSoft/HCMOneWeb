using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstGratuity
    {
        Task<List<MstGratuity>> GetAllData();
        Task<ApiResponseModel> Update(MstGratuity pMstGratuity);
        Task<ApiResponseModel> Insert(MstGratuity pMstGratuity);
    }
}
