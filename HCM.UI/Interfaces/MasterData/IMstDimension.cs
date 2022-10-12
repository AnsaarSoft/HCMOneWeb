using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterData
{
    public interface IMstDimension
    {
        Task<List<MstDimension>> GetAllData();
        Task<ApiResponseModel> Insert(MstDimension oMstDimension);
        Task<ApiResponseModel> Update(MstDimension oMstDimension);
        Task<ApiResponseModel> Insert(List<MstDimension> oMstDimension);
        Task<ApiResponseModel> Update(List<MstDimension> oMstDimension);
    }
}
