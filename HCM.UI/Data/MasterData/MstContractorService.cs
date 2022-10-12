using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstContractorService : IMstContractor
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "ContractorMaster";

        public MstContractorService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _memoryCache = memoryCache;
        }

        public async Task<List<MstContractor>> GetAllData()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstContractor> oListCache))
                {
                    return oListCache.ToList();
                }
                else
                {
                    List<MstContractor> oList = new List<MstContractor>();

                    var request = new RestRequest("MasterData/getAllContractor", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstContractor>>(request);

                    if (response.IsSuccessful)
                    {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                           .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                           .SetAbsoluteExpiration(TimeSpan.FromHours(2))
                           .SetPriority(CacheItemPriority.Normal)
                           .SetSize(1024);
                        _memoryCache.Set(CacheKey, response.Data, cacheEntryOptions);
                        return response.Data;
                    }
                    else
                    {
                        return response.Data;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }

        public async Task<ApiResponseModel> Insert(MstContractor oMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addContractor", Method.Post);
                request.AddJsonBody(oMstContractor);
                var res= await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstContractor> oListCache))
                    {
                        _memoryCache.Remove(CacheKey);
                    }
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

        public async Task<ApiResponseModel> Update(MstContractor oMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateContractor", Method.Post);
                request.AddJsonBody(oMstContractor);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstContractor> oListCache))
                    {
                        _memoryCache.Remove(CacheKey);
                    }
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

        public async Task<ApiResponseModel> Insert(List<MstContractor> oMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addContractorList", Method.Post);
                request.AddJsonBody(oMstContractor);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstContractor> oListCache))
                    {
                        _memoryCache.Remove(CacheKey);
                    }
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

        public async Task<ApiResponseModel> Update(List<MstContractor> oMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateContractorList", Method.Post);
                request.AddJsonBody(oMstContractor);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstContractor> oListCache))
                    {
                        _memoryCache.Remove(CacheKey);
                    }
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
