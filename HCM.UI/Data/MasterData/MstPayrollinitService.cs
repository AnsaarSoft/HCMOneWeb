using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstPayrollinitService : IMstPayrollinit
    {
        private readonly RestClient _restClient;

        public MstPayrollinitService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<MstPayrollBasicInitialization> GetData()
        {
            try
            {
                MstPayrollBasicInitialization mstPayrollinit = new MstPayrollBasicInitialization();

                var request = new RestRequest("MasterData/getPayrollinit", Method.Get) { RequestFormat = DataFormat.Json };
                var response = await _restClient.ExecuteAsync<MstPayrollBasicInitialization>(request);

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

        public async Task<ApiResponseModel> Update(MstPayrollBasicInitialization oMstPayrollinit)
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                var request = new RestRequest("MasterData/updatePayrollinit", Method.Post);
                request.AddJsonBody(oMstPayrollinit);
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
