using HCM.API.General;
using HCM.API.HCMModels;
using HCM.API.Interfaces.ClientSpecific;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSpecificController : ControllerBase
    {
        private ITrnsProductStage _trnsProductStage;
        private IMstTarget  _mstTarget;
        private ITrnsPerPiece _trnsPerPiece;

        public ClientSpecificController(ITrnsProductStage trnsProductStage, IMstTarget mstTarget, ITrnsPerPiece trnsPerPiece)
        {
            _trnsProductStage = trnsProductStage;
            _mstTarget = mstTarget;
            _trnsPerPiece = trnsPerPiece;
        }

        #region Production  Stages

        [Route("getAllProductStage")]
        [HttpGet]
        public async Task<IActionResult> getAllProductStage()
        {
            List<TrnsProductStage> oTrnsProductStage = new List<TrnsProductStage>();
            try
            {
                oTrnsProductStage = await _trnsProductStage.GetAllData();
                if (oTrnsProductStage == null)
                {
                    return BadRequest(oTrnsProductStage);
                }
                else
                {
                    return Ok(oTrnsProductStage);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addProductStage")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsProductStage pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Insert(pTrnsProductStage);
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

        [Route("updateProductStage")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsProductStage pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Update(pTrnsProductStage);
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

        [Route("addProductStageList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsProductStage> pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Insertlist(pTrnsProductStage);
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

        [Route("updateProductStageList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsProductStage> pTrnsProductStage)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsProductStage.Updatelist(pTrnsProductStage);
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

        #region Mst Target

        [Route("getAllMstTarget")]
        [HttpGet]
        public async Task<IActionResult> getAllMstTarget()
        {
            List<MstTarget> oList = new List<MstTarget>();
            try
            {
                oList = await _mstTarget.GetAllData();
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

        [Route("addMstTarget")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstTarget pMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTarget.Insert(pMstTarget);
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

        [Route("updateMstTarget")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstTarget pMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTarget.Update(pMstTarget);
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

        [Route("addMstTargetList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstTarget> pMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTarget.Insert(pMstTarget);
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

        [Route("updateMstTargetList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstTarget> pMstTarget)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTarget.Update(pMstTarget);
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

        #region Per Piece Transaction

        [Route("getAllPerPiece")]
        [HttpGet]
        public async Task<IActionResult> getAllPerPiece()
        {
            List<TrnsPerPieceTransaction> oTrnsPerPieceTransaction = new List<TrnsPerPieceTransaction>();
            try
            {
                oTrnsPerPieceTransaction = await _trnsPerPiece.GetAllData();
                if (oTrnsPerPieceTransaction == null)
                {
                    return BadRequest(oTrnsPerPieceTransaction);
                }
                else
                {
                    return Ok(oTrnsPerPieceTransaction);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addPerPiece")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsPerPieceTransaction pTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsPerPiece.Insert(pTrnsPerPieceTransaction);
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

        [Route("updatePerPiece")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsPerPieceTransaction pTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsPerPiece.Update(pTrnsPerPieceTransaction);
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

        [Route("addPerPieceList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsPerPieceTransaction> pTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsPerPiece.Insert(pTrnsPerPieceTransaction);
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

        [Route("updatePerPieceList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsPerPieceTransaction> pTrnsPerPieceTransaction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsPerPiece.Update(pTrnsPerPieceTransaction);
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
