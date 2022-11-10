using HCM.API.General;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ClientSpecific
{
    public class MstTargetRepo : IMstTarget
    {

        private HCMOneContext _DBContext;

        public MstTargetRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstTarget>> GetAllData()
        {
            List<MstTarget> oList = new List<MstTarget>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstTargets.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstTarget oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstTarget.CreateDate = DateTime.Now;
                    _DBContext.MstTargets.Add(oMstTarget);
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
        public async Task<ApiResponseModel> Update(MstTarget oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstTarget.UpdateDate = DateTime.Now;
                    
                    _DBContext.MstTargets.Update(oMstTarget);
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
        public async Task<ApiResponseModel> Insert(List<MstTarget> oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstTargets.AddRange(oMstTarget);
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
        public async Task<ApiResponseModel> Update(List<MstTarget> oMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstTargets.UpdateRange(oMstTarget);
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
