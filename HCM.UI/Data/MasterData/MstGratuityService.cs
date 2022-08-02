using HCM.API.General;
using HCM.API.Interfaces.MasterData;
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

        public async Task<List<IMstGratuity>> GetAllData()
        {
            try
            {
                List<IMstGratuity> oList = new List<IMstGratuity>();

                var request = new RestRequest("MasterData/getAllGratuity", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<IMstGratuity>>(request);

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

        public async Task<ApiResponseModel> Insert(IMstGratuity oMstGratuity)
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

        public Task<ApiResponseModel> Insert(MstGratuity pMstGratuity)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseModel> Update(IMstGratuity oMstGratuity)
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

        public Task<ApiResponseModel> Update(MstGratuity pMstGratuity)
        {
            throw new NotImplementedException();
        }

        Task<List<MstGratuity>> IMstGratuity.GetAllData()
        {
            throw new NotImplementedException();
        }
    }
}
