using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLoansRepo : IMstLoans
    {
        private WebHCMOneContext _DBContext;

        public MstLoansRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLoan>> GetAllData()
        {
            List<MstLoan> oList = new List<MstLoan>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstLoanss.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstLoanss
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstLoans.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstLoan oMstLoans)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLoans.CreatedBy = "manager";
                    oMstLoans.CreatedDate = DateTime.Now;
                    _DBContext.MstLoans.Add(oMstLoans);
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
        public async Task<ApiResponseModel> Update(MstLoan oMstLoans)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLoans.UpdatedBy = "manager";
                    oMstLoans.UpdatedDate = DateTime.Now;
                    _DBContext.MstLoans.Update(oMstLoans);
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
