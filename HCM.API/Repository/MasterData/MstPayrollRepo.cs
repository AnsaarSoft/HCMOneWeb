using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class CfgPayrollDefinationRepo : ICfgPayrollDefination
    {
        private HCMOneContext _DBContext;

        public CfgPayrollDefinationRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<CfgPayrollDefination>> GetAllData()
        {
            List<CfgPayrollDefination> oList = new List<CfgPayrollDefination>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.CfgPayrollDefinations.Include(c => c.MstElementLinks).Include(c => c.CfgPeriodDates).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(CfgPayrollDefination oCfgPayrollDefination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oCfgPayrollDefination.CreateDate = DateTime.Now;
                    _DBContext.CfgPayrollDefinations.Add(oCfgPayrollDefination);
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
        public async Task<ApiResponseModel> Update(CfgPayrollDefination oCfgPayrollDefination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oCfgPayrollDefination.UpdateDate = DateTime.Now;                    
                    _DBContext.CfgPayrollDefinations.Update(oCfgPayrollDefination);
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
