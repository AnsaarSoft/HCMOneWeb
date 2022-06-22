﻿using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstPositionRepo : IMstPosition
    {
        private WebHCMOneContext _DBContext;

        public MstPositionRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstPosition>> GetAllData()
        {
            List<MstPosition> oList = new List<MstPosition>();
            try
            {
                await Task.Run(() =>
                {
                    //oList = _DBContext.MstDepartments.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstDepartments
                    //         where a.FlgActive == true
                    //         select a).ToList();
                    oList = _DBContext.MstPositions.ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstPosition oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstPosition.CreatedBy = "manager";
                    oMstPosition.CreatedDate = DateTime.Now;
                    _DBContext.MstPositions.Add(oMstPosition);
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
        public async Task<ApiResponseModel> Update(MstPosition oMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstPosition.UpdatedBy = "manager";
                    oMstPosition.UpdatedDate = DateTime.Now;
                    _DBContext.MstPositions.Update(oMstPosition);
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
