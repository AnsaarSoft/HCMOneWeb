using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstBranchRepo : IMstBranch
    {
        private HCMOneContext _DBContext;

        public MstBranchRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstBranch>> GetAllData()
        {
            List<MstBranch> oList = new List<MstBranch>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstBranches.ToList();
                });                
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }            
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstBranch oMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstBranch.CreateDate = DateTime.Now;
                    _DBContext.MstBranches.Add(oMstBranch);
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
        public async Task<ApiResponseModel> Update(MstBranch oMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstBranch.UpdateDate = DateTime.Now;
                    _DBContext.MstBranches.Update(oMstBranch);
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
        public async Task<ApiResponseModel> Insert(List<MstBranch> oMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstBranches.AddRange(oMstBranch);
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
        public async Task<ApiResponseModel> Update(List<MstBranch> oMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstBranches.UpdateRange(oMstBranch);
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
