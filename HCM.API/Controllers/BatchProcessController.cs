using HCM.API.General;
using HCM.API.Interfaces.Batch;
using HCM.API.Interfaces.Bonus;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchProcessController : ControllerBase
    {
        private ITrnsBatchProcess _trnsBatch;

        public BatchProcessController(ITrnsBatchProcess trnsBatch)
        {
            _trnsBatch = trnsBatch;
        }

        #region Trns Batch

        [Route("getAllBatch")]
        [HttpGet]
        public async Task<IActionResult> GetAllBatch()
        {
            List<TrnsBatch> oTrnsBatch = new List<TrnsBatch>();
            try
            {
                oTrnsBatch = await _trnsBatch.GetAllData();
                if (oTrnsBatch == null)
                {
                    return BadRequest(oTrnsBatch);
                }
                else
                {
                    return Ok(oTrnsBatch);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addBatch")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsBatch pTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsBatch.Insert(pTrnsBatch);
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

        [Route("updateBatch")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsBatch pTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsBatch.Update(pTrnsBatch);
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

        [Route("addBatchList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsBatch> pTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsBatch.Insert(pTrnsBatch);
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

        [Route("updateBatchList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsBatch> pTrnsBatch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsBatch.Update(pTrnsBatch);
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
