using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using Microsoft.EntityFrameworkCore;
using HCM.API.Models;
using HCM.API.HCMModels;


namespace HCM.API.Repository.EmployeeMasterSetup
{
    public class TrnsSingleEntryOtrequestRepo : ITrnsSingleEntryOtrequest
    {
        private HCMOneContext _DBContext;

        public TrnsSingleEntryOtrequestRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<TrnsSingleEntryOtrequest>> GetAllData()
        {
            List<TrnsSingleEntryOtrequest> oList = new List<TrnsSingleEntryOtrequest>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.TrnsSingleEntryOtrequests.Include(t=>t.TrnsSingleEntryOtdetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(TrnsSingleEntryOtrequest oTrnsSingleEntryOtrequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsSingleEntryOtrequest.CreatedDate = DateTime.Now;
                    _DBContext.TrnsSingleEntryOtrequests.Add(oTrnsSingleEntryOtrequest);
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
        public async Task<ApiResponseModel> Update(TrnsSingleEntryOtrequest oTrnsSingleEntryOtrequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oTrnsSingleEntryOtrequest.UpdatedDate = DateTime.Now;
                    var Detail = _DBContext.TrnsSingleEntryOtdetails.Where(x => x.SingleEntryOtid == oTrnsSingleEntryOtrequest.Id).ToList();
                    _DBContext.TrnsSingleEntryOtdetails.RemoveRange(Detail);
                    _DBContext.TrnsSingleEntryOtrequests.Update(oTrnsSingleEntryOtrequest);
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
