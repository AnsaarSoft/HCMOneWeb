using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Loan;
using HCM.UI.Interfaces.MasterData;
using HCM.UI.Interfaces.MasterElement;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using MudBlazor;
using System.Globalization;

namespace HCM.UI.Pages.Loan
{
    public partial class LoanRequest
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstLoans _mstLoan { get; set; }

        [Inject]
        public IMstLove _mstLove { get; set; }

        [Inject]
        public ITrnsLoanRequest _trnsLoanRequest { get; set; }

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

        TrnsLoanRequest oModel = new TrnsLoanRequest();
        private IEnumerable<TrnsLoanRequest> oList = new List<TrnsLoanRequest>();

        MstLoan oModelLoan = new MstLoan();
        private IEnumerable<MstLoan> oListLoanType = new List<MstLoan>();
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
                parameters.Add("DialogFor", "LoanRequest");
                var dialog = Dialog.Show<DialogBox>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (TrnsLoanRequest)result.Data;
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
        private async Task GetAllLoanRequest()
        {
            try
            {
                oList = await _trnsLoanRequest.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllLoanMaster()
        {
            try
            {
                oListLoanType = await _mstLoan.GetAllData();
                oListLoanType = oListLoanType.Where(x => x.FlgActive == true);
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
                Navigation.NavigateTo("/LoanRequest", forceLoad: true);
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
        private async Task VerifyPeriodRange()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);

                var LockedPeriod = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.Start && a.EndDate >= _dateRange.End && a.FlgLocked == true).FirstOrDefault();
                if (LockedPeriod != null)
                {
                    Snackbar.Add("Leave not allowed on locked Periods.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                var CurrentPeriod = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.Start && a.EndDate >= _dateRange.Start && a.FlgLocked == false).FirstOrDefault();
                var CurrentPeriod2 = oPayrollPeriodList.Where(a => a.PayrollId == EmpPayrollID && a.StartDate <= _dateRange.End && a.EndDate >= _dateRange.End && a.FlgLocked == false).FirstOrDefault();
                if (CurrentPeriod != CurrentPeriod2)
                {
                    Snackbar.Add("Leave Document range can not fall on multiple Periods.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                string checkPeriodTodate = "";
                string checkPeriodTodate2 = "";
                if (CurrentPeriod != null && CurrentPeriod2 != null)
                {
                    checkPeriodTodate = CurrentPeriod.PeriodName;
                    checkPeriodTodate2 = CurrentPeriod2.PeriodName;
                }
                if (oModelEmployee.JoiningDate > _dateRange.Start)
                {
                    Snackbar.Add("From date could not be greater then to Join date", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                if (oModelEmployee.JoiningDate > _dateRange.End)
                {
                    Snackbar.Add("End date could not be greater then to Join date", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                if (_dateRange.Start > _dateRange.End)
                {
                    Snackbar.Add("From date could not be greater then to date.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return;
                }
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }
        private async Task CalculateInstallmentAmount()
        {
            try
            {
                await Task.Delay(1);
                if (oModel.RequestedAmount > 0 && oModel.NoOfInstallments > 0)
                {
                    oModel.InstallmentAmount = oModel.RequestedAmount / oModel.NoOfInstallments;
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task SetLoan()
        {
            try
            {
                await Task.Delay(1);
                if (!string.IsNullOrWhiteSpace(oModel.LoanCode))
                {
                    oModelLoan = oListLoanType.Where(x => x.Code == oModel.LoanCode).FirstOrDefault();
                    oModel.FkloanId = oModelLoan.Id;
                    oModel.LoanCode = oModelLoan.Code;
                    oModel.LoanDescription = oModelLoan.Description;
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
                if (oModel.DocStatus == "Opened")
                {
                    Snackbar.Add("Opened document can't be update, select cancel to update", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    Loading = false;
                    return null;
                }
                if (!string.IsNullOrWhiteSpace(oModelEmployee.EmpId) && !string.IsNullOrWhiteSpace(oModel.LoanCode) && oModel.RequestedAmount > 0 && oModel.NoOfInstallments > 0)
                {
                    if (oModel.DocStatus == "Open" && oModel.DocAprStatus == "Approved" && !string.IsNullOrWhiteSpace(oModel.PaymentMode))
                    {
                        //Need code here
                    }
                    if (oModel.Id > 0)
                    {
                        oModel.UpdateBy = LoginUser;
                        res = await _trnsLoanRequest.Update(oModel);
                    }
                    else
                    {
                        oModel.UserId = LoginUser;
                        res = await _trnsLoanRequest.Insert(oModel);
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/LoanRequest", forceLoad: true);
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
                var result = await _trnsLoanRequest.GetAllData();
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
                        await GetAllLoanRequest();
                        await SetDocNo();
                        await GetAllLoanMaster();
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocStatus = "Draft";
                        oModel.DocAprStatus = "Pending";
                        oModel.DocDate = DateTime.Today;
                        oModel.RequiredDate = DateTime.Today;
                        oModel.BasicSalary = 0;
                        oModel.GrossSalary = 0;
                        oModel.NoOfInstallments = 0;
                        oModel.RequestedAmount = 0;
                        oModel.ApprovedAmount = 0;
                        oModel.InstallmentAmount = 0;
                        oModel.FlgStopInstallment = true;
                        await GetAllLove();
                        await GetPayrollInit();
                    }
                    else
                    {
                        _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date);
                        oModel.DocDate = DateTime.Today;
                        oModel.RequiredDate = DateTime.Today;
                        oModel.BasicSalary = 0;
                        oModel.GrossSalary = 0;
                        oModel.NoOfInstallments = 0;
                        oModel.RequestedAmount = 0;
                        oModel.ApprovedAmount = 0;
                        oModel.InstallmentAmount = 0;
                        oModel.FlgStopInstallment = true;
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
