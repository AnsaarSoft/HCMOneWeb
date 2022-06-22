using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
namespace HCM.API.Repository.MasterData
{
    public class MstAttendanceRulesRepo: IMstAttendanceRules
    {
        private WebHCMOneContext _DBContext;
        public MstAttendanceRulesRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<MstAttendanceRule> GetAllData()
        {
            MstAttendanceRule mstAttendanceConfig = new MstAttendanceRule();
            try
            {
                await Task.Run(() =>
                {
                    mstAttendanceConfig = _DBContext.MstAttendanceRules.FirstOrDefault();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return mstAttendanceConfig;

        }

        public async Task<ApiResponseModel> Insert(MstAttendanceRule oMstAttendanceRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstAttendanceRule.CreatedBy = "manager";
                    oMstAttendanceRule.CreatedDate = DateTime.Now;
                    _DBContext.MstAttendanceRules.Add(oMstAttendanceRule);
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
        public async Task<ApiResponseModel> Update(MstAttendanceRule oMstAttendanceRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstAttendanceRule.UpdatedBy = "manager";
                    oMstAttendanceRule.UpdatedDate = DateTime.Now;
                    _DBContext.MstAttendanceRules.Update(oMstAttendanceRule);
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
