using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;

namespace HCM.API.Repository.MasterElement
{
    public class MstOverTimeRepo : IMstOverTime
    {
        private WebHCMOneContext _DBContext;

        public MstOverTimeRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstOverTime>> GetAllData()
        {
            List<MstOverTime> oList = new List<MstOverTime>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstDepartments.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstDepartments
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstOverTimes.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstOverTime oMstOverTime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstOverTime.CreatedBy = "manager";
                    oMstOverTime.CreatedDate = DateTime.Now;
                    _DBContext.MstOverTimes.Add(oMstOverTime);
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
        public async Task<ApiResponseModel> Update(MstOverTime oMstOverTime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstOverTime.UpdatedBy = "manager";
                    oMstOverTime.UpdatedDate = DateTime.Now;
                    _DBContext.MstOverTimes.Update(oMstOverTime);
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
