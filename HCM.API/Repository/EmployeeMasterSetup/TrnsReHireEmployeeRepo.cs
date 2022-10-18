using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;
using HCM.API.HCMModels;


namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsReHireEmployeeRepo : ITrnsReHireEmployee
    {
        private HCMOneContext _DBContext;

        public TrnsReHireEmployeeRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsEmployeeReHire>> GetAllData()
        {
            List<TrnsEmployeeReHire> oList = new List<TrnsEmployeeReHire>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeReHires.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeReHire oTrnsEmployeeReHire)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeReHire.CreateDt = DateTime.Now;
                    _DBContext.TrnsEmployeeReHires.Add(oTrnsEmployeeReHire);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeReHire oTrnsEmployeeReHire)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {   oTrnsEmployeeReHire.UpdateDt= DateTime.Now;
                    _DBContext.TrnsEmployeeReHires.Update(oTrnsEmployeeReHire);
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
