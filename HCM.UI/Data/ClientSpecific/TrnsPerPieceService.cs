using HCM.API.General;
using HCM.API.Models;
using HCM.UI.Interfaces.ClientSpecific;
using RestSharp;

namespace HCM.UI.Data.ClientSpecific
{
    public class TrnsPerPieceService : ITrnsPerPiece
    {
        private readonly RestClient _restClient;
        public TrnsPerPieceService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }
        public async Task<List<TrnsPerPieceTransaction>> GetAllData()
        {
            try
            {
                List<TrnsPerPieceTransaction> oList = new List<TrnsPerPieceTransaction>();

                var request = new RestRequest("ClientSpecific/getAllPerPiece", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsPerPieceTransaction>>(request);

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
        public async Task<ApiResponseModel> Insert(TrnsPerPieceTransaction oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/addPerPiece", Method.Post);
                request.AddJsonBody(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Update(TrnsPerPieceTransaction oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/updatePerPiece", Method.Post);
                request.AddJsonBody(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Insert(List<TrnsPerPieceTransaction> oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/addPerPieceList", Method.Post);
                request.AddJsonBody(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Update(List<TrnsPerPieceTransaction> oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("ClientSpecific/updatePerPieceList", Method.Post);
                request.AddJsonBody(oTrnsPerPieceTransaction);
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
