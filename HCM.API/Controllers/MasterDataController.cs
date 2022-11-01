using HCM.API.General;
using HCM.API.HCMModels;
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
        private IMstForm _mstForm;
        private IMstDocumentNumberSeries _mstDocumentNumberSeries;
        private IMstDepartment _mstDepartment;
        private IMstDesignation _mstDesignation;
        private IMstLocation _mstLocation;
        private IMstPosition _mstPosition;
        private IMstBranch _mstBranch;
        private IMstGrading _mstGrading;
        private IMstCalendar _mstCalendar;
        private IMstLeaveCalendar _mstLeaveCalendar;
        private IMstEmailConfig _mstEmailConfig;
        private ICfgPayrollDefinationinit _CfgPayrollDefinationinit;
        private IMstLoans _mstLoans;
        private IMstShifts _mstShift;
        private IMstAdvance _mstAdvance;
        private IMstLeaveType _mstLeaveType;
        private IMstLeaveDeduction _mstLeaveDeduction;
        private IMstDeductionRule _mstDeductionRule;
        private IMstAttendanceRules _mstAttendanceRule;
        private ICfgTaxSetup _CfgTaxSetup;
        private ICfgPayrollDefination _CfgPayrollDefinationSetup;
        private IMstBonus _mstBonus;
        private IMstGratuity _mstGratuity;
        private IMstCountryStateCity _mstCountryStateCity;
        private IMstContractor _mstContractor;
        private IMstStation _mstStation;
        private IMstEmployeeLeaves _mstEmployeeLeaves;
        private IMstDimension _mstDimension;
        private IMstchartofAccount _mstchartofAccount;
        private IMstHoliDay _mstHoliDay;

        public MasterDataController(IMstForm mstForm, IMstDocumentNumberSeries mstDocumentNumberSeries, IMstDepartment mstDepartment, IMstDesignation mstDesignation, IMstLocation mstLocation, IMstPosition mstPosition, IMstBranch mstBranch, IMstGrading mstGrading, IMstCalendar mstCalendar,
            IMstLeaveCalendar mstLeaveCalendar, IMstEmailConfig mstEmailConfig, ICfgPayrollDefinationinit CfgPayrollDefinationinit, IMstLoans mstLoans, IMstShifts mstShift, IMstAdvance mstAdvance, IMstLeaveDeduction mstLeaveDeduction,
            IMstLeaveType mstLeaveType, IMstDeductionRule mstDeductionRule, IMstAttendanceRules mstAttendanceRule, ICfgTaxSetup CfgTaxSetup, ICfgPayrollDefination CfgPayrollDefinationSetup, IMstBonus mstBonus, IMstGratuity mstGratuity,
            IMstCountryStateCity mstCountryStateCity, IMstContractor mstContractor, IMstStation mstStation, IMstEmployeeLeaves mstEmployeeLeaves, IMstDimension mstDimension, IMstchartofAccount mstchartofAccount, IMstHoliDay mstHoliDay)
        {
            _mstForm = mstForm;
            _mstDocumentNumberSeries = mstDocumentNumberSeries;
            _mstDepartment = mstDepartment;
            _mstDesignation = mstDesignation;
            _mstLocation = mstLocation;
            _mstPosition = mstPosition;
            _mstBranch = mstBranch;
            _mstGrading = mstGrading;
            _mstCalendar = mstCalendar;
            _mstLeaveCalendar = mstLeaveCalendar;
            _mstEmailConfig = mstEmailConfig;
            _CfgPayrollDefinationinit = CfgPayrollDefinationinit;
            _mstLoans = mstLoans;
            _mstShift = mstShift;
            _mstAdvance = mstAdvance;
            _mstLeaveDeduction = mstLeaveDeduction;
            _mstLeaveType = mstLeaveType;
            _mstDeductionRule = mstDeductionRule;
            _mstAttendanceRule = mstAttendanceRule;
            _CfgTaxSetup = CfgTaxSetup;
            _CfgPayrollDefinationSetup = CfgPayrollDefinationSetup;
            _CfgPayrollDefinationSetup = CfgPayrollDefinationSetup;
            _mstBonus = mstBonus;
            _mstGratuity = mstGratuity;
            _mstCountryStateCity = mstCountryStateCity;
            _mstContractor = mstContractor;
            _mstStation = mstStation;
            _mstEmployeeLeaves = mstEmployeeLeaves;
            _mstDimension = mstDimension;
            _mstchartofAccount = mstchartofAccount;
            _mstHoliDay = mstHoliDay;
        }

        #region MST Form

        [Route("getAllForm")]
        [HttpGet]
        public async Task<IActionResult> GetAllForm()
        {
            List<MstForm> oMstForm = new List<MstForm>();
            try
            {
                oMstForm = await _mstForm.GetAllData();
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

        [Route("addForm")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstForm pMstForm)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstForm.Insert(pMstForm);
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

        [Route("updateForm")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstForm pMstForm)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstForm.Update(pMstForm);
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

        #region MST DocumentNumberSeries

        [Route("getAllDocumentNumberSeries")]
        [HttpGet]
        public async Task<IActionResult> GetAllDocumentNumberSeries()
        {
            List<MstDocumentNumberSeries> oMstDocumentNumberSeries = new List<MstDocumentNumberSeries>();
            try
            {
                oMstDocumentNumberSeries = await _mstDocumentNumberSeries.GetAllData();
                if (oMstDocumentNumberSeries == null)
                {
                    return BadRequest(oMstDocumentNumberSeries);
                }
                else
                {
                    return Ok(oMstDocumentNumberSeries);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDocumentNumberSeries")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDocumentNumberSeries pMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDocumentNumberSeries.Insert(pMstDocumentNumberSeries);
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

        [Route("updateDocumentNumberSeries")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDocumentNumberSeries pMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDocumentNumberSeries.Update(pMstDocumentNumberSeries);
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

        [Route("addDocumentNumberSeriesList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstDocumentNumberSeries> pMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDocumentNumberSeries.Insert(pMstDocumentNumberSeries);
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

        [Route("updateDocumentNumberSeriesList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstDocumentNumberSeries> pMstDocumentNumberSeries)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDocumentNumberSeries.Update(pMstDocumentNumberSeries);
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

        #region Mst Country State City

        [Route("getAllCountryStateCity")]
        [HttpGet]
        public async Task<IActionResult> GetAllCountryStateCity()
        {
            List<MstCountry> oMstCountry = new List<MstCountry>();
            try
            {
                oMstCountry = await _mstCountryStateCity.GetAllData();
                if (oMstCountry == null)
                {
                    return BadRequest(oMstCountry);
                }
                else
                {
                    return Ok(oMstCountry);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion

        #region MST Contractor

        [Route("getAllContractor")]
        [HttpGet]
        public async Task<IActionResult> GetAllContractor()
        {
            List<MstContractor> oMstContractor = new List<MstContractor>();
            try
            {
                oMstContractor = await _mstContractor.GetAllData();
                if (oMstContractor == null)
                {
                    return BadRequest(oMstContractor);
                }
                else
                {
                    return Ok(oMstContractor);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addContractor")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstContractor pMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstContractor.Insert(pMstContractor);
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

        [Route("updateContractor")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstContractor pMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstContractor.Update(pMstContractor);
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

        [Route("addContractorList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstContractor> pMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstContractor.Insert(pMstContractor);
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

        [Route("updateContractorList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstContractor> pMstContractor)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstContractor.Update(pMstContractor);
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

        #region MST Station

        [Route("getAllStation")]
        [HttpGet]
        public async Task<IActionResult> GetAllStation()
        {
            List<MstStation> oMstStation = new List<MstStation>();
            try
            {
                oMstStation = await _mstStation.GetAllData();
                if (oMstStation == null)
                {
                    return BadRequest(oMstStation);
                }
                else
                {
                    return Ok(oMstStation);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addStation")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstStation pMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStation.Insert(pMstStation);
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

        [Route("updateStation")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstStation pMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStation.Update(pMstStation);
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

        [Route("addStationList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstStation> pMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStation.Insert(pMstStation);
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

        [Route("updateStationList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstStation> pMstStation)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstStation.Update(pMstStation);
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

        [Route("addDeptList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstDepartment> pMstDepartment)
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

        [Route("updateDeptList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstDepartment> pMstDepartment)
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

        #region MST Dimension

        [Route("getAllDimen")]
        [HttpGet]
        public async Task<IActionResult> GetAllDim()
        {
            List<MstDimension> oMstDimension = new List<MstDimension>();
            try
            {
                oMstDimension = await _mstDimension.GetAllData();
                if (oMstDimension == null)
                {
                    return BadRequest(oMstDimension);
                }
                else
                {
                    return Ok(oMstDimension);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDimen")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDimension pMstDimension)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDimension.Insert(pMstDimension);
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

        [Route("updateDimen")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDimension pMstDimension)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDimension.Update(pMstDimension);
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

        [Route("addDimenList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstDimension> pMstDimension)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDimension.Insert(pMstDimension);
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

        [Route("updateDimenList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstDimension> pMstDimension)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDimension.Update(pMstDimension);
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

        [Route("addDesgList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstDesignation> pMstDesignation)
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

        [Route("updateDesgList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstDesignation> pMstDesignation)
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

        [Route("addLocList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstLocation> pMstLocation)
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

        [Route("updateLocList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstLocation> pMstLocation)
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
        [Route("addPosList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstPosition> pMstPosition)
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

        [Route("updatePosList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstPosition> pMstPosition)
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
        [Route("addBranchList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstBranch> pMstBranch)
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

        [Route("updateBranchList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstBranch> pMstBranch)
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
        [Route("addGradingList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstGrading> pMstGrading)
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

        [Route("updateGradingList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstGrading> pMstGrading)
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
        public async Task<IActionResult> Add([FromBody] List<CfgPeriodDate> pCfgPeriodDate)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstCalendar.Insert(pCfgPeriodDate);
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
            CfgPayrollBasicInitialization oCfgPayrollDefinationinit = new CfgPayrollBasicInitialization();

            try
            {
                oCfgPayrollDefinationinit = await _CfgPayrollDefinationinit.GetData();
                if (oCfgPayrollDefinationinit == null)
                {
                    return BadRequest(oCfgPayrollDefinationinit);
                }
                else
                {
                    return Ok(oCfgPayrollDefinationinit);
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
        public async Task<IActionResult> Update([FromBody] CfgPayrollBasicInitialization pCfgPayrollDefinationinit)

        {
            ApiResponseModel response = new ApiResponseModel();

            try
            {
                response = await _CfgPayrollDefinationinit.Update(pCfgPayrollDefinationinit);
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

        #region MST Attendance Rules

        [Route("getAllAttendanceRule")]
        [HttpGet]
        public async Task<IActionResult> GetAllAttendanceRules()
        {
            MstAttendanceRule oMstAttendanceRule = new MstAttendanceRule();
            try
            {
                oMstAttendanceRule = await _mstAttendanceRule.GetAllData();
                if (oMstAttendanceRule == null)
                {
                    return BadRequest(oMstAttendanceRule);
                }
                else
                {
                    return Ok(oMstAttendanceRule);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addAttendanceRule")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstAttendanceRule pMstAttendanceRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstAttendanceRule.Insert(pMstAttendanceRule);
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
        [Route("updateAttendanceRule")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstAttendanceRule pMstAttendanceRule)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstAttendanceRule.Update(pMstAttendanceRule);
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
            List<CfgTaxSetup> oCfgTaxSetup = new List<CfgTaxSetup>();
            try
            {
                oCfgTaxSetup = await _CfgTaxSetup.GetAllData();
                if (oCfgTaxSetup == null)
                {
                    return BadRequest(oCfgTaxSetup);
                }
                else
                {
                    return Ok(oCfgTaxSetup);
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
        public async Task<IActionResult> Add([FromBody] CfgTaxSetup pCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _CfgTaxSetup.Insert(pCfgTaxSetup);
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
        public async Task<IActionResult> Update([FromBody] CfgTaxSetup pCfgTaxSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _CfgTaxSetup.Update(pCfgTaxSetup);
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

        #region MST Bonus

        [Route("getAllBonus")]
        [HttpGet]
        public async Task<IActionResult> GetAllBonus()
        {
            List<MstBonu> oMstBonus = new List<MstBonu>();
            try
            {
                oMstBonus = await _mstBonus.GetAllData();
                if (oMstBonus == null)
                {
                    return BadRequest(oMstBonus);
                }
                else
                {
                    return Ok(oMstBonus);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addBonus")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstBonu pMstBonus)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstBonus.Insert(pMstBonus);
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

        [Route("updateBonus")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstBonu pMstBonus)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstBonus.Update(pMstBonus);
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

        #region MST PayrollSetup

        [Route("getAllPayrollSetup")]
        [HttpGet]
        public async Task<IActionResult> GetAllPayrollSetup()
        {
            List<CfgPayrollDefination> oCfgPayrollDefinationSetup = new List<CfgPayrollDefination>();
            try
            {
                oCfgPayrollDefinationSetup = await _CfgPayrollDefinationSetup.GetAllData();
                if (oCfgPayrollDefinationSetup == null)
                {
                    return BadRequest(oCfgPayrollDefinationSetup);
                }
                else
                {
                    return Ok(oCfgPayrollDefinationSetup);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        
        [Route("getAllPayrollSetupByEmp")]
        [HttpGet]
        public async Task<IActionResult> GetAllPayrollSetupByEmp(string EmpID)
        {
            List<CfgPayrollDefination> oCfgPayrollDefinationSetup = new List<CfgPayrollDefination>();
            try
            {
                oCfgPayrollDefinationSetup = await _CfgPayrollDefinationSetup.GetAllData(EmpID);
                if (oCfgPayrollDefinationSetup == null)
                {
                    return BadRequest(oCfgPayrollDefinationSetup);
                }
                else
                {
                    return Ok(oCfgPayrollDefinationSetup);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addPayrollSetup")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CfgPayrollDefination pCfgPayrollDefinationSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _CfgPayrollDefinationSetup.Insert(pCfgPayrollDefinationSetup);
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

        [Route("updatePayrollSetup")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CfgPayrollDefination pCfgPayrollDefinationSetup)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _CfgPayrollDefinationSetup.Update(pCfgPayrollDefinationSetup);
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

        #region MST Gratuity

        [Route("getAllGratuity")]
        [HttpGet]
        public async Task<IActionResult> GetAllGratuity()
        {
            List<MstGratuity> oMstGratuity = new List<MstGratuity>();
            try
            {
                oMstGratuity = await _mstGratuity.GetAllData();
                if (oMstGratuity == null)
                {
                    return BadRequest(oMstGratuity);
                }
                else
                {
                    return Ok(oMstGratuity);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addGratuity")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstGratuity pMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstGratuity.Insert(pMstGratuity);
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

        [Route("updateGratuity")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstGratuity pMstGratuity)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstGratuity.Update(pMstGratuity);
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

        #region MST EmployeeLeaf

        [Route("getAllEmployeeLeaves")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeLeaves()
        {
            List<MstEmployeeLeaf> oMstEmployeeLeaf = new List<MstEmployeeLeaf>();
            try
            {
                oMstEmployeeLeaf = await _mstEmployeeLeaves.GetAllData();
                if (oMstEmployeeLeaf == null)
                {
                    return BadRequest(oMstEmployeeLeaf);
                }
                else
                {
                    return Ok(oMstEmployeeLeaf);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addEmployeeLeaves")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstEmployeeLeaf pMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployeeLeaves.Insert(pMstEmployeeLeaf);
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

        [Route("updateEmployeeLeaves")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstEmployeeLeaf pMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployeeLeaves.Update(pMstEmployeeLeaf);
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

        [Route("addEmployeeLeavesList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstEmployeeLeaf> pMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployeeLeaves.Insert(pMstEmployeeLeaf);
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

        [Route("updateEmployeeLeavesList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstEmployeeLeaf> pMstEmployeeLeaf)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstEmployeeLeaves.Update(pMstEmployeeLeaf);
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

        #region MST ChartofAccount

        [Route("getAllCOA")]
        [HttpGet]
        public async Task<IActionResult> getAllCOA()
        {
            List<MstchartofAccount> oMstchartofAccount = new List<MstchartofAccount>();
            try
            {
                oMstchartofAccount = await _mstchartofAccount.GetAllData();
                if (oMstchartofAccount == null)
                {
                    return BadRequest(oMstchartofAccount);
                }
                else
                {
                    return Ok(oMstchartofAccount);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addCOA")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstchartofAccount pMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstchartofAccount.Insert(pMstchartofAccount);
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

        [Route("updateCOA")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstchartofAccount pMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstchartofAccount.Update(pMstchartofAccount);
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

        [Route("addCOAList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstchartofAccount> pMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstchartofAccount.Insert(pMstchartofAccount);
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

        [Route("updateCOAList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstchartofAccount> pMstchartofAccount)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstchartofAccount.Update(pMstchartofAccount);
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

        #region MST HoliDay

        [Route("getAllHoliday")]
        [HttpGet]
        public async Task<IActionResult> getAllHoliday()
        {
            List<MstHoliDay> oMstHoliDay = new List<MstHoliDay>();
            try
            {
                oMstHoliDay = await _mstHoliDay.GetAllData();
                if (oMstHoliDay == null)
                {
                    return BadRequest(oMstHoliDay);
                }
                else
                {
                    return Ok(oMstHoliDay);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addHoliday")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstHoliDay pMstHoliDay)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstHoliDay.Insert(pMstHoliDay);
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

        [Route("updateHoliday")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstHoliDay pMstHoliDay)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstHoliDay.Update(pMstHoliDay);
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

        [Route("addHolidayList")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<MstHoliDay> pMstHoliDay)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstHoliDay.Insert(pMstHoliDay);
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

        [Route("updateHolidayList")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<MstHoliDay> pMstHoliDay)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstHoliDay.Update(pMstHoliDay);
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
