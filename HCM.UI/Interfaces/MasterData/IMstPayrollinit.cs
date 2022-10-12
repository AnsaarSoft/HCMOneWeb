using HCM.API.Models;
namespace HCM.UI.Interfaces.MasterData
{
    public interface ICfgPayrollDefinationinit
    {
        Task<CfgPayrollBasicInitialization> GetData();
        Task<ApiResponseModel> Update(CfgPayrollBasicInitialization pCfgPayrollDefinationinit);
    }
}