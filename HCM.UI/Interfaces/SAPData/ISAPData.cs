using HCM.API.Models;

namespace HCM.UI.Interfaces.SAPData
{
    public interface ISAPData
    {
        Task<List<SAPModels>> GetExchangeRateFromSAP(string DocDate);
        Task<List<SAPModels>> GetCurrencyFromSAP();
        Task<List<SAPModels>> GetProductFromSap();
        Task<List<SAPModels>> GetCustomerFromSAP();
        Task<List<SAPModels>> GetItemsFromSAP(string clause);
        Task<List<SAPModels>> GetAllItemsFromSAP();
        Task<List<SAPModels>> GetItemsVOHFromSAP(string clause, string year, string month);
        Task<List<SAPModels>> GetAccountsFromSAP(string Clause);
        Task<List<SAPModels>> GetBomItemsFromSAP(string ProductCode);
    }
}