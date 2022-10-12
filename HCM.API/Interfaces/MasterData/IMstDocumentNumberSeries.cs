using HCM.API.Models;

namespace HCM.API.Interfaces.MasterData
{
    public interface IMstDocumentNumberSeries
    {
        Task<List<MstDocumentNumberSeries>> GetAllData();
        Task<ApiResponseModel> Insert(MstDocumentNumberSeries oMstDocumentNumberSeries);
        Task<ApiResponseModel> Update(MstDocumentNumberSeries oMstDocumentNumberSeries);
        Task<ApiResponseModel> Insert(List<MstDocumentNumberSeries> oMstDocumentNumberSeries);
        Task<ApiResponseModel> Update(List<MstDocumentNumberSeries> oMstDocumentNumberSeries);
    }
}
