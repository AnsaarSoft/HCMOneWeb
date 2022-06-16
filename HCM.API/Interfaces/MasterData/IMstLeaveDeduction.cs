using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstLeaveDeduction
    {
        Task<List<MstLeaveDeduction>> GetAllData();
        Task<ApiResponseModel> Insert(MstLeaveDeduction pMstLeaveDeduction);
        Task<ApiResponseModel> Update(MstLeaveDeduction pMstLeaveDeduction);
    }
}