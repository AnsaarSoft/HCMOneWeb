using HCM.API.General;
using HCM.API.Interfaces.Bonus;
using HCM.API.Interfaces.Loan;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusCalController : ControllerBase
    {
        private ITrnsEmployeeBonus _trnsEmployeeBonus;

        public BonusCalController(ITrnsEmployeeBonus trnsEmployeeBonus)
        {
            _trnsEmployeeBonus = trnsEmployeeBonus;
        }

        #region Trns Employee Bonus

        [Route("getAllEmployeeBonus")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeBonus()
        {
            List<TrnsEmployeeBonu> oTrnsEmployeeBonu = new List<TrnsEmployeeBonu>();
            try
            {
                oTrnsEmployeeBonu = await _trnsEmployeeBonus.GetAllData();
                if (oTrnsEmployeeBonu == null)
                {
                    return BadRequest(oTrnsEmployeeBonu);
                }
                else
                {
                    return Ok(oTrnsEmployeeBonu);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addEmployeeBonus")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsEmployeeBonu pTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeBonus.Insert(pTrnsEmployeeBonu);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateEmployeeBonus")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsEmployeeBonu pTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeBonus.Update(pTrnsEmployeeBonu);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addEmployeeBonusList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsEmployeeBonu> pTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeBonus.Insert(pTrnsEmployeeBonu);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateEmployeeBonusList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsEmployeeBonu> pTrnsEmployeeBonu)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeBonus.Update(pTrnsEmployeeBonu);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion
    }
}
