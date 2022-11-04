using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class MstGldeterminationRepo : IMstGldetermination
    {
        private HCMOneContext _DBContext;

        public MstGldeterminationRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstGldetermination>> GetAllData()
        {
            List<MstGldetermination> oList = new List<MstGldetermination>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstGldeterminations.Include(t => t.MstGldearningDetails).Include(t => t.MstGlddeductionDetails).Include(t => t.MstGldcontributions).Include(t => t.MstGldloansDetails).Include(t => t.MstGldadvanceDetails).Include(t => t.MstGldoverTimeDetails).Include(t => t.MstGldleaveDedDetails).ToList();
                    //oList = _DBContext.MstGldeterminations.ToList();                    
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstGldetermination oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstGldetermination.CreateDate = DateTime.Now;
                    _DBContext.MstGldeterminations.Add(oMstGldetermination);
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
        public async Task<ApiResponseModel> Update(MstGldetermination oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstGldetermination.UpdateDate = DateTime.Now;
                    _DBContext.MstGldeterminations.Update(oMstGldetermination);
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
        public async Task<ApiResponseModel> Insert(List<MstGldetermination> oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstGldeterminations.AddRange(oMstGldetermination);
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
        public async Task<ApiResponseModel> Update(List<MstGldetermination> oMstGldetermination)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstGldeterminations.UpdateRange(oMstGldetermination);
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
