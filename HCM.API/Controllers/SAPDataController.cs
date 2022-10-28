using HCM.API.General;
using HCM.API.Interfaces.SAPData;
using HCM.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SAPDataController : ControllerBase
    {
        private ISAPData _repo;

        public SAPDataController(ISAPData sAPObjects)
        {
            _repo = sAPObjects;
        }

        #region ExchangeRate

        [Route("getExchangeRateFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetExchangeRate(string DocDate)
        {
            List<SAPModels> oExchangeRateObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oExchangeRateObjects = _repo.GetExchangeRateFromSAP(DocDate);
                if (oExchangeRateObjects == null)
                {
                    return BadRequest(oExchangeRateObjects);
                }
                else
                {
                    return Ok(oExchangeRateObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion ExchangeRate

        #region Currency

        [Route("getCurrencyFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        {
            List<SAPModels> oCurrencyObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oCurrencyObjects = _repo.GetCurrencyFromSAP();
                if (oCurrencyObjects == null)
                {
                    return BadRequest(oCurrencyObjects);
                }
                else
                {
                    return Ok(oCurrencyObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion Currency

        #region Items

        [Route("getItemsFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetItems(string clause)
        {
            List<SAPModels> oItemObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oItemObjects = _repo.GetItemFromSAP(clause);
                if (oItemObjects == null)
                {
                    return BadRequest(oItemObjects);
                }
                else
                {
                    return Ok(oItemObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("getAllItemsFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            List<SAPModels> oItemObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oItemObjects = _repo.GetAllItemFromSAP();
                if (oItemObjects == null)
                {
                    return BadRequest(oItemObjects);
                }
                else
                {
                    return Ok(oItemObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion Items

        #region Customer

        [Route("getCustomerFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            List<SAPModels> oCustomerObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oCustomerObjects = _repo.GetCustomerFromSAP();
                if (oCustomerObjects == null)
                {
                    return BadRequest(oCustomerObjects);
                }
                else
                {
                    return Ok(oCustomerObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion Customer

        #region BOM Product

        [Route("getBOMProductFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            List<SAPModels> oProductObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oProductObjects = _repo.GetBOMProductFromSAP();
                if (oProductObjects == null)
                {
                    return BadRequest(oProductObjects);
                }
                else
                {
                    return Ok(oProductObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion BOM Product

        #region BOM Item Detail

        [Route("getBOMItemDetailFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetBOMItemDetail(string ProductCode)
        {
            List<SAPModels> oBOMItemDetailObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oBOMItemDetailObjects = _repo.GetBOMItemDetailFromSAP(ProductCode);
                if (oBOMItemDetailObjects == null)
                {
                    return BadRequest(oBOMItemDetailObjects);
                }
                else
                {
                    return Ok(oBOMItemDetailObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion BOM Item Detail

        #region Expense Account

        [Route("getExpenseAccountFromSAP")]
        [HttpGet]
        public async Task<IActionResult> GetExpenseAccount(string Clause)
        {
            List<SAPModels> oExpenseAccountObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oExpenseAccountObjects = _repo.GetExpenseAccountFromSAP(Clause);
                if (oExpenseAccountObjects == null)
                {
                    return BadRequest(oExpenseAccountObjects);
                }
                else
                {
                    return Ok(oExpenseAccountObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion Expense Account

        #region Items For VOH

        [Route("getItemsFromVOHSAP")]
        [HttpGet]
        public async Task<IActionResult> GetItemsVOH(string clause, string year, string month)
        {
            List<SAPModels> oItemObjects = new List<SAPModels>();
            try
            {
                await Task.Delay(2);
                oItemObjects = _repo.GetItemFromVOHSAP(clause, year, month);
                if (oItemObjects == null)
                {
                    return BadRequest(oItemObjects);
                }
                else
                {
                    return Ok(oItemObjects);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion Items For VOH
    }
}