using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Bibliography;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Attendance;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.ShiftManagement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.Attendance
{
    public partial class AttendanceProcessing
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public ITrnsAttendanceRegister _trnsAttendanceRegister { get; set; }

        [Inject]
        public ITrnsTempAttendance _trnsTempAttendance { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string PayrollPeriod = "";
        private string searchStringFilteredEmployee = "";

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        private bool FilterFuncFilteredEmployee(MstEmployee element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oListCalendar = new List<MstCalendar>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<TrnsAttendanceRegister> oListAttendanceRegister = new List<TrnsAttendanceRegister>();
        private IEnumerable<TrnsTempAttendance> oListTempAttendance = new List<TrnsTempAttendance>();

        private IEnumerable<MstShift> oListShift = new List<MstShift>();

        #endregion

        #region Functions

        private async Task GetAllTrnsAttendanceRegister()
        {
            try
            {
                oListAttendanceRegister = await _trnsAttendanceRegister.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllTrnsTempAttendance()
        {
            try
            {
                oListTempAttendance = await _trnsTempAttendance.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmployees()
        {
            try
            {
                oListEmployee = await _mstEmployeeMaster.GetAllData();
                oListEmployee = oListEmployee.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDesignation()
        {
            try
            {
                oListDesignation = await _mstDesignation.GetAllData();
                oListDesignation = oListDesignation.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllDepartments()
        {
            try
            {
                oListDepartment = await _mstDepartment.GetAllData();
                oListDepartment = oListDepartment.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLocation()
        {
            try
            {
                oListLocation = await _mstLocation.GetAllData();
                oListLocation = oListLocation.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllBranches()
        {
            try
            {
                oListBranch = await _mstBranch.GetAllData();
                oListBranch = oListBranch.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllPayroll()
        {
            try
            {
                oListPayroll = await _CfgPayrollDefination.GetAllData();
                oListPayroll = oListPayroll.Where(x => x.FlgActive == true).ToList();
                oModelPayroll = oListPayroll.FirstOrDefault();
                oListPayrollPeriod = oModelPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModelPayroll.Id).ToList();
                var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                //oModel.PayrollPeriodId = SelectedPeriod.Id;
                PayrollPeriod = SelectedPeriod.PeriodName;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllCalendar()
        {
            try
            {
                oListCalendar = await _mstCalendar.GetAllData();
                oModelCalendar = oListCalendar.Where(x => x.FlgActive == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllShifts()
        {
            try
            {
                oListShift = await _mstShift.GetAllData();
                oListShift = oListShift.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task<IEnumerable<MstEmployee>> SearchEmployeeFrom(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();
                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstEmployee>> SearchEmployeeTo(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListEmployee.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                    }).ToList();
                var res = oListEmployee.Where(x => x.EmpId.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstDesignation>> SearchDesignation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDesignation.Select(o => new MstDesignation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListDesignation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDesignation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstDepartment>> SearchDepartment(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListDepartment.Select(o => new MstDepartment
                    {
                        Id = o.Id,
                        DeptName = o.DeptName,
                    }).ToList();
                var res = oListDepartment.Where(x => x.DeptName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDepartment
                {
                    Id = x.Id,
                    DeptName = x.DeptName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstLocation>> SearchLocation(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListLocation.Select(o => new MstLocation
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListLocation.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstLocation
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstBranch>> SearchBranch(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListBranch.Select(o => new MstBranch
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListBranch.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstBranch
                {
                    Id = x.Id,
                    Description = x.Description,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<CfgPayrollDefination>> SearchPayroll(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPayroll.Select(o => new CfgPayrollDefination
                    {
                        Id = o.Id,
                        PayrollName = o.PayrollName,
                    }).ToList();
                var res = oListPayroll.Where(x => x.PayrollName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new CfgPayrollDefination
                {
                    Id = x.Id,
                    PayrollName = x.PayrollName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private bool FilterFuncFilteredEmployee(MstEmployee element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FirstName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PayrollName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.BranchName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LocationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DepartmentName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DesignationName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/AttendanceProcessing", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task SearchCriteria()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId))
                    || !string.IsNullOrWhiteSpace(oModelPayroll.PayrollName)
                    || !string.IsNullOrWhiteSpace(oModelDesignation.Description)
                    || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName)
                    || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    || !string.IsNullOrWhiteSpace(oModelBranch.Description))
                {
                    oListFilteredEmployee = oListEmployee.Where(x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0 && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                                                                || x.PayrollName == oModelPayroll.PayrollName
                                                                || x.DesignationName == oModelDesignation.Description
                                                                || x.DepartmentName == oModelDepartment.DeptName
                                                                || x.LocationName == oModelLocation.Description
                                                                || x.BranchName == oModelBranch.Description).ToList();
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task DeleteFromFilter(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<MstEmployee> oListEmployeeTemp = new List<MstEmployee>();
                oListEmployeeTemp = oListFilteredEmployee.ToList();
                if (oListFilteredEmployee.Count() > 0)
                {
                    var FilterRecord = oListFilteredEmployee.Where(x => x.Id == ID).FirstOrDefault();
                    oListEmployeeTemp.Remove(FilterRecord);
                    oListFilteredEmployee = oListEmployeeTemp;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task EmployeeValidation()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                //if (_dateRange.Start >= oModelCalendar.StartDate && _dateRange.End <= oModelCalendar.EndDate)
                //{
                //    foreach (var FilterEmployee in oListFilteredEmployee)
                //    {
                //        int SelectedShiftCount = 0;
                //        if (FilterEmployee.PayrollId > 0)
                //        {
                //            for (DateTime x = (DateTime)_dateRange.Start; x <= (DateTime)_dateRange.End; x = x.AddDays(1))
                //            {
                //                var PayrollPeriodID = oListPayroll.Where(x => x.Id == FilterEmployee.PayrollId).Select(b => b.CfgPeriodDates.Where(c => c.StartDate <= x && x <= c.EndDate).Select(d => d.Id)).FirstOrDefault();
                //                if (Convert.ToInt32(PayrollPeriodID.FirstOrDefault()) == 0)
                //                {
                //                    Snackbar.Add($@"Period for Selected Date Range Can't be found", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //                    return;
                //                }
                //                if (FilterEmployee.JoiningDate > x) continue;
                //                string DayOfWeek = Convert.ToString(x.DayOfWeek);
                //                TrnsAttendanceRegister oModelforUpdate = oList.Where(b => b.EmpId == FilterEmployee.Id && b.Date == x).FirstOrDefault();
                //                if (oModelforUpdate != null && (oModelforUpdate.FlgProcessed == true || oModelforUpdate.FlgPosted == true))
                //                {
                //                    Snackbar.Add($@"Shift can not be changed Employee: {FilterEmployee.EmpId} has Attendance Processed/Posted on Date: {x.ToString("MM/dd/yyyy")}", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //                    continue;
                //                }
                //                if (SelectedShiftCount == oListSelectedShift.Count())
                //                {
                //                    SelectedShiftCount = 0;
                //                }
                //                var FilterSelectedShiftRow = oListSelectedShift.ElementAt(SelectedShiftCount).MstShiftDetails.Where(x => x.Day == DayOfWeek).FirstOrDefault();
                //                SelectedShiftCount++;
                //                if (oModelforUpdate != null)
                //                {
                //                    oModelforUpdate.PeriodId = Convert.ToInt32(PayrollPeriodID.FirstOrDefault());
                //                    oModelforUpdate.ShiftId = (int)FilterSelectedShiftRow.ShiftId;
                //                    oModelforUpdate.DateDay = DayOfWeek;
                //                    if ((string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime == "00:00")
                //                        && (string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime == "00:00"))
                //                    {
                //                        oModelforUpdate.FlgOffDay = true;
                //                    }
                //                    else if ((!string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime != "00:00")
                //                       && (!string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime != "00:00"))
                //                    {
                //                        oModelforUpdate.FlgOffDay = false;
                //                    }

                //                    oModelforUpdate.UpdateDate = DateTime.Now;
                //                    oModelforUpdate.UpdatedBy = LoginUser;
                //                    oAttendanceRegisterUpdateList.Add(oModelforUpdate);
                //                }
                //                else
                //                {
                //                    TrnsAttendanceRegister oModelforAdd = new TrnsAttendanceRegister();
                //                    oModelforAdd.EmpId = FilterEmployee.Id;
                //                    oModelforAdd.FkpayrollId = (int)FilterEmployee.PayrollId;
                //                    oModelforAdd.PeriodId = Convert.ToInt32(PayrollPeriodID.FirstOrDefault());
                //                    oModelforAdd.Date = x;
                //                    oModelforAdd.DateDay = DayOfWeek;
                //                    oModelforAdd.ShiftId = (int)FilterSelectedShiftRow.ShiftId;
                //                    oModelforAdd.CreateDate = DateTime.Now;
                //                    oModelforAdd.UserId = LoginUser;
                //                    oModelforAdd.FlgProcessed = false;
                //                    oModelforAdd.FlgPosted = false;
                //                    if ((string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime == "00:00")
                //                       && (string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime == "00:00"))
                //                    {
                //                        oModelforAdd.FlgOffDay = true;
                //                    }
                //                    else if ((!string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime != "00:00")
                //                      && (!string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime != "00:00"))
                //                    {
                //                        oModelforAdd.FlgOffDay = false;
                //                    }
                //                    oAttendanceRegisterAddList.Add(oModelforAdd);
                //                }
                //            }
                //        }
                //        else
                //        {
                //            Snackbar.Add($@"No Payroll assigned to the employee: {FilterEmployee.EmpId}", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //            continue;
                //        }
                //    }
                //}
                //else
                //{
                //    Snackbar.Add($@"Date deviates from active calendar.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //    IsEmployeeValidate = false;
                //}

                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                IsEmployeeValidate = false;
            }
        }

        //private void LoadEmployeeAttendanceRecordStandard()
        //{
        //    DateTime StartDate = DateTime.MinValue, dtError = DateTime.MinValue;
        //    DateTime EndDate = DateTime.MinValue;
        //    string strEmpCode = string.Empty, strEmpName, strWorkHours, strShortHours, strTotalWorkingHours, strOffDay, strDescription, shiftName, shiftTimeIn, shiftTimeOut, shiftBufferTimeIn, shiftBufferTimeOut, StartGraceTime, EndGraceTime;
        //    string shiftHours, strTimeIn = "00:00", strTimeOut = "00:00", strOverTimeHours, strOverTimeType, strEarlyOutMinutes, strLeaveHours, strLeaveType, strLeaveTypeCode, strStatus, strDeductionRule;
        //    string strLateInMinutes, strStandardWorkingHours = "00:00", shiftReportingTime = "00:00", strOtAdjustment = "00:00";
        //    string strDay, strRemarks, strPreTimeIn, strPreTimeOut;
        //    Boolean flgOverTime, flgLeaveIsNew, flgInOverLap, flgOutOverLap, flgProcessed, flgNewImport, flgPosted, flgShiftExpectedOut, flgShiftExpectedIn;
        //    decimal LeaveCount = 0;
        //    int RecordCounter = 0, intLeaveType = -1;
        //    decimal TempTimeIn = 0, ReportingTime = 0, TempPreTimeOut = 0;
        //    string strPreviousTimeOut = "";
        //    try
        //    {
        //        StartDate = _dateRange.Start.Value;
        //        EndDate = _dateRange.End.Value;

        //        int totalCnt = 0;

        //        totalCnt = oListFilteredEmployee.Count();
        //        //prog = oApplication.StatusBar.CreateProgressBar("Attendance Processing", totalCnt, false);                

        //        for (int i = 0; i < oListFilteredEmployee.Count(); i++)
        //        {
        //            strEmpCode = oListFilteredEmployee.ElementAt(i).EmpId;
        //            var oEmp = oListEmployee.Where(x => x.EmpId == strEmpCode).FirstOrDefault();
        //            strEmpName = oEmp.FirstName + ' ' + oEmp.MiddleName + ' ' + oEmp.LastName;
        //            for (DateTime x = StartDate; x <= EndDate; x = x.AddDays(1))
        //            {
        //                if (oEmp != null)
        //                {
        //                    bool IsHoliday = false, IsPublicHoliday = false;
        //                    bool flgActualTimeOutOverlap = false;
        //                    bool flgActualTimeInOverlap = false;
        //                    strOffDay = string.Empty;
        //                    strTimeIn = string.Empty;
        //                    strTimeOut = string.Empty;
        //                    strWorkHours = string.Empty;
        //                    strShortHours = string.Empty;
        //                    shiftTimeIn = string.Empty;
        //                    shiftTimeOut = string.Empty;
        //                    shiftHours = string.Empty;
        //                    shiftBufferTimeIn = string.Empty;
        //                    shiftBufferTimeOut = string.Empty;
        //                    StartGraceTime = string.Empty;
        //                    EndGraceTime = string.Empty;
        //                    strOverTimeHours = string.Empty;
        //                    strLateInMinutes = string.Empty;
        //                    strEarlyOutMinutes = string.Empty;
        //                    strStatus = string.Empty;
        //                    strLeaveHours = string.Empty;
        //                    strLeaveType = string.Empty;
        //                    strOverTimeType = string.Empty;
        //                    strLeaveTypeCode = string.Empty;
        //                    strDeductionRule = string.Empty;
        //                    flgLeaveIsNew = false;
        //                    flgOverTime = false;
        //                    flgInOverLap = false;
        //                    flgOutOverLap = false;
        //                    flgProcessed = false;
        //                    flgPosted = false;

        //                    flgShiftExpectedIn = false;
        //                    flgShiftExpectedOut = false;
        //                    intLeaveType = -1;
        //                    LeaveCount = 0;
        //                    strOffDay = "";
        //                    strDescription = "";
        //                    strDay = string.Empty;
        //                    strRemarks = string.Empty;
        //                    strTotalWorkingHours = string.Empty;
        //                    string EmpCalenderID = oEmp.EmpCalender;
        //                    dtError = x;
        //                    TempPreTimeOut = 0;

        //                    flgProcessed = oListAttendanceRegister.Where(a => a.Date == x && a.EmpId == oEmp.Id).Select(a => a.Processed).FirstOrDefault() ?? false;

        //                    flgPosted = oListAttendanceRegister.Where(a => a.Date == x && a.EmpId == oEmp.Id).Select(a => a.FlgPosted).FirstOrDefault() ?? false;

        //                    if (flgPosted) continue;

        //                    string dayofWeeks = Convert.ToString(x.DayOfWeek);
        //                    decimal decShiftTimeIn = 0M;
        //                    decimal decShiftTimeOut = 0M;
        //                    decimal decTimeIn = 0M;
        //                    decimal decTimeOut = 0M;
        //                    decimal decTimeOutCheck24Hrs = 0M;
        //                    decimal Time24Hours = ConvertTimeToDecimal("23:59");
        //                    decimal decBufferTimeIn = 0M;

        //                    if (!flgProcessed)
        //                    {
        //                        #region Read from temp attendance

        //                        var oAttendanceRegister = oListAttendanceRegister.Where(a => a.Date == x && a.EmpId == oEmp.Id && (((a.Processed == null ? false : Convert.ToBoolean(a.Processed)) == false) ||
        //                                                   ((a.Processed == null ? false : Convert.ToBoolean(a.Processed)) == true))).FirstOrDefault();
        //                        if (oAttendanceRegister != null)
        //                        {
        //                            #region Shift Data
        //                            strDay = string.IsNullOrEmpty(oAttendanceRegister.DateDay) ? "" : oAttendanceRegister.DateDay;
        //                            shiftName = string.IsNullOrEmpty(oAttendanceRegister.Shift.Code) ? "" : oAttendanceRegister.Shift.Code;

        //                            var ShiftDetail = oListShift.Where(a => a.Code == shiftName).FirstOrDefault().MstShiftDetails.Where(a => a.Day == dayofWeeks && a.ShiftId == oAttendanceRegister.Shift.Id).FirstOrDefault();
        //                            if (ShiftDetail != null)
        //                            {
        //                                shiftTimeIn = ShiftDetail.StartTime;
        //                                shiftReportingTime = shiftTimeIn;
        //                                shiftBufferTimeIn = ShiftDetail.BufferStartTime;
        //                                shiftBufferTimeOut = ShiftDetail.BufferEndTime;
        //                                StartGraceTime = ShiftDetail.StartGraceTime;
        //                                EndGraceTime = ShiftDetail.EndGraceTime;
        //                                shiftTimeOut = ShiftDetail.EndTime;
        //                                shiftHours = ShiftDetail.Duration;
        //                                flgInOverLap = ShiftDetail.FlgInOverlap == null ? false : ShiftDetail.FlgInOverlap.Value;
        //                                flgOutOverLap = ShiftDetail.FlgOutOverlap == null ? false : ShiftDetail.FlgOutOverlap.Value;
        //                                flgShiftExpectedIn = ShiftDetail.FlgExpectedIn == null ? false : ShiftDetail.FlgExpectedIn.Value;
        //                                flgShiftExpectedOut = ShiftDetail.FlgExpectedOut == null ? false : ShiftDetail.FlgExpectedOut.Value;
        //                                decShiftTimeIn = ConvertTimeToDecimal(shiftTimeIn);
        //                                decShiftTimeOut = ConvertTimeToDecimal(shiftTimeOut);

        //                            }
        //                            #endregion

        //                            DateTime nextDay = x.AddDays(1);
        //                            DateTime previosDay = x.AddDays(-1);

        //                            var TempAttendanceList = (from a in dbHrPayroll.TrnsTempAttendance
        //                                                      where a.EmpID == oEmp.EmpID
        //                                                      && a.PunchedDate >= StartDate
        //                                                      && a.PunchedDate <= EndDate
        //                                                      //select a).ToList();
        //                                                      select a).OrderBy(b => b.PunchedDate).ThenBy(t => t.PunchedTime).ToList();

        //                            var TempAttendance = (from a in dbHrPayroll.TrnsTempAttendance
        //                                                  where a.EmpID == oEmp.EmpID
        //                                                  && a.PunchedDate == x
        //                                                  //select a).ToList();
        //                                                  select a).OrderBy(b => b.PunchedDate).ThenBy(t => t.PunchedTime).ToList();

        //                            var TempAttendanceNextDay = (from a in dbHrPayroll.TrnsTempAttendance
        //                                                         where a.EmpID == oEmp.EmpID
        //                                                         && a.PunchedDate == nextDay
        //                                                         //select a).ToList();
        //                                                         select a).OrderBy(b => b.PunchedDate).ThenBy(t => t.PunchedTime).ToList();

        //                            var TempAttendancePreviousDay = (from a in dbHrPayroll.TrnsTempAttendance
        //                                                             where a.EmpID == oEmp.EmpID
        //                                                             && a.PunchedDate == previosDay
        //                                                             select a).ToList();

        //                            decShiftTimeIn = ConvertTimeToDecimal(shiftTimeIn);
        //                            decShiftTimeOut = ConvertTimeToDecimal(shiftTimeOut);
        //                            decBufferTimeIn = ConvertTimeToDecimal(shiftBufferTimeIn);

        //                            TempTimeIn = CalculateStringTime(strTimeIn);
        //                            ReportingTime = CalculateStringTime(shiftReportingTime);
        //                            decimal decGetTotalHours = 0, decProductiveHours = 0;
        //                            double decShortHours = 0;
                                   
        //                                #region Get data from temp attendance
        //                                //clsShortHrs.Visible = false;
        //                                if (!flgInOverLap && !flgOutOverLap)
        //                                {
        //                                    flgActualTimeOutOverlap = false;
        //                                    flgActualTimeInOverlap = false;

        //                                    if (TempAttendance.Count > 0)
        //                                    {
        //                                        strTimeIn = Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Min(b => b.PunchedTime));
        //                                        strTimeOut = Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Max(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Max(b => b.PunchedTime));

        //                                        if (flgShiftExpectedOut)
        //                                        {
        //                                            flgActualTimeOutOverlap = true;

        //                                            strTimeIn = Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime));
        //                                            strPreviousTimeOut = Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Max(b => b.PunchedTime));
        //                                            strTimeOut = Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime));
        //                                            if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strPreviousTimeOut))
        //                                            {
        //                                                TempTimeIn = CalculateStringTime(strTimeIn);
        //                                                TempPreTimeOut = CalculateStringTime(strPreviousTimeOut);
        //                                                if (TempTimeIn < TempPreTimeOut)
        //                                                {
        //                                                    strTimeOut = strPreviousTimeOut;
        //                                                    flgActualTimeOutOverlap = false;
        //                                                }
        //                                            }
        //                                            else if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut))
        //                                            {
        //                                                TempTimeIn = CalculateStringTime(shiftTimeIn);
        //                                                TempPreTimeOut = CalculateStringTime(strTimeOut);
        //                                                if (TempTimeIn < TempPreTimeOut)
        //                                                {
        //                                                    strTimeOut = "";
        //                                                    flgActualTimeOutOverlap = false;
        //                                                }
        //                                            }
        //                                            else if (string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut))
        //                                            {
        //                                                TempTimeIn = CalculateStringTime(shiftTimeIn);
        //                                                TempPreTimeOut = CalculateStringTime(strTimeOut);
        //                                                decimal decShiftHours = ConvertTimeToDecimal(shiftTimeIn);
        //                                                if (TempPreTimeOut > decShiftHours)
        //                                                {
        //                                                    strTimeOut = "";
        //                                                    flgActualTimeOutOverlap = false;
        //                                                }
        //                                            }

        //                                        }
        //                                        else
        //                                        {
        //                                            #region If Employee Time Out After 00:00
        //                                            if (!string.IsNullOrEmpty(strTimeOut))
        //                                            {
        //                                                decTimeOutCheck24Hrs = ConvertTimeToDecimal(strTimeOut);
        //                                                decTimeIn = ConvertTimeToDecimal(strTimeIn);
        //                                                decimal decShiftHours = ConvertTimeToDecimal(shiftTimeIn);
        //                                                if (TempPreTimeOut > decShiftHours)
        //                                                {
        //                                                    strTimeOut = "";
        //                                                    flgActualTimeOutOverlap = false;
        //                                                }
        //                                                //else if (decTimeOutCheck24Hrs <= Time24Hours && decTimeIn < decTimeOutCheck24Hrs)
        //                                                //{
        //                                                //    flgActualTimeOutOverlap = false;
        //                                                //    strTimeOut = "";
        //                                                //}
        //                                                else
        //                                                {
        //                                                    flgActualTimeOutOverlap = true;

        //                                                    if (TempAttendance.Count > 0)
        //                                                    {
        //                                                        strTimeIn = Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime));
        //                                                        strPreviousTimeOut = Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Max(b => b.PunchedTime));
        //                                                        strTimeOut = Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime));
        //                                                        if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strPreviousTimeOut))
        //                                                        {

        //                                                            TempTimeIn = CalculateStringTime(strTimeIn);
        //                                                            TempPreTimeOut = CalculateStringTime(strPreviousTimeOut);
        //                                                            if (TempTimeIn < TempPreTimeOut)
        //                                                            {
        //                                                                strTimeOut = strPreviousTimeOut;
        //                                                                flgActualTimeOutOverlap = false;
        //                                                            }
        //                                                        }
        //                                                        else if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut))
        //                                                        {
        //                                                            TempTimeIn = CalculateStringTime(shiftTimeIn);
        //                                                            TempPreTimeOut = CalculateStringTime(strTimeOut);
        //                                                            if (TempTimeIn < TempPreTimeOut)
        //                                                            {
        //                                                                strTimeOut = "";
        //                                                                flgActualTimeOutOverlap = false;
        //                                                            }
        //                                                        }
        //                                                    }

        //                                                }
        //                                            }
        //                                            #endregion
        //                                        }

        //                                    }

        //                                }
        //                                else if (!flgInOverLap && flgOutOverLap)
        //                                {
        //                                    flgActualTimeOutOverlap = true;
        //                                    flgActualTimeInOverlap = false;

        //                                    if (TempAttendance.Count > 0)
        //                                    {
        //                                        strTimeIn = Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime));
        //                                        strPreviousTimeOut = Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Max(b => b.PunchedTime));
        //                                        strTimeOut = Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendanceNextDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime));

        //                                        if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strPreviousTimeOut))
        //                                        {

        //                                            TempTimeIn = CalculateStringTime(strTimeIn);
        //                                            TempPreTimeOut = CalculateStringTime(strPreviousTimeOut);
        //                                            if (TempTimeIn < TempPreTimeOut)
        //                                            {
        //                                                strTimeOut = strPreviousTimeOut;
        //                                                flgActualTimeOutOverlap = false;
        //                                            }
        //                                        }
        //                                        else if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut))
        //                                        {

        //                                            TempTimeIn = CalculateStringTime(shiftTimeIn);
        //                                            TempPreTimeOut = CalculateStringTime(strTimeOut);
        //                                            if (TempTimeIn < TempPreTimeOut)
        //                                            {
        //                                                strTimeOut = "";
        //                                                flgActualTimeOutOverlap = false;
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                else if (flgInOverLap && !flgOutOverLap)
        //                                {
        //                                    flgActualTimeOutOverlap = false;
        //                                    flgActualTimeInOverlap = true;


        //                                    if (TempAttendance.Count > 0 && TempAttendancePreviousDay.Count > 0)
        //                                    {
        //                                        strTimeIn = Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendance.Where(a => a.In_Out == "01" || a.In_Out == "1" || a.In_Out == "In").Max(b => b.PunchedTime));
        //                                        strTimeOut = Convert.ToString(TempAttendancePreviousDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime)) == null ? "" : Convert.ToString(TempAttendancePreviousDay.Where(a => a.In_Out == "02" || a.In_Out == "2" || a.In_Out == "Out").Min(b => b.PunchedTime));
        //                                    }
        //                                }

        //                                decTimeOutCheck24Hrs = ConvertTimeToDecimal(strTimeOut);
        //                                decTimeIn = ConvertTimeToDecimal(strTimeIn);

        //                                if (decTimeOutCheck24Hrs <= Time24Hours && decTimeIn < decTimeOutCheck24Hrs)
        //                                {
        //                                    flgActualTimeOutOverlap = false;
        //                                    //if (decTimeOutCheck24Hrs < decTimeIn && decTimeOutCheck24Hrs >= decShiftTimeIn)
        //                                    //if (decTimeOutCheck24Hrs >= decShiftTimeIn)
        //                                    //{
        //                                    //    strTimeOut = "";
        //                                    //}
        //                                }
        //                                else
        //                                {
        //                                    flgActualTimeOutOverlap = true;
        //                                }
        //                                if (!string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut))
        //                                {
        //                                    strWorkHours = CalculateWorkHoursStandrad(strTimeIn, strTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                    if (ShiftDetail.MstShifts.FlgWorkingHoursOnMultipTimeInTimeOut.GetValueOrDefault() == false)
        //                                    {

        //                                        TempTimeIn = CalculateStringTime(strTimeIn);
        //                                        ReportingTime = CalculateStringTime(shiftReportingTime);
        //                                        if (TempTimeIn < ReportingTime)
        //                                        {
        //                                            strTotalWorkingHours = CalculateWorkHoursStandrad(shiftReportingTime, strTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                        }
        //                                        else
        //                                        {
        //                                            strTotalWorkingHours = CalculateWorkHoursStandrad(strTimeIn, strTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                        }
        //                                    }
        //                                }

        //                                strStandardWorkingHours = "00:00";
        //                                decGetTotalHours = 0; decProductiveHours = 0;
        //                                decShortHours = 0;
        //                                string strGetTotalHours = CalculateWorkHoursStandrad(strTimeIn, strTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                decGetTotalHours = CalculateStringTime(strGetTotalHours);
        //                                decProductiveHours = CalculateStringTime(strWorkHours);
        //                                if (decGetTotalHours > decProductiveHours)
        //                                {
        //                                    decShortHours = Convert.ToDouble(decGetTotalHours - decProductiveHours);

        //                                    TimeSpan ShortDuration = TimeSpan.FromMinutes(decShortHours);
        //                                    string output = ShortDuration.ToString("h\\:mm");
        //                                    int hrs = ShortDuration.Hours;
        //                                    int mint = ShortDuration.Minutes;
        //                                    strShortHours = string.Format("{0:00}", hrs) + ':' + string.Format("{0:00}", mint);
        //                                }

        //                                #endregion
                                    
        //                            //If Set for Off Day
        //                            #region Off Day Working.

        //                            //if (oAttendanceRegister.FlgOffDay != null)
        //                            //{
        //                            //    if (Convert.ToBoolean(oAttendanceRegister.FlgOffDay))
        //                            //    {
        //                            //        //shiftTimeIn = "00:00";
        //                            //        //shiftTimeOut = "00:00";
        //                            //        //shiftHours = "00:00";
        //                            //        //shiftBufferTimeIn = "00:00";
        //                            //        //shiftBufferTimeOut = "00:00";
        //                            //    }
        //                            //}

        //                            #endregion

        //                            //Weekend Calculation
        //                            #region Weekend

        //                            if (Convert.ToBoolean(oAttendanceRegister.FlgOffDay))
        //                            {
        //                                strDescription = "Off Day";
        //                                LeaveCount = 0.0M;
        //                            }
        //                            #endregion

        //                            //Public Holiday Calculation   
        //                            #region Public Holiday Calculation
        //                            if (!string.IsNullOrEmpty(EmpCalenderID))
        //                            {
        //                                SAPbobsCOM.Recordset oRecSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
        //                                string SQLHolidays = "SELECT \"HldCode\", \"Rmrks\" FROM \"HLD1\" WHERE \"HldCode\" = '" + EmpCalenderID + "' AND \"StrDate\" <= '" + x.ToString("yyyyMMdd") + "' AND \"EndDate\" >= '" + x.ToString("yyyyMMdd") + "'";
        //                                oRecSet.DoQuery(SQLHolidays);
        //                                if (oRecSet.RecordCount > 0)
        //                                {
        //                                    IsHoliday = true;
        //                                    IsPublicHoliday = true;
        //                                    strDescription = "Off Day";
        //                                    strRemarks = oRecSet.Fields.Item(1).Value;
        //                                }
        //                                if (IsHoliday)
        //                                {
        //                                    shiftTimeIn = "00:00";
        //                                    shiftTimeOut = "00:00";
        //                                    shiftHours = "00:00";
        //                                    LeaveCount = 0.0M;
        //                                }
        //                            }
        //                            #endregion

        //                            //Calculate LateIn Minutes
        //                            #region Calculate LateIn Minutes
        //                            if (!string.IsNullOrEmpty(strTimeIn))
        //                            {
        //                                strLateInMinutes = CalculateLateInMinutesStandard(shiftTimeIn, strTimeIn, flgOutOverLap, flgActualTimeInOverlap);
        //                                if (!string.IsNullOrEmpty(strLateInMinutes) && strLateInMinutes != "00:00")
        //                                {
        //                                    var GetDeductionRules = dbHrPayroll.SpAppliedDeductionRuleCompanyAndEmployeeWise(strLateInMinutes, shiftName).FirstOrDefault();
        //                                    if (GetDeductionRules != null)
        //                                    {
        //                                        string DeductionType = GetDeductionRules.DeductionRuleType;
        //                                        int leaveType = Convert.ToInt32(GetDeductionRules.LeaveType);
        //                                        bool Deduction = Convert.ToBoolean(GetDeductionRules.Deduction);
        //                                        strDeductionRule = Convert.ToString(GetDeductionRules.Code);
        //                                    }
        //                                    else
        //                                    {
        //                                        //MsgWarning("Please Update deduction Rules To Identify LeaveType for Shift Hours " + strEarlyOutMinutes);
        //                                        //return;
        //                                        //strLateInMinutes = "00:00";
        //                                        //strStatus += " Wrong TimeIn/LateIn Need Review ";
        //                                    }
        //                                }
        //                                //Buffer Period  Included Here                                      

        //                                var AttendanceRule = dbHrPayroll.MstAttendanceRule.Where(ru => ru.FlgGpActive == false).FirstOrDefault();
        //                                if (AttendanceRule != null)
        //                                {
        //                                    #region Company Level Grace Time
        //                                    string BufferInTime = AttendanceRule.GpAfterStartTime;
        //                                    if (!string.IsNullOrEmpty(BufferInTime) && BufferInTime != "00:00" && !string.IsNullOrEmpty(strLateInMinutes) && strLateInMinutes != "00:00")

        //                                    {

        //                                        if (!IsBufferApplicable(BufferInTime, strLateInMinutes))
        //                                        {
        //                                            strLateInMinutes = "00:00";
        //                                        }
        //                                        #region Grace Time deduction
        //                                        if (AttendanceRule.FlgDeductGpAfterStartTime.GetValueOrDefault() == true)
        //                                        {
        //                                            if (!string.IsNullOrEmpty(BufferInTime) && BufferInTime != "00:00" && !string.IsNullOrEmpty(strLateInMinutes) && strLateInMinutes != "00:00")
        //                                            {
        //                                                decimal decBufferTimein = ConvertTimeToDecimal(BufferInTime);
        //                                                decimal decLateInMinutes = ConvertTimeToDecimal(strLateInMinutes);
        //                                                if (decLateInMinutes > decBufferTimein)
        //                                                {
        //                                                    strLateInMinutes = DeductBufferTimeIn(BufferInTime, strLateInMinutes);
        //                                                }
        //                                            }
        //                                        }
        //                                        #endregion
        //                                    }
        //                                    #endregion
        //                                }
        //                                else
        //                                {
        //                                    #region Shift Grace Time
        //                                    if (!string.IsNullOrEmpty(StartGraceTime) && StartGraceTime != "00:00" && !string.IsNullOrEmpty(strLateInMinutes) && strLateInMinutes != "00:00")
        //                                    {

        //                                        if (!IsBufferApplicable(StartGraceTime, strLateInMinutes))
        //                                        {
        //                                            strLateInMinutes = "00:00";
        //                                        }

        //                                    }
        //                                    #endregion
        //                                }


        //                            }
        //                            else
        //                            {
        //                                strLateInMinutes = "00:00";
        //                            }
        //                            #endregion

        //                            //Calculate Earlyout Minutes
        //                            #region Calculate Earlyout Minutes
        //                            if (!string.IsNullOrEmpty(strTimeOut))
        //                            {
        //                                decTimeOut = ConvertTimeToDecimal(strTimeOut);
        //                                //if (strTimeIn != null)
        //                                if (!string.IsNullOrEmpty(strTimeIn) && strTimeIn != "00:00")
        //                                {
        //                                    decTimeIn = ConvertTimeToDecimal(strTimeIn);
        //                                }
        //                                else
        //                                {
        //                                    decShiftTimeIn = ConvertTimeToDecimal(shiftTimeIn);
        //                                }
        //                                if (decShiftTimeIn > decTimeOut && flgOutOverLap == false)
        //                                {
        //                                    //Do Nothing
        //                                    strEarlyOutMinutes = "00:00";
        //                                }
        //                                else
        //                                {
        //                                    strEarlyOutMinutes = CalculateEarlyOutMinutesISM(shiftTimeOut, strTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                    if (!string.IsNullOrEmpty(strEarlyOutMinutes) && strEarlyOutMinutes != "00:00")
        //                                    {
        //                                        var GetDeductionRules = dbHrPayroll.SpAppliedDeductionRuleCompanyAndEmployeeWise(strEarlyOutMinutes, shiftName).FirstOrDefault();
        //                                        if (GetDeductionRules != null)
        //                                        {
        //                                            string DeductionType = GetDeductionRules.DeductionRuleType;
        //                                            int leaveType = Convert.ToInt32(GetDeductionRules.LeaveType);
        //                                            bool Deduction = Convert.ToBoolean(GetDeductionRules.Deduction);
        //                                            strDeductionRule = Convert.ToString(GetDeductionRules.Code);
        //                                        }
        //                                        else
        //                                        {
        //                                            //MsgWarning("Please Update deduction Rules To Identify LeaveType for Shift Hours " + strEarlyOutMinutes + " on Date " + x);
        //                                            //return;
        //                                            //strEarlyOutMinutes = "00:00";
        //                                            //strStatus += " Wrong TimeOut/EarlyOut Need Review. ";
        //                                            //var DeductionAttendanceRule = (from a in dbHrPayroll.TrnsDeductionRulesDetail
        //                                            //                               where a.FKID == a.TrnsDeductionRules.ID
        //                                            //                               && a.TrnsDeductionRules.ID == ShiftDetail.MstShifts.DeductionRuleID
        //                                            //                               && a.Code == "DR_03"
        //                                            //                               select a).FirstOrDefault();
        //                                            //if (DeductionAttendanceRule != null)
        //                                            //{
        //                                            //    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType
        //                                            //                        where a.ID == DeductionAttendanceRule.LeaveType
        //                                            //                        select a).FirstOrDefault();
        //                                            //    strLeaveHours = shiftHours;
        //                                            //    LeaveCount = Convert.ToDecimal(DeductionAttendanceRule.LeaveCount);
        //                                            //    strLeaveType = oLeaveMaster.Description;
        //                                            //    strLeaveTypeCode = oLeaveMaster.Code;
        //                                            //    intLeaveType = oLeaveMaster.ID;
        //                                            //    flgLeaveIsNew = true;
        //                                            //    strDeductionRule = DeductionAttendanceRule.Code;
        //                                            //}


        //                                        }
        //                                    }

        //                                    var AttendanceRule = dbHrPayroll.MstAttendanceRule.Where(ru => ru.FlgGpActive == false).FirstOrDefault();
        //                                    if (AttendanceRule != null)
        //                                    {
        //                                        #region Company Level Grace
        //                                        string BufferOutTime = AttendanceRule.GpBeforeTimeEnd;
        //                                        if (!string.IsNullOrEmpty(BufferOutTime) && BufferOutTime != "00:00" && !string.IsNullOrEmpty(strEarlyOutMinutes) && strEarlyOutMinutes != "00:00")
        //                                        {
        //                                            if (!IsBufferApplicable(BufferOutTime, strEarlyOutMinutes))
        //                                            {
        //                                                strEarlyOutMinutes = "00:00";
        //                                            }
        //                                        }
        //                                        #endregion
        //                                    }
        //                                    else
        //                                    {
        //                                        #region Shift End Grace Time
        //                                        if (!string.IsNullOrEmpty(EndGraceTime) && EndGraceTime != "00:00" && !string.IsNullOrEmpty(strEarlyOutMinutes) && strEarlyOutMinutes != "00:00")
        //                                        {

        //                                            if (!IsBufferApplicable(EndGraceTime, strEarlyOutMinutes))
        //                                            {
        //                                                strEarlyOutMinutes = "00:00";
        //                                            }

        //                                        }
        //                                        #endregion
        //                                    }


        //                                }
        //                            }
        //                            else
        //                            {
        //                                strEarlyOutMinutes = "00:00";
        //                            }
        //                            #endregion

        //                            // Status is not in Use in Current Version
        //                            if (!string.IsNullOrEmpty(strLateInMinutes) && !string.IsNullOrEmpty(strEarlyOutMinutes))
        //                            {
        //                                if (string.IsNullOrEmpty(strStatus))
        //                                {
        //                                    strStatus = GetAttendanceStatus_NEW(strLateInMinutes, strEarlyOutMinutes);
        //                                }
        //                            }
        //                            //Calculate OverTime Here   
        //                            if (ShiftDetail.MstShifts.FlgWorkingHoursOnMultipTimeInTimeOut.GetValueOrDefault() == true)
        //                            {
        //                                if (strTotalWorkingHours != "")
        //                                {
        //                                    TimeSpan spanShiftHrs = TimeCalculate(shiftHours); //TimeCalculate(shiftHours);
        //                                    TimeSpan spanTotalHrs = TimeCalculate(strTotalWorkingHours);// TimeCalculate(strTotalWorkHours);
        //                                    if (spanTotalHrs > spanShiftHrs)
        //                                    {
        //                                        strOverTimeHours = CalculateOverTimeHours(shiftHours, strTotalWorkingHours);
        //                                        if (!string.IsNullOrEmpty(strOverTimeHours) && strOverTimeHours != "00:00")
        //                                        {
        //                                            strOverTimeType = dbHrPayroll.MstOverTime.Where(O => O.ID == ShiftDetail.MstShifts.OverTimeID.Value).FirstOrDefault().Code;
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                #region Calculate OverTime Here
        //                                if (!string.IsNullOrEmpty(strWorkHours))
        //                                {
        //                                    decimal decWorkHours = ConvertTimeToDecimal(strWorkHours);
        //                                    decimal decshiftHours = ConvertTimeToDecimal(shiftHours);
        //                                    Boolean flgPayroll = false;
        //                                    flgPayroll = Convert.ToBoolean(oEmp.CfgPayrollDefination.FlgOT);

        //                                    if (Convert.ToBoolean(oEmp.FlgOTApplicable))
        //                                    {
        //                                        if (Convert.ToBoolean(oAttendanceRegister.FlgOffDay) || (IsHoliday == true))
        //                                        {
        //                                            //if (Convert.ToBoolean(oEmp.FlgOffDayApplicable) || (IsHoliday == true))

        //                                            strOverTimeHours = strWorkHours;
        //                                            if (IsHoliday == true && ShiftDetail.MstShifts.FlgHoliDayOverTime.GetValueOrDefault() == true)
        //                                            {
        //                                                strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                   where a.ID == oAttendanceRegister.MstShifts.HoliDayOverTimeMstOverTime.ID
        //                                                                   select a.Code).FirstOrDefault() ?? "";
        //                                            }
        //                                            else if (ShiftDetail.MstShifts.FlgOffDayOverTime.GetValueOrDefault() == true)
        //                                            {
        //                                                strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                   where a.ID == oAttendanceRegister.MstShifts.OffDayOverTimeMstOverTime.ID
        //                                                                   select a.Code).FirstOrDefault() ?? "";
        //                                            }
        //                                            else if (flgPayroll)
        //                                            {
        //                                                strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                   where a.ID == oEmp.CfgPayrollDefination.OTValue
        //                                                                   select a.Code).FirstOrDefault() ?? "";
        //                                            }

        //                                        }
        //                                        //else if (decWorkHours > decshiftHours)
        //                                        else
        //                                        {

        //                                            if (decWorkHours > decshiftHours)
        //                                            {
        //                                                //Overtime offday logic commented as used above.
        //                                                string strInOverTime = "00:00";
        //                                                string strOutOverTime = "00:00";
        //                                                Time24Hours = ConvertTimeToDecimal("23:59");
        //                                                //decimal decShiftTimeIn = ConvertTimeToDecimal(shiftTimeIn);

        //                                                #region  OverTime from Shift

        //                                                if (!flgPayroll)
        //                                                {
        //                                                    flgOverTime = oAttendanceRegister.MstShifts.OverTime == null ? false : oAttendanceRegister.MstShifts.OverTime.Value;

        //                                                    if (!flgOverTime)
        //                                                    {
        //                                                        strOverTimeHours = "";
        //                                                        strOverTimeType = "";
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        bool flgEmployeeOTCheck = oAttendanceRegister.MstEmployee.FlgOTApplicable == null ? false : oAttendanceRegister.MstEmployee.FlgOTApplicable.Value;
        //                                                        bool flgShiftOTWorkHours = oAttendanceRegister.MstShifts.FlgOTWrkHrs == null ? false : oAttendanceRegister.MstShifts.FlgOTWrkHrs.Value;
        //                                                        if (flgShiftOTWorkHours)
        //                                                        {
        //                                                            if (flgEmployeeOTCheck)
        //                                                            {
        //                                                                strOverTimeHours = CalculateOverTimeISM(strTimeIn, strTimeOut, shiftTimeIn, shiftTimeOut, shiftBufferTimeIn, shiftBufferTimeOut, shiftHours, flgOutOverLap, flgActualTimeOutOverlap);

        //                                                            }
        //                                                            else
        //                                                            {
        //                                                                strOverTimeHours = "";
        //                                                                strOverTimeType = "";
        //                                                            }
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            if (flgEmployeeOTCheck)
        //                                                            {
        //                                                                if (string.IsNullOrEmpty(shiftBufferTimeIn))
        //                                                                {
        //                                                                    shiftBufferTimeIn = shiftTimeIn;
        //                                                                }
        //                                                                if (string.IsNullOrEmpty(shiftBufferTimeOut))
        //                                                                {
        //                                                                    shiftBufferTimeOut = shiftTimeOut;
        //                                                                }
        //                                                                strInOverTime = IFInOvertimeApplicableSSl(shiftBufferTimeIn, strTimeIn);
        //                                                                if (strInOverTime != "00:00")
        //                                                                {
        //                                                                    //CalculateIN Overtime AccordingToShift
        //                                                                    strInOverTime = CalculateInOvertimeApplicableSSL(shiftTimeIn, strTimeIn);
        //                                                                }
        //                                                                decTimeOut = ConvertTimeToDecimal(strTimeOut);
        //                                                                decimal decshiftBufferTimeOut = ConvertTimeToDecimal(shiftBufferTimeOut);
        //                                                                //if (Convert.ToBoolean(oAttendanceRegister.FlgOffDay))
        //                                                                //{
        //                                                                //    strOutOverTime = strWorkHours;
        //                                                                //}
        //                                                                if (decTimeOut <= Time24Hours && decShiftTimeIn > decTimeOut)
        //                                                                {
        //                                                                    strOutOverTime = IFOutOvertimeApplicableStandrad(strTimeOut, shiftBufferTimeOut, flgOutOverLap, flgActualTimeOutOverlap); //IFOutOvertimeApplicable(strTimeOut, shiftBufferTimeOut);
        //                                                                }
        //                                                                else if (decTimeOut > decshiftBufferTimeOut)
        //                                                                {
        //                                                                    //if (Convert.ToBoolean(oAttendanceRegister.FlgOffDay))
        //                                                                    //{
        //                                                                    //    strOutOverTime = strWorkHours;
        //                                                                    //}
        //                                                                    //else
        //                                                                    //{
        //                                                                    strOutOverTime = IFOutOvertimeApplicableStandrad(strTimeOut, shiftBufferTimeOut, flgOutOverLap, flgActualTimeOutOverlap); //IFOutOvertimeApplicable(strTimeOut, shiftBufferTimeOut);
        //                                                                                                                                                                                              //}

        //                                                                }

        //                                                                if (strOutOverTime != "00:00")
        //                                                                {
        //                                                                    //strOutOverTime = CalculateOutOvertimeApplicable(strTimeOut, shiftTimeOut);

        //                                                                    //strOutOverTime = CalculateOutOvertimeApplicableSSL(strTimeOut, shiftTimeOut, flgOutOverLap);
        //                                                                    if (flgActualTimeOutOverlap == true)
        //                                                                    {
        //                                                                        strOutOverTime = IFOutOvertimeApplicableStandrad(strTimeOut, shiftTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                                                    }
        //                                                                    else
        //                                                                    {
        //                                                                        //strOutOverTime = CalculateOutOvertimeApplicable(TimeOut, shiftTimeOut);
        //                                                                        strOutOverTime = CalculateOutOvertimeApplicableSSL(strTimeOut, shiftTimeOut, flgOutOverLap);
        //                                                                    }

        //                                                                }

        //                                                                strOverTimeHours = CalculateOverTimeHoursInandOutTimeSSL(strInOverTime, strOutOverTime);

        //                                                            }

        //                                                            else
        //                                                            {
        //                                                                strOverTimeHours = "";
        //                                                            }
        //                                                        }
        //                                                        if (!string.IsNullOrEmpty(strOverTimeHours) && strOverTimeHours != "00:00")
        //                                                        {

        //                                                            strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                               where a.ID == oAttendanceRegister.MstShifts.MstOverTime.ID
        //                                                                               select a.Code).FirstOrDefault() ?? "";
        //                                                        }
        //                                                        else
        //                                                        {
        //                                                            strOverTimeType = "";
        //                                                        }
        //                                                    }
        //                                                }
        //                                                #endregion

        //                                                #region OverTime from Payroll
        //                                                else
        //                                                {

        //                                                    if (string.IsNullOrEmpty(shiftBufferTimeIn))
        //                                                    {
        //                                                        shiftBufferTimeIn = shiftTimeIn;
        //                                                    }
        //                                                    if (string.IsNullOrEmpty(shiftBufferTimeOut))
        //                                                    {
        //                                                        shiftBufferTimeOut = shiftTimeOut;
        //                                                    }
        //                                                    strInOverTime = IFInOvertimeApplicableSSl(shiftBufferTimeIn, strTimeIn);
        //                                                    if (strInOverTime != "00:00")
        //                                                    {
        //                                                        //CalculateIN Overtime AccordingToShift
        //                                                        strInOverTime = CalculateInOvertimeApplicableSSL(shiftTimeIn, strTimeIn);
        //                                                    }
        //                                                    //strOutOverTime = IFOutOvertimeApplicableSSL(strTimeOut, shiftBufferTimeOut, flgOutOverLap); //IFOutOvertimeApplicable(strTimeOut, shiftBufferTimeOut);
        //                                                    strOutOverTime = IFOutOvertimeApplicableStandrad(strTimeOut, shiftBufferTimeOut, flgOutOverLap, flgActualTimeOutOverlap);
        //                                                    //IFOutOvertimeApplicableStandrad
        //                                                    if (strOutOverTime != "00:00")
        //                                                    {
        //                                                        //strOutOverTime = CalculateOutOvertimeApplicable(strTimeOut, shiftTimeOut);
        //                                                        strOutOverTime = CalculateOutOvertimeApplicableSSL(strTimeOut, shiftTimeOut, flgOutOverLap);
        //                                                    }
        //                                                    if (decTimeIn > decShiftTimeIn)
        //                                                    {
        //                                                        strOverTimeHours = CalculateOverTimeHours(shiftHours, strWorkHours);
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        strOverTimeHours = CalculateOverTimeHoursInandOutTime(strInOverTime, strOutOverTime);
        //                                                    }
        //                                                    //OverTime on Weekend
        //                                                    if (shiftHours == "00:00")
        //                                                    {
        //                                                        strOverTimeHours = strWorkHours;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(strOverTimeHours) && strOverTimeHours != "00:00")
        //                                                    {
        //                                                        //strOverTimeType = dbHrPayroll.MstOverTime.Where(O => O.ID == AttendanceRegister.MstShifts.OverTimeID.Value).FirstOrDefault().Code;
        //                                                        strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                           where a.ID == oEmp.CfgPayrollDefination.OTValue
        //                                                                           select a.Code).FirstOrDefault() ?? "";
        //                                                    }

        //                                                }
        //                                                #endregion
        //                                            }
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        strOverTimeHours = "";
        //                                        strOverTimeType = "";
        //                                    }
        //                                }
        //                                #endregion
        //                            }
        //                            //Calculate New Leaves Structured.

        //                            #region Calculate Leaves
        //                            //Full Days Leave Absent
        //                            #region Full Leave Case
        //                            if (string.IsNullOrEmpty(strTimeIn) && string.IsNullOrEmpty(strTimeOut) && shiftHours != "00:00")
        //                            {

        //                                var PostedLeave = (from a in dbHrPayroll.TrnsLeavesRequest
        //                                                   where a.MstEmployee.EmpID == oEmp.EmpID
        //                                                   && a.LeaveFrom <= x
        //                                                   && a.LeaveTo >= x
        //                                                   && a.DocAprStatus == "LV0006"
        //                                                   select a).FirstOrDefault();

        //                                if (PostedLeave != null)
        //                                {
        //                                    strLeaveHours = "00:00";
        //                                    LeaveCount = 0M;
        //                                    strLeaveType = "";
        //                                    strLeaveTypeCode = "";
        //                                    intLeaveType = 0;
        //                                    flgLeaveIsNew = false;
        //                                    strDeductionRule = "";
        //                                    strDescription = PostedLeave.LeaveDescription; //"Leave already Posted.";
        //                                }
        //                                else
        //                                {
        //                                    if (oAttendanceRegister.FlgOffDay != true)
        //                                    {
        //                                        if (Program.systemInfo.FlgAbsent == true)
        //                                        {

        //                                        }
        //                                        if ((oEmp.DefaultOffDay != null ? oEmp.DefaultOffDay.ToLower() : "") != dayofWeeks.ToLower())
        //                                        {
        //                                            var oDedRule = (from a in dbHrPayroll.MstDeductionRules
        //                                                            where a.Code == "DR_03"
        //                                                            select a).FirstOrDefault();

        //                                            if (oDedRule != null)
        //                                            {
        //                                                if (oDedRule.LeaveType != null && oDedRule.LeaveType != 0)
        //                                                {
        //                                                    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType
        //                                                                        where a.ID == oDedRule.LeaveType
        //                                                                        select a).FirstOrDefault();
        //                                                    strLeaveHours = shiftHours;
        //                                                    LeaveCount = 1.0M;
        //                                                    strLeaveType = oLeaveMaster.Description;
        //                                                    strLeaveTypeCode = oLeaveMaster.Code;
        //                                                    intLeaveType = oLeaveMaster.ID;
        //                                                    flgLeaveIsNew = true;
        //                                                    strDeductionRule = oDedRule.Code;
        //                                                    //strDesc = "";
        //                                                }
        //                                                else
        //                                                {
        //                                                    MsgError("Leave Type not selected in deduction rule 3.");
        //                                                    return;
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            #endregion

        //                            //Work Hour differ's from Shift Hours
        //                            #region Work Hour Differs Shift Hours
        //                            if (!string.IsNullOrEmpty(strWorkHours) && shiftHours != "00:00")
        //                            {
        //                                if ((oEmp.DefaultOffDay != null ? oEmp.DefaultOffDay.ToLower() : "") != dayofWeeks.ToLower())
        //                                {
        //                                    #region Leave from Leave Request
        //                                    var PostedLeave = (from a in dbHrPayroll.TrnsLeavesRequest
        //                                                       where a.MstEmployee.EmpID == oEmp.EmpID
        //                                                       && a.LeaveFrom <= x
        //                                                       && a.LeaveTo >= x
        //                                                       && a.DocAprStatus == "LV0006"
        //                                                       select a).FirstOrDefault();

        //                                    if (PostedLeave != null)
        //                                    {
        //                                        //strLeaveHours = "00:00";
        //                                        LeaveCount = Convert.ToDecimal(PostedLeave.TotalCount);
        //                                        //strLeaveType = "";
        //                                        //strLeaveTypeCode = "";
        //                                        //intLeaveType = 0;
        //                                        //flgLeaveIsNew = false;
        //                                        //strDeductionRule = "";
        //                                        strDescription = PostedLeave.LeaveDescription + "-" + LeaveCount.ToString(); //"Leave already Posted.";
        //                                    }
        //                                    #endregion
        //                                    strTotalWorkingHours = strWorkHours;
        //                                    TimeSpan spanShiftHrs = TimeCalculate(shiftHours); //TimeCalculate(shiftHours);
        //                                    TimeSpan spanTotalHrs = TimeCalculate(strTotalWorkingHours);// TimeCalculate(strTotalWorkHours);
        //                                    string TempLeaveHours = "";
        //                                    if (CompanyName.ToLower() == "nsm" && spanTotalHrs <= spanShiftHrs)
        //                                    {
        //                                        TempLeaveHours = CalculateOverTimeHours(strWorkHours, shiftHours);
        //                                    }
        //                                    else
        //                                    {
        //                                        TempLeaveHours = CalculateLeaveHoursOTAdjustment(shiftHours, strWorkHours, strOverTimeHours, strLateInMinutes, strEarlyOutMinutes, out strOverTimeHours);
        //                                    }
        //                                    if (!string.IsNullOrEmpty(TempLeaveHours) && TempLeaveHours != "00:00")
        //                                    {
        //                                        var oDedRule = dbHrPayroll.SpAppliedDeductionRuleCompanyAndEmployeeWise(TempLeaveHours, shiftName).FirstOrDefault();
        //                                        if (oDedRule != null)
        //                                        {
        //                                            if (oDedRule.Code == "DR_02")
        //                                            {
        //                                                if (oDedRule.LeaveType != null && oDedRule.LeaveType != 0)
        //                                                {
        //                                                    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType
        //                                                                        where a.ID == oDedRule.LeaveType
        //                                                                        select a).FirstOrDefault();
        //                                                    strLeaveHours = TempLeaveHours;// CalculateHalfShiftHours(shiftHours);
        //                                                    LeaveCount = Convert.ToDecimal(oDedRule.LeaveCount.GetValueOrDefault());
        //                                                    strLeaveType = oLeaveMaster.Description;
        //                                                    strLeaveTypeCode = oLeaveMaster.Code;
        //                                                    intLeaveType = oLeaveMaster.ID;
        //                                                    flgLeaveIsNew = true;
        //                                                    strDeductionRule = oDedRule.Code;
        //                                                    strOffDay = "";
        //                                                }
        //                                            }
        //                                            else if (oDedRule.Code == "DR_01")
        //                                            {
        //                                                if (oDedRule.LeaveType != null && oDedRule.LeaveType != 0)
        //                                                {
        //                                                    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType
        //                                                                        where a.ID == oDedRule.LeaveType
        //                                                                        select a).FirstOrDefault();

        //                                                    strLeaveHours = TempLeaveHours;
        //                                                    LeaveCount = GetLeaveCountOnMinLeaves(strLeaveHours, shiftHours);
        //                                                    strLeaveType = oLeaveMaster.Description;
        //                                                    strLeaveTypeCode = oLeaveMaster.Code;
        //                                                    intLeaveType = oLeaveMaster.ID;
        //                                                    flgLeaveIsNew = true;
        //                                                    strDeductionRule = oDedRule.Code;
        //                                                    strOffDay = "";
        //                                                }
        //                                            }
        //                                            else if (oDedRule.Code == "DR_03")
        //                                            {
        //                                                if (oDedRule.LeaveType != null && oDedRule.LeaveType != 0)
        //                                                {
        //                                                    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType
        //                                                                        where a.ID == oDedRule.LeaveType
        //                                                                        select a).FirstOrDefault();
        //                                                    strLeaveHours = TempLeaveHours;
        //                                                    LeaveCount = Convert.ToDecimal(oDedRule.LeaveCount.GetValueOrDefault());
        //                                                    strLeaveType = oLeaveMaster.Description;
        //                                                    strLeaveTypeCode = oLeaveMaster.Code;
        //                                                    intLeaveType = oLeaveMaster.ID;
        //                                                    flgLeaveIsNew = true;
        //                                                    strDeductionRule = oDedRule.Code;
        //                                                    strOffDay = "";
        //                                                }
        //                                            }
        //                                        }

        //                                    }
        //                                }
        //                            }
        //                            #endregion
        //                            //Time In / Time Out Missing.
        //                            #region Time In,Out Missing.
        //                            if (((string.IsNullOrEmpty(strTimeIn) && !string.IsNullOrEmpty(strTimeOut)) ||
        //                                    (!string.IsNullOrEmpty(strTimeIn) && string.IsNullOrEmpty(strTimeOut)))
        //                                && (Convert.ToBoolean(Program.systemInfo.FlgAbsent.GetValueOrDefault()))
        //                                && !(Convert.ToBoolean(oAttendanceRegister.FlgOffDay.GetValueOrDefault()))
        //                                && !IsHoliday)
        //                            {
        //                                var oAttRule = (from a in dbHrPayroll.MstAttendanceRule select a).FirstOrDefault();
        //                                if (oAttRule != null)
        //                                {
        //                                    var oLeaveMaster = (from a in dbHrPayroll.MstLeaveType where a.Code == oAttRule.LeaveTypeWOP select a).FirstOrDefault();
        //                                    if (oLeaveMaster != null)
        //                                    {
        //                                        strLeaveHours = shiftHours;
        //                                        LeaveCount = 1.0M;
        //                                        strLeaveType = oLeaveMaster.Description;
        //                                        strLeaveTypeCode = oLeaveMaster.Code;
        //                                        intLeaveType = oLeaveMaster.ID;
        //                                        flgLeaveIsNew = true;
        //                                        strDeductionRule = "DR_03";
        //                                    }
        //                                }
        //                            }
        //                            else if (((string.IsNullOrEmpty(strTimeIn) || string.IsNullOrEmpty(strTimeOut)))
        //                                && (Convert.ToBoolean(Program.systemInfo.FlgAbsent == false))
        //                                && (Convert.ToBoolean(oAttendanceRegister.FlgOffDay == false)))
        //                            {
        //                                LeaveCount = 0.0M;
        //                                strLeaveTypeCode = "";
        //                                flgLeaveIsNew = false;
        //                            }
        //                            #endregion

        //                            #endregion

        //                            if (strLeaveHours.Trim() == "")
        //                            {
        //                                strLeaveHours = "00:00";
        //                            }
        //                            if (strOverTimeHours.Trim() == "")
        //                            {
        //                                strOverTimeHours = "00:00";
        //                            }

        //                            #region Assign value in grid
        //                            dtAttendance.Rows.Add(1);
        //                            dtAttendance.SetValue("Id", RecordCounter, oAttendanceRegister.Id);
        //                            dtAttendance.SetValue("No", RecordCounter, RecordCounter + 1);
        //                            dtAttendance.SetValue("EmpCode", RecordCounter, strEmpCode.Trim());
        //                            dtAttendance.SetValue("EmpName", RecordCounter, strEmpName.Trim());
        //                            dtAttendance.SetValue("Date", RecordCounter, Convert.ToDateTime(x).ToString("yyyyMMdd"));
        //                            dtAttendance.SetValue(clDay.DataBind.Alias, RecordCounter, strDay);
        //                            dtAttendance.SetValue("Shift", RecordCounter, shiftName.Trim());
        //                            dtAttendance.SetValue("SfStart", RecordCounter, shiftTimeIn.Trim());
        //                            dtAttendance.SetValue("SfEnd", RecordCounter, shiftTimeOut.Trim());
        //                            dtAttendance.SetValue("SfHours", RecordCounter, shiftHours.Trim());
        //                            dtAttendance.SetValue("ReportingTime", RecordCounter, shiftReportingTime.Trim());
        //                            dtAttendance.SetValue("TimeIn", RecordCounter, strTimeIn.Trim());
        //                            dtAttendance.SetValue("TimeOut", RecordCounter, strTimeOut.Trim());
        //                            dtAttendance.SetValue("LateInMin", RecordCounter, strLateInMinutes.Trim());
        //                            dtAttendance.SetValue("EarlyOutMin", RecordCounter, strEarlyOutMinutes.Trim());
        //                            dtAttendance.SetValue("Status", RecordCounter, strStatus.Trim());
        //                            dtAttendance.SetValue("WorkHours", RecordCounter, strWorkHours.Trim());
        //                            dtAttendance.SetValue("ShortHours", RecordCounter, strShortHours.Trim());
        //                            dtAttendance.SetValue("OTType", RecordCounter, strOverTimeType.Trim());
        //                            dtAttendance.SetValue("OTHours", RecordCounter, strOverTimeHours.Trim());
        //                            dtAttendance.SetValue("LevHours", RecordCounter, strLeaveHours.Trim());
        //                            if (CompanyName.ToLower() == "dl nash")
        //                            {
        //                                dtAttendance.SetValue("LevCount", RecordCounter, string.Format("{0:0.00000}", LeaveCount));
        //                            }
        //                            else
        //                            {
        //                                dtAttendance.SetValue("LevCount", RecordCounter, string.Format("{0:0.0000}", LeaveCount));
        //                            }
        //                            dtAttendance.SetValue("IsNewLeave", RecordCounter, flgLeaveIsNew == true ? "Y" : "N");
        //                            dtAttendance.SetValue("LevType", RecordCounter, strLeaveTypeCode.Trim());
        //                            dtAttendance.SetValue("clDesc", RecordCounter, strDescription.Trim());
        //                            dtAttendance.SetValue("AdjHrs", RecordCounter, "00:00");
        //                            dtAttendance.SetValue("TotalHrs", RecordCounter, strWorkHours.Trim());
        //                            dtAttendance.SetValue("OTAdjt", RecordCounter, "00:00");
        //                            dtAttendance.SetValue("StandHrs", RecordCounter, strStandardWorkingHours);
        //                            dtAttendance.SetValue(clDRType.DataBind.Alias, RecordCounter, strDeductionRule.Trim());
        //                            dtAttendance.SetValue(clRemarks.DataBind.Alias, RecordCounter, strRemarks);
        //                            RecordCounter++;
        //                            #endregion
        //                        }
        //                        else
        //                        {
        //                            if (oEmp.JoiningDate > x)
        //                            {
        //                                //oApplication.StatusBar.SetText("EmpID : " + oEmp.EmpID + " is New Joiner, date of joining is: " + Convert.ToDateTime(oEmp.JoiningDate).ToString("MM/dd/yyyy") + "", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //                            }
        //                            else
        //                            {
        //                                oApplication.StatusBar.SetText("EmpID : " + oEmp.EmpID + " shift not assign on date : " + x.ToString("MM/dd/yyyy"), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //                            }
        //                        }
        //                        #endregion
        //                    }

        //                    else
        //                    {
        //                        #region Read from saved attendance
        //                        IsHoliday = false;
        //                        IsPublicHoliday = false;
        //                        var oAttendanceRegisterSaved = (from a in dbHrPayroll.TrnsAttendanceRegister
        //                                                        where a.Date == x && a.MstEmployee.EmpID == oEmp.EmpID
        //                                                        && (a.Processed == null ? false : Convert.ToBoolean(a.Processed)) == true
        //                                                        select a).FirstOrDefault();
        //                        if (oAttendanceRegisterSaved != null)
        //                        {
        //                            shiftName = string.IsNullOrEmpty(oAttendanceRegisterSaved.MstShifts.Description) ? "" : oAttendanceRegisterSaved.MstShifts.Description;
        //                            var ShiftDetail = (from a in dbHrPayroll.MstShiftDetails where a.Day == dayofWeeks && a.ShiftID == oAttendanceRegisterSaved.MstShifts.Id select a).FirstOrDefault();
        //                            if (ShiftDetail != null)
        //                            {
        //                                shiftTimeIn = ShiftDetail.StartTime;
        //                                shiftBufferTimeIn = ShiftDetail.BufferStartTime;
        //                                shiftBufferTimeOut = ShiftDetail.BufferEndTime;
        //                                shiftTimeOut = ShiftDetail.EndTime;
        //                                shiftHours = ShiftDetail.Duration;
        //                                flgInOverLap = ShiftDetail.FlgInOverlap.Value;
        //                                flgOutOverLap = ShiftDetail.FlgOutOverlap.Value;
        //                            }
        //                            strStatus = "";
        //                            strTimeIn = oAttendanceRegisterSaved.TimeIn;
        //                            strTimeOut = oAttendanceRegisterSaved.TimeOut;
        //                            strWorkHours = oAttendanceRegisterSaved.WorkHour;
        //                            strLateInMinutes = string.IsNullOrEmpty(oAttendanceRegisterSaved.LateInMin) ? "" : oAttendanceRegisterSaved.LateInMin;
        //                            strEarlyOutMinutes = string.IsNullOrEmpty(oAttendanceRegisterSaved.EarlyOutMin) ? "" : oAttendanceRegisterSaved.EarlyOutMin;
        //                            strOverTimeHours = string.IsNullOrEmpty(oAttendanceRegisterSaved.OTHour) ? "" : oAttendanceRegisterSaved.OTHour;
        //                            strDeductionRule = string.IsNullOrEmpty(oAttendanceRegisterSaved.LeaveDedRule) ? "" : oAttendanceRegisterSaved.LeaveDedRule.Trim();
        //                            strLeaveType = oAttendanceRegisterSaved.LeaveType == null ? "" : Convert.ToString(oAttendanceRegisterSaved.LeaveType);
        //                            strOffDay = oAttendanceRegisterSaved.Description == null ? "" : (Convert.ToBoolean(oAttendanceRegisterSaved.FlgOffDay) ? "Off Day" : "");
        //                            strDescription = string.IsNullOrEmpty(oAttendanceRegisterSaved.Description) ? "" : oAttendanceRegisterSaved.Description;
        //                            strLeaveHours = string.IsNullOrEmpty(oAttendanceRegisterSaved.LeaveHour) ? "" : oAttendanceRegisterSaved.LeaveHour;
        //                            flgLeaveIsNew = Convert.ToBoolean(oAttendanceRegisterSaved.FlgIsNewLeave);
        //                            strRemarks = string.IsNullOrEmpty(oAttendanceRegisterSaved.Remarks) ? "" : oAttendanceRegisterSaved.Remarks;
        //                            strDay = string.IsNullOrEmpty(oAttendanceRegisterSaved.DateDay) ? "" : oAttendanceRegisterSaved.DateDay;
        //                            strPreTimeIn = string.IsNullOrEmpty(oAttendanceRegisterSaved.PreTimeIn) ? "" : oAttendanceRegisterSaved.PreTimeIn;
        //                            strPreTimeOut = string.IsNullOrEmpty(oAttendanceRegisterSaved.PreTimeOut) ? "" : oAttendanceRegisterSaved.PreTimeOut;
        //                            strStandardWorkingHours = string.IsNullOrEmpty(oAttendanceRegisterSaved.StandardPaidHours) ? "" : oAttendanceRegisterSaved.StandardPaidHours;
        //                            shiftReportingTime = string.IsNullOrEmpty(oAttendanceRegisterSaved.ReportingTime) ? "" : oAttendanceRegisterSaved.ReportingTime;
        //                            strOtAdjustment = string.IsNullOrEmpty(oAttendanceRegisterSaved.OvertimeAdjustment) ? "" : oAttendanceRegisterSaved.OvertimeAdjustment;
        //                            strShortHours = string.IsNullOrEmpty(oAttendanceRegisterSaved.ShortHours) ? "" : oAttendanceRegisterSaved.ShortHours;
        //                            #region Weekend
        //                            if (!string.IsNullOrEmpty(shiftHours) && shiftHours == "00:00")
        //                            {
        //                                strOffDay = "Off Day";
        //                                LeaveCount = 0.0M;
        //                                IsHoliday = true;
        //                            }

        //                            if (Convert.ToBoolean(oAttendanceRegisterSaved.FlgOffDay))
        //                            {
        //                                strOffDay = "Off Day";
        //                                LeaveCount = 0.0M;
        //                                IsHoliday = true;
        //                                if (!string.IsNullOrEmpty(strWorkHours) && strWorkHours != "00:00")
        //                                {
        //                                    bool flgShiftOffDayOTHours = oAttendanceRegisterSaved.MstShifts.FlgOffDayOverTime == null ? false : oAttendanceRegisterSaved.MstShifts.OverTime.Value;
        //                                    if (flgShiftOffDayOTHours)
        //                                    {
        //                                        //strOverTimeHours = strWorkHours;
        //                                        if (flgShiftOffDayOTHours)
        //                                        {
        //                                            strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                               where a.ID == oAttendanceRegisterSaved.MstShifts.OffDayOverTimeMstOverTime.ID
        //                                                               select a.Code).FirstOrDefault() ?? "";
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            #endregion

        //                            #region Public Holiday Calculation
        //                            if (!string.IsNullOrEmpty(EmpCalenderID))
        //                            {
        //                                SAPbobsCOM.Recordset oRecSet = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
        //                                string SQLHolidays = "SELECT \"HldCode\", \"Rmrks\" FROM \"HLD1\" WHERE \"HldCode\" = '" + EmpCalenderID + "' AND \"StrDate\" <= '" + x.ToString("yyyyMMdd") + "' AND \"EndDate\" >= '" + x.ToString("yyyyMMdd") + "'";
        //                                oRecSet.DoQuery(SQLHolidays);
        //                                if (oRecSet.RecordCount > 0)
        //                                {
        //                                    IsHoliday = true;
        //                                    IsPublicHoliday = true;
        //                                    strDescription = "Off Day";
        //                                    strRemarks = oRecSet.Fields.Item(1).Value;
        //                                }
        //                                if (IsHoliday)
        //                                {
        //                                    shiftTimeIn = "00:00";
        //                                    shiftTimeOut = "00:00";
        //                                    shiftHours = "00:00";
        //                                    LeaveCount = 0.0M;
        //                                }
        //                            }
        //                            #endregion

        //                            #region Calculate OverTime Here

        //                            if (!string.IsNullOrEmpty(strWorkHours) && strWorkHours != "00:00")
        //                            {
        //                                strOverTimeType = "";
        //                                decimal decWorkHours = ConvertTimeToDecimal(strWorkHours);
        //                                decimal decshiftHours = ConvertTimeToDecimal(shiftHours);
        //                                bool flgEmployeeOTCheck = oAttendanceRegisterSaved.MstEmployee.FlgOTApplicable == null ? false : oAttendanceRegisterSaved.MstEmployee.FlgOTApplicable.Value;
        //                                bool flgShiftOTHours = oAttendanceRegisterSaved.MstShifts.FlgOTWrkHrs == null ? false : oAttendanceRegisterSaved.MstShifts.FlgOTWrkHrs.Value;
        //                                bool flgShiftOffDayOTHours = oAttendanceRegisterSaved.MstShifts.FlgOffDayOverTime == null ? false : oAttendanceRegisterSaved.MstShifts.FlgOffDayOverTime.Value;
        //                                bool flgShiftHoliDayOTHours = oAttendanceRegisterSaved.MstShifts.FlgHoliDayOverTime == null ? false : oAttendanceRegisterSaved.MstShifts.FlgHoliDayOverTime.Value;
        //                                Boolean flgOvertimePayrollSetup = oEmp.CfgPayrollDefination.FlgOT != null ? Convert.ToBoolean(oEmp.CfgPayrollDefination.FlgOT) : false;
        //                                Boolean flgPayroll = false;
        //                                flgPayroll = Convert.ToBoolean(oEmp.CfgPayrollDefination.FlgOT);
        //                                if (flgEmployeeOTCheck)
        //                                {
        //                                    if (flgShiftOffDayOTHours || flgShiftOTHours || flgShiftHoliDayOTHours)
        //                                    {
        //                                        if (Convert.ToBoolean(oAttendanceRegisterSaved.FlgOffDay) || (IsHoliday == true) || IsPublicHoliday == true)
        //                                        {
        //                                            if (flgShiftOffDayOTHours || flgShiftHoliDayOTHours || IsHoliday == true || IsPublicHoliday == true)
        //                                            {
        //                                                strOverTimeHours = strWorkHours;
        //                                                if (IsPublicHoliday == true && flgShiftHoliDayOTHours)
        //                                                {
        //                                                    strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                       where a.ID == oAttendanceRegisterSaved.MstShifts.HoliDayOverTimeMstOverTime.ID
        //                                                                       select a.Code).FirstOrDefault() ?? "";
        //                                                }
        //                                                else if (flgShiftOffDayOTHours && Convert.ToBoolean(oAttendanceRegisterSaved.FlgOffDay))
        //                                                {
        //                                                    strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                       where a.ID == oAttendanceRegisterSaved.MstShifts.OffDayOverTimeMstOverTime.ID
        //                                                                       select a.Code).FirstOrDefault() ?? "";
        //                                                }
        //                                                else if (flgOvertimePayrollSetup)
        //                                                {
        //                                                    strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                       where a.ID == oEmp.CfgPayrollDefination.OTValue
        //                                                                       select a.Code).FirstOrDefault() ?? "";
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                if (!string.IsNullOrEmpty(oAttendanceRegisterSaved.OTHour))
        //                                                {
        //                                                    strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                       where a.ID == oAttendanceRegisterSaved.OTType
        //                                                                       select a.Code).FirstOrDefault() ?? "";
        //                                                }
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            if (!string.IsNullOrEmpty(oAttendanceRegisterSaved.OTHour))
        //                                            {
        //                                                strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                                   where a.ID == oAttendanceRegisterSaved.OTType
        //                                                                   select a.Code).FirstOrDefault() ?? "";
        //                                            }
        //                                        }
        //                                    }
        //                                    else if (flgPayroll)
        //                                    {
        //                                        if (!string.IsNullOrEmpty(oAttendanceRegisterSaved.OTHour))
        //                                        {
        //                                            strOverTimeType = (from a in dbHrPayroll.MstOverTime
        //                                                               where a.ID == oAttendanceRegisterSaved.OTType
        //                                                               select a.Code).FirstOrDefault() ?? "";
        //                                        }
        //                                    }
        //                                }

        //                            }
        //                            #endregion

        //                            if (Convert.ToBoolean(oAttendanceRegisterSaved.FlgOffDay) || (IsHoliday == true))
        //                            {
        //                                strLeaveTypeCode = "-1";
        //                                LeaveCount = 0;
        //                                flgLeaveIsNew = false;
        //                            }
        //                            else
        //                            {
        //                                if (!string.IsNullOrEmpty(strLeaveType))
        //                                {
        //                                    strLeaveTypeCode = (from a in dbHrPayroll.MstLeaveType where a.ID.ToString() == strLeaveType select a.Code).FirstOrDefault() ?? "";
        //                                    LeaveCount = Convert.ToDecimal(oAttendanceRegisterSaved.LeaveCount);

        //                                }
        //                            }
        //                            if (!string.IsNullOrEmpty(strLateInMinutes) && !string.IsNullOrEmpty(strEarlyOutMinutes))
        //                            {
        //                                strStatus = GetAttendanceStatus_NEW(strLateInMinutes, strEarlyOutMinutes);
        //                            }


        //                            #region Assign value in grid
        //                            dtAttendance.Rows.Add(1);
        //                            dtAttendance.SetValue("Id", RecordCounter, oAttendanceRegisterSaved.Id);
        //                            dtAttendance.SetValue("No", RecordCounter, RecordCounter + 1);
        //                            dtAttendance.SetValue("EmpCode", RecordCounter, strEmpCode.Trim());
        //                            dtAttendance.SetValue("EmpName", RecordCounter, strEmpName.Trim());
        //                            dtAttendance.SetValue("Date", RecordCounter, Convert.ToDateTime(x).ToString("yyyyMMdd"));
        //                            dtAttendance.SetValue(clDay.DataBind.Alias, RecordCounter, strDay);
        //                            dtAttendance.SetValue("Shift", RecordCounter, shiftName.Trim());
        //                            dtAttendance.SetValue("SfStart", RecordCounter, shiftTimeIn.Trim());
        //                            dtAttendance.SetValue("SfEnd", RecordCounter, shiftTimeOut.Trim());
        //                            dtAttendance.SetValue("SfHours", RecordCounter, shiftHours.Trim());
        //                            dtAttendance.SetValue("ReportingTime", RecordCounter, shiftReportingTime.Trim());
        //                            dtAttendance.SetValue("TimeIn", RecordCounter, strTimeIn.Trim());
        //                            dtAttendance.SetValue("TimeOut", RecordCounter, strTimeOut.Trim());
        //                            dtAttendance.SetValue("LateInMin", RecordCounter, strLateInMinutes.Trim());
        //                            dtAttendance.SetValue("EarlyOutMin", RecordCounter, strEarlyOutMinutes.Trim());
        //                            dtAttendance.SetValue("Status", RecordCounter, strStatus.Trim());
        //                            dtAttendance.SetValue("WorkHours", RecordCounter, strWorkHours.Trim());
        //                            dtAttendance.SetValue("ShortHours", RecordCounter, strShortHours.Trim());
        //                            dtAttendance.SetValue("OTType", RecordCounter, strOverTimeType.Trim());
        //                            dtAttendance.SetValue("OTHours", RecordCounter, strOverTimeHours.Trim());
        //                            dtAttendance.SetValue("LevHours", RecordCounter, strLeaveHours.Trim());
        //                            if (CompanyName.ToLower() == "dl nash")
        //                            {
        //                                dtAttendance.SetValue("LevCount", RecordCounter, string.Format("{0:0.00000}", LeaveCount));
        //                            }
        //                            else
        //                            {
        //                                dtAttendance.SetValue("LevCount", RecordCounter, string.Format("{0:0.0000}", LeaveCount));
        //                            }
        //                            dtAttendance.SetValue("IsNewLeave", RecordCounter, flgLeaveIsNew == true ? "Y" : "N");
        //                            dtAttendance.SetValue("LevType", RecordCounter, strLeaveTypeCode.Trim());
        //                            dtAttendance.SetValue("clDesc", RecordCounter, strDescription.Trim());
        //                            dtAttendance.SetValue("AdjHrs", RecordCounter, "00:00");
        //                            dtAttendance.SetValue("TotalHrs", RecordCounter, strWorkHours.Trim());
        //                            dtAttendance.SetValue("OTAdjt", RecordCounter, strOtAdjustment.Trim());
        //                            dtAttendance.SetValue("StandHrs", RecordCounter, strStandardWorkingHours);
        //                            dtAttendance.SetValue(clDRType.DataBind.Alias, RecordCounter, strDeductionRule.Trim());
        //                            dtAttendance.SetValue(clRemarks.DataBind.Alias, RecordCounter, strRemarks);

        //                            RecordCounter++;
        //                            #endregion
        //                        }
        //                        else
        //                        {
        //                            oApplication.StatusBar.SetText("EmpID : " + oEmp.EmpID + " shift not assign on date : " + x.ToString("MM/dd/yyyy"), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //                        }
        //                        #endregion
        //                    }
        //                }
        //            }
        //            prog.Text = "(" + prog.Value.ToString() + " of " + totalCnt.ToString() + " ) Attendance Processing of EmpID--> " + strEmpCode + "";
        //        }
        //        System.Windows.Forms.Application.DoEvents();
        //        if (prog != null)
        //        {
        //            prog.Stop();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(prog);
        //            prog = null;
        //            totalCnt = 0;
        //        }

        //        #region Company wise Logics               
        //        if (Program.systemInfo.FlgLateInEarlyOutLeaveRules == true)
        //        {
        //            CalculatingLateInOrEarlyOut();
        //        }
        //        else if (CompanyName.ToLower() == "ssl")
        //        {
        //            ApplyDeductionsSSL();
        //        }
        //        var oAttendanceRule = (from a in dbHrPayroll.MstAttendanceRule
        //                               select a).FirstOrDefault();
        //        if (oAttendanceRule != null)
        //        {
        //            if (Convert.ToBoolean(oAttendanceRule.FlgSandwichLeaves))
        //            {
        //                SandWichLeave();
        //            }
        //        }
        //        if (CompanyName.ToLower() == "ism")
        //        {
        //            SandWichLeave();
        //        }
        //        #endregion

        //        grdAttendance.LoadFromDataSource();

        //        if (flgDirectSave == true)
        //        {
        //            //SaveAttendanceRecordStandarsDirectSave();
        //            SaveAttendanceRecordStandard();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string strErrorLineNumber = ex.StackTrace;
        //        oApplication.StatusBar.SetText("Error loading records EmpCode : " + strEmpCode + " Date : " + dtError.ToString("MM/dd/yyyy") + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //    finally
        //    {
        //        if (prog != null)
        //        {
        //            prog.Stop();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(prog);
        //        }
        //        prog = null;
        //    }
        //}

        //private decimal ConvertTimeToDecimal(string ActualHours)
        //{
        //    decimal OtHours = 0;
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(ActualHours))
        //        {
        //            string[] EndDate = ActualHours.Split(':');
        //            if (EndDate.Length != 2)
        //            {
        //                return 0;
        //            }
        //            else
        //            {
        //                double decPunchTimeOUT = TimeCalculate(ActualHours).TotalHours;
        //                OtHours = Convert.ToDecimal(decPunchTimeOUT);
        //            }
        //        }
        //        return OtHours;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex.Message);
        //        return 0;
        //    }

        //}

        //private static TimeSpan TimeCalculate(string Hours)
        //{
        //    try
        //    {
        //        TimeSpan spanShiftHrs = new TimeSpan(int.Parse(Hours.Split(':')[0]),
        //   int.Parse(Hours.Split(':')[1]), 0);
        //        return spanShiftHrs;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex.Message);
        //        return TimeSpan.Zero;
        //    }

        //}

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                if (oListFilteredEmployee.Count() > 0)
                {
                    //if (oListSelectedShift.Count() > 0)
                    //{
                    //    await EmployeeValidation();
                    //    if (oAttendanceRegisterAddList.Count() > 0)
                    //    {
                    //        res = await _trnsAttendanceRegister.Insert(oAttendanceRegisterAddList);
                    //    }
                    //    if (oAttendanceRegisterUpdateList.Count() > 0)
                    //    {
                    //        res = await _trnsAttendanceRegister.Update(oAttendanceRegisterUpdateList);
                    //    }

                    //    if (res != null && res.Id == 1)
                    //    {
                    //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    //        await Task.Delay(3000);
                    //        Navigation.NavigateTo("/AttendanceProcessing", forceLoad: true);
                    //    }
                    //    else
                    //    {
                    //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //    }
                    //}
                    //else
                    //{
                    //    Snackbar.Add("No Shift selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    //}
                }
                else
                {
                    Snackbar.Add("No Employee selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
                return res;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                return null;
            }
        }

        #endregion

        #region Events

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Loading = true;
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                    await GetAllTrnsAttendanceRegister();
                    await GetAllTrnsTempAttendance();
                    await GetAllEmployees();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    await GetAllPayroll();
                    await GetAllCalendar();
                    await GetAllShifts();
                }
                else
                {
                    Navigation.NavigateTo("/Login", forceLoad: true);
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion
    }
}