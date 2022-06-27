using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstBranchRepo : IMstBranch
    {
        private WebHCMOneContext _DBContext;

        public MstBranchRepo(WebHCMOneContext DBContext)
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
                    //oList = _DBContext.MstBranchs.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstBranchs
                    //         where a.FlgActive == true
                    //         select a).ToList();
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
                    oMstBranch.CreatedBy = "manager";
                    oMstBranch.CreatedDate = DateTime.Now;
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
                    oMstBranch.UpdatedBy = "manager";
                    oMstBranch.UpdatedDate = DateTime.Now;
                    _DBContext.MstBranches.Update(oMstBranch);
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
