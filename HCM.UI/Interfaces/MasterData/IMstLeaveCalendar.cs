using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstLeaveCalendar
    {
        Task<List<MstLeaveCalendar>> GetAllData();
        Task<ApiResponseModel> Insert(MstLeaveCalendar oMstLeaveCalendar);
        Task<ApiResponseModel> Update(MstLeaveCalendar oMstLeaveCalendar);
    }
}
