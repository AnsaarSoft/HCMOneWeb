using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstStationService : IMstStation
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "StationMaster";
        public MstStationService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _memoryCache = memoryCache;
        }

        public async Task<List<MstStation>> GetAllData()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstStation> oListCache))
                {
                    return oListCache.ToList();
                }
                else
                {
                    List<MstStation> oList = new List<MstStation>();

                    var request = new RestRequest("MasterData/getAllStation", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstStation>>(request);

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

        public async Task<ApiResponseModel> Insert(MstStation oMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addStation", Method.Post);
                request.AddJsonBody(oMstStation);
                var res= await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstStation> oListCache))
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

        public async Task<ApiResponseModel> Update(MstStation oMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateStation", Method.Post);
                request.AddJsonBody(oMstStation);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstStation> oListCache))
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

        public async Task<ApiResponseModel> Insert(List<MstStation> oMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addStationList", Method.Post);
                request.AddJsonBody(oMstStation);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstStation> oListCache))
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

        public async Task<ApiResponseModel> Update(List<MstStation> oMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateStationList", Method.Post);
                request.AddJsonBody(oMstStation);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstStation> oListCache))
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
