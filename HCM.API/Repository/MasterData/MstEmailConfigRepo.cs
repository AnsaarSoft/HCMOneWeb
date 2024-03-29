﻿using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;

namespace HCM.API.Repository.MasterData
{
    public class MstEmailConfigRepo : IMstEmailConfig
    {
        private HCMOneContext _DBContext;

        public MstEmailConfigRepo(HCMOneContext DBContext)
        {
            _DBContext = DBContext;
        }

        public async Task<MstEmailConfig> GetData()
        {
            MstEmailConfig mstEmailConfig = new MstEmailConfig();
            try
            {
                await Task.Run(() =>
                {
                    mstEmailConfig = _DBContext.MstEmailConfigs.FirstOrDefault();
                });

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return mstEmailConfig;
        }

        public async Task<ApiResponseModel> Update(MstEmailConfig oMstEmailConfig)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                await Task.Run(() =>
                {
                    _DBContext.MstEmailConfigs.Update(oMstEmailConfig);
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
