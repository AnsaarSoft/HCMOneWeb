using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstAdvance
    {
        Task<List<MstAdvance>> GetAllData();
        Task<ApiResponseModel> Insert(MstAdvance pMstAdvance);
        Task<ApiResponseModel> Update(MstAdvance pMstAdvance);

    }
}