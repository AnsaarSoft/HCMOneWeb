using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstTaxSetup
    {
        Task<List<MstTaxSetup>> GetAllData();
        Task<ApiResponseModel> Update(MstTaxSetup pMstTaxSetup);
        Task<ApiResponseModel> Insert(MstTaxSetup pMstTaxSetup);
    }
}