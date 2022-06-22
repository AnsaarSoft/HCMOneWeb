using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstLeaveType
    {
        Task<List<MstLeaveType>> GetAllData();
        Task<ApiResponseModel> Insert(MstLeaveType pMstLeaveType);
        Task<ApiResponseModel> Update(MstLeaveType pMstLeaveType);
    }
}
