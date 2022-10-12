using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class CfgTaxSetupRepo : ICfgTaxSetup
    {
        private HCMOneContext _DBContext;

        public CfgTaxSetupRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<CfgTaxSetup>> GetAllData()
        {
            List<CfgTaxSetup> oList = new List<CfgTaxSetup>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.CfgTaxSetups.Include(c => c.CfgTaxDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(CfgTaxSetup oCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oCfgTaxSetup.CreateDate = DateTime.Now;
                    _DBContext.CfgTaxSetups.Add(oCfgTaxSetup);
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
        public async Task<ApiResponseModel> Update(CfgTaxSetup oCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oCfgTaxSetup.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.CfgTaxDetails.Where(x => x.Pid == oCfgTaxSetup.Id).ToList();
                    _DBContext.CfgTaxDetails.RemoveRange(Detail);
                    _DBContext.CfgTaxSetups.Update(oCfgTaxSetup);
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
