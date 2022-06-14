using HCM.API.Models;

namespace HCM.API.Interfaces.MasterElement
{
    public interface IMstElement
    {
        Task<List<MstElement>> GetAllData();
        Task<ApiResponseModel> Insert(MstElement oMstElement);
        Task<ApiResponseModel> Update(MstElement oMstElement);
    }
}
