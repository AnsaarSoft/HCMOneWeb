using Blazored.LocalStorage;
using DocumentFormat.OpenXml.Spreadsheet;
using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;


namespace HCM.UI.Pages.Authorization
{
    public partial class DataAccess
    {
        #region Inject Service

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public ICfgPayrollDefination _ICfgPayrollDefination { get; set; }

        [Inject]
        public IUserDataAccess _IUserDataAccess { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }


        #endregion

        #region Variables

        private string LoginUser = "";

        bool Loading = false;

        private string searchString1 = "";

        private bool FilterFunc(UserDataAccess element) => FilterFunc(element, searchString1);

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        CfgPayrollDefination oPayroll = new CfgPayrollDefination();
        List<CfgPayrollDefination> oListCfgPayrollDefination = new List<CfgPayrollDefination>();

        private IEnumerable<CfgPayrollDefination> SelectedPayrollList { get; set; } = new HashSet<CfgPayrollDefination>();

        UserDataAccess oModel = new UserDataAccess();
        private List<UserDataAccess> oListUserDataAccess = new List<UserDataAccess>();
        private IEnumerable<UserDataAccess> oListSaveUserDataAccess = new List<UserDataAccess>();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "UserDataAccess");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (List<UserDataAccess>)result.Data;
                    oListUserDataAccess = res;
                }
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
                //Where(x => x.FlgActive == true).
                oListDesignation = oListDesignation.ToList();
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
                //Where(x => x.FlgActive == true).
                oListDepartment = oListDepartment.ToList();
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
                oListCfgPayrollDefination = await _ICfgPayrollDefination.GetAllData();
                oListCfgPayrollDefination = oListCfgPayrollDefination.Where(x => x.FlgActive == true).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private string GetPayrollSelection(List<string> selectedValues)
        {
            try
            {
                if (selectedValues.Count < 1)
                {
                    return $"Please choose Payroll";
                }
                return $"{selectedValues.Count} Payroll{(selectedValues.Count > 1 ? "s have" : " has")} been selected";
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
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

        private async Task SearchCriteria()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                var a = SelectedPayrollList;
                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId)) 
                    || !string.IsNullOrWhiteSpace(oModelDesignation.Description) 
                    || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName) 
                    || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    )
                {
                    oListFilteredEmployee = oListEmployee.Where(
                        x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0
                        && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                        || x.DesignationName == oModelDesignation.Description
                        || x.DepartmentName == oModelDepartment.DeptName
                        || x.LocationName == oModelLocation.Description
                        ).ToList();
                    if (SelectedPayrollList.Count() > 0)
                    {
                        oListSaveUserDataAccess = await _IUserDataAccess.GetAllData();
                        foreach (var item in SelectedPayrollList)
                        {
                            foreach (var item1 in oListFilteredEmployee)
                            {
                                var chkCount = oListUserDataAccess.Where(x=>x.EmpId == item1.EmpId && x.FkPayrollId == item.Id).Count();
                                if (chkCount == 0)
                                {
                                    var chkList = oListSaveUserDataAccess.Where(x => x.EmpId == item1.EmpId && x.FkPayrollId == item.Id).Count();
                                    if (chkList == 0)
                                    {
                                        UserDataAccess deitaolmodel = new UserDataAccess();
                                        deitaolmodel.FkEmpId = item1.Id;
                                        deitaolmodel.EmpId = item1.EmpId;
                                        deitaolmodel.FkPayrollId = item.Id;
                                        deitaolmodel.PayrollName = item.PayrollName;
                                        deitaolmodel.FlgActive = true;
                                        deitaolmodel.CreatedBy = LoginUser;
                                        deitaolmodel.CreatedDate = DateTime.Now;
                                        oListUserDataAccess.Add(deitaolmodel);
                                    }
                                }
                            }
                        }
                        oListUserDataAccess = oListUserDataAccess.OrderBy(x => x.EmpId).ToList();
                    }
                    else
                    {
                        Snackbar.Add("Please Fill Field.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Select Employee Filteration.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private bool FilterFunc(UserDataAccess element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.PayrollName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/DataAccess", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task DeleteFromFilter(string empID,int payrollID)
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                var FilterRecord = oListUserDataAccess.Where(x => x.EmpId == empID && x.FkPayrollId == payrollID).FirstOrDefault();
                oListUserDataAccess.Remove(FilterRecord);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (oListUserDataAccess.Count() == 0)
                {
                    Snackbar.Add("Select Data Access Detail.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return null;
                }

                var update = oListUserDataAccess.Where(x => x.Id > 0).ToList();
                var insert = oListUserDataAccess.Where(x => x.Id == 0).ToList();

                if (insert != null && insert.Count() > 0)
                {
                    res = await _IUserDataAccess.Insert(insert);
                }
                if (update != null && update.Count() > 0)
                {
                    update.ToList().ForEach(x => { x.UpdatedBy = LoginUser; x.UpdatedDate = DateTime.Now; });
                    res = await _IUserDataAccess.Update(update);
                }
                //res = await _IUserDataAccess.Insert(oListUserDataAccess);
                //if (oModel.Id == 0)
                //{
                //    //oListUserDataAccess.ToList().ForEach(x => { x.CreatedBy = LoginUser; x.CreatedDate = DateTime.Now; x.FlgDeleted = true; });
                //    res = await _IUserDataAccess.Insert(oListUserDataAccess);
                //}
                //else
                //{
                //    //oListUserDataAccess.ToList().ForEach(x => { x.UpdatedBy = LoginUser; x.UpdatedDate = DateTime.Now; });
                //    //res = await _IUserDataAccess.Update(oListUserDataAccess);
                //}
                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/DataAccess", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    await GetAllEmployees();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
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
