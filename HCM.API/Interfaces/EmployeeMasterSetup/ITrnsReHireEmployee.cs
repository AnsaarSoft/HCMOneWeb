﻿using HCM.API.Models;

namespace HCM.API.Interfaces.EmployeeMasterSetup
{
    public interface ITrnsReHireEmployee
    {
        Task<List<TrnsReHireEmployee>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsReHireEmployee pTrnsReHireEmployee);
        Task<ApiResponseModel> Update(TrnsReHireEmployee pTrnsReHireEmployee);
    }
}