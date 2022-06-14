using HCM.API.Models;

namespace HCM.API.Interfaces.MasterElement
{
    public interface IMstLove
    {
        Task<List<MstLove>> GetAllData();
    }
}
