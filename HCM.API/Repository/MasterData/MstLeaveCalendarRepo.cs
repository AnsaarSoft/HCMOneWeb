using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLeaveCalendarRepo : IMstLeaveCalendar
    {
        private HCMOneContext _DBContext;

        public MstLeaveCalendarRepo(HCMOneContext DBContext)
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
                    oMstLeaveCalendar.CreateDate = DateTime.Now;
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
                    oMstLeaveCalendar.UpdateDate = DateTime.Now;
                    _DBContext.MstLeaveCalendars.Update(oMstLeaveCalendar);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Update successfully";
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to Update successfully";
            }
            return response;
        }
    }
}
