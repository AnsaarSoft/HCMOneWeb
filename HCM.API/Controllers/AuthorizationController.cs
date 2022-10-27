using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.Authorization;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IUserAuthorization _UserAuthorization;
        private IUserDataAccess _UserDataAccess;

        public AuthorizationController(IUserAuthorization UserAuthorization, IUserDataAccess userDataAccess)
        {
            _UserAuthorization = UserAuthorization;
            _UserDataAccess = userDataAccess;
        }

        #region UserAuthorization

        [Route("addUserAuth")]
        [HttpPost]
        public async Task<IActionResult> AddUserAuth([FromBody] List<UserAuthorization> pUserAuthorization)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _UserAuthorization.AddUserAuthorization(pUserAuthorization);
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


        [Route("getAllUserAuthMenu")]
        [HttpGet]
        public async Task<IActionResult> getAllUserAuthMenu(string UserID)
        {
            List<VMUserAuthorization> oVMUserAuthorization = new List<VMUserAuthorization>();
            try
            {
                oVMUserAuthorization = await _UserAuthorization.GetAllAuthorizationMenu(UserID);
                if (oVMUserAuthorization == null)
                {
                    return BadRequest(oVMUserAuthorization);
                }
                else
                {
                    return Ok(oVMUserAuthorization);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion

        #region UserDataAccess

        [Route("getAllUserDataAccess")]
        [HttpGet]
        public async Task<IActionResult> GetAllDept()
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _UserDataAccess.GetAllData();
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addUserDataAccess")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<UserDataAccess> pUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _UserDataAccess.Insert(pUserDataAccess);
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

        [Route("updateUserDataAccess")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<UserDataAccess> pUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _UserDataAccess.Update(pUserDataAccess);
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
