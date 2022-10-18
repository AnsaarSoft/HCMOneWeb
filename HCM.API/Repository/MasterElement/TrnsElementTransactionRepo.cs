using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterElement
{
    public class TrnsElementTransactionRepo : ITrnsElementTransaction
    {
        private HCMOneContext _DBContext;

        public TrnsElementTransactionRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsEmployeeElement>> GetAllData()
        {
            List<TrnsEmployeeElement> oList = new List<TrnsEmployeeElement>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeElements.Include(x=> x.TrnsEmployeeElementDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeElement oTrnsEmployeeElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeElement.CreateDate = DateTime.Now;
                    _DBContext.TrnsEmployeeElements.Add(oTrnsEmployeeElement);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeElement oTrnsEmployeeElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeElement.UpdateDate = DateTime.Now;
                    _DBContext.TrnsEmployeeElements.Update(oTrnsEmployeeElement);
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
        public async Task<ApiResponseModel> Insert(List<TrnsEmployeeElement> oTrnsEmployeeElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsEmployeeElements.AddRange(oTrnsEmployeeElement);
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
        public async Task<ApiResponseModel> Update(List<TrnsEmployeeElement> oTrnsEmployeeElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsEmployeeElements.UpdateRange(oTrnsEmployeeElement);
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
