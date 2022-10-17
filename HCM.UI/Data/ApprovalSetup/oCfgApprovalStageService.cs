using HCM.UI.Interfaces.ApprovalSetup;
using HCM.API.Models;
using HCM.UI.General;
using RestSharp;

namespace HCM.UI.Data.ApprovalSetup
{
    public class oCfgApprovalStageService : ICfgApprovalStage
    {
        private readonly RestClient _restClient;
        public oCfgApprovalStageService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<CfgApprovalStage>> GetAllData()
        {
            try
            {
                List<CfgApprovalStage> oList = new List<CfgApprovalStage>();

                var request = new RestRequest("ApprovalSetup/getAllStage", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<CfgApprovalStage>>(request);

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

        public async Task<ApiResponseModel> Insert(CfgApprovalStage oCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/addStage", Method.Post);
                request.AddJsonBody(oCfgApprovalStage);
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

        public async Task<ApiResponseModel> Update(CfgApprovalStage oCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/updateStage", Method.Post);
                request.AddJsonBody(oCfgApprovalStage);
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
