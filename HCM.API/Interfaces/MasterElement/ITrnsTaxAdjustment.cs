using HCM.API.Models;

namespace HCM.API.Interfaces.MasterElement
{
    public interface ITrnsTaxAdjustment
    {
        Task<List<TrnsTaxAdjustment>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsTaxAdjustment oTrnsTaxAdjustment);
        Task<ApiResponseModel> Update(TrnsTaxAdjustment oTrnsTaxAdjustment);
    }
}
