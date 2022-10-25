using HCM.API.Models;

namespace HCM.UI.Interfaces.Authorization
{
    public interface IUserAuthorization
    {
        Task<List<UserAuthorization>> FetchUserAuth(string userID);
        Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization);
        Task<List<VMUserAuthorization>> GetAllMenu(string userID);
    }
}
