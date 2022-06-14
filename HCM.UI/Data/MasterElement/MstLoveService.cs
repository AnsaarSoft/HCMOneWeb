using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.MasterElement;
using RestSharp;

namespace HCM.UI.Data.MasterElement
{
    public class MstLoveService : IMstLove
    {
        private readonly RestClient _restClient;

        public MstLoveService()
        {
            _restClient = new RestClient(Settings.APIBaseURL);
        }

        public async Task<List<MstLove>> GetAllData()
        {
            try
            {
                List<MstLove> oList = new List<MstLove>();

                var request = new RestRequest("MasterElement/getAllLove", Method.Get) { RequestFormat = DataFormat.Json };

                var response = await _restClient.ExecuteAsync<List<MstLove>>(request);

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
