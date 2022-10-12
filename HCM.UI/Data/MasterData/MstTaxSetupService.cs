using HCM.API.General;
using HCM.UI.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;


namespace HCM.UI.Data.MasterData
{
    public class CfgTaxSetupService : ICfgTaxSetup
    {
        private readonly RestClient _restClient;

        public CfgTaxSetupService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<CfgTaxSetup>> GetAllData()
        {
            try
            {
                List<CfgTaxSetup> oList = new List<CfgTaxSetup>();

                var request = new RestRequest("MasterData/getAllTaxSetup", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<CfgTaxSetup>>(request);

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

        public async Task<ApiResponseModel> Insert(CfgTaxSetup oCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addTaxSetup", Method.Post);
                request.AddJsonBody(oCfgTaxSetup);
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

        public async Task<ApiResponseModel> Update(CfgTaxSetup oCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateTaxSetup", Method.Post);
                request.AddJsonBody(oCfgTaxSetup);
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
