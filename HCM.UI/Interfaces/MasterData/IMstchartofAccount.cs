using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstchartofAccount
    {
        Task<List<MstchartofAccount>> GetAllData();
        Task<ApiResponseModel> Insert(MstchartofAccount oMstchartofAccount);
        Task<ApiResponseModel> Update(MstchartofAccount oMstchartofAccount);
        Task<ApiResponseModel> Insert(List<MstchartofAccount> oMstchartofAccount);
        Task<ApiResponseModel> Update(List<MstchartofAccount> oMstchartofAccount);
    }
}
