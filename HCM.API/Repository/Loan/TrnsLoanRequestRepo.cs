using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Interfaces.Loan;
using HCM.API.Models;

namespace HCM.API.Repository.Loan
{
    public class TrnsLoanRequestRepo : ITrnsLoanRequest
    {
        private HCMOneContext _DBContext;

        public TrnsLoanRequestRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
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
                    _DBContext.TrnsLoanRequests.Add(oTrnsLoanRequest);
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
