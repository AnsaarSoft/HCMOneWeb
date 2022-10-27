using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.Authorization
{
    public class UserDataAccessService : IUserDataAccess
    {
        private readonly RestClient _restClient;

        public UserDataAccessService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<UserDataAccess>> GetAllData()
        {
            try
            {
                List<UserDataAccess> oList = new List<UserDataAccess>();

                var request = new RestRequest("Authorization/getAllUserDataAccess", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<UserDataAccess>>(request);

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

        public async Task<ApiResponseModel> Insert(List<UserDataAccess> oUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Authorization/addUserDataAccess", Method.Post);
                request.AddJsonBody(oUserDataAccess);
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

        public async Task<ApiResponseModel> Update(List<UserDataAccess> oUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Authorization/updateUserDataAccess", Method.Post);
                request.AddJsonBody(oUserDataAccess);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    return response;
                }
                else
                {
                    response.Id = 0;
                    response.Message = "Failed to Update successfully";
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
    }
}
