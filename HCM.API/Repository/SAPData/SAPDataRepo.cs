using HCM.API.General;
using HCM.API.Interfaces.SAPData;
using HCM.API.Models;
using Microsoft.Data.SqlClient;

namespace HCM.API.Repository.SAPData
{
    public class SAPDataRepo : ISAPData
    {
        private IConfiguration configuration;

        public SAPDataRepo(IConfiguration pconfiguration)
        {
            configuration = pconfiguration;
        }

        #region ExchangeRate

        public List<SAPModels> GetExchangeRateFromSAP(string DocDate)
        {
            List<SAPModels> oList = new List<SAPModels>();
            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string formatDocDate = Convert.ToDateTime(DocDate).ToString("yyyy-MM-dd");
                    string StrQuery = $@"select Currency,Rate,RateDate from ORTT where RateDate = '{formatDocDate}'";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oExchangeRateObjects = new SAPModels();
                        oExchangeRateObjects.Currency = Convert.ToString(rdr["Currency"]);
                        oExchangeRateObjects.Rate = Convert.ToDouble(rdr["Rate"]);
                        oExchangeRateObjects.RateDate = Convert.ToString(rdr["RateDate"]);
                        oList.Add(oExchangeRateObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion ExchangeRate

        #region Currency

        public List<SAPModels> GetCurrencyFromSAP()
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select CurrCode,CurrName from OCRN";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oCurrencyObjects = new SAPModels();
                        oCurrencyObjects.CurrCode = Convert.ToString(rdr["CurrCode"]);
                        oCurrencyObjects.CurrName = Convert.ToString(rdr["CurrName"]);
                        oList.Add(oCurrencyObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion Currency

        #region Items

        public List<SAPModels> GetItemFromSAP(string clause)
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select ItemCode,ItemName,U_Item_Department from OITM where 1=1 and {clause}";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oItemObjects = new SAPModels();
                        oItemObjects.ItemCode = Convert.ToString(rdr["ItemCode"]);
                        oItemObjects.ItemName = Convert.ToString(rdr["ItemName"]);
                        oItemObjects.U_Item_Department = Convert.ToString(rdr["U_Item_Department"]);
                        oList.Add(oItemObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }
        public List<SAPModels> GetAllItemFromSAP()
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select ItemCode,ItemName,ItmsGrpCod from OITM";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oItemObjects = new SAPModels();
                        oItemObjects.ItemCode = Convert.ToString(rdr["ItemCode"]);
                        oItemObjects.ItemName = Convert.ToString(rdr["ItemName"]);
                        oItemObjects.ItemGroupCode = Convert.ToInt32(rdr["ItmsGrpCod"]);
                        oList.Add(oItemObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion Items

        #region Customer

        public List<SAPModels> GetCustomerFromSAP()
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select CardCode,CardName from OCRD where CardType = 'C'";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oCustomerObjects = new SAPModels();
                        oCustomerObjects.CardCode = Convert.ToString(rdr["CardCode"]);
                        oCustomerObjects.CardName = Convert.ToString(rdr["CardName"]);
                        oList.Add(oCustomerObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion Customer

        #region BOM Product

        public List<SAPModels> GetBOMProductFromSAP()
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select Code,Name,U_Dept from OITT";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oBOMProductObjects = new SAPModels();
                        oBOMProductObjects.Code = Convert.ToString(rdr["Code"]);
                        oBOMProductObjects.Name = Convert.ToString(rdr["Name"]);
                        oBOMProductObjects.U_Dept = Convert.ToString(rdr["U_Dept"]);
                        oList.Add(oBOMProductObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion BOM Product

        #region BOM Item Detail

        public List<SAPModels> GetBOMItemDetailFromSAP(string ProductCode)
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select t1.Code,t2.ItemName,t1.Quantity,t2.InvntryUom from OITT t0
                                        inner join ITT1 t1 on t0.Code=t1.Father
                                        inner join OITM t2 on t2.ItemCode=t1.Code
                                        where t1.Father = '{ProductCode}'";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oBOMItemDetailObjects = new SAPModels();
                        oBOMItemDetailObjects.BOMItemCode = Convert.ToString(rdr["Code"]);
                        oBOMItemDetailObjects.BOMItemName = Convert.ToString(rdr["ItemName"]);
                        oBOMItemDetailObjects.BOMQuantity = Convert.ToDouble(rdr["Quantity"]);
                        oBOMItemDetailObjects.BOMUOM = Convert.ToString(rdr["InvntryUom"]);
                        oList.Add(oBOMItemDetailObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion BOM Item Detail

        #region Expense Account

        public List<SAPModels> GetExpenseAccountFromSAP(string Clause)
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"select AcctCode,AcctName from OACT where 1=1 and {Clause}";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oBOMItemDetailObjects = new SAPModels();
                        oBOMItemDetailObjects.AcctCode = Convert.ToString(rdr["AcctCode"]);
                        oBOMItemDetailObjects.AcctName = Convert.ToString(rdr["AcctName"]);
                        oList.Add(oBOMItemDetailObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion Expense Account

        #region Items VOH

        public List<SAPModels> GetItemFromVOHSAP(string clause, string year, string month)
        {
            List<SAPModels> oList = new List<SAPModels>();

            try
            {
                string constr = configuration.GetSection("SAPConnection").Value.ToString();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    string StrQuery = $@"SELECT a.ItemCode, a.ItemName, sum(b.Quantity) as Quantity,a.CreateDate
FROM OITM as a
INNER JOIN RDR1 b ON a.ItemCode=b.ItemCode
where 1=1 and a.ItmsGrpCod={clause} and  DATEPART(yy, a.CreateDate) ={year} and DATEPART(mm,a.CreateDate)={month}
GROUP BY a.ItemCode, a.ItemName,a.CreateDate,a.CreateDate
";
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand command = new(StrQuery, conn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        SAPModels oItemObjects = new SAPModels();
                        oItemObjects.ItemCodeVOH = Convert.ToString(rdr["ItemCode"]);
                        oItemObjects.ItemNameVOH = Convert.ToString(rdr["ItemName"]);
                        oItemObjects.ItemQuantityVOH = Convert.ToString(rdr["Quantity"]);
                        oItemObjects.ItemYear = Convert.ToString(rdr["CreateDate"]);
                        oItemObjects.ItemMonth = Convert.ToString(rdr["CreateDate"]);

                        oList.Add(oItemObjects);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                oList = null;
            }
            return oList;
        }

        #endregion Items VOH
    }
}