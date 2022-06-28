using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstPayroll
    {
        Task<List<MstPayroll>> GetAllData();
        Task<ApiResponseModel> Insert(MstPayroll pMstAdvance);
        Task<ApiResponseModel> Update(MstPayroll pMstAdvance);
    }
}
