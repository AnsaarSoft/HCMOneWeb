using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstHoliday
    {
        Task<List<MstHoliDay>> GetAllData();
        Task<ApiResponseModel> Insert(MstHoliDay oMstHoliDay);
        Task<ApiResponseModel> Update(MstHoliDay oMstHoliDay);
        Task<ApiResponseModel> Insert(List<MstHoliDay> oMstHoliDay);
        Task<ApiResponseModel> Update(List<MstHoliDay> oMstHoliDay);
    }
}
