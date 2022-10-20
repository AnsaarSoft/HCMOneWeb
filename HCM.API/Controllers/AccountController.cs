using HCM.API.General;
using HCM.API.Interfaces.Account;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMstUser _mstUser;
        public AccountController(IMstUser mstUser)
        {
            _mstUser = mstUser;
        }

        #region MST User

        [Route("getAllUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            List<MstEmployee> oMstEmployee = new List<MstEmployee>();
            try
            {
                oMstEmployee = await _mstUser.GetAllData();
                if (oMstEmployee == null)
                {
                    return BadRequest(oMstEmployee);
                }
                else
                {
                    return Ok(oMstEmployee);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("validateLogin")]
        [HttpGet]
        public async Task<IActionResult> ValidateLogin([FromBody] MstEmployee pMstEmployee)
        {
            MstEmployee oMstEmployee = new MstEmployee();
            try
            {
                oMstEmployee = await _mstUser.Login(pMstEmployee);
                if (oMstEmployee == null)
                {
                    return BadRequest(oMstEmployee);
                }
                else
                {
                    return Ok(oMstEmployee);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("generateOTP")]
        [HttpGet]
        public async Task<IActionResult> GenerateOTP([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.GenerateOTP(pMstEmployee);
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

        [Route("authenticateOTP")]
        [HttpGet]
        public async Task<IActionResult> AuthenticateOTP([FromBody] PasswordReset pPasswordReset)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.AuthenticateOTP(pPasswordReset);
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

        [Route("changePassword")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.ChangePassword(pMstEmployee);
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

        [Route("addUser")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.Insert(pMstEmployee);
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

        [Route("updateUser")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.Update(pMstEmployee);
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
