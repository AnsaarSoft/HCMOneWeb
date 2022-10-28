using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.SAPData;
using RestSharp;

namespace HCM.UI.Data.SAPData
{
    public class SAPDataService : ISAPData
    {
        private readonly RestClient _restClient;

        public SAPDataService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<SAPModels>> GetExchangeRateFromSAP(string DocDate)
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getExchangeRateFromSAP?DocDate={DocDate}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetBomItemsFromSAP(string ProductCode)
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getBOMItemDetailFromSAP?ProductCode={ProductCode}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetCurrencyFromSAP()
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest("SAPData/getCurrencyFromSAP", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetProductFromSap()
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>(); 

                var request = new RestRequest("SAPData/getBOMProductFromSAP", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetCustomerFromSAP()
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest("SAPData/getCustomerFromSAP", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetItemsFromSAP(string clause)
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getItemsFromSAP?clause={clause}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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
        public async Task<List<SAPModels>> GetAllItemsFromSAP()
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getAllItemsFromSAP", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetItemsVOHFromSAP(string clause, string year, string month)
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getItemsFromVOHSAP?clause={clause}&year={year}&month={month}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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

        public async Task<List<SAPModels>> GetAccountsFromSAP(string Clause)
        {
            try
            {
                List<SAPModels> oList = new List<SAPModels>();

                var request = new RestRequest($"SAPData/getExpenseAccountFromSAP?clause={Clause}", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<SAPModels>>(request);

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
    }
}