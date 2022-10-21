using HCM.API.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;


namespace HCM.UI.Data.EmployeeMasterSetup
{
    public class TrnsSingleEntryOtrequestService : ITrnsSingleEntryOtrequest
    {
        private readonly RestClient _restClient;

        public TrnsSingleEntryOtrequestService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsSingleEntryOtrequest>> GetAllData()
        {
            try
            {
                List<TrnsSingleEntryOtrequest> oList = new List<TrnsSingleEntryOtrequest>();

                var request = new RestRequest("EmployeeMasterData/getAllMonthlyOT", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsSingleEntryOtrequest>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsSingleEntryOtrequest oTrnsSingleEntryOtrequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addMonthlyOT", Method.Post);
                request.AddJsonBody(oTrnsSingleEntryOtrequest);
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

        public async Task<ApiResponseModel> Update(TrnsSingleEntryOtrequest oTrnsSingleEntryOtrequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateMonthlyOT", Method.Post);
                request.AddJsonBody(oTrnsSingleEntryOtrequest);
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
