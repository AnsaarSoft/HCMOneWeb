using HCM.API.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using HCM.API.HCMModels;


namespace HCM.UI.Data.EmployeeMasterSetup
{
    public class TrnsReHireEmployeeService : ITrnsReHireEmployee
    {
        private readonly RestClient _restClient;

        public TrnsReHireEmployeeService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsEmployeeReHire>> GetAllData()
        {
            try
            {
                List<TrnsEmployeeReHire> oList = new List<TrnsEmployeeReHire>();

                var request = new RestRequest("EmployeeMasterData/getAllEmpReHire", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsEmployeeReHire>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsEmployeeReHire oTrnsEmployeeReHire)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addEmpReHire", Method.Post);
                request.AddJsonBody(oTrnsEmployeeReHire);
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

        public async Task<ApiResponseModel> Update(TrnsEmployeeReHire oTrnsEmployeeReHire)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateEmpReHire", Method.Post);
                request.AddJsonBody(oTrnsEmployeeReHire);
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
