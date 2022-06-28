using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstBonusRepo : IMstBonus
    {
        private WebHCMOneContext _DBContext;

        public MstBonusRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstBonu>> GetAllData()
        {
            List<MstBonu> oList = new List<MstBonu>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstBonus.ToList();
                });                
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }            
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstBonu oMstBonus)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstBonus.CreatedDate = DateTime.Now;
                    _DBContext.MstBonus.Add(oMstBonus);
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
        public async Task<ApiResponseModel> Update(MstBonu oMstBonus)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstBonus.UpdatedDate = DateTime.Now;
                    _DBContext.MstBonus.Update(oMstBonus);
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
