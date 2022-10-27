using HCM.API.Models;

namespace HCM.UI.Interfaces.Authorization
{
    public interface IUserDataAccess
    {
        Task<List<UserDataAccess>> GetAllData();
        Task<ApiResponseModel> Insert(List<UserDataAccess> oUserDataAccess);
        Task<ApiResponseModel> Update(List<UserDataAccess> oUserDataAccess);
    }
}
