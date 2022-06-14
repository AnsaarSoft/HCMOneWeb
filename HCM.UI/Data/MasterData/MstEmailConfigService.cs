using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstEmailConfigService : IMstEmailConfig
    {
        private readonly RestClient _restClient;

        public MstEmailConfigService() 
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<MstEmailConfig> GetData()
        {
            try
            {
                MstEmailConfig mstEmailConfig = new MstEmailConfig();

                var request = new RestRequest("MasterData/getEmailConfig", Method.Get) { RequestFormat = DataFormat.Json };
                var response = await _restClient.ExecuteAsync<MstEmailConfig>(request);

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

        public async Task<ApiResponseModel> Update(MstEmailConfig oMstEmailConfig)
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                var request = new RestRequest("MasterData/updateEmailConfig", Method.Post);
                request.AddJsonBody(oMstEmailConfig);
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
