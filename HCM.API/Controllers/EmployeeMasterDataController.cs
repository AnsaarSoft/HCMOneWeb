using HCM.API.General;
using HCM.API.Interfaces.EmployeeMasterSetup;
using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterDataController : ControllerBase
    {
        private IMstEmployeeMasterData _mstEmployee;
        private ITrnsEmployeeTransfer _TrnsEmployeeTransfer;
        private ITrnsLeaveRequest _trnsLeaveRequest;
        private ITrnsEmployeeResign _trnsEmployeeResign;

        public EmployeeMasterDataController(IMstEmployeeMasterData mstEmployee, ITrnsLeaveRequest trnsLeaveRequest, ITrnsEmployeeTransfer TrnsEmployeeTransfer, ITrnsEmployeeResign trnsEmployeeResign)
        {
            _mstEmployee = mstEmployee;
            _TrnsEmployeeTransfer = TrnsEmployeeTransfer;
            _trnsLeaveRequest = trnsLeaveRequest;
            _trnsEmployeeResign = trnsEmployeeResign;
        }

        #region MST Employee

        [Route("getAllEmployee")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            List<MstEmployee> oMstEmployee = new List<MstEmployee>();
            try
            {
                oMstEmployee = await _mstEmployee.GetAllData();
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

        [Route("addEmployee")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployee.Insert(pMstEmployee);
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

        [Route("updateEmployee")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstEmployee pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployee.Update(pMstEmployee);
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

        [Route("addEmployeeList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstEmployee> pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployee.Insert(pMstEmployee);
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

        [Route("updateEmployeeList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstEmployee> pMstEmployee)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployee.Update(pMstEmployee);
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

        #region Employee Transfer

        [Route("getAllEmptrns")]
        [HttpGet]
        public async Task<IActionResult> getAllEmptrns()
        {
            List<TrnsEmployeeTransfer> oTrnsEmployeeTransfer = new List<TrnsEmployeeTransfer>();
            try
            {
                oTrnsEmployeeTransfer = await _TrnsEmployeeTransfer.GetAllData();
                if (oTrnsEmployeeTransfer == null)
                {
                    return BadRequest(oTrnsEmployeeTransfer);
                }
                else
                {
                    return Ok(oTrnsEmployeeTransfer);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addEmptrns")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsEmployeeTransfer pTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _TrnsEmployeeTransfer.Insert(pTrnsEmployeeTransfer);
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

        [Route("updateEmptrns")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsEmployeeTransfer pTrnsEmployeeTransfer)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _TrnsEmployeeTransfer.Update(pTrnsEmployeeTransfer);
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

        #region Trns leave Request

        [Route("getAllLeavesRequest")]
        [HttpGet]
        public async Task<IActionResult> GetAllLeavesRequest()
        {
            List<TrnsLeavesRequest> oTrnsLeavesRequest = new List<TrnsLeavesRequest>();
            try
            {
                oTrnsLeavesRequest = await _trnsLeaveRequest.GetAllData();
                if (oTrnsLeavesRequest == null)
                {
                    return BadRequest(oTrnsLeavesRequest);
                }
                else
                {
                    return Ok(oTrnsLeavesRequest);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLeavesRequest")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsLeavesRequest pTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLeaveRequest.Insert(pTrnsLeavesRequest);
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

        [Route("updateLeavesRequest")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsLeavesRequest pTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLeaveRequest.Update(pTrnsLeavesRequest);
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

        [Route("addLeavesRequestList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsLeavesRequest> pTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLeaveRequest.Insert(pTrnsLeavesRequest);
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

        [Route("updateLeavesRequestList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsLeavesRequest> pTrnsLeavesRequest)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsLeaveRequest.Update(pTrnsLeavesRequest);
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

        #region Trns Employee Resign

        [Route("getAllEmployeeResign")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeResign()
        {
            List<TrnsResignation> oTrnsEmployeeResign = new List<TrnsResignation>();
            try
            {
                oTrnsEmployeeResign = await _trnsEmployeeResign.GetAllData();
                if (oTrnsEmployeeResign == null)
                {
                    return BadRequest(oTrnsEmployeeResign);
                }
                else
                {
                    return Ok(oTrnsEmployeeResign);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addEmployeeResign")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TrnsResignation pTrnsEmployeeResign)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeResign.Insert(pTrnsEmployeeResign);
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

        [Route("updateEmployeeResign")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TrnsResignation pTrnsEmployeeResign)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeResign.Update(pTrnsEmployeeResign);
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

        [Route("addEmployeeResignList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<TrnsResignation> pTrnsEmployeeResign)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeResign.Insert(pTrnsEmployeeResign);
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

        [Route("updateEmployeeResignList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<TrnsResignation> pTrnsEmployeeResign)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _trnsEmployeeResign.Update(pTrnsEmployeeResign);
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
