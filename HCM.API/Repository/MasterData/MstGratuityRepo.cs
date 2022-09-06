using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class MstGratuityRepo:IMstGratuity
    {
        private WebHCMOneContext _DBContext;

        public MstGratuityRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstGratuity>> GetAllData()
        {
            List<MstGratuity> oList = new List<MstGratuity>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstGratuities.Include(c => c.MstGratuityDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstGratuity oMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstGratuity.CreateDate = DateTime.Now;
                    _DBContext.MstGratuities.Add(oMstGratuity);
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
        public async Task<ApiResponseModel> Update(MstGratuity oMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstGratuity.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.MstGratuityDetails.Where(x => x.Fkid == oMstGratuity.Id).ToList();
                    _DBContext.MstGratuityDetails.RemoveRange(Detail);
                    _DBContext.MstGratuities.Update(oMstGratuity);                    
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
