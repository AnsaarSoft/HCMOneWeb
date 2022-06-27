using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLeaveCalendarRepo : IMstLeaveCalendar
    {
        private WebHCMOneContext _DBContext;

        public MstLeaveCalendarRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLeaveCalendar>> GetAllData()
        {
            List<MstLeaveCalendar> oList = new List<MstLeaveCalendar>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstLeaveCalendars.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstLeaveCalendars
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstLeaveCalendars.ToList();
                });                
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }            
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstLeaveCalendar oMstLeaveCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveCalendar.CreatedBy = "manager";
                    oMstLeaveCalendar.CreatedDate = DateTime.Now;
                    _DBContext.MstLeaveCalendars.Add(oMstLeaveCalendar);
                    _DBContext.SaveChanges();                    
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save successfully";
            }
            return response;
        }
        public async Task<ApiResponseModel> Update(MstLeaveCalendar oMstLeaveCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveCalendar.UpdatedBy = "manager";
                    oMstLeaveCalendar.UpdatedDate = DateTime.Now;
                    _DBContext.MstLeaveCalendars.Update(oMstLeaveCalendar);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved successfully";
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save successfully";
            }
            return response;
        }
    }
}
