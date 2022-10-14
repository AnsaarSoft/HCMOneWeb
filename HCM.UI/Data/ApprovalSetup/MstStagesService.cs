using HCM.UI.Interfaces.ApprovalSetup;
using HCM.API.Models;
using HCM.UI.General;
using RestSharp;

namespace HCM.UI.Data.ApprovalSetup
{
    public class MstStagesService : IMstStages
    {
        private readonly RestClient _restClient;
        public MstStagesService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstStage>> GetAllData()
        {
            try
            {
                List<MstStage> oList = new List<MstStage>();

                var request = new RestRequest("ApprovalSetup/getAllStage", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstStage>>(request);

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

        public async Task<ApiResponseModel> Insert(MstStage oMstStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/addStage", Method.Post);
                request.AddJsonBody(oMstStage);
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

        public async Task<ApiResponseModel> Update(MstStage oMstStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ApprovalSetup/updateStage", Method.Post);
                request.AddJsonBody(oMstStage);
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
