using HCM.API.Models;
namespace HCM.API.Interfaces.MasterData
{
    public interface ICfgPayrollDefinationinit
    {
        Task<CfgPayrollBasicInitialization> GetData();
        Task<ApiResponseModel> Update(CfgPayrollBasicInitialization pCfgPayrollDefinationinit);
    }
}