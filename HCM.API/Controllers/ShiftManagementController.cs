using HCM.API.General;
using HCM.API.Interfaces.ShiftManagement;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftManagementController : ControllerBase
    {
        private ITrnsAttendanceRegister _trnsAttendanceRegister;

        public ShiftManagementController(ITrnsAttendanceRegister trnsAttendanceRegister)
        {
            _trnsAttendanceRegister = trnsAttendanceRegister;
        }

        #region Shift Scheduler

        [Route("getAllTrnsAttendanceRegister")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<TrnsAttendanceRegister> oTrnsAttendanceRegister = new List<TrnsAttendanceRegister>();
            try
            {
                oTrnsAttendanceRegister = await _trnsAttendanceRegister.GetAllData();
                if (oTrnsAttendanceRegister == null)
                {
                    return BadRequest(oTrnsAttendanceRegister);
                }
                else
                {
                    return Ok(oTrnsAttendanceRegister);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addTrnsAttendanceRegister")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsAttendanceRegister pTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAttendanceRegister.Insert(pTrnsAttendanceRegister);
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

        [Route("updateTrnsAttendanceRegister")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsAttendanceRegister pTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAttendanceRegister.Update(pTrnsAttendanceRegister);
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

        [Route("addTrnsAttendanceRegisterList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsAttendanceRegister> pTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAttendanceRegister.Insert(pTrnsAttendanceRegister);
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

        [Route("updateTrnsAttendanceRegisterList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsAttendanceRegister> pTrnsAttendanceRegister)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsAttendanceRegister.Update(pTrnsAttendanceRegister);
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
