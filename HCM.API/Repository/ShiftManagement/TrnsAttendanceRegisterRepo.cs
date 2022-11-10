using HCM.API.General;
using HCM.API.Interfaces.ShiftManagement;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ShiftManagement
{
    public class TrnsAttendanceRegisterRepo : ITrnsAttendanceRegister
    {
        private HCMOneContext _DBContext;

        public TrnsAttendanceRegisterRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsAttendanceRegister>> GetAllData()
        {
            List<TrnsAttendanceRegister> oList = new List<TrnsAttendanceRegister>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsAttendanceRegisters.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsAttendanceRegister oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAttendanceRegisters.Add(oTrnsAttendanceRegister);
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
        public async Task<ApiResponseModel> Update(TrnsAttendanceRegister oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAttendanceRegisters.Update(oTrnsAttendanceRegister);
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
        public async Task<ApiResponseModel> Insert(List<TrnsAttendanceRegister> oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAttendanceRegisters.AddRange(oTrnsAttendanceRegister);
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
        public async Task<ApiResponseModel> Update(List<TrnsAttendanceRegister> oTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAttendanceRegisters.UpdateRange(oTrnsAttendanceRegister);
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
