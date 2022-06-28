using HCM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstAttendanceRules
    {
        Task<List<MstAttendanceRule>> GetAllData();
        Task<ApiResponseModel> Insert (MstAttendanceRule mstAttendanceRule);
        Task<ApiResponseModel> Update(MstAttendanceRule mstAttendanceRule);
    }
}
