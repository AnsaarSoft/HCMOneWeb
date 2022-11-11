using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ClientSpecific
{
    public class TrnsPerPieceRepo : ITrnsPerPiece
    {

        private HCMOneContext _DBContext;

        public TrnsPerPieceRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsPerPieceTransaction>> GetAllData()
        {
            List<TrnsPerPieceTransaction> oList = new List<TrnsPerPieceTransaction>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsPerPieceTransactions.Include(t => t.TrnsPerPieceTransactionDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsPerPieceTransaction oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsPerPieceTransaction.CreateDate = DateTime.Now;
                    _DBContext.TrnsPerPieceTransactions.Add(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Update(TrnsPerPieceTransaction oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsPerPieceTransaction.UpdateDate = DateTime.Now;
                    var StageItems = _DBContext.TrnsPerPieceTransactionDetails.Where(x => x.FkId == oTrnsPerPieceTransaction.Id).ToList();
                    _DBContext.TrnsPerPieceTransactionDetails.RemoveRange(StageItems);
                    
                    _DBContext.TrnsPerPieceTransactions.Update(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Insert(List<TrnsPerPieceTransaction> oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsPerPieceTransactions.AddRange(oTrnsPerPieceTransaction);
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
        public async Task<ApiResponseModel> Update(List<TrnsPerPieceTransaction> oTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsPerPieceTransactions.UpdateRange(oTrnsPerPieceTransaction);
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
