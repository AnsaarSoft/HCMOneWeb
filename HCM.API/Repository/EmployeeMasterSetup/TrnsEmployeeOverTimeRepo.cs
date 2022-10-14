using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;


namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsEmployeeOverTimeRepo : ITrnsEmployeeOverTime
    {
        private HCMOneContext _DBContext;

        public TrnsEmployeeOverTimeRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsEmployeeOvertime>> GetAllData()
        {
            List<TrnsEmployeeOvertime> oList = new List<TrnsEmployeeOvertime>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeOvertimes.Include(t=>t.TrnsEmployeeOvertimeDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeOvertime oTrnsEmployeeOvertime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeOvertime.CreateDate = DateTime.Now;
                    _DBContext.TrnsEmployeeOvertimes.Add(oTrnsEmployeeOvertime);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeOvertime oTrnsEmployeeOvertime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeOvertime.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.TrnsEmployeeOvertimeDetails.Where(x => x.EmpOvertimeId == oTrnsEmployeeOvertime.Id).ToList();
                    _DBContext.TrnsEmployeeOvertimeDetails.RemoveRange(Detail);
                    _DBContext.TrnsEmployeeOvertimes.Update(oTrnsEmployeeOvertime);
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
