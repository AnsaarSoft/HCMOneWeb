using HCM.API.General;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsLeaveRequestRepo : ITrnsLeaveRequest
    {
        private HCMOneContext _DBContext;
        private IDocApprovalDecesion _IDocApprovalDecesionRepo;

        public TrnsLeaveRequestRepo(HCMOneContext DBContext, IDocApprovalDecesion docApprovalDecesion)
        {
            _DBContext = DBContext;
            _IDocApprovalDecesionRepo = docApprovalDecesion;
        }

        public async Task<List<TrnsLeavesRequest>> GetAllData()
        {
            List<TrnsLeavesRequest> oList = new List<TrnsLeavesRequest>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsLeavesRequests.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsLeavesRequest oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsLeavesRequest.CreateDate = DateTime.Now;
                    oTrnsLeavesRequest.DocStatus = "Draft";
                    oTrnsLeavesRequest.DocAprStatus = "Pending";
                    _DBContext.TrnsLeavesRequests.Add(oTrnsLeavesRequest);
                    _DBContext.SaveChanges();
                    var EmpID = oTrnsLeavesRequest.CreatedBy;
                    var chkStatus = _IDocApprovalDecesionRepo.InsertDocApprovalDecesion(EmpID, Convert.ToInt32(oTrnsLeavesRequest.DocNum), 2, "Leave Request");
                    if (chkStatus == 2)
                    {
                        oTrnsLeavesRequest.DocStatus = "Opened";
                        oTrnsLeavesRequest.DocAprStatus = "Approved";
                        _DBContext.TrnsLeavesRequests.Update(oTrnsLeavesRequest);
                        _DBContext.SaveChanges();
                        response.Id = 1;
                        response.Message = "Saved successfully";
                    }
                    else
                    {
                        response.Id = 1;
                        response.Message = "Saved successfully waiting for approval.";
                    }
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
        public async Task<ApiResponseModel> Update(TrnsLeavesRequest oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsLeavesRequest.UpdateDate = DateTime.Now;                    
                    _DBContext.TrnsLeavesRequests.Update(oTrnsLeavesRequest);
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
        public async Task<ApiResponseModel> Insert(List<TrnsLeavesRequest> oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsLeavesRequests.AddRange(oTrnsLeavesRequest);
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
        public async Task<ApiResponseModel> Update(List<TrnsLeavesRequest> oTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsLeavesRequests.UpdateRange(oTrnsLeavesRequest);
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
