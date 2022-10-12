using HCM.API.General;
using HCM.UI.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Microsoft.Extensions.Caching.Memory;

namespace HCM.UI.Data.MasterData
{
    public class MstGratuityService: IMstGratuity
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "GratuityMaster";

        public MstGratuityService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _memoryCache = memoryCache;
        }

        public async Task<List<MstGratuity>> GetAllData()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstGratuity> oListCache))
                {
                    return oListCache.ToList();
                }
                else
                {
                    List<MstGratuity> oList = new List<MstGratuity>();

                    var request = new RestRequest("MasterData/getAllGratuity", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstGratuity>>(request);

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

        public async Task<ApiResponseModel> Insert(MstGratuity oMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addGratuity", Method.Post);
                request.AddJsonBody(oMstGratuity);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstGratuity> oListCache))
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

        public async Task<ApiResponseModel> Update(MstGratuity oMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateGratuity", Method.Post);
                request.AddJsonBody(oMstGratuity);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstGratuity> oListCache))
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
