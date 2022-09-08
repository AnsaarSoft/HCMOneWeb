using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstContractor
    {
        Task<List<MstContractor>> GetAllData();
        Task<ApiResponseModel> Insert(MstContractor oMstContractor);
        Task<ApiResponseModel> Update(MstContractor oMstContractor);
        Task<ApiResponseModel> Insert(List<MstContractor> oMstContractor);
        Task<ApiResponseModel> Update(List<MstContractor> oMstContractor);
    }
}
