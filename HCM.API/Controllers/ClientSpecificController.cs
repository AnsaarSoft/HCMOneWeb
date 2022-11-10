using HCM.API.General;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSpecificController : ControllerBase
    {
        private ITrnsProductStage _trnsProductStage;

        public ClientSpecificController(ITrnsProductStage trnsProductStage)
        {
            _trnsProductStage = trnsProductStage;
        }

        #region Production  Stages

        [Route("getAllProductStage")]
        [HttpGet]
        public async Task<IActionResult> getAllProductStage()
        {
            List<TrnsProductStage> oTrnsProductStage = new List<TrnsProductStage>();
            try
            {
                oTrnsProductStage = await _trnsProductStage.GetAllData();
                if (oTrnsProductStage == null)
                {
                    return BadRequest(oTrnsProductStage);
                }
                else
                {
                    return Ok(oTrnsProductStage);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addProductStage")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsProductStage pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Insert(pTrnsProductStage);
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

        [Route("updateProductStage")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsProductStage pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Update(pTrnsProductStage);
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

        [Route("addProductStageList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsProductStage> pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Insertlist(pTrnsProductStage);
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

        [Route("updateProductStageList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsProductStage> pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Updatelist(pTrnsProductStage);
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
