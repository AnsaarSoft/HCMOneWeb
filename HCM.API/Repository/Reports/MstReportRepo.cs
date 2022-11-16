using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.Reports;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.Reports
{
    public class MstReportRepo : IMstReport
    {
        private HCMOneContext _DBContext;

        public MstReportRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstReport>> GetAllData()
        {
            List<MstReport> oList = new List<MstReport>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstReports.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstReport oMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                await Task.Run(() =>
                {
                    oMstReport.CreatedDate = DateTime.Now;
                    _DBContext.MstReports.Add(oMstReport);
                    if (oMstReport.FlgLayout != true)
                    {
                        MstMenu mstMenu = new MstMenu();
                        mstMenu.MenuId = _DBContext.MstMenus.Count() + 1;
                        mstMenu.SortNum = _DBContext.MstMenus.Where(a => a.MenuName == "Reports").Count() + 1;
                        mstMenu.MenuParent = 73;
                        mstMenu.ReportCode = oMstReport.ReportCode;
                        mstMenu.MenuName = oMstReport.ReportName;
                        mstMenu.MenuLink = oMstReport.FilePath;
                        mstMenu.FlgReport = true;
                        mstMenu.FlgActive = true;
                        mstMenu.CreatedBy = oMstReport.CreatedBy;
                        mstMenu.CreatedDate = DateTime.Now.Date;
                        _DBContext.MstMenus.Add(mstMenu);
                    }
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
        public async Task<ApiResponseModel> Update(MstReport oMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstReport.UpdatedDate = DateTime.Now;
                    _DBContext.MstReports.Update(oMstReport);
                    if (oMstReport.FlgLayout != true)
                    {
                        MstMenu mstMenu = new MstMenu();
                        mstMenu = _DBContext.MstMenus.Where(a => a.ReportCode == oMstReport.ReportCode).FirstOrDefault();
                        // mstMenu.MenuId = _DBContext.MstMenus.Where(a => a.ReportCode == oMstReport.ReportCode).Select(a => a.MenuId).FirstOrDefault();
                        mstMenu.ReportCode = oMstReport.ReportCode;
                        mstMenu.MenuName = oMstReport.ReportName;
                        mstMenu.MenuLink = oMstReport.FilePath;
                        mstMenu.UpdatedBy = oMstReport.UpdatedBy;
                        mstMenu.UpdatedDate = DateTime.Now.Date;
                        _DBContext.MstMenus.Update(mstMenu);
                    }
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
        public async Task<ApiResponseModel> Insert(List<MstReport> oMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstReports.AddRange(oMstReport);
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
        public async Task<ApiResponseModel> Update(List<MstReport> oMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstReports.UpdateRange(oMstReport);
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
