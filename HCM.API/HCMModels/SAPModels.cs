namespace HCM.API.Models
{
    public class SAPModels
    {
        #region ExchangeRate

        public string Currency { get; set; }
        public double Rate { get; set; }
        public string RateDate { get; set; }

        #endregion ExchangeRate

        #region Currency

        public string CurrCode { get; set; }
        public string CurrName { get; set; }

        #endregion Currency

        #region Items

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string U_Item_Department { get; set; }
        public int ItemGroupCode { get; set; }

        #endregion Items

        #region ItemsVOH

        public string ItemCodeVOH { get; set; }
        public string ItemNameVOH { get; set; }
        public string ItemQuantityVOH { get; set; }
        public string ItemYear { get; set; }
        public string ItemMonth { get; set; }

        #endregion ItemsVOH

        #region Customer

        public string CardCode { get; set; }
        public string CardName { get; set; }

        #endregion Customer

        #region BOM Product

        public string Code { get; set; }
        public string Name { get; set; }
        public string U_Dept { get; set; }

        #endregion BOM Product

        #region BOM Item Detail

        public string BOMItemCode { get; set; }
        public string BOMItemName { get; set; }
        public double BOMQuantity { get; set; }
        public string BOMUOM { get; set; }

        #endregion BOM Item Detail

        #region Expense Account

        public string AcctCode { get; set; }
        public string AcctName { get; set; }

        #endregion Expense Account

        public string DialogFor { get; set; }
        public string FoamName { get; set; }
    }
}