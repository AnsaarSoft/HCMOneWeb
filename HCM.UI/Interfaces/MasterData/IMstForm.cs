using HCM.API.Models;
namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstForm
    {
        Task<List<MstForm>> GetAllData();
        Task<ApiResponseModel> Insert(MstForm oMstForm);
        Task<ApiResponseModel> Update(MstForm oMstForm);
    }
}
