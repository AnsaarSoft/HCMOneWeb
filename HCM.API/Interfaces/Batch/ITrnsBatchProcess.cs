using HCM.API.Models;

namespace HCM.API.Interfaces.Batch
{
    public interface ITrnsBatchProcess
    {
        Task<List<TrnsBatch>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsBatch oTrnsBatch);
        Task<ApiResponseModel> Update(TrnsBatch oTrnsBatch);
        Task<ApiResponseModel> Insert(List<TrnsBatch> oTrnsBatch);
        Task<ApiResponseModel> Update(List<TrnsBatch> oTrnsBatch);
    }
}
