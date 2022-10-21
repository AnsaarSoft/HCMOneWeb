using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.ShiftManagement;
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

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oListCalendar = new List<MstCalendar>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        List<TrnsAttendanceRegister> oAttendanceRegisterAddList = new List<TrnsAttendanceRegister>();
        List<TrnsAttendanceRegister> oAttendanceRegisterUpdateList = new List<TrnsAttendanceRegister>();
        private IEnumerable<TrnsAttendanceRegister> oList = new List<TrnsAttendanceRegister>();

        private IEnumerable<MstShift> oListMasterShift = new List<MstShift>();
        private IEnumerable<MstShift> oListSelectedShift = new List<MstShift>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        #endregion

        #region Functions

        private async Task GetAllTrnsAttendanceRegister()
        {
            try
            {
                oList = await _trnsAttendanceRegister.GetAllData();
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
                if (_dateRange.Start >= oModelCalendar.StartDate && _dateRange.End <= oModelCalendar.EndDate)
                {
                    foreach (var FilterEmployee in oListFilteredEmployee)
                    {
                        int SelectedShiftCount = 0;
                        if (FilterEmployee.PayrollId > 0)
                        {
                            for (DateTime x = (DateTime)_dateRange.Start; x <= (DateTime)_dateRange.End; x = x.AddDays(1))
                            {
                                var PayrollPeriodID = oListPayroll.Where(x => x.Id == FilterEmployee.PayrollId).Select(b => b.CfgPeriodDates.Where(c => c.StartDate <= x && x <= c.EndDate).Select(d => d.Id)).FirstOrDefault();
                                if (Convert.ToInt32(PayrollPeriodID.FirstOrDefault()) == 0)
                                {
                                    Snackbar.Add($@"Period for Selected Date Range Can't be found", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                                    return;
                                }
                                if (FilterEmployee.JoiningDate > x) continue;
                                string DayOfWeek = Convert.ToString(x.DayOfWeek);
                                TrnsAttendanceRegister oModelforUpdate = oList.Where(b => b.EmpId == FilterEmployee.Id && b.Date == x).FirstOrDefault();
                                if (oModelforUpdate != null && (oModelforUpdate.FlgProcessed == true || oModelforUpdate.FlgPosted == true))
                                {
                                    Snackbar.Add($@"Shift can not be changed Employee: {FilterEmployee.EmpId} has Attendance Processed/Posted on Date: {x.ToString("MM/dd/yyyy")}", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                                    continue;
                                }
                                if (SelectedShiftCount == oListSelectedShift.Count())
                                {
                                    SelectedShiftCount = 0;
                                }
                                var FilterSelectedShiftRow = oListSelectedShift.ElementAt(SelectedShiftCount).MstShiftDetails.Where(x => x.Day == DayOfWeek).FirstOrDefault();
                                SelectedShiftCount++;
                                if (oModelforUpdate != null)
                                {
                                    oModelforUpdate.PeriodId = Convert.ToInt32(PayrollPeriodID.FirstOrDefault());
                                    oModelforUpdate.ShiftId = (int)FilterSelectedShiftRow.ShiftId;
                                    oModelforUpdate.DateDay = DayOfWeek;
                                    if ((string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime == "00:00")
                                        && (string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime == "00:00"))
                                    {
                                        oModelforUpdate.FlgOffDay = true;
                                    }
                                    else if ((!string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime != "00:00")
                                       && (!string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime != "00:00"))
                                    {
                                        oModelforUpdate.FlgOffDay = false;
                                    }

                                    oModelforUpdate.UpdateDate = DateTime.Now;
                                    oModelforUpdate.UpdatedBy = LoginUser;
                                    oAttendanceRegisterUpdateList.Add(oModelforUpdate);
                                }
                                else
                                {
                                    TrnsAttendanceRegister oModelforAdd = new TrnsAttendanceRegister();
                                    oModelforAdd.EmpId = FilterEmployee.Id;
                                    oModelforAdd.FkpayrollId = (int)FilterEmployee.PayrollId;
                                    oModelforAdd.PeriodId = Convert.ToInt32(PayrollPeriodID.FirstOrDefault());
                                    oModelforAdd.Date = x;
                                    oModelforAdd.DateDay = DayOfWeek;
                                    oModelforAdd.ShiftId = (int)FilterSelectedShiftRow.ShiftId;
                                    oModelforAdd.CreateDate = DateTime.Now;
                                    oModelforAdd.UserId = LoginUser;
                                    oModelforAdd.FlgProcessed = false;
                                    oModelforAdd.FlgPosted = false;
                                    if ((string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime == "00:00")
                                       && (string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime == "00:00"))
                                    {
                                        oModelforAdd.FlgOffDay = true;
                                    }
                                    else if ((!string.IsNullOrEmpty(FilterSelectedShiftRow.StartTime) || FilterSelectedShiftRow.StartTime != "00:00")
                                      && (!string.IsNullOrEmpty(FilterSelectedShiftRow.EndTime) || FilterSelectedShiftRow.EndTime != "00:00"))
                                    {
                                        oModelforAdd.FlgOffDay = false;
                                    }
                                    oAttendanceRegisterAddList.Add(oModelforAdd);
                                }
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
                        if (oAttendanceRegisterAddList.Count() > 0)
                        {
                            res = await _trnsAttendanceRegister.Insert(oAttendanceRegisterAddList);
                        }
                        if (oAttendanceRegisterUpdateList.Count() > 0)
                        {
                            res = await _trnsAttendanceRegister.Update(oAttendanceRegisterUpdateList);
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
                var Session = await _localStorage.GetItemAsync<MstEmployee>("User");
                if (Session != null)
                {
                    LoginUser = Session.EmpId;
                    _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                    await GetAllTrnsAttendanceRegister();
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
