using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class LeaveAllocation
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
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ICfgPayrollDefinationinit _CfgPayrollDefinationInit { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IMstLeaveCalendar _mstLeaveCalendar { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstShifts _mstShift { get; set; }

        [Inject]
        public IMstEmployeeLeaves _mstEmployeeLeaves { get; set; }

        [Inject]
        public IMstLeaveType _mstLeaveType { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        bool ShowLeaveCalendar = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchStringFilteredEmployee = "";
        private string searchStringLeaveType = "";
        private bool FilterFuncFilteredEmployee(MstEmployee element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);
        private bool FilterFuncLeaveType(MstLeaveType element) => FilterFuncLeaveType(element, searchStringLeaveType);

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

        MstLeaveCalendar oModelLeaveCalendar = new MstLeaveCalendar();
        private IEnumerable<MstLeaveCalendar> oListLeaveCalendar = new List<MstLeaveCalendar>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<MstLeaveType> oListLeaveType = new List<MstLeaveType>();
        private IEnumerable<MstLeaveType> oListFilteredLeaveType = new List<MstLeaveType>();

        List<MstEmployeeLeaf> oMstEmployeeLeafAddList = new List<MstEmployeeLeaf>();
        List<MstEmployeeLeaf> oMstEmployeeLeafUpdateList = new List<MstEmployeeLeaf>();
        private IEnumerable<MstEmployeeLeaf> oList = new List<MstEmployeeLeaf>();

        #endregion

        #region Functions

        private async Task GetPayrollInit()
        {
            try
            {
                var PayrollInit = await _CfgPayrollDefinationInit.GetData();
                if (PayrollInit != null)
                {
                    if (PayrollInit.FlgLeaveCalendar == true)
                    {
                        await GetAllLeaveCalendar();
                        ShowLeaveCalendar = true;
                    }
                    else
                    {
                        await GetAllCalendar();
                        ShowLeaveCalendar = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllMstEmployeeLeaves()
        {
            try
            {
                oList = await _mstEmployeeLeaves.GetAllData();
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

        private async Task GetAllLeaveType()
        {
            try
            {
                oListLeaveType = await _mstLeaveType.GetAllData();
                oListLeaveType = oListLeaveType.Where(x => x.FlgActive == true).ToList();
                oListFilteredLeaveType = oListLeaveType;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task ResetLeaveTypes()
        {
            try
            {
                await Task.Delay(1);
                //oListFilteredLeaveType = oListLeaveType;
                await GetAllLeaveType();
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
        private async Task GetAllLeaveCalendar()
        {
            try
            {
                oListLeaveCalendar = await _mstLeaveCalendar.GetAllData();
                oModelLeaveCalendar = oListLeaveCalendar.Where(x => x.FlgActive == true).FirstOrDefault();
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
        private bool FilterFuncLeaveType(MstLeaveType element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeductionType.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.DeductionId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/LeaveAllocation", forceLoad: true);
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
        private async Task DeleteLeaveType(int ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<MstLeaveType> oListLeaveTypeTemp = new List<MstLeaveType>();
                oListLeaveTypeTemp = oListFilteredLeaveType.ToList();
                if (oListFilteredLeaveType.Count() > 0)
                {
                    var FilterRecord = oListFilteredLeaveType.Where(x => x.Id == ID).FirstOrDefault();
                    oListLeaveTypeTemp.Remove(FilterRecord);
                    oListFilteredLeaveType = oListLeaveTypeTemp;
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
                if (!string.IsNullOrWhiteSpace(oModelLeaveCalendar.Code) || !string.IsNullOrWhiteSpace(oModelCalendar.Code))
                {
                    foreach (var FilterEmployee in oListFilteredEmployee)
                    {
                        foreach (var FilterLeave in oListFilteredLeaveType)
                        {
                            MstEmployeeLeaf oModel = new MstEmployeeLeaf();
                            oModel = oList.Where(x => x.EmpId == FilterEmployee.Id && x.LeaveTypeCode == FilterLeave.Code).FirstOrDefault();
                            if (oModel != null && oModel.EmpId > 0)
                            {
                                oModel.EmpId = FilterEmployee.Id;
                                if (!string.IsNullOrWhiteSpace(oModelCalendar.Code))
                                {
                                    oModel.CalId = oModelCalendar.Id;
                                    oModel.LeaveCalCode = oModelCalendar.Code;
                                }
                                else if (!string.IsNullOrWhiteSpace(oModelLeaveCalendar.Code))
                                {
                                    oModel.CalId = oModelLeaveCalendar.Id;
                                    oModel.LeaveCalCode = oModelLeaveCalendar.Code;
                                }
                                oModel.LeaveTypeCode = FilterLeave.Code;
                                oModel.LeavesEntitled = (decimal)FilterLeave.LeaveCap;
                                oModel.FlgActive = true;
                                oModel.UserId = LoginUser;
                                oModel.CarryForwardDate = FilterLeave.MonthCollapse;
                                oModel.Source = "Leave Allocation";
                                oMstEmployeeLeafUpdateList.Add(oModel);
                            }
                            else
                            {
                                oModel = new MstEmployeeLeaf();
                                oModel.EmpId = FilterEmployee.Id;
                                if (!string.IsNullOrWhiteSpace(oModelCalendar.Code))
                                {
                                    oModel.LeaveCalCode = oModelCalendar.Code;
                                }
                                else if (!string.IsNullOrWhiteSpace(oModelLeaveCalendar.Code))
                                {
                                    oModel.LeaveCalCode = oModelLeaveCalendar.Code;
                                }
                                oModel.LeaveType = FilterLeave.Id;
                                oModel.LeaveTypeCode = FilterLeave.Code;
                                oModel.LeaveTypeDescription = FilterLeave.Description;
                                oModel.LeavesEntitled = (decimal)FilterLeave.LeaveCap;
                                oModel.FlgActive = true;
                                oModel.UserId = LoginUser;
                                oModel.CarryForwardDate = FilterLeave.MonthCollapse;
                                oModel.Source = "Leave Allocation";
                                oMstEmployeeLeafAddList.Add(oModel);
                            }
                        }
                    }
                }
                else
                {
                    Snackbar.Add($@"No Calendar assigned.", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
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
                    if (oListFilteredLeaveType.Count() > 0)
                    {
                        await EmployeeValidation();
                        if (oMstEmployeeLeafAddList.Count() > 0)
                        {
                            res = await _mstEmployeeLeaves.Insert(oMstEmployeeLeafAddList);
                        }
                        if (oMstEmployeeLeafUpdateList.Count() > 0)
                        {
                            res = await _mstEmployeeLeaves.Update(oMstEmployeeLeafUpdateList);
                        }

                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(3000);
                            Navigation.NavigateTo("/LeaveAllocation", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                    }
                    else
                    {
                        Snackbar.Add("No Leaves selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    await GetPayrollInit();
                    await GetAllMstEmployeeLeaves();
                    await GetAllEmployees();
                    await GetAllLeaveType();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    await GetAllPayroll();
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
