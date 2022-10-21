using HCM.API.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using RestSharp;


namespace HCM.UI.Data.EmployeeMasterSetup
{
    public class TrnsEmployeeTransferService : ITrnsEmployeeTransfer
    {
        private readonly RestClient _restClient;

        public TrnsEmployeeTransferService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsEmployeeTransfer>> GetAllData()
        {
            try
            {
                List<TrnsEmployeeTransfer> oList = new List<TrnsEmployeeTransfer>();

                var request = new RestRequest("EmployeeMasterData/getAllEmptrns", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsEmployeeTransfer>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/addEmptrns", Method.Post);
                request.AddJsonBody(oTrnsEmployeeTransfer);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Saved successfully";
                    return response;
                }
                else
                {
                    if (res.Content == "\"Cant update document, pending for approval\"")
                    {
                        response.Id = 2;
                        response.Message = "Cant update document, pending for approval";
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "Failed to Update successfully";
                    }
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

        public async Task<ApiResponseModel> Update(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("EmployeeMasterData/updateEmptrns", Method.Post);
                request.AddJsonBody(oTrnsEmployeeTransfer);
                var res = await _restClient.ExecuteAsync(request);
                if (res.IsSuccessful)
                {
                    response.Id = 1;
                    response.Message = "Update successfully";
                    return response;
                }
                else
                {
                    if (res.Content == "\"Cant update document, pending for approval\"")
                    {
                        response.Id = 2;
                        response.Message = "Cant update document, pending for approval";
                    }
                    else
                    {
                        response.Id = 0;
                        response.Message = "Failed to Update successfully";
                    }
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
