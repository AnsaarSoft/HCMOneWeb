using HCM.API.Models;

namespace HCM.API.Interfaces.Reports
{
    public interface IMstReport
    {
        Task<List<MstReport>> GetAllData();
        Task<ApiResponseModel> Insert(MstReport pMstReport);
        Task<ApiResponseModel> Update(MstReport pMstReport);
        Task<ApiResponseModel> Insert(List<MstReport> pMstReport);
        Task<ApiResponseModel> Update(List<MstReport> pMstReport);
    }
}
