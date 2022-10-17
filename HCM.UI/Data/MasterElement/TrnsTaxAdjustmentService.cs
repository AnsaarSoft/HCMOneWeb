using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using RestSharp;

namespace HCM.UI.Data.MasterElement
{
    public class TrnsTaxAdjustmentService : ITrnsTaxAdjustment
    {
        private readonly RestClient _restClient;

        public TrnsTaxAdjustmentService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<TrnsTaxAdjustment>> GetAllData()
        {
            try
            {
                List<TrnsTaxAdjustment> oList = new List<TrnsTaxAdjustment>();

                var request = new RestRequest("MasterElement/getAllTaxAdjust", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<TrnsTaxAdjustment>>(request);

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

        public async Task<ApiResponseModel> Insert(TrnsTaxAdjustment oTrnsTaxAdjustment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterElement/addTaxAdjust", Method.Post);
                request.AddJsonBody(oTrnsTaxAdjustment);
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

        public async Task<ApiResponseModel> Update(TrnsTaxAdjustment oTrnsTaxAdjustment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                var request = new RestRequest("MasterElement/updateTaxAdjust", Method.Post);
                request.AddJsonBody(oTrnsTaxAdjustment);
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
