using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Bonus;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace HCM.UI.Data.Bonus
{
    public class TrnsEmployeeBonusService : ITrnsEmployeeBonus
    {
        private readonly RestClient _restClient;

        public TrnsEmployeeBonusService(IMemoryCache memoryCache)
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsEmployeeBonu>> GetAllData()
        {
            try
            {
                List<TrnsEmployeeBonu> oList = new List<TrnsEmployeeBonu>();

                var request = new RestRequest("BonusCal/getAllEmployeeBonus", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsEmployeeBonu>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsEmployeeBonu oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BonusCal/addEmployeeBonus", Method.Post);
                request.AddJsonBody(oTrnsEmployeeBonu);
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

        public async Task<ApiResponseModel> Update(TrnsEmployeeBonu oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BonusCal/updateEmployeeBonus", Method.Post);
                request.AddJsonBody(oTrnsEmployeeBonu);
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

        public async Task<ApiResponseModel> Insert(List<TrnsEmployeeBonu> oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BonusCal/addEmployeeBonusList", Method.Post);
                request.AddJsonBody(oTrnsEmployeeBonu);
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

        public async Task<ApiResponseModel> Update(List<TrnsEmployeeBonu> oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("BonusCal/updateEmployeeBonusList", Method.Post);
                request.AddJsonBody(oTrnsEmployeeBonu);
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
