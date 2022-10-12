using HCM.API.General;
using HCM.API.Interfaces.Attendance;
using HCM.API.Models;

namespace HCM.API.Repository.Attendance
{
    public class TrnsTempAttendanceRepo : ITrnsTempAttendance
    {
        private HCMOneContext _DBContext;

        public TrnsTempAttendanceRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsTempAttendance>> GetAllData()
        {
            List<TrnsTempAttendance> oList = new List<TrnsTempAttendance>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsTempAttendances.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsTempAttendance oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsTempAttendance.CreatedDate = DateTime.Now;
                    _DBContext.TrnsTempAttendances.Add(oTrnsTempAttendance);
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
        public async Task<ApiResponseModel> Update(TrnsTempAttendance oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsTempAttendance.UpdateDate = DateTime.Now;
                    _DBContext.TrnsTempAttendances.Update(oTrnsTempAttendance);
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
        public async Task<ApiResponseModel> Insert(List<TrnsTempAttendance> oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsTempAttendances.AddRange(oTrnsTempAttendance);
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
        public async Task<ApiResponseModel> Update(List<TrnsTempAttendance> oTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsTempAttendances.UpdateRange(oTrnsTempAttendance);
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
