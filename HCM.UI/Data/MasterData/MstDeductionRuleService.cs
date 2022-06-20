using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using RestSharp;

namespace HCM.UI.Data.MasterData
{

    public class MstDeductionRuleService : IMstDeductionRule
    {
        private readonly RestClient _restClient;

        public MstDeductionRuleService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstDeductionRule>> GetAllData()
        {
            try
            {
                List<MstDeductionRule> oList = new List<MstDeductionRule>();

                var request = new RestRequest("MasterData/getAllDeductionRule", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstDeductionRule>>(request);

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

        public async Task<ApiResponseModel> Update(MstDeductionRule oMstDeductionRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updateDeductionRule", Method.Post);
                request.AddJsonBody(oMstDeductionRule);
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
