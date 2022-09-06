using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstCountryStateCity
    {
        Task<List<MstCountry>> GetAllData();
    }
}
