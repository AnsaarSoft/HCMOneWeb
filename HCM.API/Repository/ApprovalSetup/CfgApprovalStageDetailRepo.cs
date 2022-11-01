using HCM.API.General;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ApprovalSetup
{
    public class CfgApprovalStageDetailRepo : ICfgApprovalStage
    {
        private HCMOneContext _DBContext;

        public CfgApprovalStageDetailRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<CfgApprovalStage>> GetAllData()
        {
            List<CfgApprovalStage> oList = new List<CfgApprovalStage>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.CfgApprovalStages.Where(x=>x.FlgActive == true).Include(t => t.CfgApprovalStageDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(CfgApprovalStage oCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgApprovalStages.Add(oCfgApprovalStage);
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
        public async Task<ApiResponseModel> Update(CfgApprovalStage oCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    var Detail = _DBContext.CfgApprovalStageDetails.Where(x => x.Asid == oCfgApprovalStage.Id).ToList();
                    _DBContext.CfgApprovalStageDetails.RemoveRange(Detail);
                    _DBContext.CfgApprovalStages.Update(oCfgApprovalStage);
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
