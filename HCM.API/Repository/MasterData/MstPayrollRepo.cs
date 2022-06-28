using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstPayrollRepo : IMstPayroll
    {
        private WebHCMOneContext _DBContext;

        public MstPayrollRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstPayroll>> GetAllData()
        {
            List<MstPayroll> oList = new List<MstPayroll>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstPayrolls.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstPayroll oMstPayroll)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstPayroll.CreatedDate = DateTime.Now;
                    _DBContext.MstPayrolls.Add(oMstPayroll);
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
        public async Task<ApiResponseModel> Update(MstPayroll oMstPayroll)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstPayroll.UpdatedDate = DateTime.Now;
                    _DBContext.MstPayrolls.Update(oMstPayroll);
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
