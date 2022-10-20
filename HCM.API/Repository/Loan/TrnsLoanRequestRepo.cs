using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Interfaces.Loan;
using HCM.API.Models;
using HCM.API.Repository.ApprovalSetup;

namespace HCM.API.Repository.Loan
{
    public class TrnsLoanRequestRepo : ITrnsLoanRequest
    {
        private HCMOneContext _DBContext;
        private IDocApprovalDecesion _IDocApprovalDecesionRepo;

        public TrnsLoanRequestRepo(HCMOneContext DBContext, IDocApprovalDecesion docApprovalDecesion)
        {
            _DBContext = DBContext;
            _IDocApprovalDecesionRepo = docApprovalDecesion;
        }

        public async Task<List<TrnsLoanRequest>> GetAllData()
        {
            List<TrnsLoanRequest> oList = new List<TrnsLoanRequest>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsLoanRequests.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsLoanRequest oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsLoanRequest.CreateDate = DateTime.Now;
                    oTrnsLoanRequest.DocStatus = "Draft";
                    oTrnsLoanRequest.DocAprStatus = "Pending";
                    _DBContext.TrnsLoanRequests.Add(oTrnsLoanRequest);
                    _DBContext.SaveChanges();
                    var EmpID = oTrnsLoanRequest.UserId;
                    var chkStatus = _IDocApprovalDecesionRepo.InsertDocApprovalDecesion(EmpID, Convert.ToInt32(oTrnsLoanRequest.DocNum), 3, "Loan Request");
                    if (chkStatus == 2)
                    {
                        oTrnsLoanRequest.DocStatus = "Opened";
                        oTrnsLoanRequest.DocAprStatus = "Approved";
                        _DBContext.TrnsLoanRequests.Update(oTrnsLoanRequest);
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
        public async Task<ApiResponseModel> Update(TrnsLoanRequest oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsLoanRequest.UpdateDate = DateTime.Now;
                    _DBContext.TrnsLoanRequests.Update(oTrnsLoanRequest);
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
        public async Task<ApiResponseModel> Insert(List<TrnsLoanRequest> oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsLoanRequests.AddRange(oTrnsLoanRequest);
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
        public async Task<ApiResponseModel> Update(List<TrnsLoanRequest> oTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsLoanRequests.UpdateRange(oTrnsLoanRequest);
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
