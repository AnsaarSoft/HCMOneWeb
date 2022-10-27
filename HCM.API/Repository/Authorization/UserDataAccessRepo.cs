using HCM.API.General;
using HCM.API.Interfaces.Authorization;
using HCM.API.Models;

namespace HCM.API.Repository.Authorization
{
    public class UserDataAccessRepo : IUserDataAccess
    {
        private HCMOneContext _DBContext;

        public UserDataAccessRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<UserDataAccess>> GetAllData()
        {
            List<UserDataAccess> oList = new List<UserDataAccess>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.UserDataAccesses.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(List<UserDataAccess> oUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.UserDataAccesses.AddRange(oUserDataAccess);
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
        public async Task<ApiResponseModel> Update(List<UserDataAccess> oUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.UserDataAccesses.UpdateRange(oUserDataAccess);
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
