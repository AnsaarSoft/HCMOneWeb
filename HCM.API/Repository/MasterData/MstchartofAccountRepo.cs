using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstchartofAccountRepo : IMstchartofAccount
    {
        private HCMOneContext _DBContext;

        public MstchartofAccountRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstchartofAccount>> GetAllData()
        {
            List<MstchartofAccount> oList = new List<MstchartofAccount>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstchartofAccounts.ToList();                    
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstchartofAccount oMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstchartofAccount.CreatedDate = DateTime.Now;
                    _DBContext.MstchartofAccounts.Add(oMstchartofAccount);
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
        public async Task<ApiResponseModel> Update(MstchartofAccount oMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstchartofAccount.UpdatedDate = DateTime.Now;
                    _DBContext.MstchartofAccounts.Update(oMstchartofAccount);
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
        public async Task<ApiResponseModel> Insert(List<MstchartofAccount> oMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstchartofAccounts.AddRange(oMstchartofAccount);
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
        public async Task<ApiResponseModel> Update(List<MstchartofAccount> oMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstchartofAccounts.UpdateRange(oMstchartofAccount);
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
