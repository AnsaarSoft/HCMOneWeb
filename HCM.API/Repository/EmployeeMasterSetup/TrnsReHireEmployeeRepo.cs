using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;


namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsReHireEmployeeRepo : ITrnsReHireEmployee
    {
        private HCMOneContext _DBContext;

        public TrnsReHireEmployeeRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsReHireEmployee>> GetAllData()
        {
            List<TrnsReHireEmployee> oList = new List<TrnsReHireEmployee>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsReHireEmployees.Include(t=>t.TrnsReHireEmployeeDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsReHireEmployee oTrnsReHireEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsReHireEmployee.CreateDate = DateTime.Now;
                    _DBContext.TrnsReHireEmployees.Add(oTrnsReHireEmployee);
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
        public async Task<ApiResponseModel> Update(TrnsReHireEmployee oTrnsReHireEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsReHireEmployee.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.TrnsReHireEmployeeDetails.Where(x => x.ReHireId == oTrnsReHireEmployee.Id).ToList();
                    _DBContext.TrnsReHireEmployeeDetails.RemoveRange(Detail);
                    _DBContext.TrnsReHireEmployees.Update(oTrnsReHireEmployee);
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
