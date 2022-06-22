using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class MstTaxSetupRepo : IMstTaxSetup
    {
        private WebHCMOneContext _DBContext;

        public MstTaxSetupRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstTaxSetup>> GetAllData()
        {
            List<MstTaxSetup> oList = new List<MstTaxSetup>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstTaxSetups.ToList();

                    foreach (var Header in oList)
                    {
                        var detail = _DBContext.MstTaxSetupDetails.Where(s => s.Fkid == Header.Id).ToList();                        
                    }                   
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstTaxSetup oMstTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstTaxSetups.Add(oMstTaxSetup);
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
        public async Task<ApiResponseModel> Update(MstTaxSetup oMstTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    //_DBContext.MstTaxSetups.Attach(oMstTaxSetup);
                    //_DBContext.Entry<MstTaxSetup>(oMstTaxSetup).State = EntityState.Modified;                    
                    _DBContext.MstTaxSetups.Update(oMstTaxSetup);
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
