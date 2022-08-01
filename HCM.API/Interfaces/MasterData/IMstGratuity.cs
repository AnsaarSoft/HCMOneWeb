using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstGratuity
    {
        Task<List<MstGratuity>> GetAllData();
        Task<ApiResponseModel> Update(MstGratuity pMstGratuity);
        Task<ApiResponseModel> Insert(MstGratuity pMstGratuity);
    }
}
