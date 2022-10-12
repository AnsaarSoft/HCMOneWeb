using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Attendance;
using RestSharp;

namespace HCM.UI.Data.Attendance
{
    public class TrnsTempAttendanceService : ITrnsTempAttendance
    {
        private readonly RestClient _restClient;

        public TrnsTempAttendanceService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsTempAttendance>> GetAllData()
        {
            try
            {
                List<TrnsTempAttendance> oList = new List<TrnsTempAttendance>();

                var request = new RestRequest("Attendance/getAllTempAttendance", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsTempAttendance>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsTempAttendance oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Attendance/addTempAttendance", Method.Post);
                request.AddJsonBody(oTrnsTempAttendance);
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

        public async Task<ApiResponseModel> Update(TrnsTempAttendance oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Attendance/updateTempAttendance", Method.Post);
                request.AddJsonBody(oTrnsTempAttendance);
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

        public async Task<ApiResponseModel> Insert(List<TrnsTempAttendance> oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Attendance/addTempAttendanceList", Method.Post);
                request.AddJsonBody(oTrnsTempAttendance);
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

        public async Task<ApiResponseModel> Update(List<TrnsTempAttendance> oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("Attendance/updateTempAttendanceList", Method.Post);
                request.AddJsonBody(oTrnsTempAttendance);
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
