using HCM.API.General;
using HCM.UI.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstGratuityService: IMstGratuity
    {
        private readonly RestClient _restClient;

        public MstGratuityService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstGratuity>> GetAllData()
        {
            try
            {
                List<MstGratuity> oList = new List<MstGratuity>();

                var request = new RestRequest("MasterData/getAllGratuity", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstGratuity>>(request);

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
    }
}
