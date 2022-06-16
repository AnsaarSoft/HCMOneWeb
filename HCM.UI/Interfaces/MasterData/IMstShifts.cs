using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstShifts
    {
        Task<List<MstShift>> GetAllData();
        Task<ApiResponseModel> Insert(MstShift pMstShift);
        Task<ApiResponseModel> Update(MstShift pMstShift);
    }
}
