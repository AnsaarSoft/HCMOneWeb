﻿using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstBonus
    {
        Task<List<MstBonu>> GetAllData();
        Task<ApiResponseModel> Insert(MstBonu pMstBonus);
        Task<ApiResponseModel> Update(MstBonu pMstBonus);
    }
}