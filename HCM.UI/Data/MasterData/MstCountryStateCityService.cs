using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterData;
using RestSharp;

namespace HCM.UI.Data.MasterData
{
    public class MstCountryStateCityService : IMstCountryStateCity
    {
        private readonly RestClient _restClient;

        public MstCountryStateCityService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstCountry>> GetAllData()
        {
            try
            {
                List<MstCountry> oList = new List<MstCountry>();

                var request = new RestRequest("MasterData/getAllCountryStateCity", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstCountry>>(request);

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
