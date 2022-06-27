using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstAdvanceRepo : IMstAdvance
    {
        private WebHCMOneContext _DBContext;

        public MstAdvanceRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstAdvance>> GetAllData()
        {
            List<MstAdvance> oList = new List<MstAdvance>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstAdvances.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstAdvance oMstAdvance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstAdvance.CreatedDate = DateTime.Now;
                    _DBContext.MstAdvances.Add(oMstAdvance);
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
        public async Task<ApiResponseModel> Update(MstAdvance oMstAdvance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstAdvance.UpdatedDate = DateTime.Now;
                    _DBContext.MstAdvances.Update(oMstAdvance);
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
