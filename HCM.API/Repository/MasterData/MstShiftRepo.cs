﻿using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HCM.API.Repository.MasterData
{
    public class MstShiftRepo : IMstShifts
    {
        private WebHCMOneContext _DBContext;

        public MstShiftRepo(WebHCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<List<MstShift>> GetAllData()
        {
            List<MstShift> oList = new List<MstShift>();
            try
            {
                await Task.Run(() =>
                {
                    oList = _DBContext.MstShifts.Include(c => c.MstShiftsDetails).ToList();
                });
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return oList;
        }
        public async Task<ApiResponseModel> Insert(MstShift oMstShift)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstShift.CreatedDate = DateTime.Now;
                    _DBContext.MstShifts.Add(oMstShift);
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
        public async Task<ApiResponseModel> Update(MstShift oMstShift)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    oMstShift.UpdatedDate = DateTime.Now;
                    _DBContext.MstShifts.Update(oMstShift);
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
