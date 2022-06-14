using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterElement
{
    public interface IMstLove
    {
        Task<List<MstLove>> GetAllData();
    }
}
