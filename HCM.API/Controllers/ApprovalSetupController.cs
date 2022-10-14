using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.General;
using HCM.API.Models;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalSetupController : ControllerBase
    {
        private IMstStages _mstStages;

        public ApprovalSetupController(IMstStages mstStages)
        {
            _mstStages = mstStages;
        }

        #region MstStages

        [Route("getAllStage")]
        [HttpGet]
        public async Task<IActionResult> GetAllStage()
        {
            List<MstStage> oMstStages = new List<MstStage>();
            try
            {
                oMstStages = await _mstStages.GetAllData();
                if (oMstStages == null)
                {
                    return BadRequest(oMstStages);
                }
                else
                {
                    return Ok(oMstStages);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addStage")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstStage pMstStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStages.Insert(pMstStage);
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

        [Route("updateStage")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstStage pMstStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStages.Update(pMstStage);
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
