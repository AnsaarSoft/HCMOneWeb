using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Advance;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCM.UI.Pages.Advance
{
    public partial class AdvanceRequest
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstAdvance _mstAdvance { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public ITrnsAdvanceRequest _trnsAdvanceRequest { get; set; }

        [Inject]
        public ICfgPayrollDefinationinit _CfgPayrollDefinationinit { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private string LoginUser = "";

        #endregion

        #region Variables

        bool Loading = false;
        int EmpPayrollID = 0;
        DateRange _dateRange;

        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };

        TrnsAdvanceRequest oModel = new TrnsAdvanceRequest();
        private IEnumerable<TrnsAdvanceRequest> oList = new List<TrnsAdvanceRequest>();

        MstAdvance oModelAdvance = new MstAdvance();
        private IEnumerable<MstAdvance> oListAdvanceType = new List<MstAdvance>();
        List<MstLove> oLoveList = new List<MstLove>();

        MstEmployee oModelEmployee = new MstEmployee();

        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        CfgPayrollBasicInitialization oModelPayrollInit = new CfgPayrollBasicInitialization();

        MstCalendar oModelCalendar = new MstCalendar();
        private IEnumerable<MstCalendar> oCalendarlList = new List<MstCalendar>();

        private IEnumerable<CfgPayrollDefination> oPayrollList = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oPayrollPeriodList = new List<CfgPeriodDate>();

        [Parameter]
        public int DocNum { get; set; }

        #endregion

        #region Functions

        private async Task OpenDialog(DialogOptions options)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "AdvanceRequest");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsAdvanceRequest)result.Data;
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
                    oModel.GrossSalary = oModelEmployee.GrossSalary;
                    oModel.BasicSalary = oModelEmployee.BasicSalary;
                    oModel.DateOfJoining = oModelEmployee.JoiningDate;
                    EmpPayrollID = (int)oModelEmployee.PayrollId;
                    await GetEmpPayroll();
                    await GetPayrollPeriods();
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
        private async Task GetAllAdvanceRequest()
        {
            try
            {
                oList = await _trnsAdvanceRequest.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllAdvanceMaster()
        {
            try
            {
                oListAdvanceType = await _mstAdvance.GetAllData();
                oListAdvanceType = oListAdvanceType.Where(x => x.FlgActive == true);
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetPayrollInit()
        {
            try
            {
                oModelPayrollInit = await _CfgPayrollDefinationinit.GetData();
                await GetCalendar();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetCalendar()
        {
            try
            {
                oCalendarlList = await _mstCalendar.GetAllData();
                oModelCalendar = oCalendarlList.Where(x => x.FlgActive == true).FirstOrDefault();
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
                Navigation.NavigateTo("/AdvanceRequest", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task GetEmpPayroll()
        {
            try
            {
                oPayrollList = await _CfgPayrollDefination.GetAllData();
                oModelPayroll = oPayrollList.Where(x => x.Id == EmpPayrollID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetPayrollPeriods()
        {
            try
            {
                await Task.Delay(1);
                if (oModelPayroll.Id > 0)
                {
                    oPayrollPeriodList = oModelPayroll.CfgPeriodDates.ToList();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }        
        private async Task SetAdvance()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.AdvanceCode))
                {
                    oModelAdvance = oListAdvanceType.Where(x => x.AllowanceId == oModel.AdvanceCode).FirstOrDefault();
                    oModel.FkadvanceId = oModelAdvance.Id;
                    oModel.AdvanceCode = oModelAdvance.AllowanceId;
                    oModel.AdvanceDescription = oModelAdvance.Description;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task VerifyAmount()
        {
            try
            {
                await Task.Delay(1);
                if (oModel.RequestedAmount > oModel.GrossSalary)
                {
                    Snackbar.Add("Requested Amount can't be greater then Salary", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    oModel.RequestedAmount = 0;
                }                
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId) && !string.IsNullOrWhiteSpace(oModel.AdvanceCode) && oModel.RequestedAmount > 0)
                {
                    if (oModel.DocStatus == "Open" && oModel.DocAprStatus == "Approved" && !string.IsNullOrWhiteSpace(oModel.PaymentMode))
                    {
                        //Need code here
                    }
                    if (oModel.Id > 0)
                    {
                        oModel.UpdateBy = LoginUser;
                        res = await _trnsAdvanceRequest.Update(oModel);
                    }
                    else
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsAdvanceRequest.Insert(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/AdvanceRequest", forceLoad: true);
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
                        await GetAllAdvanceRequest();
                        await SetDocNo();
                        await GetAllAdvanceMaster();
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocStatus = "Draft";
                        oModel.DocAprStatus = "Pending";
                        oModel.DocDate = DateTime.Today;
                        oModel.RequiredDate = DateTime.Today;
                        oModel.BasicSalary = 0;
                        oModel.GrossSalary = 0;
                        oModel.RequestedAmount = 0;
                        oModel.ApprovedAmount = 0;
                        oModel.InstallmentAmount = 0;
                        await GetAllLove();
                        await GetPayrollInit();
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
