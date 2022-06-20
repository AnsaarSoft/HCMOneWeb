using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstDeductionRuleRepo : IMstDeductionRule
    {
        private WebHCMOneContext _DBContext;

        public MstDeductionRuleRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstDeductionRule>> GetAllData()
        {
            List<MstDeductionRule> oList = new List<MstDeductionRule>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstDeductionRule.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstDepartments
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstDeductionRules.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        
        public async Task<ApiResponseModel> Update(MstDeductionRule oMstDeductionRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstDeductionRules.Update(oMstDeductionRule);
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
