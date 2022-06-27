using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstCalendarRepo : IMstCalendar
    {
        private WebHCMOneContext _DBContext;

        public MstCalendarRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstCalendar>> GetAllData()
        {
            List<MstCalendar> oList = new List<MstCalendar>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstCalendars.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstCalendars
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstCalendars.ToList();
                });                
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }            
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstCalendar oMstCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstCalendar.CreatedBy = "manager";
                    oMstCalendar.CreatedDate = DateTime.Now;
                    _DBContext.MstCalendars.Add(oMstCalendar);
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
        public async Task<ApiResponseModel> Update(MstCalendar oMstCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstCalendar.UpdatedBy = "manager";
                    oMstCalendar.UpdatedDate = DateTime.Now;
                    _DBContext.MstCalendars.Update(oMstCalendar);
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
        public async Task<ApiResponseModel> Insert(MstPayrollPeriod oMstPayrollPeriod)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstPayrollPeriods.Add(oMstPayrollPeriod);
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
