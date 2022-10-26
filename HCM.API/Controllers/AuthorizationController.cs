using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ApprovalSetup;
using HCM.API.Interfaces.Authorization;
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

        public AuthorizationController(IUserAuthorization UserAuthorization)
        {
            _UserAuthorization = UserAuthorization;
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
    }
}
