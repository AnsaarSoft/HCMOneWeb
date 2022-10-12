using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstForm
    {
        Task<List<MstForm>> GetAllData();
        Task<ApiResponseModel> Insert(MstForm oMstForm);
        Task<ApiResponseModel> Update(MstForm oMstForm);
    }
}
