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
        private IDocApprovalDecesion _docApprovalDecesion;

        public ApprovalSetupController(ICfgApprovalStage mstStages, ICfgApprovalTemplate cfgApprovalTemplate, IDocApprovalDecesion docApprovalDecesion)
        {
            _cfgApprovalStage = mstStages;
            _cfgApprovalTemplate = cfgApprovalTemplate;
            _docApprovalDecesion = docApprovalDecesion;
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

        #endregion

        #region DocApprovalDecesion

        [Route("getAllDocApprovalDecesion")]
        [HttpGet]
        public async Task<IActionResult> GetAllDocApprovalDecesion(string EmpID, string DocStatus)
        {
            List<DocApprovalDecesion> oDocApproval = new List<DocApprovalDecesion>();
            try
            {
                oDocApproval = await _docApprovalDecesion.GetAllData(EmpID, DocStatus);
                if (oDocApproval == null)
                {
                    return BadRequest(oDocApproval);
                }
                else
                {
                    return Ok(oDocApproval);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateDocApprovalStatus")]
        [HttpPost]
        public async Task<IActionResult> UpdateDocApprovalStatus([FromBody] DocApprovalDecesion pDocApproval)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _docApprovalDecesion.UpdateDocApprStatus(pDocApproval);
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
