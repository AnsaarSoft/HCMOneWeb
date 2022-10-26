using HCM.API.Models;

namespace HCM.API.Interfaces.Authorization
{
    public interface IUserAuthorization
    {
        Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization);
        Task<List<VMUserAuthorization>> GetAllAuthorizationMenu(string UserID);
    }
}
