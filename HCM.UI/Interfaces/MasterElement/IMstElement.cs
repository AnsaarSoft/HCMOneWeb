using HCM.API.Models;

namespace HCM.UI.Interfaces.MasterElement
{
    public interface IMstElement
    {
        Task<List<MstElement>> GetAllData();
        Task<ApiResponseModel> Insert(MstElement oMstElement);
        Task<ApiResponseModel> Update(MstElement oMstElement);
    }
}
