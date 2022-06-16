using HCM.API.Models;

namespace HCM.API.Interfaces.MasterElement
{
    public interface IMstOverTime
    {
        Task<List<MstOverTime>> GetAllData();
        Task<ApiResponseModel> Insert(MstOverTime pMstOverTime);
        Task<ApiResponseModel> Update(MstOverTime pMstOverTime);
    }
}