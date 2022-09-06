using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstGratuity
    {
        Task<List<MstGratuity>> GetAllData();
        Task<ApiResponseModel> Insert(MstGratuity pMstGratuity);
        Task<ApiResponseModel> Update(MstGratuity pMstGratuity);
    }
}
