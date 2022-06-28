using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstLeaveType
    {
        Task<List<MstLeaveType>> GetAllData();
        Task<ApiResponseModel> Insert(MstLeaveType pMstLeaveType);
        Task<ApiResponseModel> Update(MstLeaveType pMstLeaveType);
    }
}