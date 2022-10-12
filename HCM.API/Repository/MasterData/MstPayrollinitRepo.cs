using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class CfgPayrollDefinationinitRepo : ICfgPayrollDefinationinit
    {

        private HCMOneContext _DBContext;

        public CfgPayrollDefinationinitRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<CfgPayrollBasicInitialization> GetData()
        {
            CfgPayrollBasicInitialization CfgPayrollDefinationinit = new CfgPayrollBasicInitialization();
            try
            {
                await Task.Run(() =>
                {
                    CfgPayrollDefinationinit = _DBContext.CfgPayrollBasicInitializations.FirstOrDefault();
                });

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return CfgPayrollDefinationinit;
        }

        public async Task<ApiResponseModel> Update(CfgPayrollBasicInitialization pCfgPayrollDefinationinit)
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                await Task.Run(() =>
                {
                    _DBContext.CfgPayrollBasicInitializations.Update(pCfgPayrollDefinationinit);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Update Successfully";
                });

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to Update uccessfully";
            }
            return response;
        }
    }
}
