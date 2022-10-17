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
        private ICfgApprovalStage _cfgApprovalStage;
        private ICfgApprovalTemplate _cfgApprovalTemplate;

        public ApprovalSetupController(ICfgApprovalStage mstStages, ICfgApprovalTemplate cfgApprovalTemplate)
        {
            _cfgApprovalStage = mstStages;
            _cfgApprovalTemplate = cfgApprovalTemplate;
        }

        #region CfgApprovalStage

        [Route("getAllStage")]
        [HttpGet]
        public async Task<IActionResult> GetAllStage()
        {
            List<CfgApprovalStage> oCfgApprovalStage = new List<CfgApprovalStage>();
            try
            {
                oCfgApprovalStage = await _cfgApprovalStage.GetAllData();
                if (oCfgApprovalStage == null)
                {
                    return BadRequest(oCfgApprovalStage);
                }
                else
                {
                    return Ok(oCfgApprovalStage);
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
        public async Task<IActionResult> Add([FromBody] CfgApprovalStage pCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _cfgApprovalStage.Insert(pCfgApprovalStage);
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
        public async Task<IActionResult> Update([FromBody] CfgApprovalStage pCfgApprovalStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _cfgApprovalStage.Update(pCfgApprovalStage);
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

        #region CfgApprovalTemplate

        [Route("getAllApprovalTemplate")]
        [HttpGet]
        public async Task<IActionResult> getAllApprovalTemplate()
        {
            List<CfgApprovalTemplate> oCfgApprovalTemplate = new List<CfgApprovalTemplate>();
            try
            {
                oCfgApprovalTemplate = await _cfgApprovalTemplate.GetAllData();
                if (oCfgApprovalTemplate == null)
                {
                    return BadRequest(oCfgApprovalTemplate);
                }
                else
                {
                    return Ok(oCfgApprovalTemplate);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addApprovalTemplate")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CfgApprovalTemplate pCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _cfgApprovalTemplate.Insert(pCfgApprovalTemplate);
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

        [Route("updateApprovalTemplate")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CfgApprovalTemplate pCfgApprovalTemplate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _cfgApprovalTemplate.Update(pCfgApprovalTemplate);
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

        [Route("GetApprovalForm")]
        [HttpGet]
        public async Task<IActionResult> GetApprovalForm()
        {
            List<MstForm> oMstForm = new List<MstForm>();
            try
            {
                oMstForm = await _cfgApprovalTemplate.GetApprovalDocs();
                if (oMstForm == null)
                {
                    return BadRequest(oMstForm);
                }
                else
                {
                    return Ok(oMstForm);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        //[Route("getAllDocApproval")]
        //[HttpGet]
        //public async Task<IActionResult> GetAlerts(int UserID, string DocStatus)
        //{
        //    List<DocApproval> oDocApproval = new List<DocApproval>();
        //    try
        //    {
        //        oDocApproval = await _mstApprovalSetup.GetAlerts(UserID, DocStatus);
        //        if (oDocApproval == null)
        //        {
        //            return BadRequest(oDocApproval);
        //        }
        //        else
        //        {
        //            return Ok(oDocApproval);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return BadRequest("Something went wrong.");
        //    }
        //}

        //[Route("updateDocApprovalStatus")]
        //[HttpPost]
        //public async Task<IActionResult> UpdateDocApprovalStatus([FromBody] DocApproval pDocApproval)
        //{
        //    DocApproval oDocApproval = new DocApproval();
        //    try
        //    {
        //        oDocApproval = await _mstApprovalSetup.UpdateDocApprStatus(pDocApproval);
        //        if (oDocApproval == null)
        //        {
        //            return BadRequest(oDocApproval);
        //        }
        //        else
        //        {
        //            return Ok(oDocApproval);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return BadRequest("Something went wrong.");
        //    }
        //}

        #endregion
    }
}
