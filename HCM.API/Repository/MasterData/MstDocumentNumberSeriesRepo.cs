using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstDocumentNumberSeriesRepo : IMstDocumentNumberSeries
    {
        private HCMOneContext _DBContext;

        public MstDocumentNumberSeriesRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstDocumentNumberSeries>> GetAllData()
        {
            List<MstDocumentNumberSeries> oList = new List<MstDocumentNumberSeries>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstDocumentNumberSeries.ToList();                    
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstDocumentNumberSeries oMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstDocumentNumberSeries.CreatedDate = DateTime.Now;
                    _DBContext.MstDocumentNumberSeries.Add(oMstDocumentNumberSeries);
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
        public async Task<ApiResponseModel> Update(MstDocumentNumberSeries oMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstDocumentNumberSeries.UpdatedDate = DateTime.Now;
                    _DBContext.MstDocumentNumberSeries.Update(oMstDocumentNumberSeries);
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
        public async Task<ApiResponseModel> Insert(List<MstDocumentNumberSeries> oMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstDocumentNumberSeries.AddRange(oMstDocumentNumberSeries);
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
        public async Task<ApiResponseModel> Update(List<MstDocumentNumberSeries> oMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstDocumentNumberSeries.UpdateRange(oMstDocumentNumberSeries);
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
