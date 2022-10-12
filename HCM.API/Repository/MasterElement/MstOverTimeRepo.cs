using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;

namespace HCM.API.Repository.MasterElement
{
    public class MstOverTimeRepo : IMstOverTime
    {
        private HCMOneContext _DBContext;

        public MstOverTimeRepo(HCMOneContext DBContext)
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
                    oMstOverTime.CreateDate = DateTime.Now;
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
                    oMstOverTime.UpdateDate = DateTime.Now;
                    _DBContext.MstOverTimes.Update(oMstOverTime);
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
