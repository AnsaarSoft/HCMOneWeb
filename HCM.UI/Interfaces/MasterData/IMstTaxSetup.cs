using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstTaxSetup
    {
        Task<List<MstTaxSetup>> GetAllData();
        Task<ApiResponseModel> Insert(MstTaxSetup pMstTaxSetup);
        Task<ApiResponseModel> Update(MstTaxSetup pMstTaxSetup);
    }
}
