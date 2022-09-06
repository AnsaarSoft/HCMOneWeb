using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstGrading
    {
        Task<List<MstGrading>> GetAllData();
        Task<ApiResponseModel> Insert(MstGrading oMstGrading);
        Task<ApiResponseModel> Update(MstGrading oMstGrading);
        Task<ApiResponseModel> Insert(List<MstGrading> oMstGrading);
        Task<ApiResponseModel> Update(List<MstGrading> oMstGrading);
    }
}
