using Blazored.LocalStorage;
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
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        [Inject]
        public IDialogService Dialog { get; set; }
        [Inject]
        public ICfgPayrollDefination _ICfgPayrollDefination { get; set; }
        [Inject]
        public IMstEmployeeMasterData _mstEmployeeMaster { get; set; }
        [Inject]
        public IUserDataAccess _IUserDataAccess { get; set; }
        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        #endregion

        #region Variables

        private string LoginUser = "";

        bool Loading = false;
        
        private string searchStringFilteredEmployee = "";
        private string searchStringEmplyeeTransfer = "";

        private bool FilterFuncFilteredEmployee(TrnsEmployeeTransferDetail element) => FilterFuncFilteredEmployee(element, searchStringFilteredEmployee);

        


     

        private IEnumerable<MstEmployee> oListEmployee = new List<MstEmployee>();
        private IEnumerable<MstEmployee> oListFilteredEmployee = new List<MstEmployee>();

        private IEnumerable<TrnsEmployeeTransfer> oList = new List<TrnsEmployeeTransfer>();
        private TrnsEmployeeTransfer oModel = new TrnsEmployeeTransfer();

        private IEnumerable<TrnsEmployeeTransferDetail> oDetailList = new List<TrnsEmployeeTransferDetail>();
        
        
        

 


        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        UserDataAccess oDetail = new UserDataAccess();

        private IEnumerable<UserDataAccess> oListUserDataAccess = new List<UserDataAccess>();

        MstEmployee oModelEmployeeFrom = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeFrom = new List<MstEmployee>();

        MstEmployee oModelEmployeeTo = new MstEmployee();
        private IEnumerable<MstEmployee> oListEmployeeTo = new List<MstEmployee>();

        private IEnumerable<CfgPayrollDefination> PayrollName { get; set; } = new HashSet<CfgPayrollDefination>();
        private IEnumerable<CfgPayrollDefination> PayrollName1 { get; set; } = new HashSet<CfgPayrollDefination>();

        CfgPayrollDefination oPayroll = new CfgPayrollDefination();
        List<CfgPayrollDefination> oListCfgPayrollDefination = new List<CfgPayrollDefination>();

        List<UserDataAccess> oDetailListadd = new List<UserDataAccess>();

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
                var a = PayrollName;
                if ((!string.IsNullOrWhiteSpace(oModelEmployeeFrom.EmpId) && !string.IsNullOrWhiteSpace(oModelEmployeeTo.EmpId)))
                {
                    oListFilteredEmployee = oListEmployee.Where(
                        x => String.Compare(x.EmpId, oModelEmployeeFrom.EmpId) >= 0
                        && String.Compare(x.EmpId, oModelEmployeeTo.EmpId) <= 0).ToList();
                    if (PayrollName.Count() > 0)
                    {
                        foreach (var item in oListFilteredEmployee)
                        {
                            UserDataAccess deitaolmodel = new UserDataAccess();
                            deitaolmodel.FkEmpId = item.Id;
                            deitaolmodel.EmpId = item.EmpId;
                            deitaolmodel.FkPayrollId = oPayroll.Id;
                            oDetailListadd.Add(deitaolmodel);
                        }
                        oListUserDataAccess = oDetailListadd.ToList();

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
                //Loading = true;
                var res = new ApiResponseModel();
                //await Task.Delay(3);
                //if (oModel.DocStatus == "Opened")
                //{
                //    Snackbar.Add("Opened document can't be update, select cancel to update", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    Loading = false;
                //    return null;
                //}
                //if (oListFilteredEmployeeTransferDetail.Count() > 0)
                //{
                //    oDetailListadd.Clear();
                //    oModel.DocDate = docdate;
                //    foreach (var item in oListFilteredEmployeeTransferDetail)
                //    {
                //        oModel.TrnsEmployeeTransferDetails = oListFilteredEmployeeTransferDetail.ToList();
                //        //oDetailList.ToList();                        
                //        if (oModel.Id == 0)
                //        {
                //            item.CreatedBy = LoginUser;
                //            item.CreateDate = DateTime.Now.Date;
                //            oDetailListadd.Add(item);
                //            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();

                //        }
                //        else
                //        {
                //            item.UpdatedBy = LoginUser;
                //            item.UpdateDate = DateTime.Now.Date;
                //            oDetailListadd.Add(item);
                //            oModel.TrnsEmployeeTransferDetails = oDetailListadd.ToList();
                //        }


                //    }
                //    if (oModel.Id == 0)
                //    {
                //        oModel.CreatedBy = LoginUser;
                //        res = await _IUserDataAccess.Insert(oModel);
                //    }
                //    else
                //    {
                //        oModel.UpdatedBy = LoginUser;
                //        res = await _IUserDataAccess.Update(oModel);
                //    }

                //    if (res != null && res.Id == 1)
                //    {
                //        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                //        await Task.Delay(3000);
                //        Navigation.NavigateTo("/EmployeeTransfer", forceLoad: true);
                //    }
                //    else
                //    {
                //        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //    }
                //}
                //else
                //{
                //    Snackbar.Add("No Employee selected.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                //}
                //Loading = false;
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
