using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLeaveTypeRepo : IMstLeaveType
    {
        private WebHCMOneContext _DBContext;

        public MstLeaveTypeRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLeaveType>> GetAllData()
        {
            List<MstLeaveType> oList = new List<MstLeaveType>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstLeaveTypes.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstLeaveType oMstLeaveType)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveType.CreatedDate = DateTime.Now;
                    _DBContext.MstLeaveTypes.Add(oMstLeaveType);
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
        public async Task<ApiResponseModel> Update(MstLeaveType oMstLeaveType)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveType.UpdatedDate = DateTime.Now;
                    _DBContext.MstLeaveTypes.Update(oMstLeaveType);
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
