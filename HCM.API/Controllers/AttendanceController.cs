using HCM.API.General;
using HCM.API.Interfaces.Attendance;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private ITrnsTempAttendance _trnsTempAttendance;

        public AttendanceController(ITrnsTempAttendance trnsTempAttendance)
        {
            _trnsTempAttendance = trnsTempAttendance;
        }

        #region Trns Temp Attendance

        [Route("getAllTempAttendance")]
        [HttpGet]
        public async Task<IActionResult> GetAllTempAttendance()
        {
            List<TrnsTempAttendance> oTrnsTempAttendance = new List<TrnsTempAttendance>();
            try
            {
                oTrnsTempAttendance = await _trnsTempAttendance.GetAllData();
                if (oTrnsTempAttendance == null)
                {
                    return BadRequest(oTrnsTempAttendance);
                }
                else
                {
                    return Ok(oTrnsTempAttendance);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addTempAttendance")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsTempAttendance pTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsTempAttendance.Insert(pTrnsTempAttendance);
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

        [Route("updateTempAttendance")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsTempAttendance pTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsTempAttendance.Update(pTrnsTempAttendance);
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

        [Route("addTempAttendanceList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsTempAttendance> pTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsTempAttendance.Insert(pTrnsTempAttendance);
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

        [Route("updateTempAttendanceList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsTempAttendance> pTrnsTempAttendance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsTempAttendance.Update(pTrnsTempAttendance);
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
