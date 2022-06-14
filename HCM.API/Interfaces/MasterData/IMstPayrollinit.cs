using HCM.API.Models;
namespace HCM.API.Interfaces.MasterData
{
    public interface IMstPayrollinit
    {
        Task<MstPayrollBasicInitialization> GetData();
        Task<ApiResponseModel> Update(MstPayrollBasicInitialization pMstPayrollinit);
    }
}