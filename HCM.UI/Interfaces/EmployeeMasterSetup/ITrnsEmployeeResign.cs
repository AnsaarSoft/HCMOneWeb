using HCM.API.Models;

namespace HCM.UI.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsEmployeeResign
    {
        Task<List<TrnsResignation>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsResignation pTrnsResignation);
        Task<ApiResponseModel> Update(TrnsResignation pTrnsResignation);
        Task<ApiResponseModel> Insert(List<TrnsResignation> pTrnsResignation);
        Task<ApiResponseModel> Update(List<TrnsResignation> pTrnsResignation);
    }
}
