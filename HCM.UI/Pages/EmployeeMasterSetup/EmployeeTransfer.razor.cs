using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using MudBlazor;
using System.Collections.Immutable;
using static MudBlazor.CategoryTypes;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeTransfer
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public IMstBranch _mstBranch { get; set; }

        [Inject]
        public IMstDesignation _mstDesignation { get; set; }

        [Inject]
        public IMstDimension _mstDimension { get; set; }
        [Inject]
        public IMstDepartment _mstDepartment { get; set; }

        [Inject]
        public IMstLocation _mstLocation { get; set; }

        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }

        [Inject]
        public ITrnsEmployeeTransfer _trnsEmployeeTransfer { get; set; }


        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        bool IsEmployeeValidate = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");

        private string value { get; set; } = "Select Dimension";
        private int docno { get; set; }

        private string searchStringFilteredEmployee = "";
        private bool FilterFuncFilteredEmployee(TrnsEmployeeTransferDetail element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);

        private string searchStringEmplyeeTransfer = "";

        MstDesignation oModelDesignation = new MstDesignation();
        private IEnumerable<MstDesignation> oListDesignation = new List<MstDesignation>();

        MstDepartment oModelDepartment = new MstDepartment();
        private IEnumerable<MstDepartment> oListDepartment = new List<MstDepartment>();

        MstDimension oModelDimension = new MstDimension();
        private IEnumerable<MstDimension> oListDimension = new List<MstDimension>();

        MstLocation oModelLocation = new MstLocation();
        private IEnumerable<MstLocation> oListLocation = new List<MstLocation>();

        MstLocation oModeltoLocation = new MstLocation();
        private IEnumerable<MstLocation> oListtoLocation = new List<MstLocation>();

        MstBranch oModelBranch = new MstBranch();
        private IEnumerable<MstBranch> oListBranch = new List<MstBranch>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<TrnsEmployeeTransfer> oList = new List<TrnsEmployeeTransfer>();
        private TrnsEmployeeTransfer oModel = new TrnsEmployeeTransfer();

        private IEnumerable<TrnsEmployeeTransferDetail> oDetailList = new List<TrnsEmployeeTransferDetail>();
        List<TrnsEmployeeTransferDetail> oDetailListadd = new List<TrnsEmployeeTransferDetail>();
        TrnsEmployeeTransferDetail oDetail = new TrnsEmployeeTransferDetail();
        private IEnumerable<TrnsEmployeeTransferDetail> oListFilteredEmployeeTransferDetail = new List<TrnsEmployeeTransferDetail>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime? docdate;


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };

        [Parameter]
        public int DocNum { get; set; }

        #endregion

        #region Functions
        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "TrnsEmployeeTransfer");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsEmployeeTransfer)result.Data;
                    oModel = res;
                    docdate = oModel.DocDate;
                    oListFilteredEmployeeTransferDetail = oModel.TrnsEmployeeTransferDetails;
                    oListFilteredEmployeeTransferDetail = oListFilteredEmployeeTransferDetail.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllEmpTrnsfer()
        {
            try
            {
                oList = await _trnsEmployeeTransfer.GetAllData();
                oModel.DoNum = oList.Select(x => x.DoNum).LastOrDefault() + 1;
                if (oModel.DoNum == null)
                {
                    oModel.DoNum = 1;
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
        private async Task GetAllBranch()
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
        private async Task GetAllDimension()
        {
            try
            {
                oListDimension = await _mstDimension.GetAllData();
                //Where(x => x.FlgActive == true).
                var states = oListDimension.ToList();
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
                //Where(x => x.FlgActive == true).
                oListtoLocation = oListLocation.ToList();
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

                if (oListFilteredEmployeeTransferDetail.Count() > 0)
                {
                    foreach (var item in oListFilteredEmployeeTransferDetail)
                    {
                        item.ToLocation = oModeltoLocation.Description;
                    }
                }
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
        private bool FilterFuncFilteredEmployee(TrnsEmployeeTransferDetail element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            //if (element.EmpId.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            if (element.EmpName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (element.PayrollName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            //if (element.BranchName.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
            //    return true;
            if (element.ExistingLocation.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.ToLocation.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Dimension1.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/EmployeeTransfer", forceLoad: true);
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
                
                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId)) || !string.IsNullOrWhiteSpace(oModel.DocStatus)

                    || !string.IsNullOrWhiteSpace(oModelDesignation.Description) || !string.IsNullOrWhiteSpace(oModelDepartment.DeptName) || !string.IsNullOrWhiteSpace(oModelLocation.Description)
                    )
                {
                    oListFilteredEmployee = oListEmployee.Where(
                        x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0
                        && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0
                        || x.DesignationName == oModelDesignation.Description
                        || x.DepartmentName == oModelDepartment.DeptName
                        || x.LocationName == oModelLocation.Description
                        ).ToList();



                    if ((!string.IsNullOrWhiteSpace(oModeltoLocation.Description)) && (!string.IsNullOrWhiteSpace(oDetail.Dimension1)) && (!string.IsNullOrWhiteSpace(oDetail.Dimension2))
                        && (!string.IsNullOrWhiteSpace(oDetail.Dimension3))
                        && (!string.IsNullOrWhiteSpace(oDetail.Dimension4)) && (!string.IsNullOrWhiteSpace(oDetail.Dimension5)))
                    {
                        foreach (var item in oListFilteredEmployee)
                        {
                            TrnsEmployeeTransferDetail deitaolmodel = new TrnsEmployeeTransferDetail();
                            deitaolmodel.EmpId = item.Id;
                            deitaolmodel.EmpCode = item.EmpId;
                            deitaolmodel.EmpName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                            deitaolmodel.ExistingLocation = item.LocationName;
                            deitaolmodel.ToLocation = oModeltoLocation.Description;
                            deitaolmodel.Dimension1 = oDetail.Dimension1;
                            deitaolmodel.Dimension2 = oDetail.Dimension2;
                            deitaolmodel.Dimension3 = oDetail.Dimension3;
                            deitaolmodel.Dimension4 = oDetail.Dimension4;
                            deitaolmodel.Dimension5 = oDetail.Dimension5;
                            oDetailListadd.Add(deitaolmodel);
                        }
                        oListFilteredEmployeeTransferDetail = oDetailListadd.ToList();

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

        //public void EditRecord(int LineNum)
        //{
        //    try
        //    {
        //        var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                
        //        if (res != null)
        //        {
        //            oModel.Id = res.Id;
        //            oModel.DoNum = res.DoNum;
        //            oModel.DocDate= res.DocDate;
        //            oModel.TrnsEmployeeTransferDetails = res.TrnsEmployeeTransferDetails;
        //            oListFilteredEmployeeTransferDetail = res.TrnsEmployeeTransferDetails;
                    
        //            oList = oList.Where(x => x.Id != LineNum);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.GenerateLogs(ex);
        //    }

        //}
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
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (oListFilteredEmployeeTransferDetail.Count() > 0)
                {
                    oDetailListadd.Clear();
                    oModel.DocDate = docdate;
                    foreach (var item in oListFilteredEmployeeTransferDetail)
                    {
                        oModel.TrnsEmployeeTransferDetails = oListFilteredEmployeeTransferDetail.ToList();
                            //oDetailList.ToList();                        
                        if (oModel.Id == 0)
                        {
                            item.CreatedBy = LoginUser;
                            item.CreateDate = DateTime.Now.Date;
                            oDetailListadd.Add(item);
                            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();

                        }
                        else
                        {
                            item.UpdatedBy = LoginUser;
                            item.UpdateDate = DateTime.Now.Date;
                            oDetailListadd.Add(item);
                            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();
                        }


                    }
                    if (oModel.Id == 0)
                    {
                        oModel.CreatedBy = LoginUser;
                        res = await _trnsEmployeeTransfer.Insert(oModel);
                    }
                    else
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsEmployeeTransfer.Update(oModel);
                    }

                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/EmployeeTransfer", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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
                    if (DocNum == 0)
                    {
                        LoginUser = Session.EmpId;
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocStatus = "Draft";
                        await GetAllEmployees();
                        await GetAllBranch();
                        await GetAllDesignation();
                        await GetAllDepartments();
                        await GetAllLocation();
                        await GetAllEmpTrnsfer();
                        await GetAllDimension();
                        var a = oModel;
                        docdate = DateTime.Now.Date;
                    }
                    else
                    {
                        //await GetLeaveRequestWithDocNum(DocNum);
                    }
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

