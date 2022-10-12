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

        #region MST Department

        [Route("getAllUser")]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            List<MstUser> oMstUser = new List<MstUser>();
            try
            {
                oMstUser = await _mstUser.GetAllData();
                if (oMstUser == null)
                {
                    return BadRequest(oMstUser);
                }
                else
                {
                    return Ok(oMstUser);
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
        public async Task<IActionResult> ValidateLogin([FromBody] MstUser pMstUser)
        {
            MstUser oMstUser = new MstUser();
            try
            {
                oMstUser = await _mstUser.Login(pMstUser);
                if (oMstUser == null)
                {
                    return BadRequest(oMstUser);
                }
                else
                {
                    return Ok(oMstUser);
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
        public async Task<IActionResult> GenerateOTP([FromBody] MstUser pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.GenerateOTP(pMstUser);
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
        public async Task<IActionResult> ChangePassword([FromBody] MstUser pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.ChangePassword(pMstUser);
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
        public async Task<IActionResult> Add([FromBody] MstUser pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.Insert(pMstUser);
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
        public async Task<IActionResult> Update([FromBody] MstUser pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUser.Update(pMstUser);
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
