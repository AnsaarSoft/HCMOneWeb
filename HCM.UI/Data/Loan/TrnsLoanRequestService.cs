using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Loan;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.Loan
{
    public class TrnsLoanRequestService : ITrnsLoanRequest
    {
        private readonly RestClient _restClient;

        public TrnsLoanRequestService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsLoanRequest>> GetAllData()
        {
            try
            {
                List<TrnsLoanRequest> oList = new List<TrnsLoanRequest>();

                var request = new RestRequest("Loan/getAllLoanRequest", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsLoanRequest>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsLoanRequest oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Loan/addLoanRequest", Method.Post);
                request.AddJsonBody(oTrnsLoanRequest);
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

        public async Task<ApiResponseModel> Update(TrnsLoanRequest oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Loan/updateLoanRequest", Method.Post);
                request.AddJsonBody(oTrnsLoanRequest);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    return response;
                }
                else
                {
                    if (res.Content == "\"Cant update document, pending for approval\"")
                    {
                        response.Id = 2;
                        response.Message = "Cant update document, pending for approval";
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "Failed to Update successfully";
                    }
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

        public async Task<ApiResponseModel> Insert(List<TrnsLoanRequest> oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Loan/addLoanRequestList", Method.Post);
                request.AddJsonBody(oTrnsLoanRequest);
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

        public async Task<ApiResponseModel> Update(List<TrnsLoanRequest> oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Loan/updateLoanRequestList", Method.Post);
                request.AddJsonBody(oTrnsLoanRequest);
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
