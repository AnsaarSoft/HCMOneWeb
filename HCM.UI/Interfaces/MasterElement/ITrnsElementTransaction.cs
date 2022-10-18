using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterElement
{
    public interface ITrnsElementTransaction
    {
        Task<List<TrnsEmployeeElement>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeElement oTrnsEmployeeElement);
        Task<ApiResponseModel> Update(TrnsEmployeeElement oTrnsEmployeeElement);
        Task<ApiResponseModel> Insert(List<TrnsEmployeeElement> oTrnsEmployeeElement);
        Task<ApiResponseModel> Update(List<TrnsEmployeeElement> oTrnsEmployeeElement);
    }
}
