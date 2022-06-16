using HCM.API.General;
using HCM.API.Interfaces.MasterElement;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterElementController : ControllerBase
    {
        private IMstElement _mstElement;
        private IMstLove _mstLove;
        private IMstOverTime _mstOverTime;

        public MasterElementController(IMstElement mstElement, IMstLove mstLove, IMstOverTime mstOverTime)
        {
            _mstElement = mstElement;
            _mstLove = mstLove;
            _mstOverTime = mstOverTime;
        }

        #region MST Element

        [Route("getAllElement")]
        [HttpGet]
        public async Task<IActionResult> GetAllElement()
        {
            List<MstElement> oMstElement = new List<MstElement>();
            try
            {
                oMstElement = await _mstElement.GetAllData();
                if (oMstElement == null)
                {
                    return BadRequest(oMstElement);
                }
                else
                {
                    return Ok(oMstElement);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addElement")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstElement pMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstElement.Insert(pMstElement);                
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

        [Route("updateElement")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstElement pMstElement)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstElement.Update(pMstElement);
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

        #region MST Love

        [Route("getAllLove")]
        [HttpGet]
        public async Task<IActionResult> GetAllLove()
        {
            List<MstLove> oMstLove = new List<MstLove>();
            try
            {
                oMstLove = await _mstLove.GetAllData();
                if (oMstLove == null)
                {
                    return BadRequest(oMstLove);
                }
                else
                {
                    return Ok(oMstLove);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion

        #region MST OverTime

        [Route("getAllOverTime")]
        [HttpGet]
        public async Task<IActionResult> GetAllOverTime()
        {
            List<MstOverTime> oMstOverTime = new List<MstOverTime>();
            try
            {
                oMstOverTime = await _mstOverTime.GetAllData();
                if (oMstOverTime == null)
                {
                    return BadRequest(oMstOverTime);
                }
                else
                {
                    return Ok(oMstOverTime);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addOverTime")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstOverTime pMstOverTime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstOverTime.Insert(pMstOverTime);
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

        [Route("updateOverTime")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstOverTime pMstOverTime)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstOverTime.Update(pMstOverTime);
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
