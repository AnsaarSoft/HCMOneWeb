﻿using Blazored.LocalStorage;
using HCM.API.Models;
using HCM.UI.General;
using HCM.UI.Interfaces.Authorization;
using HCM.UI.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Globalization;

namespace HCM.UI.Pages.MasterDataSetup
{
    public partial class Calendar
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IMstCalendar _mstCalendar { get; set; }

        [Inject]
        public IUserAuthorization _UserAuthorization { get; set; }

        [Inject]
        public ICfgPayrollDefination _CfgPayrollDefination { get; set; }

        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        private string LoginUser = "";


        #endregion

        #region Variables

        bool Loading = false;
        bool DisbaledDate = false;
        bool DisbaledCode = false;
        public IMask AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
        private string searchString1 = "";
        private bool FilterFunc(MstCalendar element) => FilterFunc(element, searchString1);

        MstCalendar oModel = new MstCalendar();
        CfgPeriodDate oModelPeriods = new CfgPeriodDate();
        CfgPayrollDefination oModelPayroll = new CfgPayrollDefination();
        private IEnumerable<MstCalendar> oList = new List<MstCalendar>();
        private IEnumerable<CfgPayrollDefination> oListPayroll = new List<CfgPayrollDefination>();
        private IEnumerable<CfgPeriodDate> oListPeriods = new List<CfgPeriodDate>();
        List<CfgPeriodDate> oListPeriodsDB = new List<CfgPeriodDate>();

        MudDateRangePicker _picker;
        DateRange _dateRange;
        DateTime MinDate;

        #endregion

