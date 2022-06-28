using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstDepartmentRepo : IMstDepartment
    {
        private WebHCMOneContext _DBContext;

        public MstDepartmentRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstDepartment>> GetAllData()
        {
            List<MstDepartment> oList = new List<MstDepartment>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstDepartments.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstDepartment oMstDepartment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstDepartment.CreatedDate = DateTime.Now;
                    _DBContext.MstDepartments.Add(oMstDepartment);
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
        public async Task<ApiResponseModel> Update(MstDepartment oMstDepartment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstDepartment.UpdatedDate = DateTime.Now;
                    _DBContext.MstDepartments.Update(oMstDepartment);
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
