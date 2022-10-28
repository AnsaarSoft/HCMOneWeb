using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface ICfgPayrollDefination
    {
        Task<List<CfgPayrollDefination>> GetAllData();
        Task<List<CfgPayrollDefination>> GetAllData(string EmpID);
        Task<ApiResponseModel> Insert(CfgPayrollDefination pCfgPayrollDefination);
        Task<ApiResponseModel> Update(CfgPayrollDefination pCfgPayrollDefination);
    }
}
