using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;

namespace HCM.API.Repository.MasterElement
{
    public class MstLoveRepo : IMstLove
    {
        private WebHCMOneContext _DBContext;

        public MstLoveRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLove>> GetAllData()
        {
            List<MstLove> oList = new List<MstLove>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstLoves.ToList();
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
