using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstAdvance
    {
        Task<List<MstAdvance>> GetAllData();
        Task<ApiResponseModel> Insert(MstAdvance pMstAdvance);
        Task<ApiResponseModel> Update(MstAdvance pMstAdvance);

    }
}