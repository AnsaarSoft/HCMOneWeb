using HCM.API.General;
using HCM.API.Models;
using HCM.UI.Interfaces.ClientSpecific;
using RestSharp;

namespace HCM.UI.Data.ClientSpecific
{
    public class MstTargetService : IMstTarget
    {
        private readonly RestClient _restClient;
        public MstTargetService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }
        public async Task<List<MstTarget>> GetAllData()
        {
            try
            {
                List<MstTarget> oList = new List<MstTarget>();

                var request = new RestRequest("ClientSpecific/getAllMstTarget", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstTarget>>(request);

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
        public async Task<ApiResponseModel> Insert(MstTarget oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/addMstTarget", Method.Post);
                request.AddJsonBody(oMstTarget);
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
        public async Task<ApiResponseModel> Update(MstTarget oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/updateMstTarget", Method.Post);
                request.AddJsonBody(oMstTarget);
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
        public async Task<ApiResponseModel> Insert(List<MstTarget> oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/addMstTargetList", Method.Post);
                request.AddJsonBody(oMstTarget);
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
        public async Task<ApiResponseModel> Update(List<MstTarget> oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/updateMstTargetList", Method.Post);
                request.AddJsonBody(oMstTarget);
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
