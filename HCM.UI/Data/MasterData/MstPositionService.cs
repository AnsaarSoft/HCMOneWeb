using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstPositionService : IMstPosition
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "PositionMaster";

        public MstPositionService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _memoryCache = memoryCache;
        }

        public async Task<List<MstPosition>> GetAllData()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstPosition> oListCache))
                {
                    return oListCache.ToList();
                }
                else
                {                    
                    List<MstPosition> oList = new List<MstPosition>();

                    var request = new RestRequest("MasterData/getAllPos", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstPosition>>(request);

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

        public async Task<ApiResponseModel> Insert(MstPosition oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addPos", Method.Post);
                request.AddJsonBody(oMstPosition);
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
        public async Task<ApiResponseModel> Update(MstPosition oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updatePos", Method.Post);
                request.AddJsonBody(oMstPosition);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstPosition> oListCache))
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
        public async Task<ApiResponseModel> Insert(List<MstPosition> oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addPosList", Method.Post);
                request.AddJsonBody(oMstPosition);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstPosition> oListCache))
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
        public async Task<ApiResponseModel> Update(List<MstPosition> oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updatePosList", Method.Post);
                request.AddJsonBody(oMstPosition);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstPosition> oListCache))
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
