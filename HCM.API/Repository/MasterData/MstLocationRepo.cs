using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLocationRepo : IMstLocation
    {
        private WebHCMOneContext _DBContext;

        public MstLocationRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLocation>> GetAllData()
        {
            List<MstLocation> oList = new List<MstLocation>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstDepartments.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstDepartments
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstLocations.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstLocation oMstLocation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstLocations.Add(oMstLocation);
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
        public async Task<ApiResponseModel> Update(MstLocation oMstLocation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstLocations.Update(oMstLocation);
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
