using HCM.API.Models;

namespace HCM.API.Interfaces.SAPData
{
    public interface ISAPData
    {
        List<SAPModels> GetExchangeRateFromSAP(string DocDate);

        List<SAPModels> GetCurrencyFromSAP();

        List<SAPModels> GetItemFromSAP(string clause);
        List<SAPModels> GetAllItemFromSAP();

        List<SAPModels> GetItemFromVOHSAP(string clause, string year, string month);

        List<SAPModels> GetExpenseAccountFromSAP(string clause);

        List<SAPModels> GetCustomerFromSAP();

        List<SAPModels> GetBOMProductFromSAP();

        List<SAPModels> GetBOMItemDetailFromSAP(string ProductCode);
    }
}