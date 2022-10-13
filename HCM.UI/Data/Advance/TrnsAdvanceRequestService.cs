using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Advance;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.Advance
{
    public class TrnsAdvanceRequestService : ITrnsAdvanceRequest
    {
        private readonly RestClient _restClient;

        public TrnsAdvanceRequestService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsAdvanceRequest>> GetAllData()
        {
            try
            {
                List<TrnsAdvanceRequest> oList = new List<TrnsAdvanceRequest>();

                var request = new RestRequest("Advance/getAllAdvanceRequest", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsAdvanceRequest>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsAdvanceRequest oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Advance/addAdvanceRequest", Method.Post);
                request.AddJsonBody(oTrnsAdvanceRequest);
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

        public async Task<ApiResponseModel> Update(TrnsAdvanceRequest oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Advance/updateAdvanceRequest", Method.Post);
                request.AddJsonBody(oTrnsAdvanceRequest);
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

        public async Task<ApiResponseModel> Insert(List<TrnsAdvanceRequest> oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Advance/addAdvanceRequestList", Method.Post);
                request.AddJsonBody(oTrnsAdvanceRequest);
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

        public async Task<ApiResponseModel> Update(List<TrnsAdvanceRequest> oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Advance/updateAdvanceRequestList", Method.Post);
                request.AddJsonBody(oTrnsAdvanceRequest);
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
