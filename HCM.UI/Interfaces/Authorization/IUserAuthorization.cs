using HCM.API.Models;

namespace HCM.UI.Interfaces.Authorization
{
    public interface IUserAuthorization
    {
        Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization);
        Task<List<VMUserAuthorization>> GetAllAuthorizationMenu(string userID);
    }
}
