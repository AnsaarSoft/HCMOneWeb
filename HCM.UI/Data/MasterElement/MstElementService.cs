using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using RestSharp;

namespace HCM.UI.Data.MasterElement
{
    public class MstElementService : IMstElement
    {
        private readonly RestClient _restClient;

        public MstElementService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstElement>> GetAllData()
        {
            try
            {
                List<MstElement> oList = new List<MstElement>();

                var request = new RestRequest("MasterElement/getAllElement", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstElement>>(request);

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

        public async Task<ApiResponseModel> Insert(MstElement oMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterElement/addElement", Method.Post);
                request.AddJsonBody(oMstElement);
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

        public async Task<ApiResponseModel> Update(MstElement oMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterElement/updateElement", Method.Post);
                request.AddJsonBody(oMstElement);
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
