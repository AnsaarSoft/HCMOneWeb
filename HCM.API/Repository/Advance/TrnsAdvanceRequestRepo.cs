using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.Advance;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.Loan;
using HCM.API.Models;
using HCM.API.Repository.ApprovalSetup;

namespace HCM.API.Repository.Advance
{
    public class TrnsAdvanceRequestRepo : ITrnsAdvanceRequest
    {
        private HCMOneContext _DBContext;
        private IDocApprovalDecesion _IDocApprovalDecesionRepo;

        public TrnsAdvanceRequestRepo(HCMOneContext DBContext, IDocApprovalDecesion docApprovalDecesion)
        {
            _DBContext = DBContext;
            _IDocApprovalDecesionRepo = docApprovalDecesion;
        }

        public async Task<List<TrnsAdvanceRequest>> GetAllData()
        {
            List<TrnsAdvanceRequest> oList = new List<TrnsAdvanceRequest>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsAdvanceRequests.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsAdvanceRequest oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsAdvanceRequest.CreateDate = DateTime.Now;
                    oTrnsAdvanceRequest.DocStatus = "Draft";
                    oTrnsAdvanceRequest.DocAprStatus = "Pending";
                    _DBContext.TrnsAdvanceRequests.Add(oTrnsAdvanceRequest);
                    _DBContext.SaveChanges();
                    var EmpID = oTrnsAdvanceRequest.UserId;
                    var chkStatus = _IDocApprovalDecesionRepo.InsertDocApprovalDecesion(EmpID, Convert.ToInt32(oTrnsAdvanceRequest.DocNum), 4, "Advance Request");
                    if (chkStatus == 2)
                    {
                        oTrnsAdvanceRequest.DocStatus = "Opened";
                        oTrnsAdvanceRequest.DocAprStatus = "Approved";
                        _DBContext.TrnsAdvanceRequests.Update(oTrnsAdvanceRequest);
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
        public async Task<ApiResponseModel> Update(TrnsAdvanceRequest oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsAdvanceRequest.UpdateDate = DateTime.Now;
                    _DBContext.TrnsAdvanceRequests.Update(oTrnsAdvanceRequest);
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
        public async Task<ApiResponseModel> Insert(List<TrnsAdvanceRequest> oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAdvanceRequests.AddRange(oTrnsAdvanceRequest);
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
        public async Task<ApiResponseModel> Update(List<TrnsAdvanceRequest> oTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsAdvanceRequests.UpdateRange(oTrnsAdvanceRequest);
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
