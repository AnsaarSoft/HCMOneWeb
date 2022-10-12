using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstCalendarRepo : IMstCalendar
    {
        private HCMOneContext _DBContext;

        public MstCalendarRepo(HCMOneContext DBContext)
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
                    oMstCalendar.CreateDate = DateTime.Now;
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
                    oMstCalendar.UpdateDate = DateTime.Now;
                    _DBContext.MstCalendars.Update(oMstCalendar);
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
        public async Task<ApiResponseModel> Insert(CfgPeriodDate oCfgPeriodDate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgPeriodDates.Add(oCfgPeriodDate);
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
        public async Task<ApiResponseModel> Insert(List<CfgPeriodDate> oCfgPeriodDate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgPeriodDates.AddRange(oCfgPeriodDate);
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
