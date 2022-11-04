using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstGldeterminationService : IMstGldetermination
    {
        private readonly RestClient _restClient;
        public MstGldeterminationService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstGldetermination>> GetAllData()
        {
            try
            {
                    List<MstGldetermination> oList = new List<MstGldetermination>();

                    var request = new RestRequest("MasterData/getAllGLD", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstGldetermination>>(request);

                    if (response.IsSuccessful)
                    {
                        return response.Data;
                    }
                    else
                    {
                        return response.Data;
                    }
                //}
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        public async Task<ApiResponseModel> Insert(MstGldetermination oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addGLD", Method.Post);
                request.AddJsonBody(oMstGldetermination);
                var res= await _restClient.ExecuteAsync(request);
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

        public async Task<ApiResponseModel> Update(MstGldetermination oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateGLD", Method.Post);
                request.AddJsonBody(oMstGldetermination);
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
                response.Message = "Failed to Update successfully";
                return response;
            }
        }

        public async Task<ApiResponseModel> Insert(List<MstGldetermination> oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addGLDList", Method.Post);
                request.AddJsonBody(oMstGldetermination);
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

        public async Task<ApiResponseModel> Update(List<MstGldetermination> oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateGLDList", Method.Post);
                request.AddJsonBody(oMstGldetermination);
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
                response.Message = "Failed to Update successfully";
                return response;
            }
        }
    }
}
