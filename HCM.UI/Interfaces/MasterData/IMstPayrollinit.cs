using HCM.API.Models;
namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstPayrollinit
    {
        Task<MstPayrollBasicInitialization> GetData();
        Task<ApiResponseModel> Update(MstPayrollBasicInitialization pMstPayrollinit);
    }
}