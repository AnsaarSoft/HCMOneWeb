using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstPayroll
    {
        Task<List<MstPayroll>> GetAllData();
        Task<ApiResponseModel> Insert(MstPayroll pMstPayroll);
        Task<ApiResponseModel> Update(MstPayroll pMstPayroll);
    }
}
