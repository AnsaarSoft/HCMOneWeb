using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.EmployeeMasterSetup
{
    public class MstEmployeeMasterDataService : IMstEmployeeMasterData
    {
        private readonly RestClient _restClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "EmployeeMaster";

        public MstEmployeeMasterDataService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
            _memoryCache = memoryCache; 
        }

        public async Task<List<MstEmployee>> GetAllData()
        {
            try
            {
                if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
                {
                    return oListCache.ToList();
                }
                else
                {
                    List<MstEmployee> oList = new List<MstEmployee>();

                    var request = new RestRequest("EmployeeMasterData/getAllEmployee", Method.Get) { RequestFormat = DataFormat.Json };

                    var response = await _restClient.ExecuteAsync<List<MstEmployee>>(request);

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

        public async Task<ApiResponseModel> Insert(MstEmployee oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addEmployee", Method.Post);
                request.AddJsonBody(oMstEmployee);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
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

        public async Task<ApiResponseModel> Update(MstEmployee oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateEmployee", Method.Post);
                request.AddJsonBody(oMstEmployee);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
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

        public async Task<ApiResponseModel> Insert(List<MstEmployee> oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addEmployeeList", Method.Post);
                request.AddJsonBody(oMstEmployee);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
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

        public async Task<ApiResponseModel> Update(List<MstEmployee> oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateEmployeeList", Method.Post);
                request.AddJsonBody(oMstEmployee);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<MstEmployee> oListCache))
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
