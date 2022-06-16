using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstLeaveType
    {
        Task<List<MstLeaveType>> GetAllData();
        Task<ApiResponseModel> Update(MstLeaveType pMstLeaveType);
    }
}
