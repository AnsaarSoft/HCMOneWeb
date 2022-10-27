using Blazored.LocalStorage;
using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Bonus;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeBonus
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
        public IMstElement _mstElement { get; set; }

        [Inject]
        public IMstBonus _mstBonus { get; set; }

        [Inject]
        public ITrnsElementTransaction _trnsElementTransaction { get; set; }

        [Inject]
        public ITrnsEmployeeBonus _trnsEmployeeBonus { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string searchStringFilteredEmployeeBonus = "";
        private bool FilterFuncFilteredEmployeeBonus(TrnsEmployeeBonusDetail element) => FilterFuncFilteredEmployeeBonus(element, searchStringFilteredEmployeeBonus);

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
        private IEnumerable<MstElementLink> oListPayrollElementLink = new List<MstElementLink>();
        private IEnumerable<CfgPeriodDate> oListPayrollPeriod = new List<CfgPeriodDate>();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oListCalendar = new List<MstCalendar>();

        private IEnumerable<MstElement> oElementListPer = new List<MstElement>();
        private IEnumerable<MstElement> oElementListFilter = new List<MstElement>();
        private IEnumerable<MstBonu> oBonusList = new List<MstBonu>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<TrnsEmployeeElement> oListEmployeeElement = new List<TrnsEmployeeElement>();
        private IEnumerable<TrnsEmployeeElementDetail> oListEmployeeElementDetail = new List<TrnsEmployeeElementDetail>();

        TrnsEmployeeBonu oModel = new TrnsEmployeeBonu();
        List<TrnsEmployeeBonu> oEmployeeBonusAddList = new List<TrnsEmployeeBonu>();
        List<TrnsEmployeeBonu> oEmployeeBonusUpdateList = new List<TrnsEmployeeBonu>();
        private IEnumerable<TrnsEmployeeBonu> oList = new List<TrnsEmployeeBonu>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeBonus");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsEmployeeBonu)result.Data;
                    oModel = res;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private Task SetDocNo()
        {
            try
            {
                oModel.DocumentNo = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }

        private async Task GetAllEmployeeBonus()
        {
            try
            {
                oList = await _trnsEmployeeBonus.GetAllData();
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
                var SelectedPayroll = oListPayroll.FirstOrDefault();
                oListPayrollElementLink = SelectedPayroll.MstElementLinks;

                List<MstElement> oListTemp = new List<MstElement>();

                foreach (var PayrollElement in oListPayrollElementLink)
                {
                    var SelectedElement = oElementListPer.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                    if (SelectedElement != null)
                    {
                        oListTemp.Add(SelectedElement);
                    }
                }
                oElementListFilter = oListTemp.ToList();

                oModel.PayrollId = SelectedPayroll.Id;
                oModel.PayrollCode = SelectedPayroll.PayrollName;
                oListPayrollPeriod = SelectedPayroll.CfgPeriodDates.Where(x => x.PayrollId == oModel.PayrollId).ToList();
                var SelectedPeriod = oListPayrollPeriod.Where(x => DateTime.Now.Date >= x.StartDate && DateTime.Now.Date <= x.EndDate).FirstOrDefault();
                oModel.PaysInPeriodId = SelectedPeriod.Id;
                oModel.PaysInPeriodCode = SelectedPeriod.PeriodName;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async void GetAllPayrollElements()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.PayrollCode))
                {
                    var SelectedPayroll = oListPayroll.Where(x => x.PayrollName == oModel.PayrollCode).FirstOrDefault();
                    oListPayrollElementLink = SelectedPayroll.MstElementLinks;

                    List<MstElement> oListTemp = new List<MstElement>();
                    foreach (var PayrollElement in oListPayrollElementLink)
                    {
                        var SelectedElement = oElementListPer.Where(x => x.Id == PayrollElement.ElementId).FirstOrDefault();
                        if (SelectedElement != null)
                        {
                            oListTemp.Add(SelectedElement);
                        }
                    }
                    oElementListFilter = oListTemp.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            _ = InvokeAsync(StateHasChanged);
        }

        private async Task GetAllCalendar()
        {
            try
            {
                oListCalendar = await _mstCalendar.GetAllData();
                oModelCalendar = oListCalendar.Where(x => x.FlgActive == true).FirstOrDefault();
                oModel.CalendarId = oModelCalendar.Id;
                oModel.CalendarCode = oModelCalendar.Code;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllElement()
        {
            try
            {
                oElementListPer = await _mstElement.GetAllData();
                oElementListPer = oElementListPer.Where(x => x.FlgActive == true && x.FlgEmployeeBonus == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllBonus()
        {
            try
            {
                oBonusList = await _mstBonus.GetAllData();
                oBonusList = oBonusList.Where(x => x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private async Task GetAllEmpElementTransaction()
        {
            try
            {
                oListEmployeeElement = await _trnsElementTransaction.GetAllData();
                //if (oList != null && oList.Count() > 0)
                //{
                //    var SelectedHeader = oListEmployeeElement.Where(x => x.FlgActive == true).FirstOrDefault();
                //    oListEmployeeElementDetail = SelectedHeader.TrnsEmployeeElementDetails;
                //}
                oListEmployeeElement = oListEmployeeElement.Where(x => x.FlgActive == true).ToList();
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
        private bool FilterFuncFilteredEmployeeBonus(TrnsEmployeeBonusDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmployeeId.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.EmployeeName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.BasicSalary.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.GrossSalary.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.SlabCode.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.SalaryRange.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Percentage.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.ToString().Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/EmployeeBonus", forceLoad: true);
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
                    oModel.TrnsEmployeeBonusDetails.Clear();
                    if (oModel.ElementType > 0)
                    {
                        foreach (var Employee in oListFilteredEmployee)
                        {
                            TrnsEmployeeBonusDetail oDetail = new TrnsEmployeeBonusDetail();
                            var CheckElementInEmployeePayroll = oListPayrollElementLink.Where(x => x.PayrollId == Employee.PayrollId).FirstOrDefault();
                            if (CheckElementInEmployeePayroll != null)
                            {
                                oDetail.EmployeeId = Employee.Id;
                                oDetail.EmployeeName = Employee.FirstName + " " + Employee.MiddleName + " " + Employee.LastName;
                                oDetail.BasicSalary = Employee.BasicSalary;
                                var GetEmployeeCalculatedGross = oListEmployeeElement.Where(x => x.EmployeeId == Employee.Id).FirstOrDefault();
                                if (GetEmployeeCalculatedGross != null)
                                {
                                    oDetail.GrossSalary = GetEmployeeCalculatedGross.EmpGrossSalary;
                                }
                                else
                                {
                                    oDetail.GrossSalary = Employee.GrossSalary;
                                }
                                if (!string.IsNullOrWhiteSpace(Employee.BonusCode))
                                {
                                    var SelectedBonus = oBonusList.Where(x => x.Code == Employee.BonusCode).FirstOrDefault();
                                    if (Convert.ToDateTime(Employee.JoiningDate).Month >= SelectedBonus.MinimumMonthsDuration)
                                    {
                                        oDetail.SlabCode = SelectedBonus.Code;
                                        oDetail.SalaryRange = SelectedBonus.SalaryFrom + "-" + SelectedBonus.SalaryTo;
                                        oDetail.Percentage = SelectedBonus.BonusPercentage;
                                        oDetail.FlgActive = true;
                                        if (SelectedBonus.ValueType == "POB")
                                        {
                                            if (Employee.BasicSalary >= SelectedBonus.SalaryFrom && Employee.BasicSalary <= SelectedBonus.SalaryTo)
                                            {
                                                oDetail.CalculatedAmount = Employee.BasicSalary * (oDetail.Percentage / 100);
                                            }
                                        }
                                        else if (SelectedBonus.ValueType == "POG")
                                        {
                                            if (oDetail.GrossSalary >= SelectedBonus.SalaryFrom && oDetail.GrossSalary <= SelectedBonus.SalaryTo)
                                            {
                                                oDetail.CalculatedAmount = oDetail.GrossSalary * (oDetail.Percentage / 100);
                                            }
                                        }
                                        else if (SelectedBonus.ValueType == "FIX")
                                        {
                                            oDetail.CalculatedAmount = oDetail.Percentage;
                                        }
                                        oModel.TrnsEmployeeBonusDetails.Add(oDetail);
                                    }
                                    else
                                    {
                                        Snackbar.Add("Joining date is smaller then minimum month on bonus", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Snackbar.Add("Select Element first", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task DeleteFromFilter(int? ID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                List<TrnsEmployeeBonusDetail> oListEmployeeBonusTemp = new List<TrnsEmployeeBonusDetail>();
                oListEmployeeBonusTemp = oModel.TrnsEmployeeBonusDetails.ToList();
                if (oModel.TrnsEmployeeBonusDetails.Count() > 0)
                {
                    var FilterRecord = oModel.TrnsEmployeeBonusDetails.Where(x => x.EmployeeId == ID).FirstOrDefault();
                    oListEmployeeBonusTemp.Remove(FilterRecord);
                    oModel.TrnsEmployeeBonusDetails = oListEmployeeBonusTemp;
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
                if (oModel.ElementType == 0)
                {
                    Snackbar.Add($@"Please fill the required field(s).", Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
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
                if (oModel.TrnsEmployeeBonusDetails.Count() > 0 && oModel.ElementType > 0)
                {
                    oModel.CreatedBy = LoginUser;
                    if (oModel.Id > 0)
                    {
                        res = await _trnsEmployeeBonus.Update(oModel);
                    }
                    else
                    {
                        res = await _trnsEmployeeBonus.Insert(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/EmployeeBonus", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
        private async Task<ApiResponseModel> ProcessedInSalary()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                List<TrnsEmployeeElement> oListTrnsElementHeaderAdd = new List<TrnsEmployeeElement>();
                List<TrnsEmployeeElement> oListTrnsElementHeaderUpdate = new List<TrnsEmployeeElement>();

                if (oModel.TrnsEmployeeBonusDetails.Count() > 0 && oModel.ElementType > 0)
                {
                    foreach (var EmployeeBonusDetail in oModel.TrnsEmployeeBonusDetails)
                    {
                        TrnsEmployeeElement oModelTrnsEmplElement = new TrnsEmployeeElement();
                        TrnsEmployeeElementDetail oModelTrnsEmplElementDetail = new TrnsEmployeeElementDetail();
                        oModelTrnsEmplElement = oListEmployeeElement.Where(x => x.EmployeeId == EmployeeBonusDetail.EmployeeId).FirstOrDefault();
                        var FilterElement = oElementListFilter.Where(x => x.Id == oModel.ElementType).FirstOrDefault();
                        if (oModelTrnsEmplElement.Id > 0)
                        {
                            oModelTrnsEmplElement.UpdatedBy = LoginUser;
                            oModelTrnsEmplElement.UpdateDate = DateTime.Now;

                            oModelTrnsEmplElementDetail = oModelTrnsEmplElement.TrnsEmployeeElementDetails.Where(x => x.ElementId == oModel.ElementType && x.PeriodName == oModel.PaysInPeriodCode).FirstOrDefault();
                            if (oModelTrnsEmplElementDetail == null)
                            {
                                oModelTrnsEmplElementDetail = new TrnsEmployeeElementDetail();
                                oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                                oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                                oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                                oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                                oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                                oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                                oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                                oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                                oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                                oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                                //oModelTrnsEmplElementDetail.EmpContr = 0;
                                //oModelTrnsEmplElementDetail.EmplrContr = 0;
                                oModelTrnsEmplElement.TrnsEmployeeElementDetails.Add(oModelTrnsEmplElementDetail);
                                oListTrnsElementHeaderUpdate.Add(oModelTrnsEmplElement);
                            }
                            //else
                            //{
                            //    oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                            //    oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                            //    oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                            //    oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                            //    oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                            //    oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                            //    oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                            //    oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                            //    oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                            //    oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                            //    //oModelTrnsEmplElementDetail.EmpContr = 0;
                            //    //oModelTrnsEmplElementDetail.EmplrContr = 0;
                            //    oModelTrnsEmplElement.TrnsEmployeeElementDetails. Add(oModelTrnsEmplElementDetail);
                            //    oListTrnsElementHeaderUpdate.Add(oModelTrnsEmplElement);
                            //}
                        }
                        else
                        {
                            oModelTrnsEmplElement.EmployeeId = EmployeeBonusDetail.EmployeeId;
                            oModelTrnsEmplElement.UserId = LoginUser;
                            oModelTrnsEmplElement.CreateDate = DateTime.Now;
                            oModelTrnsEmplElement.FlgActive = true;

                            oModelTrnsEmplElementDetail.ElementId = FilterElement.Id;
                            oModelTrnsEmplElementDetail.ElementCode = FilterElement.Code;
                            oModelTrnsEmplElementDetail.ElementDescription = FilterElement.Description;
                            oModelTrnsEmplElementDetail.ElementType = FilterElement.ElmtType;
                            oModelTrnsEmplElementDetail.ElementValueType = FilterElement.ValueType;
                            oModelTrnsEmplElementDetail.Type = FilterElement.Type;
                            oModelTrnsEmplElementDetail.FlgActive = FilterElement.FlgActive;
                            oModelTrnsEmplElementDetail.Amount = EmployeeBonusDetail.CalculatedAmount;
                            oModelTrnsEmplElementDetail.PeriodId = oModel.PaysInPeriodId;
                            oModelTrnsEmplElementDetail.PeriodName = oModel.PaysInPeriodCode;
                            oModelTrnsEmplElementDetail.EmpContr = 0;
                            oModelTrnsEmplElementDetail.EmplrContr = 0;
                            oModelTrnsEmplElement.TrnsEmployeeElementDetails.Add(oModelTrnsEmplElementDetail);
                            oListTrnsElementHeaderAdd.Add(oModelTrnsEmplElement);
                        }
                    }

                    if (oListTrnsElementHeaderAdd.Count > 0)
                    {
                        res = await _trnsElementTransaction.Insert(oListTrnsElementHeaderAdd);
                    }
                    if (oListTrnsElementHeaderUpdate.Count > 0)
                    {
                        res = await _trnsElementTransaction.Update(oListTrnsElementHeaderUpdate);
                    }
                    if (res != null && res.Id == 1)
                    {
                        oModel.Status = "Posted";
                        if (oModel.Id > 0)
                        {
                            res = await _trnsEmployeeBonus.Update(oModel);
                        }
                        else
                        {
                            res = await _trnsEmployeeBonus.Insert(oModel);
                        }

                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(3000);
                            Navigation.NavigateTo("/EmployeeBonus", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    oModel.Status = "Created";
                    await GetAllEmployeeBonus();
                    await SetDocNo();
                    await GetAllEmployees();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    await GetAllElement();
                    await GetAllPayroll();
                    await GetAllCalendar();
                    await GetAllBonus();
                    await GetAllEmpElementTransaction();
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