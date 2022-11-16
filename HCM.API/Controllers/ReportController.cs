using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Interfaces.Reports;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IMstReport _mstReport;
        public ReportController(IMstReport mstReport)
        {
            _mstReport = mstReport;
        }
        
        #region Mst Report

        [Route("getAllReport")]
        [HttpGet]
        public async Task<IActionResult> getAllMstReport()
        {
            List<MstReport> oList = new List<MstReport>();
            try
            {
                oList = await _mstReport.GetAllData();
                if (oList == null)
                {
                    return BadRequest(oList);
                }
                else
                {
                    return Ok(oList);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addMstReport")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstReport pMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstReport.Insert(pMstReport);
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

        [Route("updateMstReport")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstReport pMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstReport.Update(pMstReport);
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

        [Route("addMstReportList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstReport> pMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstReport.Insert(pMstReport);
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

        [Route("updateMstReportList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstReport> pMstReport)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstReport.Update(pMstReport);
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
