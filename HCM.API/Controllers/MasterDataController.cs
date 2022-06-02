using HCM.API.General;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private IMstDepartment _mstDepartment;
        private IMstDesignation _mstDesignation;
        private IMstLocation _mstLocation;
        private IMstPosition _mstPosition;
        private IMstBranch _mstBranch;
        private IMstGrading _mstGrading;
        private IMstCalendar _mstCalendar;
        private IMstLeaveCalendar _mstLeaveCalendar;

        public MasterDataController(IMstDepartment mstDepartment, IMstDesignation mstDesignation, IMstLocation mstLocation, IMstPosition mstPosition, IMstBranch mstBranch, IMstGrading mstGrading, IMstCalendar mstCalendar,
            IMstLeaveCalendar mstLeaveCalendar)
        {
            _mstDepartment = mstDepartment;
            _mstDesignation = mstDesignation;
            _mstLocation = mstLocation;
            _mstPosition = mstPosition;
            _mstBranch = mstBranch;
            _mstGrading = mstGrading;
            _mstCalendar = mstCalendar;
            _mstLeaveCalendar = mstLeaveCalendar;
        }

        #region MST Department

        [Route("getAllDept")]
        [HttpGet]
        public async Task<IActionResult> GetAllDept()
        {
            List<MstDepartment> oMstDepartment = new List<MstDepartment>();
            try
            {
                oMstDepartment = await _mstDepartment.GetAllData();
                if (oMstDepartment == null)
                {
                    return BadRequest(oMstDepartment);
                }
                else
                {
                    return Ok(oMstDepartment);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDept")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDepartment pMstDepartment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDepartment.Insert(pMstDepartment);
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

        [Route("updateDept")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDepartment pMstDepartment)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDepartment.Update(pMstDepartment);
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

        #region MST Designation

        [Route("getAllDesg")]
        [HttpGet]
        public async Task<IActionResult> GetAllDesg()
        {
            List<MstDesignation> oMstDesignation = new List<MstDesignation>();
            try
            {
                oMstDesignation = await _mstDesignation.GetAllData();
                if (oMstDesignation == null)
                {
                    return BadRequest(oMstDesignation);
                }
                else
                {
                    return Ok(oMstDesignation);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDesg")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDesignation pMstDesignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDesignation.Insert(pMstDesignation);
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

        [Route("updateDesg")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDesignation pMstDesignation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDesignation.Update(pMstDesignation);
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

        #region MST Location

        [Route("getAllLoc")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoc()
        {
            List<MstLocation> oMstLocation = new List<MstLocation>();
            try
            {
                oMstLocation = await _mstLocation.GetAllData();
                if (oMstLocation == null)
                {
                    return BadRequest(oMstLocation);
                }
                else
                {
                    return Ok(oMstLocation);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLoc")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstLocation pMstLocation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLocation.Insert(pMstLocation);
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

        [Route("updateLoc")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstLocation pMstLocation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLocation.Update(pMstLocation);
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

        #region MST Position

        [Route("getAllPos")]
        [HttpGet]
        public async Task<IActionResult> GetAllPos()
        {
            List<MstPosition> oMstPosition = new List<MstPosition>();
            try
            {
                oMstPosition = await _mstPosition.GetAllData();
                if (oMstPosition == null)
                {
                    return BadRequest(oMstPosition);
                }
                else
                {
                    return Ok(oMstPosition);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addPos")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstPosition pMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstPosition.Insert(pMstPosition);
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

        [Route("updatePos")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstPosition pMstPosition)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstPosition.Update(pMstPosition);
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

        #region MST Branch

        [Route("getAllBranch")]
        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            List<MstBranch> oMstBranch = new List<MstBranch>();
            try
            {
                oMstBranch = await _mstBranch.GetAllData();
                if (oMstBranch == null)
                {
                    return BadRequest(oMstBranch);
                }
                else
                {
                    return Ok(oMstBranch);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addBranch")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstBranch pMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstBranch.Insert(pMstBranch);
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

        [Route("updateBranch")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstBranch pMstBranch)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstBranch.Update(pMstBranch);
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

        //#region MST Grading

        //[Route("getAllGrading")]
        //[HttpGet]
        //public async Task<IActionResult> GetAllGrading()
        //{
        //    List<MstGrading> oMstGrading = new List<MstGrading>();
        //    try
        //    {
        //        oMstGrading = await _mstGrading.GetAllData();
        //        if (oMstGrading == null)
        //        {
        //            return BadRequest(oMstGrading);
        //        }
        //        else
        //        {
        //            return Ok(oMstGrading);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return BadRequest("Something went wrong.");
        //    }
        //}

        //[Route("addGrading")]
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] MstGrading pMstGrading)
        //{
        //    ApiResponseModel response = new ApiResponseModel();
        //    try
        //    {
        //        response = await _mstGrading.Insert(pMstGrading);
        //        if (response == null)
        //        {
        //            return BadRequest(response);
        //        }
        //        else
        //        {
        //            return Ok(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return BadRequest("Something went wrong.");
        //    }
        //}

        //[Route("updateGrading")]
        //[HttpPost]
        //public async Task<IActionResult> Update([FromBody] MstGrading pMstGrading)
        //{
        //    ApiResponseModel response = new ApiResponseModel();
        //    try
        //    {
        //        response = await _mstGrading.Update(pMstGrading);
        //        if (response == null)
        //        {
        //            return BadRequest(response);
        //        }
        //        else
        //        {
        //            return Ok(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //        return BadRequest("Something went wrong.");
        //    }
        //}

        //#endregion

        #region MST Calendar

        [Route("getAllCalendar")]
        [HttpGet]
        public async Task<IActionResult> GetAllCalendar()
        {
            List<MstCalendar> oMstCalendar = new List<MstCalendar>();
            try
            {
                oMstCalendar = await _mstCalendar.GetAllData();
                if (oMstCalendar == null)
                {
                    return BadRequest(oMstCalendar);
                }
                else
                {
                    return Ok(oMstCalendar);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addCalendar")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstCalendar pMstCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstCalendar.Insert(pMstCalendar);
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

        [Route("updateCalendar")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstCalendar pMstCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstCalendar.Update(pMstCalendar);
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

        #region MST LeaveCalendar

        [Route("getAllLeaveCalendar")]
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveCalendar()
        {
            List<MstLeaveCalendar> oMstLeaveCalendar = new List<MstLeaveCalendar>();
            try
            {
                oMstLeaveCalendar = await _mstLeaveCalendar.GetAllData();
                if (oMstLeaveCalendar == null)
                {
                    return BadRequest(oMstLeaveCalendar);
                }
                else
                {
                    return Ok(oMstLeaveCalendar);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLeaveCalendar")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstLeaveCalendar pMstLeaveCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveCalendar.Insert(pMstLeaveCalendar);
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

        [Route("updateLeaveCalendar")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstLeaveCalendar pMstLeaveCalendar)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveCalendar.Update(pMstLeaveCalendar);
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
