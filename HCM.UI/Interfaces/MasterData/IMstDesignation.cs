using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstDesignation
    {
        Task<List<MstDesignation>> GetAllData();
        Task<ApiResponseModel> Insert(MstDesignation oMstDesignation);
        Task<ApiResponseModel> Update(MstDesignation oMstDesignation);
        Task<ApiResponseModel> Insert(List<MstDesignation> oMstDesignation);
        Task<ApiResponseModel> Update(List<MstDesignation> oMstDesignation);
    }
}
