﻿using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.ShiftManagement
{
    public partial class ShiftScheduler
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public IMstPayroll _mstPayroll { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstCountryStateCity _mstCountryStateCity { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchStringFilteredEmployee = "";
        private bool FilterFuncFilteredEmployee(MstEmployee element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);

        private string searchStringMasterShift = "";
        private bool FilterFuncMasterShift(MstShift element) => FilterFuncMasterShift(element, searchStringMasterShift);

        private string searchStringSelectedShift = "";
        private bool FilterFuncSelectedShift(MstShift element) => FilterFuncSelectedShift(element, searchStringSelectedShift);

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        MstPayroll oModelPayroll = new MstPayroll();
        private IEnumerable<MstPayroll> oListPayroll = new List<MstPayroll>();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oListCalendar = new List<MstCalendar>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        TrnsAttendanceRegister oModel = new TrnsAttendanceRegister();
        List<TrnsAttendanceRegister> oListTrnsAttendanceRegister = new List<TrnsAttendanceRegister>();
        private IEnumerable<TrnsAttendanceRegister> oList = new List<TrnsAttendanceRegister>();

        private IEnumerable<MstShift> oListMasterShift = new List<MstShift>();
        private IEnumerable<MstShift> oListSelectedShift = new List<MstShift>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        #endregion

        #region Functions

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
                oListPayroll = await _mstPayroll.GetAllData();
                oListPayroll = oListPayroll.Where(x => x.FlgActive == true).ToList();
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
                oListMasterShift = await _mstShift.GetAllData();
                oListMasterShift = oListMasterShift.Where(x => x.FlgActive == true).ToList();
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
                        Description = o.Description,
                    }).ToList();
                var res = oListDepartment.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstDepartment
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
        private async Task<IEnumerable<MstPayroll>> SearchPayroll(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPayroll.Select(o => new MstPayroll
                    {
                        Id = o.Id,
                        PayrollName = o.PayrollName,
                    }).ToList();
                var res = oListPayroll.Where(x => x.PayrollName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstPayroll
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
        private bool FilterFuncMasterShift(MstShift element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private bool FilterFuncSelectedShift(MstShift element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/ShiftScheduler", forceLoad: true);
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
                    || !string.IsNullOrWhiteSpace(oModelDepartment.Description)
                    || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    || !string.IsNullOrWhiteSpace(oModelBranch.Description))
                {
                    oListFilteredEmployee = oListEmployee.Where(x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0 && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                                                                || x.PayrollName == oModelPayroll.PayrollName
                                                                || x.DesignationName == oModelDesignation.Description
                                                                || x.DepartmentName == oModelDepartment.Description
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

        private async Task AddShift(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<MstShift> oListShiftTemp = new List<MstShift>();
                oListShiftTemp = oListSelectedShift.ToList();
                if (oListMasterShift.Count() > 0)
                {
                    var FilterRecord = oListMasterShift.Where(x => x.Id == ID).FirstOrDefault();
                    oListShiftTemp.Add(FilterRecord);
                    oListSelectedShift = oListShiftTemp;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task DeleteShift(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<MstShift> oListShiftTemp = new List<MstShift>();
                oListShiftTemp = oListSelectedShift.ToList();
                if (oListSelectedShift.Count() > 0)
                {
                    var FilterRecord = oListSelectedShift.Where(x => x.Id == ID).FirstOrDefault();
                    oListShiftTemp.Remove(FilterRecord);
                    oListSelectedShift = oListShiftTemp;
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
                if (oModelCalendar.StartDate >= _dateRange.Start && oModelCalendar.EndDate <= _dateRange.End)
                {
                    foreach (var FilterEmployee in oListFilteredEmployee)
                    {
                        int SelectedShiftCount = 0;
                        if (FilterEmployee.PayrollId > 0)
                        {
                            oModel.PayrollId = FilterEmployee.PayrollId;
                            for (DateTime x = (DateTime)_dateRange.Start; x <= (DateTime)_dateRange.End; x = x.AddDays(1))
                            {
                                var PayrollPeriodID = oListPayroll.Where(x => x.Id == FilterEmployee.PayrollId).Select(x => x.MstPayrollPeriods.Select(x => x.Id)).FirstOrDefault();

                                if (Convert.ToInt32(PayrollPeriodID) > 0)
                                {
                                    oModel.PeriodId = Convert.ToInt32(PayrollPeriodID);
                                }
                                else
                                {
                                    Snackbar.Add($@"Period for Selected Date Range Can't be found", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                                    return;
                                }
                                if (FilterEmployee.JoiningDate > x) continue;
                                string DayOfWeek = Convert.ToString(x.DayOfWeek);

                                var CheckPostedEmployee = oList.Where(b => b.EmpId == FilterEmployee.Id && b.Date == x).FirstOrDefault();
                                if(CheckPostedEmployee != null && (CheckPostedEmployee.FlgProcessed == true || CheckPostedEmployee.FlgPosted == true))
                                {
                                    Snackbar.Add($@"Shift can not be changed Employee: {FilterEmployee.EmpId} has Attendance Processed/Posted on Date: {x.ToString("MM/dd/yyyy")}", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });                                    
                                    continue;
                                }
                                if (SelectedShiftCount == oListSelectedShift.Count())
                                {
                                    SelectedShiftCount = 0;
                                }
                                SelectedShiftCount++;
                                var FilterSelectedShiftRow = oListSelectedShift.ElementAt(SelectedShiftCount).MstShiftsDetails.ToList();
                            }
                        }
                        else
                        {
                            Snackbar.Add($@"No Payroll assigned to the employee: {FilterEmployee.EmpId}", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            continue;
                        }
                    }
                }
                else
                {
                    Snackbar.Add($@"Date deviates from active calendar.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    IsEmployeeValidate = false;
                }

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
                    if (oListSelectedShift.Count() > 0)
                    {
                        await EmployeeValidation();
                        if (IsEmployeeValidate)
                        {
                            if (oModel.Id == 0)
                            {
                                oModel.CreatedBy = LoginUser;
                                //res = await _mstEmployeeMaster.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUser;
                                //res = await _mstEmployeeMaster.Update(oModel);
                            }

                            if (res != null && res.Id == 1)
                            {
                                Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                                await Task.Delay(3000);
                                Navigation.NavigateTo("/ShiftScheduler", forceLoad: true);
                            }
                            else
                            {
                                Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                        }
                    }
                    else
                    {
                        Snackbar.Add("No Shift selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
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
                var Session = await _localStorage.GetItemAsync<MstUser>("User");
                if (Session != null)
                {
                    LoginUser = Session.UserCode;
                    _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
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