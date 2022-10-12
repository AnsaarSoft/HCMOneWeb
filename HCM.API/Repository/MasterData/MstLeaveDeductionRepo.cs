using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstLeaveDeductionRepo : IMstLeaveDeduction
    {
        private HCMOneContext _DBContext;

        public MstLeaveDeductionRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstLeaveDeduction>> GetAllData()
        {
            List<MstLeaveDeduction> oList = new List<MstLeaveDeduction>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstLeaveDeductions.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstLeaveDeduction oMstLeaveDeduction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveDeduction.CreateDate = DateTime.Now;
                    _DBContext.MstLeaveDeductions.Add(oMstLeaveDeduction);
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
        public async Task<ApiResponseModel> Update(MstLeaveDeduction oMstLeaveDeduction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstLeaveDeduction.UpdateDate = DateTime.Now;
                    _DBContext.MstLeaveDeductions.Update(oMstLeaveDeduction);
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
