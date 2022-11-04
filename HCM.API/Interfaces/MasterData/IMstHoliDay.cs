using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstHoliDay
    {
        Task<List<MstHoliday1>> GetAllData();
        Task<ApiResponseModel> Insert(MstHoliday1 oMstHoliday1);
        Task<ApiResponseModel> Update(MstHoliday1 oMstHoliday1);
        Task<ApiResponseModel> Insert(List<MstHoliday1> oMstHoliday1);
        Task<ApiResponseModel> Update(List<MstHoliday1> oMstHoliday1);
    }
}
