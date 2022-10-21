using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.EmployeeMasterSetup;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.EmployeeMasterSetup
{
    public partial class EmployeeResign
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public ITrnsEmployeeResign _trnsEmployeeResign { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        DateRange _dateRange;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        TrnsResignation oModel = new TrnsResignation();
        private IEnumerable<TrnsResignation> oList = new List<TrnsResignation>();

        List<MstLove> oLoveList = new List<MstLove>();

        MstEmployee oModelEmployee = new MstEmployee();

        [Parameter]
        public int DocNum { get; set; }

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "EmployeeResign");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsResignation)result.Data;
                    oModel = res;
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
                parameters.Add("DialogFor", "EmployeeMaster");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstEmployee)result.Data;
                    oModelEmployee = res;
                    oModel.EmpId = oModelEmployee.Id;
                    oModel.EmpName = oModelEmployee.FirstName + " " + oModelEmployee.MiddleName + " " + oModelEmployee.LastName;
                    oModel.EmpDept = oModelEmployee.DepartmentName;
                    oModel.EmpDesg = oModelEmployee.DesignationName;
                    oModel.DateOfJoining = oModelEmployee.JoiningDate;
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
                oModel.DocNum = oList.Count() + 1;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

            return Task.CompletedTask;
        }
        private async Task GetAllEmployeeResign()
        {
            try
            {
                oList = await _trnsEmployeeResign.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLove()
        {
            try
            {
                oLoveList = await _mstLove.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/EmployeeResign", forceLoad: true);
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
                if (oModel.DocStatus == "Opened")
                {
                    Snackbar.Add("Opened document can't be update, select cancel to update", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return null;
                }
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId))
                {
                    if (oModel.Id > 0)
                    {
                        oModel.UpdatedBy = LoginUser;
                        res = await _trnsEmployeeResign.Update(oModel);
                    }
                    else
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsEmployeeResign.Insert(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/EmployeeResign", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                }
                else
                {
                    Snackbar.Add("Fill the required fields.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
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

        private async Task GetDataWithDocNum(int DocNum)
        {
            try
            {
                var result = await _trnsEmployeeResign.GetAllData();
                oModel = result.Where(x => x.DocNum == DocNum).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
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
                        await GetAllEmployeeResign();
                        await SetDocNo();
                        await GetAllLove();
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocStatus = "Draft";
                        oModel.DocAprStatus = "Pending";
                        oModel.DocDate = DateTime.Today;
                        oModel.ResignDate = DateTime.Today;
                        oModel.NoticeDays = 0;
                        oModel.StopSalary = false;
                        oModel.FlgOption1 = true;
                    }
                    else
                    {
                        oModel.DocDate = DateTime.Today;
                        oModel.ResignDate = DateTime.Today;
                        oModel.NoticeDays = 0;
                        oModel.StopSalary = false;
                        oModel.FlgOption1 = true;
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        await GetDataWithDocNum(DocNum);
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
