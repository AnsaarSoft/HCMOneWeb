using HCM.API.General;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.HCMModels;
using System.Linq;

namespace HCM.API.Repository.ApprovalSetup
{
    public class CfgApprovalTemplateRepo : ICfgApprovalTemplate
    {
        private HCMOneContext _DBContext;

        public CfgApprovalTemplateRepo(HCMOneContext dBContext)
        {
            _DBContext = dBContext;
        }
        public async Task<List<CfgApprovalTemplate>> GetAllData()
        {
            List<CfgApprovalTemplate> oList = new List<CfgApprovalTemplate>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.CfgApprovalTemplates
                    .Include(x => x.CfgApprovalTemplateDocuments)
                    .Include(x => x.CfgApprovalTemplateOriginators)
                    .Include(x => x.CfgApprovalTemplateStages)
                    .ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgApprovalTemplates.Add(oCfgApprovalTemplate);
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
        public async Task<ApiResponseModel> Update(CfgApprovalTemplate oCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    var DocDetail = _DBContext.CfgApprovalTemplateDocuments.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    var OriDetail = _DBContext.CfgApprovalTemplateOriginators.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    var StagesDetail = _DBContext.CfgApprovalTemplateStages.Where(x => x.Atid == oCfgApprovalTemplate.Id).ToList();
                    _DBContext.CfgApprovalTemplateDocuments.RemoveRange(DocDetail);
                    _DBContext.CfgApprovalTemplateOriginators.RemoveRange(OriDetail);
                    _DBContext.CfgApprovalTemplateStages.RemoveRange(StagesDetail);
                    _DBContext.CfgApprovalTemplates.Update(oCfgApprovalTemplate);
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
        public async Task<List<MstForm>> GetApprovalDocs()
        {
            List<MstForm> oList = new List<MstForm>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstForms.Where(x => x.FlgActive == true && x.FlgPayrollForms == true).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
    }
}
