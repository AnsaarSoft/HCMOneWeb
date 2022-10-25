using HCM.API.Models;

namespace HCM.API.Interfaces.Authorization
{
    public interface IUserAuthorization
    {
        Task<List<UserAuthorization>> FetchUserAuth(string userID);
        Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization);
        Task<List<VMUserAuthorization>> GetAllMenu(string UserID);
    }
}
