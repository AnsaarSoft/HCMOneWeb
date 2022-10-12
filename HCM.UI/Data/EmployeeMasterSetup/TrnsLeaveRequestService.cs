using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.EmployeeMasterSetup
{
    public class TrnsLeaveRequestService : ITrnsLeaveRequest
    {
        private readonly RestClient _restClient;

        public TrnsLeaveRequestService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsLeavesRequest>> GetAllData()
        {
            try
            {
                List<TrnsLeavesRequest> oList = new List<TrnsLeavesRequest>();

                var request = new RestRequest("EmployeeMasterData/getAllLeavesRequest", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsLeavesRequest>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsLeavesRequest oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addLeavesRequest", Method.Post);
                request.AddJsonBody(oTrnsLeavesRequest);
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

        public async Task<ApiResponseModel> Update(TrnsLeavesRequest oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateLeavesRequest", Method.Post);
                request.AddJsonBody(oTrnsLeavesRequest);
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

        public async Task<ApiResponseModel> Insert(List<TrnsLeavesRequest> oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addLeavesRequestList", Method.Post);
                request.AddJsonBody(oTrnsLeavesRequest);
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

        public async Task<ApiResponseModel> Update(List<TrnsLeavesRequest> oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateLeavesRequestList", Method.Post);
                request.AddJsonBody(oTrnsLeavesRequest);
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
