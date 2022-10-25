using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using RestSharp;

namespace HCM.UI.Data.Authorization
{
    public class UserAuthorizationService : IUserAuthorization
    {

        private readonly RestClient _restClient;

        public UserAuthorizationService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<UserAuthorization>> FetchUserAuth(string userID)
        {
            try
            {
                List<UserAuthorization> oList = new List<UserAuthorization>();

                var request = new RestRequest($"Authorization/getUserAuthorization?userID={userID}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<UserAuthorization>>(request);

                if (response.IsSuccessful)
                {
                    return response.Data;
                }
                else
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        public async Task<ApiResponseModel> AddUserAuthorization(List<UserAuthorization> oUserAuthorization)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Authorization/addUserAuth", Method.Post);
                request.AddJsonBody(oUserAuthorization);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    return response;
                }
                else
                {
                    response.Id = 0;
                    response.Message = "Failed to save successfully";
                    return response;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save successfully";
                return response;
            }
        }

        public async Task<List<VMUserAuthorization>> GetAllMenu(string UserID)
        {
            try
            {
                List<VMUserAuthorization> oList = new List<VMUserAuthorization>();

                var request = new RestRequest($"Authorization/getAllUserAuthMenu?userID={UserID}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<VMUserAuthorization>>(request);

                if (response.IsSuccessful)
                {
                    return response.Data;
                }
                else
                {
                    return response.Data;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
    }
}
