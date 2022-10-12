using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class MstCountryStateCityRepo : IMstCountryStateCity
    {
        private HCMOneContext _DBContext;

        public MstCountryStateCityRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstCountry>> GetAllData()
        {
            List<MstCountry> oList = new List<MstCountry>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstCountries.Include(c => c.MstStates).Include(x => x.MstCities).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
    }
}
