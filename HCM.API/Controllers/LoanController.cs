using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.Attendance;
using HCM.API.Interfaces.Loan;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private ITrnsLoanRequest _trnsLoanRequest;

        public LoanController(ITrnsLoanRequest trnsLoanRequest)
        {
            _trnsLoanRequest = trnsLoanRequest;
        }

        #region Trns Loan Request

        [Route("getAllLoanRequest")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoanRequest()
        {
            List<TrnsLoanRequest> oTrnsLoanRequest = new List<TrnsLoanRequest>();
            try
            {
                oTrnsLoanRequest = await _trnsLoanRequest.GetAllData();
                if (oTrnsLoanRequest == null)
                {
                    return BadRequest(oTrnsLoanRequest);
                }
                else
                {
                    return Ok(oTrnsLoanRequest);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLoanRequest")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsLoanRequest pTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLoanRequest.Insert(pTrnsLoanRequest);
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

        [Route("updateLoanRequest")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsLoanRequest pTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLoanRequest.Update(pTrnsLoanRequest);
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

        [Route("addLoanRequestList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsLoanRequest> pTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLoanRequest.Insert(pTrnsLoanRequest);
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

        [Route("updateLoanRequestList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsLoanRequest> pTrnsLoanRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLoanRequest.Update(pTrnsLoanRequest);
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
