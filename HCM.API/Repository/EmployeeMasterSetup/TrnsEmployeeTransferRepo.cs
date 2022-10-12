using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class TrnsEmployeeTransferRepo : ITrnsEmployeeTransfer
    {
        private HCMOneContext _DBContext;

        public TrnsEmployeeTransferRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsEmployeeTransfer>> GetAllData()
        {
            List<TrnsEmployeeTransfer> oList = new List<TrnsEmployeeTransfer>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeTransfers.Include(t=>t.TrnsEmployeeTransferDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeTransfer.CreateDate = DateTime.Now;
                    _DBContext.TrnsEmployeeTransfers.Add(oTrnsEmployeeTransfer);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeTransfer oTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeTransfer.UpdateDate = DateTime.Now;
                    var Detail = _DBContext.TrnsEmployeeTransferDetails.Where(x => x.ParentId == oTrnsEmployeeTransfer.Id).ToList();
                    _DBContext.TrnsEmployeeTransferDetails.RemoveRange(Detail);
                    _DBContext.TrnsEmployeeTransfers.Update(oTrnsEmployeeTransfer);
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
