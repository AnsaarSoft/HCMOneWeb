using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface ICfgTaxSetup
    {
        Task<List<CfgTaxSetup>> GetAllData();
        Task<ApiResponseModel> Update(CfgTaxSetup pCfgTaxSetup);
        Task<ApiResponseModel> Insert(CfgTaxSetup pCfgTaxSetup);
    }
}