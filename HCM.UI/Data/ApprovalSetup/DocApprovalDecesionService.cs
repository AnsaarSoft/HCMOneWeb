using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ApprovalSetup;
using RestSharp;

namespace HCM.UI.Data.ApprovalSetup
{
    public class DocApprovalDecesionService : IDocApprovalDecesion
    {
        private readonly RestClient _restClient;

        public DocApprovalDecesionService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<DocApprovalDecesion>> GetAllData(string EmpID, string DocStatus)
        {
            try
            {
                List<DocApprovalDecesion> oList = new List<DocApprovalDecesion>();

                var request = new RestRequest($"ApprovalSetup/getAllDocApprovalDecesion?EmpID={EmpID}&DocStatus={DocStatus}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<DocApprovalDecesion>>(request);

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

        public async Task<ApiResponseModel> UpdateDocApproval(DocApprovalDecesion oDocApproval)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/updateDocApprovalStatus", Method.Post);
                request.AddJsonBody(oDocApproval);
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
