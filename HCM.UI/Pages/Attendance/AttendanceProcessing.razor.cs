﻿using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
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

        [Inject]
        public ITrnsLeaveRequest _trnsLeaveRequest { get; set; }

        [Inject]
        public IMstLeaveType _mstLeaveType { get; set; }

        [Inject]
        public ITrnsEmployeeOverTime _TrnsEmployeeOverTime { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool NextButtonClicked = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string PayrollPeriod = "";
        private string searchStringFilteredEmployee = "";
        private string searchStringAttRegister = "";

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        private bool FilterFuncFilteredEmployee(MstEmployee element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);
        private bool FilterFuncAttRegister(TrnsAttendanceRegister element) => FilterFuncAttRegister(element, searchStringAttRegister);

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
        private IEnumerable<TrnsAttendanceRegister> oListFilteredAttendanceRegister = new List<TrnsAttendanceRegister>();
        private IEnumerable<TrnsTempAttendance> oListTempAttendance = new List<TrnsTempAttendance>();

        private IEnumerable<MstShift> oListShift = new List<MstShift>();

        TrnsLeavesRequest oModelLeaveRequest = new TrnsLeavesRequest();
        private IEnumerable<TrnsLeavesRequest> oListLeaveRequest = new List<TrnsLeavesRequest>();

        private IEnumerable<MstLeaveType> oListLeaveType = new List<MstLeaveType>();

        TrnsEmployeeOvertime oModel = new TrnsEmployeeOvertime();
        private IEnumerable<TrnsEmployeeOvertime> oList = new List<TrnsEmployeeOvertime>();

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

        private async Task GetAllLeaveRequest()
        {
            try
            {
                oListLeaveRequest = await _trnsLeaveRequest.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllLeaveType()
        {
            try
            {
                oListLeaveType = await _mstLeaveType.GetAllData();
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
        private bool FilterFuncAttRegister(TrnsAttendanceRegister element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId != null && element.EmpId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FkpayrollId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PeriodId != null && element.PeriodId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ShiftId != null && element.ShiftId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Date != null && element.Date.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DateDay != null && element.DateDay.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.TimeIn != null && element.TimeIn.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.TimeOut != null && element.TimeOut.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.WorkHour != null && element.WorkHour.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LateInMin != null && element.LateInMin.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LateOutMin != null && element.LateOutMin.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EarlyInMin != null && element.EarlyInMin.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EarlyOutMin != null && element.EarlyOutMin.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Othour != null && element.Othour.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Ottype.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LeaveDuration != null && element.LeaveDuration.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LeaveType != null && element.LeaveType.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.LeaveCount != null && element.LeaveCount.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgOffDay != null && element.FlgOffDay.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgProcessed != null && element.FlgProcessed.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgPosted != null && element.FlgPosted.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
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

        private async Task FetchAttendanceProcessed()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                if (oListFilteredEmployee.Count() > 0 && _dateRange != null)
                {
                    List<TrnsAttendanceRegister> oListTemp = new List<TrnsAttendanceRegister>();
                    for (DateTime CurrentDate = (DateTime)_dateRange.Start; CurrentDate <= _dateRange.End; CurrentDate = CurrentDate.AddDays(1))
                    {
                        foreach (var FilterEmployee in oListFilteredEmployee)
                        {
                            var Attendance = oListAttendanceRegister.Where(x => x.Date == CurrentDate && x.EmpId == FilterEmployee.Id).FirstOrDefault();
                            if (Attendance != null)
                            {
                                oListTemp.Add(Attendance);
                            }
                        }
                    }
                    oListFilteredAttendanceRegister = oListTemp.ToList();
                }
                NextButtonClicked = true;
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                NextButtonClicked = false;
            }
        }

        private async Task Back()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                oListFilteredAttendanceRegister = new List<TrnsAttendanceRegister>();
                NextButtonClicked = false;
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                NextButtonClicked = false;
            }
        }

        private async Task Post()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                oListFilteredAttendanceRegister.ToList().ForEach(x => x.FlgPosted = true);
                foreach (var FilterAttendance in oListFilteredAttendanceRegister)
                {
                    if (FilterAttendance.LeaveType != null && FilterAttendance.LeaveType > 0)
                    {
                        oModelLeaveRequest = new TrnsLeavesRequest();
                        var Employee = oListFilteredEmployee.Where(x => x.Id == FilterAttendance.EmpId).FirstOrDefault();

                        var LeaveRequest = oListLeaveRequest.Where(x => FilterAttendance.Date >= x.LeaveFrom && FilterAttendance.Date <= x.LeaveTo && x.EmpId == Employee.Id).FirstOrDefault();

                        if (LeaveRequest == null)
                        {
                            oModelLeaveRequest.EmpId = Employee.Id;
                            oModelLeaveRequest.EmpName = Employee.FirstName + " " + Employee.MiddleName + " " + Employee.LastName;
                            oModelLeaveRequest.EmpDesg = Employee.DesignationName;
                            oModelLeaveRequest.EmpDept = Employee.DepartmentName;
                            oModelLeaveRequest.EmpLoc = Employee.LocationName;
                            oModelLeaveRequest.DocNum = oListLeaveRequest.Count() + 1;
                            oModelLeaveRequest.DocStatus = "Approved";
                            oModelLeaveRequest.DocAprStatus = "Approved";
                            oModelLeaveRequest.DocType = 13;
                            oModelLeaveRequest.DocDate = DateTime.Today;
                            oModelLeaveRequest.DocDate = DateTime.Today;
                            if (FilterAttendance.LeaveCount >= 1)
                            {
                                oModelLeaveRequest.Value = "Day";
                                oModelLeaveRequest.TotalCount = FilterAttendance.LeaveCount;
                                oModelLeaveRequest.LeaveFrom = FilterAttendance.Date;
                                oModelLeaveRequest.LeaveTo = FilterAttendance.Date;
                                oModelLeaveRequest.Units = FilterAttendance.LeaveCount;
                                oModelLeaveRequest.LeavesType = oListLeaveType.Where(x => x.Id == FilterAttendance.LeaveType).Select(x => x.Code).FirstOrDefault();
                            }
                            if (FilterAttendance.LeaveCount <= 1)
                            {
                                var SelectedShift = oListShift.Where(x => x.Id == FilterAttendance.ShiftId).FirstOrDefault().MstShiftDetails.Where(a => a.Day == FilterAttendance.DateDay).FirstOrDefault();
                                if (SelectedShift != null)
                                {
                                    oModelLeaveRequest.Value = "Hour";
                                    oModelLeaveRequest.TotalCount = FilterAttendance.LeaveCount;
                                    oModelLeaveRequest.FromTime = SelectedShift.StartTime;
                                    oModelLeaveRequest.ToTime = FilterAttendance.TimeIn;
                                    oModelLeaveRequest.Units = FilterAttendance.LeaveCount;
                                    oModelLeaveRequest.LeavesType = oListLeaveType.Where(x => x.Id == FilterAttendance.LeaveType).Select(x => x.Code).FirstOrDefault();
                                }
                            }
                            oModelLeaveRequest.CreateDate = DateTime.Today;
                            oModelLeaveRequest.CreatedBy = LoginUser;
                        }
                    }
                    else if (FilterAttendance.Ottype != null && FilterAttendance.Ottype > 0)
                    {
                        oModelLeaveRequest = new TrnsLeavesRequest();
                        var Employee = oListFilteredEmployee.Where(x => x.Id == FilterAttendance.EmpId).FirstOrDefault();

                        var LeaveRequest = oListLeaveRequest.Where(x => FilterAttendance.Date >= x.LeaveFrom && FilterAttendance.Date <= x.LeaveTo && x.EmpId == Employee.Id).FirstOrDefault();

                        if (LeaveRequest == null)
                        {
                            oModelLeaveRequest.EmpId = Employee.Id;
                            oModelLeaveRequest.EmpName = Employee.FirstName + " " + Employee.MiddleName + " " + Employee.LastName;
                            oModelLeaveRequest.EmpDesg = Employee.DesignationName;
                            oModelLeaveRequest.EmpDept = Employee.DepartmentName;
                            oModelLeaveRequest.EmpLoc = Employee.LocationName;
                            oModelLeaveRequest.DocNum = oListLeaveRequest.Count() + 1;
                            oModelLeaveRequest.DocStatus = "Approved";
                            oModelLeaveRequest.DocAprStatus = "Approved";
                            oModelLeaveRequest.DocType = 13;
                            oModelLeaveRequest.DocDate = DateTime.Today;
                            oModelLeaveRequest.DocDate = DateTime.Today;
                            if (FilterAttendance.LeaveCount >= 1)
                            {
                                oModelLeaveRequest.Value = "Day";
                                oModelLeaveRequest.TotalCount = FilterAttendance.LeaveCount;
                                oModelLeaveRequest.LeaveFrom = FilterAttendance.Date;
                                oModelLeaveRequest.LeaveTo = FilterAttendance.Date;
                                oModelLeaveRequest.Units = FilterAttendance.LeaveCount;
                                oModelLeaveRequest.LeavesType = oListLeaveType.Where(x => x.Id == FilterAttendance.LeaveType).Select(x => x.Code).FirstOrDefault();
                            }
                            if (FilterAttendance.LeaveCount <= 1)
                            {
                                var SelectedShift = oListShift.Where(x => x.Id == FilterAttendance.ShiftId).FirstOrDefault().MstShiftDetails.Where(a => a.Day == FilterAttendance.DateDay).FirstOrDefault();
                                if (SelectedShift != null)
                                {
                                    oModelLeaveRequest.Value = "Hour";
                                    oModelLeaveRequest.TotalCount = FilterAttendance.LeaveCount;
                                    oModelLeaveRequest.FromTime = SelectedShift.StartTime;
                                    oModelLeaveRequest.ToTime = FilterAttendance.TimeIn;
                                    oModelLeaveRequest.Units = FilterAttendance.LeaveCount;
                                    oModelLeaveRequest.LeavesType = oListLeaveType.Where(x => x.Id == FilterAttendance.LeaveType).Select(x => x.Code).FirstOrDefault();
                                }
                            }
                            oModelLeaveRequest.CreateDate = DateTime.Today;
                            oModelLeaveRequest.CreatedBy = LoginUser;
                        }
                    }
                    {
                        continue;
                    }
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
                NextButtonClicked = false;
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
                    await GetAllLeaveType();
                    await GetAllLeaveRequest();
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