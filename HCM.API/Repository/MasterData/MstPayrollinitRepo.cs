using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstPayrollinitRepo : IMstPayrollinit
    {

        private WebHCMOneContext _DBContext;

        public MstPayrollinitRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<MstPayrollBasicInitialization> GetData()
        {
            MstPayrollBasicInitialization mstPayrollinit = new MstPayrollBasicInitialization();
        try
            {
                await Task.Run(() =>
                {
                    mstPayrollinit = (MstPayrollBasicInitialization)_DBContext.MstPayrollBasicInitializations.FirstOrDefault();
                });

            }
        catch(Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return mstPayrollinit;
        }

        public async Task<ApiResponseModel> Update(MstPayrollBasicInitialization pMstPayrollinit)
        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                await Task.Run(() =>
                {                  
                    _DBContext.MstPayrollBasicInitializations.Update(pMstPayrollinit);
                    _DBContext.SaveChanges();
                    response.Id = 1;
                    response.Message = "Saved Successfully";
                });

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                response.Id = 0;
                response.Message = "Failed to save uccessfully";
            }
            return response;
        }
    }
}
