using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;

namespace HCM.API.Repository.MasterElement
{
    public class MstElementRepo : IMstElement
    {
        private HCMOneContext _DBContext;

        public MstElementRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstElement>> GetAllData()
        {
            List<MstElement> oList = new List<MstElement>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstElements.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstElement oMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstElement.CreateDate = DateTime.Now;
                    _DBContext.MstElements.Add(oMstElement);                   
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
        public async Task<ApiResponseModel> Update(MstElement oMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstElement.UpdateDate = DateTime.Now;
                    _DBContext.MstElements.Update(oMstElement);
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
