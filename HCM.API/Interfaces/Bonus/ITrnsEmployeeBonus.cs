using HCM.API.Models;

namespace HCM.API.Interfaces.Bonus
{
    public interface ITrnsEmployeeBonus
    {
        Task<List<TrnsEmployeeBonu>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsEmployeeBonu oTrnsEmployeeBonu);
        Task<ApiResponseModel> Update(TrnsEmployeeBonu oTrnsEmployeeBonu);
        Task<ApiResponseModel> Insert(List<TrnsEmployeeBonu> oTrnsEmployeeBonu);
        Task<ApiResponseModel> Update(List<TrnsEmployeeBonu> oTrnsEmployeeBonu);
    }
}
