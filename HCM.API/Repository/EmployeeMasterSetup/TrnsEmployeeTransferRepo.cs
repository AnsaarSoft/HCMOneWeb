using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;
using HCM.API.Repository.ApprovalSetup;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.HCMModels;

namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsEmployeeTransferRepo : ITrnsEmployeeTransfer
    {
        private HCMOneContext _DBContext;
        private IDocApprovalDecesion _IDocApprovalDecesionRepo;

        public TrnsEmployeeTransferRepo(HCMOneContext DBContext, IDocApprovalDecesion docApprovalDecesion)
        {
            _DBContext = DBContext;
            _IDocApprovalDecesionRepo = docApprovalDecesion;
        }
        public async Task<List<TrnsEmployeeTransfer>> GetAllData()
        {
            List<TrnsEmployeeTransfer> oList = new List<TrnsEmployeeTransfer>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeTransfers.Include(t=>t.TrnsEmployeeTransferDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeTransfer.CreateDate = DateTime.Now;
                    oTrnsEmployeeTransfer.DocStatus = "Draft";
                    oTrnsEmployeeTransfer.DocAprStatus = "Pending";
                    _DBContext.TrnsEmployeeTransfers.Add(oTrnsEmployeeTransfer);
                    _DBContext.SaveChanges();
                    var EmpID = oTrnsEmployeeTransfer.CreatedBy;
                    var chkStatus = _IDocApprovalDecesionRepo.InsertDocApprovalDecesion(EmpID, Convert.ToInt32(oTrnsEmployeeTransfer.DoNum), 5, "Employee Transfer");
                    if (chkStatus == 2)
                    {
                        oTrnsEmployeeTransfer.DocStatus = "Opened";
                        oTrnsEmployeeTransfer.DocAprStatus = "Approved";
                        _DBContext.TrnsEmployeeTransfers.Update(oTrnsEmployeeTransfer);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeTransfer.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.TrnsEmployeeTransferDetails.Where(x => x.ParentId == oTrnsEmployeeTransfer.Id).ToList();
                    _DBContext.TrnsEmployeeTransferDetails.RemoveRange(Detail);
                    _DBContext.TrnsEmployeeTransfers.Update(oTrnsEmployeeTransfer);
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
        
    }
}
