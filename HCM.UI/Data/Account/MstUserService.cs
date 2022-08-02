using Blazored.LocalStorage;
using CA.UI.Authentication;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using Microsoft.AspNetCore.Components.Authorization;
using RestSharp;

namespace HCM.UI.Data.Account
{
    public class MstUserService : IMstUser
    {
        private readonly RestClient _restClient;
        private readonly AuthenticationStateProvider _oAuth;
        private ILocalStorageService _oLocalStorage;

        public MstUserService(ILocalStorageService oLocalStorage, AuthenticationStateProvider oAuth)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _oLocalStorage = oLocalStorage;
            _oAuth = oAuth;
        }

        public async Task<List<MstUser>> GetAllData()
        {
            try
            {
                List<MstUser> oList = new List<MstUser>();

                var request = new RestRequest("Account/getAllUser", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstUser>>(request);

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

        public async Task<MstUser> Login(MstUser oMstUser)
        {
            try
            {
                var request = new RestRequest("Account/validateLogin", Method.Get) { RequestFormat = DataFormat.Json };
                request.AddBody(oMstUser);
                var response = await _restClient.ExecuteAsync<MstUser>(request);

                if (response.IsSuccessful)
                {
                    if (response.Data.Id != 0)
                    {
                        await _oLocalStorage.SetItemAsync("User", response.Data);
                        ((AuthStateProvider)_oAuth).NotifyUserAuthentication(response.Data.UserName);
                        return response.Data;
                    }
                    else
                    {
                        return response.Data;
                    }
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

        public async Task<ApiResponseModel> GenerateOTP(MstUser oMstUser)
        {
            try
            {
                var request = new RestRequest("Account/generateOTP", Method.Get) { RequestFormat = DataFormat.Json };
                request.AddBody(oMstUser);
                var response = await _restClient.ExecuteAsync<ApiResponseModel>(request);

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

        public async Task<ApiResponseModel> AuthenticateOTP(PasswordReset oPasswordReset)
        {
            try
            {
                var request = new RestRequest("Account/authenticateOTP", Method.Get) { RequestFormat = DataFormat.Json };
                request.AddBody(oPasswordReset);
                var response = await _restClient.ExecuteAsync<ApiResponseModel>(request);

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

        public async Task<ApiResponseModel> ChangePassword(MstUser oMstUser)
        {
            try
            {
                var request = new RestRequest("Account/changePassword", Method.Get) { RequestFormat = DataFormat.Json };
                request.AddBody(oMstUser);
                var response = await _restClient.ExecuteAsync<ApiResponseModel>(request);

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

        public async Task<bool> Logout()
        {
            try
            {
                await _oLocalStorage.RemoveItemAsync("User");
                ((AuthStateProvider)_oAuth).NotifyUserLogout();
                return true;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return false;
            }
        }

        public async Task<ApiResponseModel> Insert(MstUser oMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Account/addUser", Method.Post);
                request.AddJsonBody(oMstUser);
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

        public async Task<ApiResponseModel> Update(MstUser oMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Account/updateUser", Method.Post);
                request.AddJsonBody(oMstUser);
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
    }
}
