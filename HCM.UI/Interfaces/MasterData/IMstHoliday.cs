using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstHoliday
    {
        Task<List<MstHoliday1>> GetAllData();
        Task<ApiResponseModel> Insert(MstHoliday1 oMstHoliDay);
        Task<ApiResponseModel> Update(MstHoliday1 oMstHoliDay);
        Task<ApiResponseModel> Insert(List<MstHoliday1> oMstHoliDay);
        Task<ApiResponseModel> Update(List<MstHoliday1> oMstHoliDay);
    }
}
