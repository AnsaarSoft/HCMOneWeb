using HCM.UI.Interfaces.Batch;
using HCM.API.Models;
using HCM.UI.General;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.Batch
{
    public class TrnsBatchProcessService : ITrnsBatchProcess
    {
        private readonly RestClient _restClient;

        public TrnsBatchProcessService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsBatch>> GetAllData()
        {
            try
            {
                List<TrnsBatch> oList = new List<TrnsBatch>();

                var request = new RestRequest("BatchProcess/getAllBatch", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsBatch>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsBatch oTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BatchProcess/addBatch", Method.Post);
                request.AddJsonBody(oTrnsBatch);
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

        public async Task<ApiResponseModel> Update(TrnsBatch oTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BatchProcess/updateBatch", Method.Post);
                request.AddJsonBody(oTrnsBatch);
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

        public async Task<ApiResponseModel> Insert(List<TrnsBatch> oTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BatchProcess/addBatchList", Method.Post);
                request.AddJsonBody(oTrnsBatch);
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

        public async Task<ApiResponseModel> Update(List<TrnsBatch> oTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BatchProcess/updateBatchList", Method.Post);
                request.AddJsonBody(oTrnsBatch);
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
