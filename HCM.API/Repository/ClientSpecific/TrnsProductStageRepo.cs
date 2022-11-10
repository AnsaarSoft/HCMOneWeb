using HCM.API.General;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.ClientSpecific
{
    public class TrnsProductStageRepo: ITrnsProductStage
    {

        private HCMOneContext _DBContext;

        public TrnsProductStageRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsProductStage>> GetAllData()
        {
            List<TrnsProductStage> oList = new List<TrnsProductStage>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsProductStages.Include(t => t.TrnsProductStageItems).Include(t => t.TrnsProductStageTeamLeads).Include(t => t.TrnsProductStageStations).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsProductStage oTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsProductStage.CreateDate = DateTime.Now;
                    _DBContext.TrnsProductStages.Add(oTrnsProductStage);
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
        public async Task<ApiResponseModel> Update(TrnsProductStage oTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsProductStage.UpdateDate = DateTime.Now;
                    var StageItems = _DBContext.TrnsProductStageItems.Where(x => x.Psid == oTrnsProductStage.Id).ToList();
                    _DBContext.TrnsProductStageItems.RemoveRange(StageItems);
                    
                    var StageTeamLeads = _DBContext.TrnsProductStageTeamLeads.Where(x => x.Psid == oTrnsProductStage.Id).ToList();
                    _DBContext.TrnsProductStageTeamLeads.RemoveRange(StageTeamLeads);
                    
                    var StageStations = _DBContext.TrnsProductStageStations.Where(x => x.Psid == oTrnsProductStage.Id).ToList();
                    _DBContext.TrnsProductStageStations.RemoveRange(StageStations);

                    _DBContext.TrnsProductStages.Update(oTrnsProductStage);
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
        public async Task<ApiResponseModel> Insertlist(List<TrnsProductStage> oTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsProductStages.AddRange(oTrnsProductStage);
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
        public async Task<ApiResponseModel> Updatelist(List<TrnsProductStage> oTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.TrnsProductStages.UpdateRange(oTrnsProductStage);
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
