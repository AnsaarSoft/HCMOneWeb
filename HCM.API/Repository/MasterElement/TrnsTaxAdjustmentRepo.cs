using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterElement
{
    public class TrnsTaxAdjustmentRepo : ITrnsTaxAdjustment
    {
        private HCMOneContext _DBContext;

        public TrnsTaxAdjustmentRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsTaxAdjustment>> GetAllData()
        {
            List<TrnsTaxAdjustment> oList = new List<TrnsTaxAdjustment>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsTaxAdjustments.Include(x=> x.TrnsTaxAdjustmentDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsTaxAdjustment oTrnsTaxAdjustment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsTaxAdjustment.CreateDt = DateTime.Now;
                    _DBContext.TrnsTaxAdjustments.Add(oTrnsTaxAdjustment);
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
        public async Task<ApiResponseModel> Update(TrnsTaxAdjustment oTrnsTaxAdjustment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsTaxAdjustment.UpdateDt = DateTime.Now;
                    _DBContext.TrnsTaxAdjustments.Update(oTrnsTaxAdjustment);
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
