using HCM.API.General;
using HCM.API.Interfaces.Attendance;
using HCM.API.Interfaces.Bonus;
using HCM.API.Models;

namespace HCM.API.Repository.Bonus
{
    public class TrnsEmployeeBonusRepo : ITrnsEmployeeBonus
    {
        private HCMOneContext _DBContext;

        public TrnsEmployeeBonusRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsEmployeeBonu>> GetAllData()
        {
            List<TrnsEmployeeBonu> oList = new List<TrnsEmployeeBonu>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsEmployeeBonus.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsEmployeeBonu oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeBonu.CreatedDate = DateTime.Now;
                    _DBContext.TrnsEmployeeBonus.Add(oTrnsEmployeeBonu);
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
        public async Task<ApiResponseModel> Update(TrnsEmployeeBonu oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsEmployeeBonu.UpdatedDate = DateTime.Now;
                    _DBContext.TrnsEmployeeBonus.Update(oTrnsEmployeeBonu);
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
        public async Task<ApiResponseModel> Insert(List<TrnsEmployeeBonu> oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsEmployeeBonus.AddRange(oTrnsEmployeeBonu);
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
        public async Task<ApiResponseModel> Update(List<TrnsEmployeeBonu> oTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsEmployeeBonus.UpdateRange(oTrnsEmployeeBonu);
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
