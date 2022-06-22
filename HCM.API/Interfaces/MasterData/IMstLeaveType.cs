using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstLeaveType
    {
        Task<List<MstLeaveType>> GetAllData();
        Task<ApiResponseModel> Update(MstLeaveType pMstLeaveType);
        Task<ApiResponseModel> Insert(MstLeaveType pMstLeaveType);
    }
}