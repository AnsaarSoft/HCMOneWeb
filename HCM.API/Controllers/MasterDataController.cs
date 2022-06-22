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
        private IMstEmailConfig _mstEmailConfig;
        private IMstPayrollinit _mstPayrollinit;
        private IMstLoans _mstLoans;
        private IMstShifts _mstShift;
        private IMstAdvance _mstAdvance;
        private IMstLeaveType _mstLeaveType;
        private IMstLeaveDeduction _mstLeaveDeduction;
        private IMstDeductionRule _mstDeductionRule;
        private IMstTaxSetup _mstTaxSetup;

        public MasterDataController(IMstDepartment mstDepartment, IMstDesignation mstDesignation, IMstLocation mstLocation, IMstPosition mstPosition, IMstBranch mstBranch, IMstGrading mstGrading, IMstCalendar mstCalendar,
            IMstLeaveCalendar mstLeaveCalendar, IMstEmailConfig mstEmailConfig, IMstPayrollinit mstPayrollinit, IMstLoans mstLoans, IMstShifts mstShift, IMstAdvance mstAdvance, IMstLeaveDeduction mstLeaveDeduction,
            IMstLeaveType mstLeaveType, IMstDeductionRule mstDeductionRule, IMstTaxSetup mstTaxSetup)
        {
            _mstDepartment = mstDepartment;
            _mstDesignation = mstDesignation;
            _mstLocation = mstLocation;
            _mstPosition = mstPosition;
            _mstBranch = mstBranch;
            _mstGrading = mstGrading;
            _mstCalendar = mstCalendar;
            _mstLeaveCalendar = mstLeaveCalendar;
            _mstEmailConfig = mstEmailConfig;
            _mstPayrollinit = mstPayrollinit;
            _mstLoans = mstLoans;
            _mstShift = mstShift;
            _mstAdvance = mstAdvance;
            _mstLeaveDeduction = mstLeaveDeduction;
            _mstLeaveType = mstLeaveType;
            _mstDeductionRule = mstDeductionRule;
            _mstTaxSetup = mstTaxSetup;
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

        #region MST Grading

        [Route("getAllGrading")]
        [HttpGet]
        public async Task<IActionResult> GetAllGrading()
        {
            List<MstGrading> oMstGrading = new List<MstGrading>();
            try
            {
                oMstGrading = await _mstGrading.GetAllData();
                if (oMstGrading == null)
                {
                    return BadRequest(oMstGrading);
                }
                else
                {
                    return Ok(oMstGrading);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addGrading")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstGrading pMstGrading)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstGrading.Insert(pMstGrading);
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

        [Route("updateGrading")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstGrading pMstGrading)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstGrading.Update(pMstGrading);
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

        [Route("addPRPeriods")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstPayrollPeriod pMstPayrollPeriod)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstCalendar.Insert(pMstPayrollPeriod);
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

        #region MST EmailConfig

        [Route("getEmailConfig")]
        [HttpGet]
        public async Task<IActionResult> GetEmailConfig()
        {
            MstEmailConfig oMstEmailConfig = new MstEmailConfig();

            try
            {
                oMstEmailConfig = await _mstEmailConfig.GetData();
                if (oMstEmailConfig == null)
                {
                    return BadRequest(oMstEmailConfig);
                }
                else
                {
                    return Ok(oMstEmailConfig);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went Wrong");
            }
        }

        [Route("updateEmailConfig")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstEmailConfig pMstEmailConfig)

        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                response = await _mstEmailConfig.Update(pMstEmailConfig);
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
                return BadRequest("Something went Wrong");
            }
        }
        #endregion

        #region Payrollinit

        [Route("getPayrollinit")]
        [HttpGet]
        public async Task<IActionResult> GetPayrollinit()
        {
            MstPayrollBasicInitialization oMstPayrollinit = new MstPayrollBasicInitialization();

            try
            {
                oMstPayrollinit = await _mstPayrollinit.GetData();
                if (oMstPayrollinit == null)
                {
                    return BadRequest(oMstPayrollinit);
                }
                else
                {
                    return Ok(oMstPayrollinit);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went Wrong");
            }
        }

        [Route("updatePayrollinit")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstPayrollBasicInitialization pMstPayrollinit)

        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                response = await _mstPayrollinit.Update(pMstPayrollinit);
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
                return BadRequest("Something went Wrong");
            }
        }

        #endregion

        #region MST Loans

        [Route("getAllLoans")]
        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            List<MstLoan> oMstLoans = new List<MstLoan>();
            try
            {
                oMstLoans = await _mstLoans.GetAllData();
                if (oMstLoans == null)
                {
                    return BadRequest(oMstLoans);
                }
                else
                {
                    return Ok(oMstLoans);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLoans")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstLoan pMstLoans)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLoans.Insert(pMstLoans);
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

        [Route("updateLoans")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstLoan pMstLoans)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLoans.Update(pMstLoans);
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

        #region MST Shift

        [Route("getAllShift")]
        [HttpGet]
        public async Task<IActionResult> GetAllShift()
        {
            List<MstShift> oMstShift = new List<MstShift>();
            try
            {
                oMstShift = await _mstShift.GetAllData();
                if (oMstShift == null)
                {
                    return BadRequest(oMstShift);
                }
                else
                {
                    return Ok(oMstShift);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addShift")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstShift pMstShift)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstShift.Insert(pMstShift);
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

        [Route("updateShift")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstShift pMstShift)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstShift.Update(pMstShift);
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

        #region MST Advance

        [Route("getAllAdvance")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdvance()
        {
            List<MstAdvance> oMstAdvance = new List<MstAdvance>();
            try
            {
                oMstAdvance = await _mstAdvance.GetAllData();
                if (oMstAdvance == null)
                {
                    return BadRequest(oMstAdvance);
                }
                else
                {
                    return Ok(oMstAdvance);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addAdvance")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstAdvance pMstAdvance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstAdvance.Insert(pMstAdvance);
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

        [Route("updateAdvance")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstAdvance pMstAdvance)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstAdvance.Update(pMstAdvance);
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

        #region MST LeaveDeduction

        [Route("getAllLeaveDeduction")]
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveDeduction()
        {
            List<MstLeaveDeduction> oMstLeaveDeduction = new List<MstLeaveDeduction>();
            try
            {
                oMstLeaveDeduction = await _mstLeaveDeduction.GetAllData();
                if (oMstLeaveDeduction == null)
                {
                    return BadRequest(oMstLeaveDeduction);
                }
                else
                {
                    return Ok(oMstLeaveDeduction);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addLeaveDeduction")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstLeaveDeduction pMstLeaveDeduction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveDeduction.Insert(pMstLeaveDeduction);
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

        [Route("updateLeaveDeduction")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstLeaveDeduction pMstLeaveDeduction)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveDeduction.Update(pMstLeaveDeduction);
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

        #region MST LeaveType

        [Route("getAllLeaveType")]
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveType()
        {
            List<MstLeaveType> oMstLeaveType = new List<MstLeaveType>();
            try
            {
                oMstLeaveType = await _mstLeaveType.GetAllData();
                if (oMstLeaveType == null)
                {
                    return BadRequest(oMstLeaveType);
                }
                else
                {
                    return Ok(oMstLeaveType);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        
        [Route("addLeaveType")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstLeaveType pMstLeaveType)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveType.Insert(pMstLeaveType);
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
       
        [Route("updateLeaveType")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstLeaveType pMstLeaveType)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstLeaveType.Update(pMstLeaveType);
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

        #region MST DeductionRule

        [Route("getAllDeductionRule")]
        [HttpGet]
        public async Task<IActionResult> GetAllDeductionRule()
        {
            List<MstDeductionRule> oMstDeductionRule = new List<MstDeductionRule>();
            try
            {
                oMstDeductionRule = await _mstDeductionRule.GetAllData();
                if (oMstDeductionRule == null)
                {
                    return BadRequest(oMstDeductionRule);
                }
                else
                {
                    return Ok(oMstDeductionRule);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDeductionRule")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDeductionRule pMstDeductionRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDeductionRule.Insert(pMstDeductionRule);
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

        [Route("updateDeductionRule")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDeductionRule pMstDeductionRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDeductionRule.Update(pMstDeductionRule);
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

        #region MST TaxSetup

        [Route("getAllTaxSetup")]
        [HttpGet]
        public async Task<IActionResult> GetAllTaxSetup()
        {
            List<MstTaxSetup> oMstTaxSetup = new List<MstTaxSetup>();
            try
            {
                oMstTaxSetup = await _mstTaxSetup.GetAllData();
                if (oMstTaxSetup == null)
                {
                    return BadRequest(oMstTaxSetup);
                }
                else
                {
                    return Ok(oMstTaxSetup);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addTaxSetup")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstTaxSetup pMstTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTaxSetup.Insert(pMstTaxSetup);
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

        [Route("updateTaxSetup")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstTaxSetup pMstTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstTaxSetup.Update(pMstTaxSetup);
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