        #region Functions

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(oModel.Code) && !string.IsNullOrWhiteSpace(oModel.Description))
                {
                    if (oList.Where(x => x.Code.Trim().ToLowerInvariant() == oModel.Code.Trim().ToLowerInvariant()).Count() > 0)
                    {
                        Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oModel.StartDate = _dateRange.Start;
                        oModel.EndDate = _dateRange.End;
                        if (oModel.Code.Length > 20)
                        {
                            Snackbar.Add("Code accept only 20 characters", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        }
                        else
                        {
                            var MonthDifference = DateTimeSpan.GetMonthDifference((DateTime)oModel.StartDate, (DateTime)oModel.EndDate);
                            if (MonthDifference < 12)
                            {
                                Snackbar.Add("Invalid Date Selection, must be within 12 months range", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            }
                            else
                            {

                                if (oModel.Id == 0)
                                {
                                    if (oList.Where(x => x.FlgActive == true).Count() > 0)
                                    {
                                        oModel.FlgActive = false;
                                    }
                                    oModel.UserId = LoginUser;
                                    res = await _mstCalendar.Insert(oModel);
                                }
                                else
                                {
                                    oModel.UpdatedBy = LoginUser;
                                    res = await _mstCalendar.Update(oModel);
                                }
                            }
                        }
                    }
                    if (res != null && res.Id == 1)
                    {
                        Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        await Task.Delay(3000);
                        Navigation.NavigateTo("/Calendar", forceLoad: true);
                    }
                    else
                    {
                        Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    oModel.FlgActive = true;
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

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(3);
                Navigation.NavigateTo("/Calendar", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        private async Task GetAllCalendars()
        {
            try
            {
                oList = await _mstCalendar.GetAllData();
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
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }
        private async Task GetAllPayrollPeriods()
        {
            try
            {
                //oListPeriods = await _CfgPayrollDefination.GetAllData();
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
        }

        private bool FilterFunc(MstCalendar element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            if (element.Code.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Description.Contains(searchString1, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.FlgActive.Equals(searchString1))
                return true;
            return false;
        }

        public void RemoveRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id != LineNum);
                oList = res;
                if (oList.Count() == 0)
                {
                    oModel = new MstCalendar();
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        public void EditRecord(int LineNum)
        {
            try
            {
                var res = oList.Where(x => x.Id == LineNum).FirstOrDefault();
                if (res != null)
                {
                    AlphaNumericMask = new RegexMask(@"^[a-zA-Z0-9_]*$");
                    DisbaledDate = true;
                    //oModel.Id = res.Id;
                    //oModel.Code = res.Code;
                    //DisbaledCode = true;
                    //oModel.Description = res.Description;
                    //oModel.StartDate = _dateRange.Start = res.StartDate;
                    //oModel.EndDate = _dateRange.End = res.EndDate;
                    //_dateRange = new DateRange(oModel.StartDate, oModel.EndDate);
                    //oModel.FlgActive = res.FlgActive;
                    oModel = res;
                    _dateRange = new DateRange(oModel.StartDate, oModel.EndDate);
                    DisbaledCode = true;
                    oList = oList.Where(x => x.Id != LineNum);
                    //_ = InvokeAsync(StateHasChanged);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }

        }

        private async Task<ApiResponseModel> VerifyPeriods()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                var oCalendarCurrent = oList.Where(a => a.FlgActive.GetValueOrDefault() == true).FirstOrDefault();
                //foreach (var oPayroll in oListPayroll)
                //{
                int intPreviosYearID = 0, intCurrentYearID = 0;
                //if (oPayroll.FlgActive.GetValueOrDefault() == true && !string.IsNullOrEmpty(oPayroll.PayrollType) && oPayroll.FirstPeriodEndDt != null)
                //{
                int intCount = oList.Where(a => a.FlgActive.GetValueOrDefault() == true).Count();
                if (intCount == 1)
                {

                    if (oCalendarCurrent != null)
                    {
                        if (oCalendarCurrent != null)
                        {
                            intPreviosYearID = oCalendarCurrent.Id - 1;
                            intCurrentYearID = oCalendarCurrent.Id;
                        }
                        if (intPreviosYearID > 0)
                        {
                            var oCalendarPrevious = oList.Where(a => a.Id == intPreviosYearID).FirstOrDefault();
                            if (oCalendarPrevious != null)
                            {
                                int intPeriodCount = oListPeriods.Where(a => a.CalCode == oCalendarPrevious.Code
                                && a.FlgLocked.GetValueOrDefault() == false).Count();
                                if (intPeriodCount > 0)
                                {
                                    Snackbar.Add("Please Post JE and close all previous financial year periods first", Severity.Warning, (options) => { options.Icon = Icons.Sharp.Warning; });
                                    //return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Snackbar.Add("One Financial Year Should be Active", Severity.Warning, (options) => { options.Icon = Icons.Sharp.Warning; });
                }
                //Message Print
                //oApplication.StatusBar.SetText("Financial Year " + code + " Periods Creation Started... Please wait.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                AddPeriodDates(Convert.ToDateTime(oCalendarCurrent.StartDate), Convert.ToDateTime(oCalendarCurrent.EndDate), oCalendarCurrent.Code, oCalendarCurrent.Id);
                //}
                //}
                bool flgActive = Convert.ToBoolean(oList.Where(x => x.FlgActive.GetValueOrDefault() == true).FirstOrDefault());
                if (flgActive == true)
                {
                    Snackbar.Add("Code already exist", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }

                if (res != null && res.Id == 1)
                {
                    Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                    await Task.Delay(3000);
                    Navigation.NavigateTo("/Calendar", forceLoad: true);
                }
                else
                {
                    Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                oModel.FlgActive = true;

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
        public async void AddPeriodDates(DateTime pFromDate, DateTime pToDate, string pCalendarCode, Int32 pCalendarID)
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                var oPayrollCollection = oListPayroll.Where(a => a.FlgActive.GetValueOrDefault() == true).ToList();
                foreach (var oPayroll in oPayrollCollection)
                {
                    var CheckPeriods = oListPeriods.Where(a => a.PayrollId == oPayroll.Id
                                        && a.CalCode == pCalendarCode).Count();
                    if (CheckPeriods == 0)
                    {
                        DateTime PeriodStartDate = pFromDate;
                        DateTime PeriodEndDate;
                        DateTime FirstPeriodEndDate = Convert.ToDateTime(oPayroll.FirstPeriodEndDt);
                        if (pFromDate < FirstPeriodEndDate)
                        {
                            PeriodEndDate = FirstPeriodEndDate;
                        }
                        else
                        {
                            if (FirstPeriodEndDate.Month == pFromDate.Month)
                            {
                                PeriodEndDate = new DateTime(pFromDate.Year, FirstPeriodEndDate.Month, FirstPeriodEndDate.Day);
                            }
                            else
                            {
                                PeriodEndDate = new DateTime(pFromDate.Year, pFromDate.Month, FirstPeriodEndDate.Day);
                            }
                        }
                        string PayrollType = oPayroll.PayrollType;
                        int i = 0;
                        int count = 0;
                        Boolean flgHalfMonthlyTrigger = true;
                        DateTime LocalStart = DateTime.MinValue, LocalEnd = DateTime.MinValue;

                        switch (PayrollType.Trim())
                        {

                            case "MNTH":
                                while (LocalEnd <= pToDate && flgHalfMonthlyTrigger)
                                {
                                    i++;
                                    CfgPeriodDate oPeriod = new CfgPeriodDate();
                                    oPeriod.EndDate = PeriodEndDate;
                                    oPeriod.PayrollId = oPayroll.Id;
                                    oPeriod.FlgLocked = false;
                                    oPeriod.FlgPosted = false;
                                    oPeriod.FlgVisible = true;
                                    oPeriod.CalCode = pCalendarCode;
                                    //oPeriod.FkcalId = pCalendarID;
                                    if (i == 1)
                                    {
                                        LocalStart = PeriodStartDate;
                                        LocalEnd = PeriodEndDate;
                                    }
                                    oPeriod.StartDate = LocalStart;
                                    oPeriod.EndDate = LocalEnd;
                                    oPeriod.PeriodName = pCalendarCode + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(LocalEnd.Month);

                                    LocalStart = PeriodStartDate.AddMonths(i);
                                    LocalEnd = PeriodEndDate.AddMonths(i);

                                    int cnt = oListPeriods.Where(p => p.PayrollId == oPayroll.Id
                                    && p.StartDate == oPeriod.StartDate
                                    && p.EndDate == oPeriod.EndDate).Count();
                                    if (cnt == 0)
                                    {
                                        oListPeriodsDB.Add(oPeriod);
                                    }
                                }
                                break;
                            case "HMNT":
                                while (PeriodEndDate <= pToDate && flgHalfMonthlyTrigger)
                                {
                                    CfgPeriodDate oPeriodHalfMonth = new CfgPeriodDate();
                                    oPeriodHalfMonth.EndDate = PeriodEndDate;
                                    oPeriodHalfMonth.PayrollId = oPayroll.Id;
                                    oPeriodHalfMonth.FlgLocked = false;
                                    oPeriodHalfMonth.FlgPosted = false;
                                    oPeriodHalfMonth.FlgVisible = true;
                                    oPeriodHalfMonth.CalCode = pCalendarCode;
                                    //oPeriodHalfMonth.FkcalId = pCalendarID;

                                    int thatMonthDays = DateTime.DaysInMonth(PeriodEndDate.Year, PeriodEndDate.Month);
                                    int monthHalf = thatMonthDays / 2;
                                    int mFirstStart = 0, mFirstEnd = monthHalf - 1;
                                    int mMidStart = monthHalf, mMidEnd = thatMonthDays - 1;
                                    {
                                        DateTime startDate;
                                        count++;
                                        if (count == 1)
                                        {
                                            startDate = new DateTime(PeriodEndDate.Year, PeriodEndDate.Month, 1);

                                            oPeriodHalfMonth.StartDate = Convert.ToDateTime(startDate.AddDays(mFirstStart));
                                            oPeriodHalfMonth.EndDate = Convert.ToDateTime(startDate.AddDays(mFirstEnd));
                                            oPeriodHalfMonth.PeriodName += pCalendarCode + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.Month) + "-" + count;
                                        }
                                        else
                                        {
                                            startDate = new DateTime(PeriodEndDate.Year, PeriodEndDate.Month, 1);
                                            oPeriodHalfMonth.StartDate = Convert.ToDateTime(startDate.AddDays(mMidStart));
                                            oPeriodHalfMonth.EndDate = Convert.ToDateTime(startDate.AddDays(mMidEnd));
                                            //oPeriodHalfMonth.PeriodName += CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.Month) + "-" + String.Format("{0:000}", startDate.DayOfYear) + "-" + count;
                                            oPeriodHalfMonth.PeriodName += pCalendarCode + "-" + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(startDate.Month) + "-" + count;
                                        }
                                        if (count == 2)
                                        {
                                            PeriodEndDate = PeriodEndDate.AddMonths(1);
                                            count = 0;
                                        }
                                    }
                                    int cnt = oListPeriods.Where(p => p.PayrollId == oPayroll.Id
                                    && p.StartDate == oPeriodHalfMonth.StartDate
                                    && p.EndDate == oPeriodHalfMonth.EndDate).Count();
                                    if (cnt == 0)
                                    {
                                        oListPeriodsDB.Add(oPeriodHalfMonth);
                                    }
                                }
                                break;
                        }
                        if (oListPeriodsDB.Count > 0)
                        {
                            res = await _mstCalendar.Insert(oListPeriodsDB);
                            oListPeriodsDB.Clear();
                        }
                        if (res != null && res.Id == 1)
                        {
                            Snackbar.Add(res.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Loading = false;
                Logs.GenerateLogs(ex.Message);
            }
            Loading = false;
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

                    var res1 = await _UserAuthorization.GetAllAuthorizationMenu(LoginUser);
                    if (res1.Where(x => x.CMenuID == 23 && x.UserRights == true).ToList().Count > 0)
                    {
                        oModel.FlgActive = true;
                        await GetAllCalendars();
                        await GetAllPayroll();
                        if (oList.Where(x => x.FlgActive == true).Count() > 0)
                        {
                            DisbaledDate = true;
                            var res = oList.Where(x => x.FlgActive == true).Max(x => x.EndDate);
                            Convert.ToDateTime(res).AddDays(1);
                            _dateRange = new DateRange(Convert.ToDateTime(res.Value).AddDays(1), Convert.ToDateTime(res).AddMonths(12));
                            _dateRange.Start = MinDate = Convert.ToDateTime(res).AddDays(1);
                        }
                        else
                        {
                            //MinDate = DateTime.Now.Date;
                            _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.Date.AddMonths(12));
                        }
                    }
                    else
                    {
                        Navigation.NavigateTo("/Dashboard", forceLoad: true);
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
