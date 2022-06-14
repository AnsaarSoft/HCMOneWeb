using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstEmailConfig
    {
        Task<MstEmailConfig> GetData();

        Task<ApiResponseModel> Update(MstEmailConfig oMstEmailConfig);
    }
}
