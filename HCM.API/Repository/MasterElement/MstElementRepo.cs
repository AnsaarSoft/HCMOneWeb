﻿using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;

namespace HCM.API.Repository.MasterElement
{
    public class MstElementRepo : IMstElement
    {
        private WebHCMOneContext _DBContext;

        public MstElementRepo(WebHCMOneContext DBContext)
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
                    //oList = _DBContext.MstDepartments.Where(a => a.FlgActive == true).ToList();
                    //oList = (from a in _DBContext.MstDepartments
                    //         where a.FlgActive == true
                    //         select a).ToList();
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
                    _DBContext.MstElements.Update(oMstElement);
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