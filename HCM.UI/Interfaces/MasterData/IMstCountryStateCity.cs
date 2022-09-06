using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstCountryStateCity
    {
        Task<List<MstCountry>> GetAllData();
    }
}
