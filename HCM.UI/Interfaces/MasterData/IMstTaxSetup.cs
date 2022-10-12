using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface ICfgTaxSetup
    {
        Task<List<CfgTaxSetup>> GetAllData();
        Task<ApiResponseModel> Insert(CfgTaxSetup pCfgTaxSetup);
        Task<ApiResponseModel> Update(CfgTaxSetup pCfgTaxSetup);
    }
}
