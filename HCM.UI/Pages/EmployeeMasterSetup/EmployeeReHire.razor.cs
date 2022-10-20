using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
//using HCM.API.Interfaces.EmployeeMasterSetup;
//using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Account;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using MudBlazor;
using System.Collections.Immutable;
using static MudBlazor.CategoryTypes;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeReHire
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public IMstPosition _mstPosition { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public IMstUser _mstUser { get; set; }

        [Inject]
        public ITrnsReHireEmployee _trnsReHireEmployee { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsFlg = false;

        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        string EmpName = "";
        private string searchString1 = "";

        private bool FilterFunc(TrnsEmployeeOvertimeDetail element) => FilterFunc(element, searchString1);

        VMEmployeeReHire oModelVMEmployeeReHire = new VMEmployeeReHire();

        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        TrnsEmployeeReHire oModel = new TrnsEmployeeReHire();
        private IEnumerable<TrnsEmployeeReHire> oList = new List<TrnsEmployeeReHire>();

        private IEnumerable<TrnsReHireEmployeeDetail> oDetailList = new List<TrnsReHireEmployeeDetail>();
        TrnsReHireEmployeeDetail oDetail = new TrnsReHireEmployeeDetail();
        private IEnumerable<TrnsReHireEmployeeDetail> oListdtl = new List<TrnsReHireEmployeeDetail>();

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstPosition oModelPosition = new MstPosition();
        private IEnumerable<MstPosition> oListPosition = new List<MstPosition>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstEmployee oModelUser = new MstEmployee();
        private IEnumerable<MstEmployee> oListUser = new List<MstEmployee>();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

       // DateTime? docdate;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion


        #region Functions
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeReHireEdit");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsEmployeeReHire)result.Data;
                    oModel = res;
                    oModelMstEmployee = oListEmployee.Where(x => x.Id == res.EmpId).FirstOrDefault();
                    if (oModelMstEmployee != null)
                    {
                        EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;
                        oModelDepartment.Id = (int)res.DepartmentIdnew;
                        oModelDepartment.DeptName = res.DepartmentNameNew;
                        oModelDesignation.Id = (int)res.DesignationIdnew;
                        oModelDesignation.Description = res.DesignationNameNew;
                        oModelBranch.Id = (int)res.BranchIdnew;
                        oModelBranch.Description = res.BranchNameNew;
                        oModelLocation.Id = (int)res.LocationIdnew;
                        oModelLocation.Description = res.LocationNameNew;
                        oModelPosition.Id = (int)res.PositionIdNew;
                        oModelPosition.Description = res.PositionNameNew;
                        oModelPayroll.Id = (int)res.PayrollIdNew;
                        oModelPayroll.PayrollName = res.PayrollNameNew;
                        oModelUser.Id = (int)res.ManagerIdnew;
                        oModelUser.FirstName = res.ManagerNameNew;
                        //oModelPayroll.Id = res.;
                        //oModelPayroll.Id = res.PayrollIdNew;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task OpenDialogEmployee(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeReHire");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelMstEmployee = res;
                    EmpName = oModelMstEmployee.FirstName + " " + oModelMstEmployee.MiddleName + " " + oModelMstEmployee.LastName;
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
              //  oListEmployee = oListEmployee.Where(x => x.FlgActive == false && (x.ResignDate != null || x.TerminationDate != null)).ToList();
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
        private async Task GetAllPosition()
        {
            try
            {
                oListPosition = await _mstPosition.GetAllData();
                oListPosition = oListPosition.Where(x => x.FlgActive == true).ToList();
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
        private async Task GetAllEmployeeReHire()
        {
            try
            {
                oList = await _trnsReHireEmployee.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllUser()
        {
            try
            {
                await Task.Delay(1);
                oListUser = oListEmployee;
                oListUser = oListUser.Where(x => x.FlgActive == true).ToList();
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
                oModel.DocNo = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private bool FilterFunc(TrnsEmployeeOvertimeDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.OvertimeId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.FlgActive.Equals(searchString1))
            //    return true;
            return false;
        }
        private async Task<IEnumerable<MstEmployee>> SearchEmployee(string value)
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
        private async Task<IEnumerable<MstEmployee>> SearchUser(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListUser.Select(o => new MstEmployee
                    {
                        Id = o.Id,
                        EmpId = o.EmpId,
                        FirstName = o.FirstName,
                    }).ToList();
                var res = oListUser.Where(x => x.FirstName.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstEmployee
                {
                    Id = x.Id,
                    EmpId = x.EmpId,
                    FirstName = x.FirstName,
                }).ToList();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task<IEnumerable<MstPosition>> SearchPosition(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oListPosition.Select(o => new MstPosition
                    {
                        Id = o.Id,
                        Description = o.Description,
                    }).ToList();
                var res = oListPosition.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstPosition
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

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/EmployeeReHire", forceLoad: true);
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
                List<TrnsTaxAdjustmentDetail> oListTrnsEmployeeTaxAdjustDtl = new List<TrnsTaxAdjustmentDetail>();
                //  oListTrnsEmployeeTaxAdjustDtl = oDetailList.ToList();
                if (oDetailList.Count() > 0)
                {
                    var FilterRecord = oDetailList.Where(x => x.Id == ID).FirstOrDefault();
                    //  oListTrnsEmployeeTaxAdjustDtl.Remove(FilterRecord);
                    // oDetailList = oListTrnsEmployeeTaxAdjustDtl;
                }
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

                oModel.EmpId = oModelMstEmployee.Id;
                oModel.EmployeeName = EmpName;
                oModel.DepartmentOld = oModelMstEmployee.DepartmentId;
                oModel.DepartNameOld = oModelMstEmployee.DepartmentName;
                oModel.DepartmentIdnew = oModelDepartment.Id;
                oModel.DepartmentNameNew = oModelDepartment.DeptName;

                oModel.DesignationOld = oModelMstEmployee.DesignationId;
                oModel.DesigNameOld = oModelMstEmployee.DesignationName;
                oModel.DesignationIdnew = oModelDesignation.Id;
                oModel.DesignationNameNew = oModelDesignation.Description;

                oModel.LocationOld = oModelMstEmployee.Location;
                oModel.LocNameOld = oModelMstEmployee.LocationName;
                oModel.LocationIdnew = oModelLocation.Id;
                oModel.LocationNameNew = oModelLocation.Description;

                oModel.BranchOld = oModelMstEmployee.BranchId;
                oModel.BranchNameOld = oModelMstEmployee.BranchName;
                oModel.BranchIdnew = oModelBranch.Id;
                oModel.BranchNameNew = oModelBranch.Description;

                oModel.PositionIdOld = oModelMstEmployee.PositionId;
                oModel.PositionNameOld = oModelMstEmployee.PositionName;
                oModel.PositionIdNew = oModelPosition.Id;
                oModel.PositionNameNew = oModelPosition.Description;

                oModel.ManagerIdold = oModelMstEmployee.Manager;
                oModel.ManagerNameOld = oModelMstEmployee.ManagerName;
                oModel.ManagerIdnew = oModelUser.Id;
                oModel.ManagerNameNew = oModelUser.FirstName;

                oModel.PayrollIdOld = oModelMstEmployee.PayrollId;
                oModel.PayrollNameOld = oModelMstEmployee.PayrollName;
                oModel.PayrollIdNew = oModelPayroll.Id;
                oModel.PayrollNameNew = oModelPayroll.PayrollName;


                oModel.Bsold = oModelMstEmployee.BasicSalary;
                oModel.Gsold = oModelMstEmployee.GrossSalary;
                oModel.JoiningDtOld = oModelMstEmployee.JoiningDate;
                oModel.JoiningDtNew = DateTime.Now;
                oModel.ResignationDtOld = oModelMstEmployee.ResignDate;
                oModel.TerminationDtOld = oModelMstEmployee.TerminationDate;

                // Update employee mst
                oModelMstEmployee.DepartmentId = oModelDepartment.Id;
                oModelMstEmployee.DepartmentName = oModelDepartment.DeptName;
                oModelMstEmployee.DesignationId = oModelDesignation.Id;
                oModelMstEmployee.DesignationName = oModelDesignation.Description;
                oModelMstEmployee.Location = oModelLocation.Id;
                oModelMstEmployee.LocationName = oModelLocation.Description;
                oModelMstEmployee.BranchId = oModelBranch.Id;
                oModelMstEmployee.BranchName = oModelBranch.Description;
                oModelMstEmployee.PositionId = oModelPosition.Id;
                oModelMstEmployee.PositionName = oModelPosition.Description;
                oModelMstEmployee.Manager = oModelUser.Id;
                oModelMstEmployee.ManagerName = oModelUser.FirstName;
                oModelMstEmployee.PayrollId = oModelPayroll.Id;
                oModelMstEmployee.PayrollName = oModelPayroll.PayrollName;
                oModelMstEmployee.JoiningDate = oModel.JoiningDtNew;
                oModelMstEmployee.BasicSalary = oModel.Bsnew;
                oModelMstEmployee.GrossSalary = oModel.Gsnew;
                oModelMstEmployee.FlgActive = oModel.FlgReHire;
                oModelMstEmployee.TermCount = 1;
                oModelMstEmployee.UpdatedBy = LoginUser;
                oModelMstEmployee.UpdateDate = DateTime.Now;
                //oModel.Emp = oModelMstEmployee;


                if ((oModel.EmpId != null && oModel.EmpId > 0)
                    && (oModel.DocDate != null)
                    && (oModel.DepartmentIdnew != null && oModel.DepartmentIdnew > 0)
                    && (oModel.DesignationIdnew != null && oModel.DesignationIdnew > 0)
                    && (oModel.BranchIdnew != null && oModel.BranchIdnew > 0)
                    && (oModel.LocationIdnew != null && oModel.LocationIdnew > 0)
                    && (oModel.PositionIdNew != null && oModel.PositionIdNew > 0)
                    && (oModel.PayrollIdNew != null && oModel.PayrollIdNew > 0)
                    && (oModel.Bsnew > 0 && oModel.Gsnew > 0)
                    && (oModel.FlgReHire == true))
                {
                    if (oModel.InternalId == 0)
                    {
                        oModelVMEmployeeReHire.TrnsEmployeeReHire = oModel;
                        oModelVMEmployeeReHire.MstEmployee = oModelMstEmployee;
                        oModel.CreatedBy = LoginUser;
                        res = await _trnsReHireEmployee.Insert(oModelVMEmployeeReHire);
                    }
                    else
                    {
                        oModelVMEmployeeReHire.TrnsEmployeeReHire = oModel;
                        oModelVMEmployeeReHire.MstEmployee = oModelMstEmployee;
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsReHireEmployee.Update(oModelVMEmployeeReHire);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/EmployeeReHire", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    await GetAllEmployees();
                    await GetAllEmployeeReHire();
                    await SetDocNo();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    await GetAllPosition();
                    await GetAllPayroll();
                    await GetAllUser();
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

