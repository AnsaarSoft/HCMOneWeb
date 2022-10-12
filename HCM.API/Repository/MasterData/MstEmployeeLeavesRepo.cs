using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstEmployeeLeavesRepo : IMstEmployeeLeaves
    {
        private HCMOneContext _DBContext;

        public MstEmployeeLeavesRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstEmployeeLeaf>> GetAllData()
        {
            List<MstEmployeeLeaf> oList = new List<MstEmployeeLeaf>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstEmployeeLeaves.ToList();                    
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstEmployeeLeaf oMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstEmployeeLeaf.CreateDate = DateTime.Now;
                    _DBContext.MstEmployeeLeaves.Add(oMstEmployeeLeaf);
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
        public async Task<ApiResponseModel> Update(MstEmployeeLeaf oMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstEmployeeLeaf.UpdateDate = DateTime.Now;
                    _DBContext.MstEmployeeLeaves.Update(oMstEmployeeLeaf);
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
        public async Task<ApiResponseModel> Insert(List<MstEmployeeLeaf> oMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstEmployeeLeaves.AddRange(oMstEmployeeLeaf);
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
        public async Task<ApiResponseModel> Update(List<MstEmployeeLeaf> oMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstEmployeeLeaves.UpdateRange(oMstEmployeeLeaf);
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
