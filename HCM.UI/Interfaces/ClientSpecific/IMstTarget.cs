using HCM.API.Models;

namespace HCM.UI.Interfaces.ClientSpecific
{
    public interface IMstTarget
    {
        Task<List<MstTarget>> GetAllData();
        Task<ApiResponseModel> Insert(MstTarget pMstTarget);
        Task<ApiResponseModel> Update(MstTarget pMstTarget);
        Task<ApiResponseModel> Insert(List<MstTarget> pMstTarget);
        Task<ApiResponseModel> Update(List<MstTarget> pMstTarget);
    }
}
