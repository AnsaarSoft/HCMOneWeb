using HCM.API.Models;

namespace HCM.UI.Interfaces.ClientSpecific
{
    public interface ITrnsPerPiece
    {
        Task<List<TrnsPerPieceTransaction>> GetAllData();
        Task<ApiResponseModel> Insert(TrnsPerPieceTransaction pTrnsPerPieceTransaction);
        Task<ApiResponseModel> Update(TrnsPerPieceTransaction pTrnsPerPieceTransaction);
        Task<ApiResponseModel> Insert(List<TrnsPerPieceTransaction> pTrnsPerPieceTransaction);
        Task<ApiResponseModel> Update(List<TrnsPerPieceTransaction> pTrnsPerPieceTransaction);
    }
}
