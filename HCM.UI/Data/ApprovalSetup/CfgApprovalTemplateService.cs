using HCM.API.Models;
using RestSharp;
using HCM.UI.Interfaces.ApprovalSetup;
using HCM.UI.General;

namespace HCM.UI.Data.ApprovalSetup
{
    public class CfgApprovalTemplateService : ICfgApprovalTemplate
    {
        private readonly RestClient _restClient;
        
        public CfgApprovalTemplateService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<CfgApprovalTemplate>> GetAllData()
        {
            try
            {
                List<CfgApprovalTemplate> oList = new List<CfgApprovalTemplate>();

                var request = new RestRequest("ApprovalSetup/getAllApprovalTemplate", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<CfgApprovalTemplate>>(request);

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

        public async Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/addApprovalTemplate", Method.Post);
                request.AddJsonBody(oCfgApprovalTemplate);
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

        public async Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/updateApprovalTemplate", Method.Post);
                request.AddJsonBody(oCfgApprovalTemplate);
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

        public async Task<List<MstForm>> GetApprovalDocs()
        {
            try
            {
                List<MstForm> oList = new List<MstForm>();

                var request = new RestRequest("ApprovalSetup/GetApprovalForm", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstForm>>(request);

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
    }
}
