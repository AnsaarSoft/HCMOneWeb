using Blazored.LocalStorage;
using DocumentFormat.OpenXml.InkML;
using HCM.API.HCMModels;
using HCM.API.Models;
using HCM.UI.General;
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
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; } 
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


        MstEmployee oModelMstEmployee = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        TrnsReHireEmployee oModel = new TrnsReHireEmployee();
        private IEnumerable<TrnsReHireEmployee> oList = new List<TrnsReHireEmployee>();

        private IEnumerable<TrnsReHireEmployeeDetail> oDetailList = new List<TrnsReHireEmployeeDetail>();
        TrnsReHireEmployeeDetail oDetail = new TrnsReHireEmployeeDetail();
        private IEnumerable<TrnsReHireEmployeeDetail> oListdtl = new List<TrnsReHireEmployeeDetail>();

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();


        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        DateTime? docdate;
        TimeSpan? timefrom = new TimeSpan();
        TimeSpan? timeto = new TimeSpan();

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        #endregion


        #region Functions
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
                oListEmployee = oListEmployee.Where(x => x.FlgActive == false && (x.ResignDate != null || x.TerminationDate != null)).ToList();
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
        private Task SetDocNo()
        {
            try
            {
                oModel.DocNum = oList.Count() + 1;
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
                oModel.UserId = LoginUser;
                oDetail.ReHireId = oModel.Id;
                oDetail.DesignationId = oModelMstEmployee.DesignationId;
                oDetail.NewDesignationId = oModelDesignation.Id;
                oDetail.DeptId = oModelMstEmployee.DepartmentId;
                oDetail.NewDeptId = oModelDepartment.Id;

                oDetail.LocationId = oModelMstEmployee.LocationName;

                oDetail.NewLocaitonId = oModelLocation.Id;
                oDetail.BranchId = oModelMstEmployee.BranchId;
                oDetail.NewBranchId = oModelBranch.Id;

                if (oModel.EmpId != null)
                {
                    //foreach (var item in oDetailList)
                    //{
                    //    if (oModel.Id == 0)
                    //    {
                    //        item.CreateDt = DateTime.Now;
                    //        item.CreatedBy = LoginUser;
                    //    }
                    //    else
                    //    {
                    //        item.UpdateDt = DateTime.Now;
                    //        item.UpdatedBy = LoginUser;
                    //    }
                    //}



                    oModel.TrnsReHireEmployeeDetails.Add(oDetail);
                    if (oModel.Id == 0)
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsReHireEmployee.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsReHireEmployee.Update(oModel);
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
                //else
                //{
                //    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
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
                    await SetDocNo();
                    await GetAllDesignation();
                    await GetAllDepartments();
                    await GetAllLocation();
                    await GetAllBranches();
                    //await GetAllCalendar();
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

