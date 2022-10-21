using HCM.API.General;
using HCM.API.Interfaces.Advance;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private ITrnsAdvanceRequest _trnsAdvanceRequest;

        public AdvanceController(ITrnsAdvanceRequest trnsAdvanceRequest)
        {
            _trnsAdvanceRequest = trnsAdvanceRequest;
        }

        #region Trns Advance Request

        [Route("getAllAdvanceRequest")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdvanceRequest()
        {
            List<TrnsAdvanceRequest> oTrnsAdvanceRequest = new List<TrnsAdvanceRequest>();
            try
            {
                oTrnsAdvanceRequest = await _trnsAdvanceRequest.GetAllData();
                if (oTrnsAdvanceRequest == null)
                {
                    return BadRequest(oTrnsAdvanceRequest);
                }
                else
                {
                    return Ok(oTrnsAdvanceRequest);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addAdvanceRequest")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsAdvanceRequest pTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAdvanceRequest.Insert(pTrnsAdvanceRequest);
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

        [Route("updateAdvanceRequest")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsAdvanceRequest pTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAdvanceRequest.Update(pTrnsAdvanceRequest);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else if (response.Id == 2)
                {
                    return BadRequest("Cant update document, pending for approval");
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

        [Route("addAdvanceRequestList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsAdvanceRequest> pTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAdvanceRequest.Insert(pTrnsAdvanceRequest);
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

        [Route("updateAdvanceRequestList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsAdvanceRequest> pTrnsAdvanceRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAdvanceRequest.Update(pTrnsAdvanceRequest);
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
