using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class MstEmployeeMasterDataRepo : IMstEmployeeMasterData
    {
        private HCMOneContext _DBContext;

        public MstEmployeeMasterDataRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<List<MstEmployee>> GetAllData(string EmpID)
        {
            List<MstEmployee> oList = new List<MstEmployee>();
            try
            {
                await Task.Run(() =>
                {
                    if (EmpID.ToLower() == "manager")
                    {
                        oList = _DBContext.MstEmployees.Where(x => x.EmpId != "manager").Include(x => x.MstEmployeeAttachments).Include(x => x.MstEmployeeLeaves).Include(x => x.TrnsEmployeeElements).ThenInclude(x => x.TrnsEmployeeElementDetails).ToList();
                    }
                    else
                    {
                        oList = (from a in _DBContext.MstEmployees.Where(x => x.EmpId != "manager").Include(x => x.MstEmployeeAttachments).Include(x => x.MstEmployeeLeaves).Include(x => x.TrnsEmployeeElements).ThenInclude(x => x.TrnsEmployeeElementDetails)
                                 join d in _DBContext.UserDataAccesses on a.PayrollId equals d.FkPayrollId
                                 where d.FlgActive == true && d.EmpId == EmpID
                                 select a
                                 ).ToList();
                    }
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }

        public async Task<List<MstEmployee>> GetAllData()
        {
            List<MstEmployee> oList = new List<MstEmployee>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstEmployees.Where(x => x.EmpId != "manager").Include(x => x.MstEmployeeAttachments).Include(x => x.MstEmployeeLeaves).Include(x => x.TrnsEmployeeElements).ThenInclude(x => x.TrnsEmployeeElementDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstEmployee oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstEmployee.CreateDate = DateTime.Now;
                    _DBContext.MstEmployees.Add(oMstEmployee);
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
        public async Task<ApiResponseModel> Update(MstEmployee oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstEmployee.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.MstEmployeeAttachments.Where(x => x.EmpId == oMstEmployee.Id).ToList();
                    _DBContext.MstEmployeeAttachments.RemoveRange(Detail);
                    _DBContext.MstEmployees.Update(oMstEmployee);
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
        public async Task<ApiResponseModel> Insert(List<MstEmployee> oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstEmployees.AddRange(oMstEmployee);
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
        public async Task<ApiResponseModel> Update(List<MstEmployee> oMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstEmployees.UpdateRange(oMstEmployee);
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
