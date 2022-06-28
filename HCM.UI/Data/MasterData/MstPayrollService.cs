using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstPayrollService : IMstPayroll
    {
        private readonly RestClient _restClient;

        public MstPayrollService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }
        public async Task<List<MstPayroll>> GetAllData()
        {
            try
            {
                List<MstPayroll> oList = new List<MstPayroll>();

                var request = new RestRequest("MasterData/getAllPayrollSetup", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstPayroll>>(request);

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
        public async Task<ApiResponseModel> Insert(MstPayroll oMstPayroll)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/addPayrollSetup", Method.Post);
                request.AddJsonBody(oMstPayroll);
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
        public async Task<ApiResponseModel> Update(MstPayroll oMstPayroll)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterData/updatePayrollSetup", Method.Post);
                request.AddJsonBody(oMstPayroll);
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
