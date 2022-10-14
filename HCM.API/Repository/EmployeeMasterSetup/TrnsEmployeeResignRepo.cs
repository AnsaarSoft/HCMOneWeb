using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsEmployeeResignRepo : ITrnsEmployeeResign
    {
        private HCMOneContext _DBContext;

        public TrnsEmployeeResignRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<List<TrnsResignation>> GetAllData()
        {
            List<TrnsResignation> oList = new List<TrnsResignation>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsResignations.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsResignation oTrnsResignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsResignation.CreateDate = DateTime.Now;
                    _DBContext.TrnsResignations.Add(oTrnsResignation);
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
        public async Task<ApiResponseModel> Update(TrnsResignation oTrnsResignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsResignation.UpdateDate = DateTime.Now;                    
                    _DBContext.TrnsResignations.Update(oTrnsResignation);
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
        public async Task<ApiResponseModel> Insert(List<TrnsResignation> oTrnsResignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsResignations.AddRange(oTrnsResignation);
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
        public async Task<ApiResponseModel> Update(List<TrnsResignation> oTrnsResignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsResignations.UpdateRange(oTrnsResignation);
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
