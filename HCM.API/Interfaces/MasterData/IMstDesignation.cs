using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstDesignation
    {
        Task<List<MstDesignation>> GetAllData();
        Task<ApiResponseModel> Insert(MstDesignation oMstDesignation);
        Task<ApiResponseModel> Update(MstDesignation oMstDesignation);
    }
}
