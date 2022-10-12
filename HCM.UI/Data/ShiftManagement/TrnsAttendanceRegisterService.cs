using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.ShiftManagement;
using RestSharp;

namespace HCM.UI.Data.ShiftManagement
{
    public class TrnsAttendanceRegisterService : ITrnsAttendanceRegister
    {
        private readonly RestClient _restClient;

        public TrnsAttendanceRegisterService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsAttendanceRegister>> GetAllData()
        {
            try
            {
                List<TrnsAttendanceRegister> oList = new List<TrnsAttendanceRegister>();

                var request = new RestRequest("ShiftManagement/getAllTrnsAttendanceRegister", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsAttendanceRegister>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsAttendanceRegister oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ShiftManagement/addTrnsAttendanceRegister", Method.Post);
                request.AddJsonBody(oTrnsAttendanceRegister);
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

        public async Task<ApiResponseModel> Update(TrnsAttendanceRegister oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ShiftManagement/updateTrnsAttendanceRegister", Method.Post);
                request.AddJsonBody(oTrnsAttendanceRegister);
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

        public async Task<ApiResponseModel> Insert(List<TrnsAttendanceRegister> oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ShiftManagement/addTrnsAttendanceRegisterList", Method.Post);
                request.AddJsonBody(oTrnsAttendanceRegister);
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

        public async Task<ApiResponseModel> Update(List<TrnsAttendanceRegister> oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ShiftManagement/updateTrnsAttendanceRegisterList", Method.Post);
                request.AddJsonBody(oTrnsAttendanceRegister);
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
