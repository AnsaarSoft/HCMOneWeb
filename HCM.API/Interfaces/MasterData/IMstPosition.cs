﻿using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstPosition
    {
        Task<List<MstPosition>> GetAllData();
        Task<ApiResponseModel> Insert(MstPosition oMstPosition);
        Task<ApiResponseModel> Update(MstPosition oMstPosition);
    }
}
