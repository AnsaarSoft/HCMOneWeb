using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstDeductionRule
    {
        Task<List<MstDeductionRule>> GetAllData();
        Task<ApiResponseModel> Update(MstDeductionRule pMstDeductionRule);
    }
}